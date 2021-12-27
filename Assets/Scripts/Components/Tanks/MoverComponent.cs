using UnityEngine;

namespace BattleCity.Tanks
{
    public class MoverComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _raycastDistance;

        public Mover Mover { get; private set; }

        private void Awake()
        {
            Mover = new Mover(_speed, transform, _raycastDistance);
        }

        private void OnDestroy()
        {
            Mover.Dispose();
        }
    }
}