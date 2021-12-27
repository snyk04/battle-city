namespace BattleCity.AI
{
    public class Bot : IBot
    {
        public IState State { get; set; }
        public BotInfo BotInfo { get; set; }

        public Bot(BotInfo botInfo)
        {
            BotInfo = botInfo;
            BotInfo.OnStateChange += (state) => State = state;

            var decisionMaker = new DecisionMaker(BotInfo);
            // decisionMaker.MakeDecision();
        }

        public void Update()
        {
            State?.Update();
        }
    }
}