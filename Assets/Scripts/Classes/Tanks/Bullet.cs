using UnityEngine;

namespace BattleCity.Tanks
{
    public class Bullet
    {
        private readonly int _damage;
        private readonly GameObject _shooter;
        
        private readonly GameObject _bulletObject;
        
        public Bullet(int damage, GameObject shooter, GameObject bulletObject)
        {
            _damage = damage;
            _shooter = shooter;
            
            _bulletObject = bulletObject;
        }
        
        public void Hit(GameObject objectToHit)
        {
            if (objectToHit == _shooter)
            {
                return;
            }
            
            if (objectToHit.TryGetComponent(out DamageableComponent damageableComponent))
            {
                damageableComponent.Damageable.ApplyDamage(_damage);
            }
            
            Object.Destroy(_bulletObject);
        }
    }
}
