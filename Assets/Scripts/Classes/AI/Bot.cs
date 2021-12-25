namespace BattleCity.AI
{
    public class Bot : IBot
    {
        public IState State { get; set; }

        public Bot(BotInfo botInfo)
        {
            botInfo.OnStateChange += state => State = state;

            var decisionMaker = new DecisionMaker(botInfo);
            decisionMaker.MakeDecision();
        }

        public void Update()
        {
            State.Update();
        }
    }
}