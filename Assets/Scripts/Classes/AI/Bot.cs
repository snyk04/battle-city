namespace BattleCity.AI
{
    public class Bot : IBot
    {
        public IState State { get; set; }

        public Bot(BotInfo botInfo)
        {
            botInfo.OnStateChange += state => State = state;

            State = new KillPlayerState(botInfo);
        }

        public void Update()
        {
            State.Update();
        }
    }
}