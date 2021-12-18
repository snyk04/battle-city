using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.Input
{
    [RequireComponent(typeof(MoverComponent))]
    public class MovementInputComponent : MonoBehaviour
    {
        public MovementInput MovementInput { get; private set; }

        private void Awake()
        {
            Mover mover = GetComponent<MoverComponent>().Mover;
            MovementInput = new MovementInput(mover, new Controls().Player.Move);
        }
        
        private void OnEnable()
        {
            MovementInput.Enable();
        }
        private void OnDisable()
        {
            MovementInput.Disable();
        }
        private void OnDestroy()
        {
            MovementInput.Dispose();
        }
    }
}
