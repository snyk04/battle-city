using UnityEngine;

namespace BattleCity.Tanks
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoverComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public Mover Mover { get; private set; }
        
        private void Awake()
        {
            var rb = GetComponent<Rigidbody>();
            Mover = new Mover(rb, transform, _speed);
        }
    }
}
