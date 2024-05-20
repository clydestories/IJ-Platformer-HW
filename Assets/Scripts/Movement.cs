using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxClimbAngle;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded = true;
    private float _direction;

    public UnityEvent Jumped;
    public UnityEvent StartedMoving;
    public UnityEvent StoppedMoving;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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

    private void Move()//Move to new input system
    {
        Vector2 veloclity = _rigidbody.velocity;
        veloclity.x = _direction * _speed;
        _rigidbody.velocity = veloclity;

        if (Input.GetAxis(Horizontal) == 0)
        {
            StoppedMoving?.Invoke();
        }
        else//костыль
        {
            StartedMoving?.Invoke();
        }
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody.AddForce(_jumpForce * Vector2.up, ForceMode2D.Force);
            _isGrounded = false;
            Jumped?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//Collision2D and ContactPoint2D and 3D research
    {
        Debug.Log(Vector2.Angle(Vector2.up, collision.GetContact(0).normal));

        if (Vector2.Angle(Vector2.up, collision.GetContact(0).normal) < _maxClimbAngle)
        {
            _isGrounded = true;
        }
    }
}
