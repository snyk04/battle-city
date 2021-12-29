using System;

namespace BattleCity.GameLoop
{
    public interface ITankSpawner
    {
        int AmountOfLives { get; }
        event Action LivesReduced;
        event Action NoLivesLeft;
    }
}