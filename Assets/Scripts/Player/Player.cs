using UnityEngine;

[RequireComponent(typeof(Mover), typeof(PlayerAnimator), typeof(Rigidbody2D))]
[RequireComponent(typeof(Attacker))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _input;

    private Mover _mover;
    private PlayerAnimator _playerAnimator;
    private Rigidbody2D _rigidbody;
    private Attacker _attacker;
    private bool _isMoving = false;
    private float _directionX = 0f;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _attacker = GetComponent<Attacker>();
    }

    private void OnEnable()
    {
        _input.Jumped += Jump;
        _input.Moved += Move;
        _input.Attacked += Attack;
    }

    private void Update()
    {
        _isMoving = _directionX != 0 && _rigidbody.velocity.x != 0;

        if (_isMoving == false)
        {
            _playerAnimator.StopMovementAnimation();
        }
        else if (_isMoving)
        {
            _playerAnimator.StartMovementAnimation();
        }
    }

    private void OnDisable()
    {
        _input.Jumped -= Jump;
        _input.Moved -= Move;
        _input.Attacked -= Attack;
    }

    private void Jump()
    {
        if (_mover.TryJump())
        {
            _playerAnimator.StartJumpAnimation();
        }
    }

    private void Move(float direction)
    {
        _mover.SetDirection(direction);
        _playerAnimator.SetDirection(direction);
        _directionX = direction;
    }

    private void Attack()
    {
        _attacker.Attack();
        _playerAnimator.PlayAttackEffect();
    }
}
