using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
public class PlayerAnimationHandler : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string IsMoving = nameof(IsMoving);
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private ParticleSystem _attackEffect;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
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

    public void StartMovementAnimation()
    {
        _animator.SetBool(IsMoving, true);
    }

    public void StopMovementAnimation()
    {
        _animator.SetBool(IsMoving, false);
    }

    public void StartJumpAnimation()
    {
        _animator.SetTrigger(Jump);
    }

    public void StartAttackEffect()
    {
        _attackEffect.Play();
    }
}
