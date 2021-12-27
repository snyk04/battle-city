using System;
using BattleCity.Tanks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BattleCity.GameLoop
{
    public class PlayerSpawner : ITankSpawner, IPlayerTracker
    {
        private readonly GameObject _playerPrefab;
        private readonly Vector3 _spawnPoint;
        public int AmountOfLives { get; private set; }

        private GameObject _player;
        public Transform Player => _player != null ? _player.transform : null;

        public event Action NoLivesLeft;

        public PlayerSpawner(GameObject playerPrefab, Vector3 spawnPoint, int amountOfLives)
        {
            _playerPrefab = playerPrefab;
            _spawnPoint = spawnPoint;
            AmountOfLives = amountOfLives;

            SpawnPlayer();
        }

        private void TryToRespawnPlayer()
        {
            AmountOfLives -= 1;

            if (AmountOfLives <= 0)
            {
                NoLivesLeft?.Invoke();
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