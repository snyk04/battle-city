using System;
using BattleCity.Tanks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BattleCity.GameLoop
{
    public class PlayerSpawner : ICurrentPlayerTracker
    {
        private readonly GameObject _playerPrefab;
        private readonly Vector3 _spawnPoint;
        private int _amountOfLives;

        private GameObject _currentPlayer;
        public Vector3 CurrentPlayerPosition => _currentPlayer.transform.position;

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
            _currentPlayer = Object.Instantiate(_playerPrefab, _spawnPoint, Quaternion.identity);
            
            Damageable playerDamageable = _currentPlayer.GetComponent<DamageableComponent>().Damageable; 
            playerDamageable.OnDestroy += TryToRespawnPlayer;
        }
    }
}
