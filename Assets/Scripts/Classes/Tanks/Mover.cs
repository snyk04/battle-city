using System;
using System.Threading;
using System.Threading.Tasks;
using BattleCity.Common;
using UnityEngine;

namespace BattleCity.Tanks
{
    public class Mover : IDisposable
    {
        private readonly float _speed;
        private readonly Transform _transform;
        private readonly float _raycastDistance;
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public Vector2 Velocity { get; private set; }

        public Mover(float speed, Transform transform, float raycastDistance = 0.1f)
        {
            _speed = speed;
            _transform = transform;
            _raycastDistance = raycastDistance;

            MoveAsync(_cancellationSource.Token);
        }

        public void StartMoving(Vector2 direction)
        {
            // TODO : Direction can be only V2.left/right/up/down
            Velocity = _speed * direction.normalized;

            if (direction != Vector2.zero)
            {
                _transform.forward = direction.ReProjectFromXZ();
            }
        }

        public void Dispose()
        {
            _cancellationSource.Cancel();
            _cancellationSource.Dispose();
        }

        private async Task MoveAsync(CancellationToken cancellation)
        {
            while (!cancellation.IsCancellationRequested)
            {
                if (Velocity != Vector2.zero && !Raycast())
                {
                    _transform.position += Time.deltaTime * Velocity.ReProjectFromXZ();
                }

                await Task.Yield();
            }
        }

        private bool Raycast()
        {
            return Physics.BoxCast(_transform.position, Vector3.one * 0.2f, Velocity.ReProjectFromXZ().normalized, Quaternion.identity, _raycastDistance);
        }
    }

    public class GroupLogic
    {
        private readonly int _сколькоМожноСёрбатьБлять;
        private const string TheTruth = "Даннил пидор";

        public string Truth => TheTruth;
        public int СёрбкиДани => _сколькоМожноСёрбатьБлять;

        public GroupLogic(int сколькоМожноСёрбатьБлять)
        {
            _сколькоМожноСёрбатьБлять = сколькоМожноСёрбатьБлять;
        }
    }
}
