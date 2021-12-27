using UnityEngine;

namespace BattleCity.Tanks.Audio
{
    public class ShooterSound
    {
        public ShooterSound(Shooter shooter, AudioSource audioSource, AudioClip shotSound)
        {
            audioSource.clip = shotSound;

            shooter.OnShot += audioSource.Play;
        }
    }
}