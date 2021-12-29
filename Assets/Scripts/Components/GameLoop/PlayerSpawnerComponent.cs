using BattleCity.Input;
using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.GameLoop
{
    public class PlayerSpawnerComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Vector3 _spawnPoint;
        [SerializeField] private int _amountOfLives;

        public PlayerSpawner PlayerSpawner { get; private set; }

        private void Awake()
        {
            PlayerSpawner = new PlayerSpawner(_playerPrefab, _spawnPoint, _amountOfLives);
        }
        private void OnValidate()
        {
            if (!_playerPrefab.TryGetComponent(out MovementInputComponent movementInput)
                || !_playerPrefab.TryGetComponent(out ShootingInputComponent shootingInput)
                || !_playerPrefab.TryGetComponent(out DamageableComponent damageableComponent)
                || !_playerPrefab.TryGetComponent(out MoverComponent moverComponent)
                || !_playerPrefab.TryGetComponent(out ShooterComponent shooterComponent))
            {
                Debug.LogError("Player prefab is not valid!");
            }
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_spawnPoint, Vector3.one);
        }
    }
}