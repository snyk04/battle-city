using UnityEngine;

namespace BattleCity.AI
{
    public class IdleState : State
    {
        public IdleState(BotInfo botInfo) : base(botInfo) { }

        public override void Update()
        {
            BotInfo.Mover.StartMoving(Vector2.zero);
        }
    }
}