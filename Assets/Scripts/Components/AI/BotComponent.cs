using BattleCity.GameLoop;
using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.AI
{
    [RequireComponent(typeof(MoverComponent))]
    public class BotComponent : MonoBehaviour
    {
        [SerializeField] private PlayerSpawnerComponent _playerSpawner;
        
        public Bot Bot { get; private set; }
        
        private void Awake()
        {
            Mover mover = GetComponent<MoverComponent>().Mover;
            ICurrentPlayerTracker currentPlayerTracker = _playerSpawner.PlayerSpawner;
            
            Bot = new Bot(mover, transform, currentPlayerTracker);
        }

        private void Update()
        {
            Bot.Update();
        }
    }
}
