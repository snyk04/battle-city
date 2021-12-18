using UnityEngine;

namespace BattleCity.Tanks
{
    public class ShooterComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private int _bulletDamage;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private Transform _muzzleHole;

        public Shooter Shooter { get; private set; }
        
        private void Awake()
        {
            Shooter = new Shooter(_bulletPrefab, _bulletDamage, _bulletSpeed, _muzzleHole, gameObject);
        }
    }
}