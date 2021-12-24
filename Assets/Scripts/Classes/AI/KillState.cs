using BattleCity.Common;
using BattleCity.Input;
using UnityEngine;

namespace BattleCity.AI
{
    public class KillState : State
    {
        private readonly Transform _target;
        
        private float _lastShotTime;
        private bool _preparingToShoot;
        private float _preparingStartTime;
        
        public KillState(BotInfo botInfo, Transform target) : base(botInfo)
        {
            _target = target;
        }
        
        public override void Update()
        {
            TryShoot(_target.position);
            MoveTo(_target.position);
        }

        private void TryShoot(Vector3 target)
        {
            if (IsReloading())
            {
                return;
            }

            Vector3 botToTargetVector = target - BotInfo.Position;
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

        private void MoveTo(Vector3 goal)
        {
            // TODO : Add pathfinding, etc.

            if (IsReloading())
            {
                return;
            }
            
            Vector3 botToGoalVector = goal - BotInfo.Position;
            BotInfo.Mover.StartMoving(new Vector2(botToGoalVector.x, botToGoalVector.z).normalized);
        }
    }
}