using BattleCity.Tanks;

namespace BattleCity.AI
{
    public class EmptyCell : ICell
    {
        public bool CanBePassed(Mover caller = null) => true;
    }

    public class WallCell : ICell
    {
        public bool CanBePassed(Mover caller = null) => false;
    }

    public class BotTankCell : ICell
    {
        public Mover bot;
        public BotTankCell(Mover bot)
        {
            this.bot = bot;
        }
        public bool CanBePassed(Mover caller)
        {
            return bot == caller;
        }
    }

    public class PlayerTankCell : ICell
    {
        public bool CanBePassed(Mover caller = null)
        {
            return false;
        }
    }

    public interface ICell
    {
        bool CanBePassed(Mover caller);
    }
}