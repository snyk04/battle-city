using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.GameLoop
{
    public class GameFinisherComponent : MonoBehaviour
    {
        [SerializeField] private DamageableComponent _base;
        [SerializeField] private PlayerSpawnerComponent _playerSpawner;
        [SerializeField] private EnemySpawnerComponent _enemySpawner;

        public GameFinisher GameFinisher { get; private set; }

        private void Awake()
        {
            Damageable baseDamageable = _base.Damageable;
            PlayerSpawner playerSpawner = _playerSpawner.PlayerSpawner;
            EnemySpawner enemySpawner = _enemySpawner.EnemySpawner;

            GameFinisher = new GameFinisher(baseDamageable, playerSpawner, enemySpawner);
        }
    }
}