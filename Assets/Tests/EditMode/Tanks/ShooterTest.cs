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

        private static readonly Vector3[] ShootDirections =
        {
            Vector3.right, 
            Vector3.left
        };

        [Sequential]
        [Test]
        public void ShootTest([ValueSource(nameof(ShootDirections))]Vector3 shootDirection)
        {
            Shooter shooter = CreateShooter(shootDirection);
            shooter.Shoot();

            Vector3 expected = shootDirection * BulletSpeed;
            Vector3 actual = GameObject.Find(BulletName).GetComponent<Rigidbody>().velocity;
            Assert.Less(Math.Abs(expected.x - actual.x), AllowedErrorForFloatComparison);
            Assert.Less(Math.Abs(expected.y - actual.y), AllowedErrorForFloatComparison);
            Assert.Less(Math.Abs(expected.z - actual.z), AllowedErrorForFloatComparison);
        }
        
        private Shooter CreateShooter(Vector3 shotDirection)
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
            
            return new Shooter(bulletPrefab, BulletDamage, BulletSpeed, muzzleHole.transform, shooterObject);
        }
    }
}