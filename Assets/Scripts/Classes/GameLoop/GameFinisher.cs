using System;
using BattleCity.Tanks;

namespace BattleCity.GameLoop
{
    public class GameFinisher
    {
        public event Action<GameFinishType> GameFinished;

        public GameFinisher(Damageable baseDamageable, ITankSpawner playerSpawner, ITankSpawner enemySpawner)
        {
            baseDamageable.OnDestroy += () => GameFinished?.Invoke(GameFinishType.Defeat);
            playerSpawner.NoLivesLeft += () => GameFinished?.Invoke(GameFinishType.Defeat);
            enemySpawner.NoLivesLeft += () => GameFinished?.Invoke(GameFinishType.Victory);
        }
    }
}