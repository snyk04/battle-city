#nullable enable

using BattleCity.Common;
using BattleCity.Input;
using UnityEngine;

namespace BattleCity.AI
{
    public class KillState : State
    {
        private const float AllowedError = 0.25f;

        private Transform _target;

        private float _lastShotTime;
        private bool _preparingToShoot;
        private float _preparingStartTime;
        private Vector3 _currentGoalPoint;

        public KillState(BotInfo botInfo, Transform target) : base(botInfo)
        {
            _target = target;

            UpdateGoalPoint();
        }

        public override void Update()
        {
            // TODO : think about respawned player or base
            if (_target == null)
            {
                _target = BotInfo.PlayerTracker.Player;
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
            return Mathf.Abs(botToTargetVector.x) < 0.25f || Mathf.Abs(botToTargetVector.z) < 0.25f;
        }

        private bool TargetCanBeShot(Vector3 botToTargetVector)
        {
            var ray = new Ray(BotInfo.Transform.position, botToTargetVector);
            return Physics.Raycast(ray, out RaycastHit hitInfo, BotInfo.TanksLayerMask)
                   && hitInfo.collider.TryGetComponent(out MovementInputComponent _);
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
            // if (IsReloading())
            // {
            //     return;
            // }

            if (AtGoalPoint())
            {
                UpdateGoalPoint();
            }

            Debug.Log(_currentGoalPoint);
            Vector3 moveDirection = _currentGoalPoint - BotInfo.Position;
            Vector2 normalizedMoveDirection = new Vector2(moveDirection.x, moveDirection.z).normalized;
            BotInfo.Mover.StartMoving(normalizedMoveDirection);
        }

        private bool AtGoalPoint()
        {
            return (BotInfo.Position - _currentGoalPoint).magnitude < AllowedError;
        }

        private void UpdateGoalPoint()
        {
            _currentGoalPoint = BotInfo.FieldPathfinderHelper.FindShortestPath(BotInfo.Position, _target.position)[1];
        }
    }
}