using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private readonly int Jump = Animator.StringToHash(nameof(Jump));
    private readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));

    [SerializeField] private ParticleSystem _attackEffect;

    private Animator _animator;
    private float _directionX = 0f;
    private Quaternion _rotationLookingLeft = Quaternion.Euler(0, 180, 0);
    private Quaternion _rotationLookingRight = Quaternion.Euler(0, 0, 0);

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_directionX > 0)
        {
            transform.rotation = _rotationLookingRight;
        }
        
        if (_directionX < 0)
        {
            transform.rotation = _rotationLookingLeft;
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

    public void SetDirection(float direction)
    {
        _directionX = direction;
    }

    public void PlayAttackEffect()
    {
        _attackEffect.Play();
    }
}
