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
        [SerializeField] private LayerMask _tanksLayerMask;

        public Bot Bot { get; private set; }
        
        private bool _isInitialized;
        
        private void Update()
        {
            if (_isInitialized)
            {
                Bot.Update();
            }
        }

        public void Initialize(IPlayerTracker playerTracker, FieldPathfinderComponent fieldPathfinder, 
            Transform @base)
        {
            Mover mover = GetComponent<MoverComponent>().Mover;
            Shooter shooter = GetComponent<ShooterComponent>().Shooter;

            var botInfo = new BotInfo(
                mover,
                shooter,
                transform,
                playerTracker,
                @base,
                _tanksLayerMask,
                shooter.ShotDelay,
                fieldPathfinder,
                GetComponent<DamageableComponent>().Damageable

            );

            Bot = new Bot(botInfo);

            _isInitialized = true;
        }
    }
}