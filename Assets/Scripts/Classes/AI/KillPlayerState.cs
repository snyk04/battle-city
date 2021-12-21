namespace BattleCity.AI
{
    public class KillPlayerState : State
    {
        public KillPlayerState(BotInfo botInfo) : base(botInfo)
        {
            
        }
        
        public override void Update()
        {
            TryToShoot(BotInfo.CurrentPlayerTracker.CurrentPlayerPosition);
            MoveTo(BotInfo.CurrentPlayerTracker.CurrentPlayerPosition);
        }
    }
}
