using System;
using System.Threading.Tasks;
using BattleCity.Common;
using BattleCity.Tanks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BattleCity.Input
{
    public class MovementInput : IDisposable
    {
        private readonly Mover _mover;
        private readonly InputAction _inputAction;

        private Vector2 _lastRawDirection;
        private Vector2 _lastDirection;
        private bool _isMoving;

        public MovementInput(Mover mover, InputAction inputAction)
        {
            _mover = mover;
            _inputAction = inputAction;

            _inputAction.performed += StartMoving;
            _inputAction.canceled += StopMoving;
        }

        public void Enable()
        {
            _inputAction.Enable();
        }
        public void Disable()
        {
            _inputAction.Disable();
        }

        public void Dispose()
        {
            _inputAction.performed -= StartMoving;
            _inputAction.canceled -= StopMoving;
        }

        private void StartMoving(InputAction.CallbackContext context)
        {
            _isMoving = true;
            Moving(context);
        }
        private void StopMoving(InputAction.CallbackContext context)
        {
            _isMoving = false;
            _mover.StartMoving(Vector2.zero);
        }

        private async Task Moving(InputAction.CallbackContext context)
        {
            while (_isMoving)
            {
                var direction = context.ReadValue<Vector2>();
                NormalizeDirection(ref direction);

                _mover.StartMoving(direction);

                await Task.Yield();
            }
        }

        private void NormalizeDirection(ref Vector2 direction)
        {
            Vector2 rawDirection = direction;

            if (direction == _lastRawDirection)
            {
                direction = _lastDirection;
                return;
            }

            if (!direction.TrySnapToAxis())
            {
                direction = Mathf.Abs(direction.x - _lastRawDirection.x) > Mathf.Abs(direction.y - _lastRawDirection.y)
                    ? direction.SnapToX()
                    : direction.SnapToY();
            }

            _lastDirection = direction;
            _lastRawDirection = rawDirection;
        }
    }
}
