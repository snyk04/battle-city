namespace BattleCity.AI
{
    public interface IBot
    {
        IState State { get; set; }
    }
}