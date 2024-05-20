using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
public class PlayerAnimationHandler : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string IsMoving = nameof(IsMoving);
    private const string Horizontal = nameof(Horizontal);

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Movement _movement;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
    }

    private void OnEnable()
    {
        _movement.Jumped.AddListener(OnJump);
        _movement.StartedMoving.AddListener(OnStartMoving);
        _movement.StoppedMoving.AddListener(OnStopMoving);
    }

    private void Update()
    {
        if (Input.GetAxis(Horizontal) > 0)
        {
            _spriteRenderer.flipX = false;
        }

        if (Input.GetAxis(Horizontal) < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void OnStartMoving()
    {
        _animator.SetBool(IsMoving, true);
    }

    private void OnStopMoving()
    {
        _animator.SetBool(IsMoving, false);
    }

    private void OnJump()
    {
        _animator.SetTrigger(Jump);
    }

    private void OnDisable()
    {
        _movement.Jumped.RemoveListener(OnJump);
        _movement.StartedMoving.RemoveListener(OnStartMoving);
        _movement.StoppedMoving.RemoveListener(OnStopMoving);
    }
}
