using Core.Movement.Data;
using UnityEngine;

namespace Core.Animation.Controller
{
    class PlayerAnimator
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly JumpData _jumpData;
        private readonly Animator _animator;
        public PlayerAnimator(Rigidbody2D rigidbody, JumpData jumpData, Animator animator)
        {
            _rigidbody = rigidbody;
            _jumpData = jumpData;
            _animator = animator;
        }
        public void AnimationControllers()
        {
            bool isMoving = _rigidbody.velocity.x != 0;
            _animator.SetBool("isMoving", isMoving);
            _animator.SetBool("isGrounded", _jumpData.isGrounded);
            _animator.SetFloat("yVelocity", _rigidbody.velocity.y);
        }
    }
}
