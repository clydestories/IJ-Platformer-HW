using UnityEngine;

[RequireComponent(typeof(Mover), typeof(PlayerAnimator), typeof(Rigidbody2D))]
[RequireComponent(typeof(Attacker), typeof(VampirismAbility))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _input;

    private Mover _mover;
    private PlayerAnimator _playerAnimator;
    private Rigidbody2D _rigidbody;
    private Attacker _attacker;
    private VampirismAbility _vampirism;
    private Health _health;
    private bool _isMoving = false;
    private float _directionX = 0f;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _attacker = GetComponent<Attacker>();
        _vampirism = GetComponent<VampirismAbility>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _input.Jumped += Jump;
        _input.Moved += Move;
        _input.Attacked += Attack;
        _input.StartedAbility += StartAbility;
        _input.StoppedAbility += StopAbility;
        _health.Died += OnDeath;
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
        _input.StartedAbility -= StartAbility;
        _input.StoppedAbility -= StopAbility;
        _health.Died += OnDeath;
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

    private void StartAbility()
    {
        _vampirism.StartAbility();
    }

    private void StopAbility()
    {
        _vampirism.StopAbility();
    }

    private void OnDeath()
    {
        _mover.enabled = false;
        _attacker.enabled = false;
        _vampirism.enabled = false;
        _playerAnimator.enabled = false;
        _health.enabled = false;
        _rigidbody.velocity = Vector3.zero;
    }
}
