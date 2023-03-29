using System;
using UnityEngine;

namespace Core.Movement.Data
{
    [Serializable]
    class JumpData
    {
        [field: SerializeField] public float _jumpForce { get; set; }
        [field: SerializeField] public float _doubleJumpForce { get; private set; }
        [field: SerializeField] public LayerMask _whatIsGround { get; private set; }
        [field: SerializeField] public float _groundCheckDistance { get; private set; }
        public bool isGrounded { get; set; }
        public float _defJumpForce { get; set; }
        public bool canDoubleJump { get; set; }
    }
}
