using Core.Movement.Data;
using UnityEngine;

namespace Core.Movement.Controller
{
    class Jumper
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;
        private readonly JumpData _jumpData;

        public Jumper(Rigidbody2D rigidbody, JumpData jumpData)
        {
            _rigidbody = rigidbody;
            _transform = _rigidbody.transform;
            _jumpData = jumpData;
            _jumpData._defJumpForce = _jumpData._jumpForce;
        }

        public void JumpButton()
        {
            if (_jumpData.isGrounded)
            {
                _jumpData.canDoubleJump = true;
                Jump();
            }
            else if (_jumpData.canDoubleJump)
            {
                _jumpData.canDoubleJump = false;
                _jumpData._jumpForce = _jumpData._doubleJumpForce;
                Jump();
                _jumpData._jumpForce = _jumpData._defJumpForce;
            }
        }

        public void Jump() => _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpData._jumpForce);

        public void CollisionChecks() => _jumpData.isGrounded = Physics2D.Raycast(_transform.position, Vector2.down, _jumpData._groundCheckDistance, _jumpData._whatIsGround);
    }
}
