using Core.Movement.Data;
using UnityEngine;

namespace Core.Movement.Controller
{
    class DirectionalMover
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;
        private readonly DirectionalMovementData _directionalMovementData;

        public DirectionalMover(Rigidbody2D rigidbody, DirectionalMovementData directionalMovementData)
        {
            _rigidbody = rigidbody;
            _transform = _rigidbody.transform;
            _directionalMovementData = directionalMovementData;
        }

        public void Move(float direction)
        {
            SetDirection(direction);
            _rigidbody.velocity = new Vector2(_directionalMovementData.MoveSpeed * direction, _rigidbody.velocity.y);
        }

        private void SetDirection(float direction)
        {
            if ((_directionalMovementData.FaceRight && direction < 0) ||
               (!_directionalMovementData.FaceRight && direction > 0))           
                Flip();          
        }

        private void Flip()
        {
            _transform.Rotate(0, 180, 0);
            _directionalMovementData.FaceRight = !_directionalMovementData.FaceRight;
        }
    }
}
