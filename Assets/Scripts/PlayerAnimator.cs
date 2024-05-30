using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private readonly int Jump = Animator.StringToHash(nameof(Jump));
    private readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));

    private Animator _animator;
    private float _direction = 0f;
    private float yRotationLookingLeft = 180;
    private float yRotationLookingRight = 0;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_direction > 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, yRotationLookingRight, transform.rotation.z);
        }
        
        if (_direction < 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, yRotationLookingLeft, transform.rotation.z);
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
        _direction = direction;
    }
}
