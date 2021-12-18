using UnityEngine;
using Object = UnityEngine.Object;

namespace BattleCity.Tanks
{
    public class Shooter
    {
        private const string BulletName = "Bullet";
        
        private readonly GameObject _bulletPrefab;
        private readonly int _bulletDamage;
        private readonly float _bulletSpeed;
        private readonly Transform _muzzleHole;
        
        private readonly GameObject _gameObject;
        private readonly Transform _transform;
        
        public Shooter(GameObject bulletPrefab, int bulletDamage, float bulletSpeed, Transform muzzleHole, GameObject gameObject)
        {
            _bulletPrefab = bulletPrefab;
            _bulletDamage = bulletDamage;
            _bulletSpeed = bulletSpeed;
            _muzzleHole = muzzleHole;
            
            _gameObject = gameObject;
            _transform = gameObject.transform;
        }
        
        public void Shoot()
        {
            GameObject bullet = Object.Instantiate(
                _bulletPrefab,
                _muzzleHole.position,
                _transform.rotation
            );

            bullet.name = BulletName;
            
            var bulletComponent = bullet.GetComponent<BulletComponent>();
            bulletComponent.Initialize(_bulletDamage, _gameObject);
            
            bullet.GetComponent<Rigidbody>().velocity = _bulletSpeed * _muzzleHole.forward;
        }
    }
}
