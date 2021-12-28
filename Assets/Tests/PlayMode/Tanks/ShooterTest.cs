using System;
using System.Collections;
using BattleCity.Tanks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace Tanks
{
    public class ShooterTest
    {
        private const float AllowedErrorForFloatComparison = 0.01f;
        
        private const int BulletDamage = 1;
        private const float BulletSpeed = 1;
        private const float ShotDelay = 1;
        private const string BulletName = "Bullet";

        private static readonly Vector3[] ShootDirections =
        {
            Vector3.right
        };

        [UnityTest]
        public IEnumerator DelayTest([ValueSource(nameof(ShootDirections))]Vector3 shootDirection)
        {
            Shooter shooter = CreateShooter(shootDirection);
            
            shooter.Shoot();
            
            GameObject bullet = GameObject.Find(BulletName);
            Assert.IsTrue(bullet != null);
            
            Object.Destroy(bullet);
            yield return null;
            Assert.IsTrue(bullet == null);

            shooter.Shoot();
            Assert.IsTrue(bullet == null);
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
            
            return new Shooter(bulletPrefab, BulletDamage, BulletSpeed, ShotDelay, muzzleHole.transform, shooterObject);
        }
    }
}