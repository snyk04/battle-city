using BattleCity.GameLoop;
using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.AI
{
    public class Bot : IBot
    {
        public IState State { get; set; }

        public Bot(Mover mover, Shooter shooter, Transform transform, ICurrentPlayerTracker currentPlayerTracker, LayerMask levelWallsLayerMask, float pauseBeforeShot, float pauseAfterShot)
        {
            var botInfo = new BotInfo(this, mover, shooter, transform, currentPlayerTracker, levelWallsLayerMask, pauseBeforeShot, pauseAfterShot);
            
            State = new KillPlayerState(botInfo);
        }

        public void Update()
        {
            State.Update();
        }
    }
}
