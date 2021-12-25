using BattleCity.AI.Pathfinding;
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
        [SerializeField] private Transform _base;
        [SerializeField] private LayerMask _tanksLayerMask;
        [SerializeField] private float _pauseBeforeShot;
        [SerializeField] private float _pauseAfterShot;
        [SerializeField] private FieldPathfinderComponent _fieldPathfinder;

        public Bot Bot { get; private set; }

        private void Awake()
        {
            Mover mover = GetComponent<MoverComponent>().Mover;
            Shooter shooter = GetComponent<ShooterComponent>().Shooter;
            IPlayerTracker playerTracker = _playerSpawner.PlayerSpawner;
            FieldPathfinderHelper fieldPathfinderHelper = _fieldPathfinder.FieldPathfinderHelper;

            var botInfo = new BotInfo(
                mover,
                shooter,
                transform,
                playerTracker,
                _base,
                _tanksLayerMask,
                _pauseBeforeShot,
                _pauseAfterShot,
                fieldPathfinderHelper
            );

            Bot = new Bot(botInfo);
        }

        private void Update()
        {
            Bot.Update();
        }
    }
}