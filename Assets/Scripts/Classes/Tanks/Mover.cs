using BattleCity.Common;
using UnityEngine;

namespace BattleCity.Tanks
{
    public class Mover
    {
        private readonly Rigidbody _rigidbody;
        private readonly Transform _transform;

        private readonly float _speed;

        public Mover(Rigidbody rigidbody, Transform transform, float speed)
        {
            _rigidbody = rigidbody;
            _transform = transform;
            _speed = speed;
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
