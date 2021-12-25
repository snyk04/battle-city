using System;
using BattleCity.Tanks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BattleCity.GameLoop
{
    public class PlayerSpawner : IPlayerTracker
    {
        private readonly GameObject _playerPrefab;
        private readonly Vector3 _spawnPoint;
        private int _amountOfLives;

        private GameObject _player;
        public Transform Player => _player.transform;

        public event Action OnGameOver;
        
        public PlayerSpawner(GameObject playerPrefab, Vector3 spawnPoint, int amountOfLives)
        {
            _playerPrefab = playerPrefab;
            _spawnPoint = spawnPoint;
            _amountOfLives = amountOfLives;
            
            SpawnPlayer();
        }

        private void TryToRespawnPlayer()
        {
            _amountOfLives -= 1;

            if (_amountOfLives <= 0)
            {
                OnGameOver?.Invoke();
                return;
            }
            
            SpawnPlayer();
        }
        private void SpawnPlayer()
        {
            _player = Object.Instantiate(_playerPrefab, _spawnPoint, Quaternion.identity);
            
            Damageable playerDamageable = _player.GetComponent<DamageableComponent>().Damageable; 
            playerDamageable.OnDestroy += TryToRespawnPlayer;
        }
    }
}
