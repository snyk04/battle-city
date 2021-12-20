namespace BattleCity.AI
{
    public abstract class State : IState
    {
        protected BotInfo BotInfo;
        
        protected State(BotInfo botInfo)
        {
            BotInfo = botInfo;
        }
        
        public abstract void Update();
    }
}
