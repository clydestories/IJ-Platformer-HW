using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(PlayerAnimator))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxClimbAngle;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded = true;
    private float _directionX = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Vector2.Angle(Vector2.up, collision.GetContact(0).normal) < _maxClimbAngle)
        {
            _isGrounded = true;
        }
    }

    private void Move()
    {
        Vector2 veloclity = _rigidbody.velocity;
        veloclity.x = _directionX * _speed;
        _rigidbody.velocity = veloclity;
    }

    public bool TryJump()
    {
        if (_isGrounded)
        {
            _rigidbody.AddForce(_jumpForce * Vector2.up, ForceMode2D.Force);
            _isGrounded = false;
            return true;
        }

        return false;
    }

    public void SetDirection(float direction)
    {
        _directionX = direction;
    }
}
