using BattleCity.GameLoop;
using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.AI
{
    public class BotInfo
    {
        public readonly IBot Bot;
        public readonly Mover Mover;
        public readonly Transform Transform;
        public readonly ICurrentPlayerTracker CurrentPlayerTracker;

        public BotInfo(IBot bot, Mover mover, Transform transform, ICurrentPlayerTracker currentPlayerTracker)
        {
            Bot = bot;
            Mover = mover;
            Transform = transform;
            CurrentPlayerTracker = currentPlayerTracker;
        }
    }
}
