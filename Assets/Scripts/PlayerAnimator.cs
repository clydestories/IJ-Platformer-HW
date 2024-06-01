using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private readonly int Jump = Animator.StringToHash(nameof(Jump));
    private readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));

    private Animator _animator;
<<<<<<< Updated upstream
    private float _direction = 0f;
    private float _yRotationLookingLeft = 180;
    private float _yRotationLookingRight = 0;
=======
    private float _directionX = 0f;
    private Quaternion _rotationLookingLeft = Quaternion.Euler(0, 180, 0);
    private Quaternion _rotationLookingRight = Quaternion.Euler(0, 0, 0);
>>>>>>> Stashed changes

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_directionX > 0)
        {
<<<<<<< Updated upstream
            transform.rotation = Quaternion.Euler(transform.rotation.x, _yRotationLookingRight, transform.rotation.z);
=======
            transform.rotation = _rotationLookingRight;
>>>>>>> Stashed changes
        }
        
        if (_directionX < 0)
        {
<<<<<<< Updated upstream
            transform.rotation = Quaternion.Euler(transform.rotation.x, _yRotationLookingLeft, transform.rotation.z);
=======
            transform.rotation = _rotationLookingLeft;
>>>>>>> Stashed changes
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
}
