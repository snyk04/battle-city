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
        
        private readonly Vector3 _shotDirection = Vector3.right;

        [UnityTest]
        public IEnumerator DestroyAfterHitTest()
        {
            var objectToHit = new GameObject();
            CreateShooter(_shotDirection, out Shooter shooter);
            shooter.Shoot();
            
            GameObject bulletObject = GameObject.Find(BulletName);
            Bullet bullet = bulletObject.GetComponent<BulletComponent>().Bullet;
            bullet.Hit(objectToHit);
            
            yield return null;
            
            Assert.IsTrue(bulletObject == null);
        }

        private void CreateShooter(Vector3 shotDirection, out Shooter shooter)
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
            
            shooter = new Shooter(bulletPrefab, BulletDamage, BulletSpeed, muzzleHole.transform, shooterObject);
        }
    }
}
