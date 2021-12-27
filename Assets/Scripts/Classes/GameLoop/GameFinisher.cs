using System;
using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.GameLoop
{
    public class GameFinisher
    {
        public event Action<GameFinishType> GameFinished;

        public GameFinisher(Damageable baseDamageable, ITankSpawner playerSpawner, ITankSpawner enemySpawner)
        {
            baseDamageable.OnDestroy += () => FinishGame(GameFinishType.Defeat);
            playerSpawner.NoLivesLeft += () => FinishGame(GameFinishType.Defeat);
            enemySpawner.NoLivesLeft += () => FinishGame(GameFinishType.Victory);
        }

        private void FinishGame(GameFinishType gameFinishType)
        {
            GameFinished?.Invoke(gameFinishType);
            Time.timeScale = 0;
        }
    }
}