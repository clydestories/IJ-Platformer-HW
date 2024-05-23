using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(PlayerAnimationHandler))]
public class Movement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxClimbAngle;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded = true;
    private bool _isMoving = false;
    private float _direction;
    private PlayerAnimationHandler _animationHandler;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animationHandler = GetComponent<PlayerAnimationHandler>();
    }

    private void Update()
    {
        _direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 veloclity = _rigidbody.velocity;
        veloclity.x = _direction * _speed;
        _rigidbody.velocity = veloclity;

        if (_isMoving == true && _rigidbody.velocity.x == 0)//??
        {
            Debug.Log("Stopped");
            _animationHandler.StopMovementAnimation();
        }
        else if (_isMoving == false && Input.GetAxis(Horizontal) != 0)
        {
            Debug.Log("Started");
            _animationHandler.StartMovementAnimation();
        }

        _isMoving = Input.GetAxis(Horizontal) != 0 && _rigidbody.velocity.x != 0;
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody.AddForce(_jumpForce * Vector2.up, ForceMode2D.Force);
            _isGrounded = false;
            _animationHandler.StartJumpAnimation();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//Collision2D and ContactPoint2D and 3D research
    {
        if (Vector2.Angle(Vector2.up, collision.GetContact(0).normal) < _maxClimbAngle)
        {
            _isGrounded = true;
        }
    }
}
