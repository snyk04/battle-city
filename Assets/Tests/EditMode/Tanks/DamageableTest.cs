using BattleCity.Tanks;
using NUnit.Framework;
using UnityEngine;

namespace Tanks
{
    public class DamageableTest
    {
        private const int AmountOfHealth = 3;

        private const int Damage1 = 1;
        private const int Damage2 = 2;
        
        [Test]
        public void ApplyDamageTest1()
        {
            ApplyDamageTest(Damage1);
        }
        [Test]
        public void ApplyDamageTest2()
        {
            ApplyDamageTest(Damage2);
        }

        private void ApplyDamageTest(int damage)
        {
            CreateDamageable(AmountOfHealth, out Damageable damageable);
            damageable.ApplyDamage(damage);
            Assert.AreEqual(AmountOfHealth - damage, damageable.AmountOfHealth);
        }
        private void CreateDamageable(int amountOfHealth, out Damageable damageable)
        {
            var gameObject = new GameObject();
            damageable = new Damageable(amountOfHealth, gameObject);
        }
    }
}
