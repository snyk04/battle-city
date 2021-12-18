using BattleCity.Tanks;
using UnityEngine;

namespace BattleCity.Input
{
    [RequireComponent(typeof(ShooterComponent))]
    public class ShootingInputComponent : MonoBehaviour
    {
        public ShootingInput ShooterInput { get; private set; }

        private void Awake()
        {
            Shooter shooter = GetComponent<ShooterComponent>().Shooter;
            ShooterInput = new ShootingInput(shooter, new Controls().Player.Shoot);
        }
        
        private void OnEnable()
        {
            ShooterInput.Enable();
        }
        private void OnDisable()
        {
            ShooterInput.Disable();
        } 
        private void OnDestroy()
        {
            ShooterInput.Dispose();
        }
    }
}
