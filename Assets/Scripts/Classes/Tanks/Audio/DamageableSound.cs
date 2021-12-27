using System;
using System.Threading.Tasks;
using BattleCity.Common;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BattleCity.Tanks.Audio
{
    public class DamageableSound
    {
        private readonly AudioClip _destroySound;
        private readonly float _volume;
        
        public DamageableSound(Damageable shooter, AudioClip destroySound, float volume)
        {
            _destroySound = destroySound;
            _volume = volume;

            shooter.OnDestroy += PlaySound;
        }

        private void PlaySound()
        {
            var audioSourceObject = new GameObject();
            var audioSource = audioSourceObject.AddComponent<AudioSource>();
            audioSource.clip = _destroySound;
            audioSource.volume = _volume;
            audioSource.Play();

            int destroySoundLengthInMilliseconds = Mathf.RoundToInt(_destroySound.length * 1000);

            Tasks.DoAfterDelay(() => Object.Destroy(audioSourceObject), destroySoundLengthInMilliseconds);
        }
    }
}