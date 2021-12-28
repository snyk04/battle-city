using UnityEngine;

namespace BattleCity.Tanks.Audio
{
    [RequireComponent(typeof(DamageableComponent))]
    public class DamageableSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioClip _destroySound;
        [Range(0, 1)] [SerializeField] private float _volume;
        
        public DamageableSound DamageableSound { get; private set; }

        private void Awake()
        {
            Damageable damageable = GetComponent<DamageableComponent>().Damageable;
            
            DamageableSound = new DamageableSound(damageable, _destroySound, _volume);
        }
    }
}