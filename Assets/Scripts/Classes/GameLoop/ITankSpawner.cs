using System;

namespace BattleCity.GameLoop
{
    public interface ITankSpawner
    {
        int AmountOfLives { get; }
        event Action NoLivesLeft;
    }
}