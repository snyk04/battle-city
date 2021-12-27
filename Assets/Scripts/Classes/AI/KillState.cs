#nullable enable

using System;
using BattleCity.Common;
using BattleCity.Input;
using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.AI
{
    public class KillState : State
    {
        private readonly Vector2[] _possibleDirections = {Vector2.left, Vector2.up, Vector2.right, Vector2.down};

        private const float AllowedError = 0.05f;

        // TODO : Make depend on cell size
        private const float AllowedGoalDistance = 1f;

        private readonly Transform _target;

        private float _lastShotTime;
        private bool _preparingToShoot;
        private float _preparingStartTime;
        private Vector3 _currentGoalPoint;
        public Mover Owner { get; set; }

        public KillState(BotInfo botInfo, Transform target) : base(botInfo)
        {
            _target = target;
            Owner = botInfo.Mover;
            UpdateGoalPoint();
        }

        public override void Update()
        {
            if (_target == null)
            {
                MakeStateExpired();
                return;
            }

            TryShootTarget();
            MoveToTarget();
        }

        private void TryShootTarget()
        {
            if (IsReloading())
            {
                return;
            }

            Vector3 botToTargetVector = _target.position - BotInfo.Position;
            if (!TargetAtGunPoint(botToTargetVector))
            {
                return;
            }

            botToTargetVector.SnapToAxis();
            if (!TargetCanBeShot(botToTargetVector))
            {
                return;
            }

            if (!IsReadyToShoot())
            {
                return;
            }

            Shoot(botToTargetVector);
        }
        private bool IsReloading()
        {
            return Time.time - _lastShotTime < BotInfo.PauseAfterShot;
        }
        private bool TargetAtGunPoint(Vector3 botToTargetVector)
        {
            // TODO : 0.25f ?????
            return Mathf.Abs(botToTargetVector.x) < 0.25f || Mathf.Abs(botToTargetVector.z) < 0.25f;
        }
        private bool TargetCanBeShot(Vector3 botToTargetVector)
        {
            var ray = new Ray(BotInfo.Transform.position, botToTargetVector);
            return Physics.Raycast(ray, out RaycastHit hitInfo, BotInfo.TanksLayerMask)
                   && (hitInfo.collider.TryGetComponent(out MovementInputComponent _) 
                       || hitInfo.collider.transform == BotInfo.Base);
        }
        private bool IsReadyToShoot()
        {
            if (_preparingToShoot)
            {
                return Time.time - _preparingStartTime > BotInfo.PauseBeforeShot;
            }

            _preparingToShoot = true;
            _preparingStartTime = Time.time;
            return false;
        }
        private void Shoot(Vector3 shootDirection)
        {
            _preparingToShoot = false;
            BotInfo.Transform.forward = shootDirection;
            BotInfo.Shooter.Shoot();
            _lastShotTime = Time.time;
        }

        private void MoveToTarget()
        {
            if (AtGoalPoint() || GoalTooFar())
            {
                UpdateGoalPoint();
            }

            Vector3 moveDirection = _currentGoalPoint - BotInfo.Position;
            Vector2 normalizedMoveDirection = moveDirection.ProjectToXZ().normalized.GetClosest(_possibleDirections);
            // TODO : Make not normalized, but clamped for possibility to slow down
            BotInfo.Mover.StartMoving(
                normalizedMoveDirection);
        }
        private bool GoalTooFar()
        {
            return (BotInfo.Position - _currentGoalPoint).magnitude > AllowedGoalDistance;
        }
        private bool AtGoalPoint()
        {
            return (BotInfo.Position - _currentGoalPoint).magnitude < AllowedError;
        }
        private void UpdateGoalPoint()
        {
            Vector3[]? path = BotInfo.FieldPathfinderHelper.FindShortestPath(BotInfo.Position, _target.position, Owner, out _);

            if (path == null)
            {
                throw new ApplicationException("There is no way to that point!");
            }

            _currentGoalPoint = path.Length > 1
                ? path[1]
                : path[0];
        }
    }
}