using System;
using BattleCity.Tanks;
using NUnit.Framework;
using UnityEngine;

namespace Tanks
{
    public class ShooterTest
    {
        private const float AllowedErrorForFloatComparison = 0.01f;
        
        private const int BulletDamage = 1;
        private const float BulletSpeed = 1;
        private const string BulletName = "Bullet";

        private readonly Vector3 _direction1 = Vector3.right;
        private readonly Vector3 _direction2 = Vector3.left;

        [Test]
        public void ShootTest1()
        {
            ShootTest(_direction1);
        }
        [Test]
        public void ShootTest2()
        {
            ShootTest(_direction2);
        }

        private void ShootTest(Vector3 shotDirection)
        {
            CreateShooter(shotDirection, out Shooter shooter);
            shooter.Shoot();

            Vector3 expected = shotDirection * BulletSpeed;
            Vector3 actual = GameObject.Find(BulletName).GetComponent<Rigidbody>().velocity;
            Assert.Less(Math.Abs(expected.x - actual.x), AllowedErrorForFloatComparison);
            Assert.Less(Math.Abs(expected.y - actual.y), AllowedErrorForFloatComparison);
            Assert.Less(Math.Abs(expected.z - actual.z), AllowedErrorForFloatComparison);
        }
        private void CreateShooter(Vector3 shotDirection, out Shooter shooter)
        {
            var bulletPrefab = new GameObject();
            bulletPrefab.AddComponent<BoxCollider>();
            bulletPrefab.AddComponent<BulletComponent>();

            var shooterObject = new GameObject();
            var muzzleHole = new GameObject
            {
                transform =
                {
                    forward = shotDirection
                }
            };
            
            shooter = new Shooter(bulletPrefab, BulletDamage, BulletSpeed, muzzleHole.transform, shooterObject);
        }
    }
}
