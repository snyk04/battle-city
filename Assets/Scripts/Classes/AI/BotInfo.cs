using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.AI
{
    public class BotInfo
    {
        public readonly IBot Bot;
        public readonly Mover Mover;
        public readonly Transform Transform;

        public BotInfo(IBot bot, Mover mover, Transform transform)
        {
            Bot = bot;
            Mover = mover;
            Transform = transform;
        }
    }
}
