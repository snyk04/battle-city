using BattleCity.Common;
using UnityEngine;

namespace BattleCity.Tanks
{
    public class Mover
    {
        private readonly float _speed;
        
        private readonly Rigidbody _rigidbody;
        private readonly Transform _transform;
        
        public Mover(float speed, Rigidbody rigidbody, Transform transform)
        {
            _speed = speed;

            _rigidbody = rigidbody;
            _transform = transform;
        }
        
        public void StartMoving(Vector2 direction)
        {
            bool isDirectionZero = direction == Vector2.zero;
            
            _rigidbody.isKinematic = isDirectionZero;
            _rigidbody.velocity = _speed * direction.normalized.ReProjectFromXZ();

            if (!isDirectionZero)
            {
                _transform.forward = direction.ReProjectFromXZ();
            }
        }
    }
}
