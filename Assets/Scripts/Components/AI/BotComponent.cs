using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.AI
{
    [RequireComponent(typeof(MoverComponent))]
    public class BotComponent : MonoBehaviour
    {
        public Bot Bot { get; private set; }
        
        private void Awake()
        {
            Mover mover = GetComponent<MoverComponent>().Mover;
            Bot = new Bot(mover, transform);
        }

        private void Update()
        {
            Bot.Update();
        }
    }
}
