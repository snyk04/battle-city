using System;

namespace BattleCity.AI
{
    public abstract class State : IState
    {
        protected readonly BotInfo BotInfo;

        public event Action StateExpired;

        protected State(BotInfo botInfo)
        {
            BotInfo = botInfo;
        }

        public abstract void Update();

        protected void MakeStateExpired()
        {
            // TODO : Maybe exception
            StateExpired?.Invoke();
        }
    }
}