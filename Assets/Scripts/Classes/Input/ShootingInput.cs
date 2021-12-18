using BattleCity.Tanks;
using UnityEngine.InputSystem;

namespace BattleCity.Input
{
    public class ShootingInput
    {
        private readonly Shooter _shooter;
        private readonly InputAction _inputAction;

        public ShootingInput(Shooter shooter, InputAction inputAction)
        {
            _shooter = shooter;
            _inputAction = inputAction;
            
            _inputAction.performed += Shoot;
        }

        public void Enable()
        {
            _inputAction.Enable();
        }
        public void Disable()
        {
            _inputAction.Disable();
        }
        
        public void Dispose()
        {
            _inputAction.performed -= Shoot;
        }

        private void Shoot(InputAction.CallbackContext context)
        {
            _shooter.Shoot();
        }
    }
}
