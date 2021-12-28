using System;
using BattleCity.Common;
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
        public float ShotDelay { get; }
        private readonly Transform _muzzleHole;

        private readonly GameObject _gameObject;
        private readonly Transform _transform;

        private float _lastShotTime;

        public event Action OnShot;
        
        public Shooter(GameObject bulletPrefab, int bulletDamage, float bulletSpeed, float shotDelay, 
            Transform muzzleHole, GameObject gameObject)
        {
            _bulletPrefab = bulletPrefab;
            _bulletDamage = bulletDamage;
            _bulletSpeed = bulletSpeed;
            ShotDelay = shotDelay;
            _muzzleHole = muzzleHole;

            _gameObject = gameObject;
            _transform = gameObject.transform;

            _lastShotTime = -shotDelay;
        }

        public void Shoot()
        {
            if (!CanShoot())
            {
                return;
            }
            
            GameObject bullet = Object.Instantiate(
                _bulletPrefab,
                _muzzleHole.position,
                _transform.rotation
            );

            bullet.name = BulletName;

            var bulletComponent = bullet.GetComponent<BulletComponent>();
            bulletComponent.Initialize(_bulletDamage, _gameObject);

            Vector3 shootDirection = _muzzleHole.forward.NullifyY();

            bullet.GetComponent<Rigidbody>().velocity = _bulletSpeed * shootDirection;
            
            _lastShotTime = Time.time;
            OnShot?.Invoke();
        }

        private bool CanShoot()
        {
            return Time.time - _lastShotTime > ShotDelay;
        }
    }
}