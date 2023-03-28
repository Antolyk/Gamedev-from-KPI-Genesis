using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerEntity : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _faceRight;

    [Header("Jump")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _doubleJumpForce;
    private float _defJumpForce;
    private bool canDoubleJump = true;

    [Header("Collision info")]
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _groundCheckDistance;
    private bool isGrounded;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _defJumpForce = _jumpForce;
    }

    private void Update()
    {
        CollisionChecks();
        AnimationControllers();

        if (isGrounded)
        {
            canDoubleJump = true;
        }
    }

    public void Move(float direction)
    {
        SetDirection(direction);
        _rigidbody.velocity = new Vector2(_moveSpeed * direction, _rigidbody.velocity.y);
    }

    public void JumpButton()
    {
        if (isGrounded)
        {
            Jump();
        }
        else if (canDoubleJump)
        {
            canDoubleJump = false;
            _jumpForce = _doubleJumpForce;
            Jump();
            _jumpForce = _defJumpForce;
        }
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }

    private void SetDirection(float direction)
    {
        if ((_faceRight && direction < 0) ||
          (!_faceRight && direction > 0))
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        _faceRight = !_faceRight;
    }

    private void AnimationControllers()
    {
        bool isMoving = _rigidbody.velocity.x != 0;
        _animator.SetBool("isMoving", isMoving);
        _animator.SetBool("isGrounded", isGrounded);
        _animator.SetFloat("yVelocity", _rigidbody.velocity.y);
    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, _whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - _groundCheckDistance)); //відмальовка isGrounded
    }
}