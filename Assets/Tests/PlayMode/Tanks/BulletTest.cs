using System.Collections;
using BattleCity.Tanks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tanks
{
    public class BulletTest
    {
        private const int BulletDamage = 1;
        private const float BulletSpeed = 1;
        private const string BulletName = "Bullet";
        
        private static readonly Vector3[] ShotDirections =
        {
            Vector3.right, 
            Vector3.left 
        };

        [UnityTest]
        public IEnumerator DestroyAfterHitTest([ValueSource(nameof(ShotDirections))]Vector3 shotDirection)
        {
            var objectToHit = new GameObject();
            Shooter shooter = CreateShooter(shotDirection);
            shooter.Shoot();
            
            GameObject bulletObject = GameObject.Find(BulletName);
            Bullet bullet = bulletObject.GetComponent<BulletComponent>().Bullet;
            bullet.Hit(objectToHit);
            
            yield return null;
            
            Assert.IsTrue(bulletObject == null);
        }

        private Shooter CreateShooter(Vector3 shotDirection)
        {
            var bulletPrefab = new GameObject();
            bulletPrefab.AddComponent<BoxCollider>();
            bulletPrefab.AddComponent<Rigidbody>().isKinematic = true;
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