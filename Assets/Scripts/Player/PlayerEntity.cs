using Core.Animation.Controller;
using Core.Movement.Controller;
using Core.Movement.Data;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerEntity : MonoBehaviour
{
    [SerializeField] private DirectionalMovementData _directionalMovementData;
    [SerializeField] private JumpData _jumpData;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private DirectionalMover _directionalMover;
    private Jumper _jumper;
    private PlayerAnimator _animationController;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _directionalMover = new DirectionalMover(_rigidbody, _directionalMovementData);
        _jumper = new Jumper(_rigidbody, _jumpData);
        _animationController = new PlayerAnimator(_rigidbody, _jumpData, _animator);
    }

    private void Update()
    {
        _jumper.CollisionChecks();
        _animationController.AnimationControllers();
    }

    public void Move(float direction) => _directionalMover.Move(direction);

    public void JumpButton() => _jumper.JumpButton();

    public void Jump() => _jumper.Jump();
    private void OnDrawGizmos() => Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - _jumpData._groundCheckDistance)); //відмальовка isGrounded для зручності

}