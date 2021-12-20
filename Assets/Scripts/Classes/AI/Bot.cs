using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.AI
{
    public class Bot : IBot
    {
        public IState State { get; set; }

        public Bot(Mover mover, Transform transform)
        {
            var botInfo = new BotInfo(this, mover, transform);
            
            State = new KillPlayerState(botInfo);
        }

        public void Update()
        {
            State.Update();
        }
    }
}
