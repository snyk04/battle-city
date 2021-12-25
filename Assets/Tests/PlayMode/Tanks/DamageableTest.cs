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
            Damageable damageable = CreateDamageable(AmountOfHealth, out GameObject gameObject);
            
            damageable.Destroy();
            yield return null;
            Assert.IsTrue(gameObject == null);
        }
        [UnityTest]
        public IEnumerator ApplyDeathDamageTest()
        {
            Damageable damageable = CreateDamageable(AmountOfHealth, out GameObject gameObject);

            damageable.ApplyDamage(AmountOfHealth);
            yield return null;
            Assert.IsTrue(gameObject == null);
        }

        private Damageable CreateDamageable(int amountOfHealth, out GameObject gameObject)
        {
            gameObject = new GameObject();
            return new Damageable(amountOfHealth, gameObject);
        }
    }
}