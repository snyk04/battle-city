using BattleCity.Input;
using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.GameLoop
{
    public class PlayerSpawnerComponent : TankSpawnerComponent
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Vector3 _spawnPoint;
        [SerializeField] private int _amountOfLives;

        public PlayerSpawner PlayerSpawner { get; private set; }
        public override ITankSpawner TankSpawner { get; protected set; }

        private void Awake()
        {
            PlayerSpawner = new PlayerSpawner(_playerPrefab, _spawnPoint, _amountOfLives);
            TankSpawner = PlayerSpawner;
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