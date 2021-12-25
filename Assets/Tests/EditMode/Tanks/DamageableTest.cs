using BattleCity.Tanks;
using NUnit.Framework;
using UnityEngine;

namespace Tanks
{
    public class DamageableTest
    {
        private const int AmountOfHealth = 3;

        [Test]
        public void ApplyDamageTest([Values(1, 2)]int damage)
        {
            Damageable damageable = CreateDamageable(AmountOfHealth);
            damageable.ApplyDamage(damage);
            Assert.AreEqual(AmountOfHealth - damage, damageable.AmountOfHealth);
        }
        
        private Damageable CreateDamageable(int amountOfHealth)
        {
            var gameObject = new GameObject();
            return new Damageable(amountOfHealth, gameObject);
        }
    }
}