using System;
using UnityEngine;

namespace BattleCity.Tanks
{
    [RequireComponent(typeof(Rigidbody))] // todo remove
    public class MoverComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public Mover Mover { get; private set; }
        
        private void Awake()
        {
            Mover = new Mover(_speed, transform);
        }

        private void OnDestroy()
        {
            Mover.Dispose();
        }
    }
}
