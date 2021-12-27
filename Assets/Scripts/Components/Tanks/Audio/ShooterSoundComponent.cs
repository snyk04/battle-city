using UnityEngine;

namespace BattleCity.Tanks.Audio
{
    [RequireComponent(typeof(ShooterComponent))]
    public class ShooterSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _shotSound;
        
        public ShooterSound ShooterSound { get; private set; }

        private void Awake()
        {
            Shooter shooter = GetComponent<ShooterComponent>().Shooter;
            
            ShooterSound = new ShooterSound(shooter, _audioSource, _shotSound);
        }
    }
}