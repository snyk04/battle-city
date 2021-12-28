using System;
using System.Collections.Generic;
using BattleCity.AI;
using BattleCity.AI.Pathfinding;
using BattleCity.Common;
using BattleCity.Tanks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BattleCity.GameLoop
{
    public class EnemySpawner : ITankSpawner
    {
        private const string EnemyName = "Enemy";
        private const float SpawnPointClearRadius = 0.25f;

        private readonly List<Vector3> _spawnPoints;
        public int AmountOfLives { get; private set; }
        private readonly int _amountOfEnemiesAtStart;
        private readonly IPlayerTracker _playerTracker;
        private readonly FieldPathfinderComponent _fieldPathfinder;
        private FieldPathfinderHelper _fieldPathfinderHelper => _fieldPathfinder.FieldPathfinderHelper;
        private readonly Transform _base;

        private Queue<GameObject> _enemyPrefabs;

        private int _currentSpawnPointIndex;

        public event Action NoLivesLeft;
        
        public EnemySpawner(IReadOnlyCollection<GameObject> enemyPrefabs, IEnumerable<Vector3> spawnPoints,
            int amountOfLives, int amountOfEnemiesAtStart, IPlayerTracker playerTracker,
            FieldPathfinderComponent fieldPathfinder, Transform @base)
        {
            if (enemyPrefabs.Count != amountOfLives)
            {
                throw new ArgumentException();
            }
            
            InitializePrefabsQueue(enemyPrefabs);

            _spawnPoints = new List<Vector3>(spawnPoints);
            AmountOfLives = amountOfLives;
            _amountOfEnemiesAtStart = amountOfEnemiesAtStart;
            _playerTracker = playerTracker;
            _fieldPathfinder = fieldPathfinder;
            _base = @base;
            
            SpawnStartEnemies();
        }

        private void InitializePrefabsQueue(IEnumerable<GameObject> prefabsArray)
        {
            _enemyPrefabs = new Queue<GameObject>();
            foreach (GameObject enemyPrefab in prefabsArray)
            {
                _enemyPrefabs.Enqueue(enemyPrefab);
            }
        }

        private void SpawnStartEnemies()
        {
            for (int i = 0; i < _amountOfEnemiesAtStart; i++)
            {
                SpawnNewEnemy();
            }
        }
        private void SpawnNewEnemy()
        {
            AmountOfLives -= 1;

            if (AmountOfLives < 0)
            {
                NoLivesLeft?.Invoke();
                return;
            }

            GameObject prefab = GetNewEnemyPrefab();
            Vector3 spawnPoint = GetFreeSpawnPoint();
            GameObject enemyObject = Object.Instantiate(prefab, spawnPoint, Quaternion.identity);
            var enemyBotComponent = enemyObject.GetComponent<BotComponent>();
            enemyBotComponent.Initialize(_playerTracker, _fieldPathfinder, _base);
            
            enemyObject.transform.name = EnemyName;
            
            Damageable health = enemyObject.GetComponent<DamageableComponent>().Damageable;
            health.OnDestroy += SpawnNewEnemy;
        }

        private GameObject GetNewEnemyPrefab()
        {
            return _enemyPrefabs.Dequeue();
        }
        private Vector3 GetFreeSpawnPoint()
        {
            Vector3 spawnPoint = _spawnPoints[_currentSpawnPointIndex];
            ClearSpawnPoint(spawnPoint);

            _currentSpawnPointIndex += 1;
            if (_currentSpawnPointIndex >= _spawnPoints.Count)
            {
                _currentSpawnPointIndex = 0;
                _spawnPoints.Mix();
            }

            return spawnPoint;
        }
        private void ClearSpawnPoint(Vector3 spawnPoint)
        {
            foreach (Collider collider in Physics.OverlapSphere(spawnPoint, SpawnPointClearRadius))
            {
                if (collider.TryGetComponent(out DamageableComponent damageableComponent))
                {
                    damageableComponent.Damageable.Destroy();
                }
            }
        }
    }
}