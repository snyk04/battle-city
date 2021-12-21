using BattleCity.GameLoop;
using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.AI
{
    [RequireComponent(typeof(MoverComponent))]
    [RequireComponent(typeof(ShooterComponent))]
    public class BotComponent : MonoBehaviour
    {
        [SerializeField] private PlayerSpawnerComponent _playerSpawner;
        [SerializeField] private LayerMask _levelWallsLayerMask;
        [SerializeField] private float _pauseBeforeShot;
        [SerializeField] private float _pauseAfterShot;
        
        public Bot Bot { get; private set; }
        
        private void Awake()
        {
            Mover mover = GetComponent<MoverComponent>().Mover;
            Shooter shooter = GetComponent<ShooterComponent>().Shooter;
            ICurrentPlayerTracker currentPlayerTracker = _playerSpawner.PlayerSpawner;
            
            Bot = new Bot(mover, shooter, transform, currentPlayerTracker, _levelWallsLayerMask, _pauseBeforeShot, _pauseAfterShot);
        }

        private void Update()
        {
            Bot.Update();
        }
    }
}
