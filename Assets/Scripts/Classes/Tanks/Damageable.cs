using Action = System.Action;
using UnityEngine;

namespace BattleCity.Tanks
{
    public class Damageable
    {
        public int AmountOfHealth { get; private set; }
        public event Action OnDestroy;

        private readonly GameObject _gameObject;

        public Damageable(int amountOfHealth, GameObject gameObject)
        {
            AmountOfHealth = amountOfHealth;

            _gameObject = gameObject;
        }

        public void ApplyDamage(int damage)
        {
            AmountOfHealth = Mathf.Max(AmountOfHealth - damage, 0);

            if (AmountOfHealth == 0)
            {
                Destroy();
            }
        }
        public void Destroy()
        {
            OnDestroy?.Invoke();
            Object.Destroy(_gameObject);
        }
    }
}