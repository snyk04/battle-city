using UnityEngine;

namespace BattleCity.Tanks
{
    public class BulletComponent : MonoBehaviour
    {
        public Bullet Bullet { get; private set; }

        public void Initialize(int damage, GameObject shooter)
        {
            Bullet = new Bullet(damage, shooter, gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            Bullet.Hit(other.gameObject);
        }
    }
}
