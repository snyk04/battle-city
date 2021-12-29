using System.Collections.Generic;
using BattleCity.AI.Pathfinding;
using UnityEngine;

namespace BattleCity.GameLoop
{
    public class EnemySpawnerComponent : TankSpawnerComponent
    {
        [SerializeField] private List<GameObject> _enemyPrefabs;
        [SerializeField] private List<Vector3> _spawnPoints;
        [SerializeField] private int _amountOfLives;
        [SerializeField] private int _amountOfEnemiesAtStart;
        [SerializeField] private PlayerSpawnerComponent _playerSpawner;
        [SerializeField] private FieldPathfinderComponent _fieldPathfinderHelper;
        [SerializeField] private Transform _base;

        public EnemySpawner EnemySpawner { get; private set; }
        public override ITankSpawner TankSpawner { get; protected set; }

        private void Awake()
        {
            IPlayerTracker playerTracker = _playerSpawner.PlayerSpawner;
            
            EnemySpawner = new EnemySpawner(
                _enemyPrefabs,
                _spawnPoints,
                _amountOfLives,
                _amountOfEnemiesAtStart,
                playerTracker,
                _fieldPathfinderHelper,
                _base
            );
            TankSpawner = EnemySpawner;
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;

            foreach (Vector3 spawnPoint in _spawnPoints)
            {
                Gizmos.DrawWireCube(spawnPoint, Vector3.one);
            }
        }
    }
}