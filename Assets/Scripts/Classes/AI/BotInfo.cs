using BattleCity.GameLoop;
using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.AI
{
    public class BotInfo
    {
        public readonly IBot Bot;
        public readonly Mover Mover;
        public readonly Shooter Shooter;
        public readonly Transform Transform;
        public readonly ICurrentPlayerTracker CurrentPlayerTracker;
        public readonly LayerMask LevelWallsLayerMask;
        public readonly LayerMask TanksLayerMask;
        public readonly float PauseBeforeShot;
        public readonly float PauseAfterShot;

        public Vector3 Position => Transform.position;

        public BotInfo(IBot bot, Mover mover, Shooter shooter, Transform transform, ICurrentPlayerTracker currentPlayerTracker, LayerMask levelWallsLayerMask, LayerMask tanksLayerMask, float pauseBeforeShot, float pauseAfterShot)
        {
            Bot = bot;
            Mover = mover;
            Shooter = shooter;
            Transform = transform;
            CurrentPlayerTracker = currentPlayerTracker;
            LevelWallsLayerMask = levelWallsLayerMask;
            TanksLayerMask = tanksLayerMask;
            PauseBeforeShot = pauseBeforeShot;
            PauseAfterShot = pauseAfterShot;
        }
    }
}
