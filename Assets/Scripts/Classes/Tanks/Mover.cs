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
        
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public Vector2 Velocity { get; private set; }

        public Mover(float speed, Transform transform)
        {
            _speed = speed;
            _transform = transform;

            MoveAsync(_cancellationSource.Token);
        }
        
        public void StartMoving(Vector2 direction)
        {
            // todo direction can be only V2.left/right/up/down
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
                _transform.position += Time.deltaTime * Velocity.ReProjectFromXZ();
                
                await Task.Yield();
            }
        }
    }
}