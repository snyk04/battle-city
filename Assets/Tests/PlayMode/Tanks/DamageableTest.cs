using System.Collections;
using BattleCity.Tanks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tanks
{
    public class DamageableTest
    {
        private const int AmountOfHealth = 3;
        
        [UnityTest]
        public IEnumerator DestroyTest()
        {
            CreateDamageable(AmountOfHealth, out GameObject gameObject, out Damageable damageable);
            
            damageable.Destroy();
            yield return null;
            Assert.IsTrue(gameObject == null);
        }
        [UnityTest]
        public IEnumerator ApplyDeathDamageTest()
        {
            CreateDamageable(AmountOfHealth, out GameObject gameObject, out Damageable damageable);

            damageable.ApplyDamage(AmountOfHealth);
            yield return null;
            Assert.IsTrue(gameObject == null);
        }

        private void CreateDamageable(int amountOfHealth, out GameObject gameObject, out Damageable damageable)
        {
            gameObject = new GameObject();
            damageable = new Damageable(amountOfHealth, gameObject);
        }
    }
}
