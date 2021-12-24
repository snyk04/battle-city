using System;
using BattleCity.Common;
using UnityEngine;

namespace BattleCity.AI
{
    public abstract class State : IState
    {
        protected readonly BotInfo BotInfo;

        private float _lastShotTime;
        private bool _preparingToShoot;
        private float _preparingStartTime;
        
        protected State(BotInfo botInfo)
        {
            BotInfo = botInfo;
        }
        
        public abstract void Update();

        protected void TryShoot(Vector3 target)
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
            if (TargetBehindTheWall(botToTargetVector))
            {
                return;
            }
            if (TargetBehindBotTank(botToTargetVector))
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
        private bool TargetBehindTheWall(Vector3 botToTargetVector)
        {
            var ray = new Ray(BotInfo.Transform.position, botToTargetVector);
            return Physics.Raycast(ray, BotInfo.LevelWallsLayerMask);
        }
        private bool TargetBehindBotTank(Vector3 botToTargetVector)
        {
            var ray = new Ray(BotInfo.Transform.position, botToTargetVector);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, BotInfo.TanksLayerMask))
            {
                return hitInfo.collider.TryGetComponent(out BotComponent _);
            }
            throw new ApplicationException();
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
        
        protected void MoveTo(Vector3 goal)
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