using System;
using BattleCity.GameLoop;
using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.AI
{
    public class BotInfo
    {
        //public readonly IBot Bot;
        public event Action<IState> OnStateChange;
        public readonly Mover Mover;
        public readonly Shooter Shooter;
        public readonly Transform Transform;
        public readonly IPlayerTracker PlayerTracker;
        public readonly LayerMask LevelWallsLayerMask;
        public readonly LayerMask TanksLayerMask;
        public readonly float PauseBeforeShot;
        public readonly float PauseAfterShot;
        public readonly FieldPathfinderHelper FieldPathfinderHelper;

        public Vector3 Position => Transform.position;

        public BotInfo(Mover mover, Shooter shooter, Transform transform, IPlayerTracker playerTracker, LayerMask levelWallsLayerMask, LayerMask tanksLayerMask, float pauseBeforeShot, float pauseAfterShot, FieldPathfinderHelper fieldPathfinderHelper)
        {
            Mover = mover;
            Shooter = shooter;
            Transform = transform;
            PlayerTracker = playerTracker;
            LevelWallsLayerMask = levelWallsLayerMask;
            TanksLayerMask = tanksLayerMask;
            PauseBeforeShot = pauseBeforeShot;
            PauseAfterShot = pauseAfterShot;
            FieldPathfinderHelper = fieldPathfinderHelper;
        }

        public void ChangeState(IState state)
        {
            if (OnStateChange == null)
            {
                throw new InvalidOperationException("OnStateChange should have already been initialized.");
            }
            
            OnStateChange(state);
        }
    }
}
