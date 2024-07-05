using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _detectDistance;
    [SerializeField] private LayerMask _ignoreLayers;

    private Transform _currentPoint;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Health _health;
    private bool _isPlayerNoticed = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Died += OnDeath;
    }

    private void Start()
    {
        ChangePatrolPoint();
    }

    private void Update()
    {
        SearchForPlayer();

        if (_isPlayerNoticed)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            player.TakeDamage(_damage * Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        _health.Died -= OnDeath;
    }

    private void SearchForPlayer()
    {
        _isPlayerNoticed = false;

        if (Vector2.Distance(transform.position, _player.position) < _detectDistance)
        {
            RaycastHit2D hit = Physics2D.Linecast(transform.position, _player.position, ~_ignoreLayers);
            Debug.DrawLine(transform.position, _player.position);

            if (hit.collider != null && hit.collider.TryGetComponent(out PlayerHealth playerHealth))
            {
                Debug.Log($"Found {gameObject.name}");
                AdjustSpriteFlip();
                _isPlayerNoticed = true;
            }
            else
            {
                Debug.Log($"{hit.collider.gameObject.name} {gameObject.name}");
            }
        }
    }

    private void Patrol()
    {
        if (Vector2.Distance(transform.position, _currentPoint.position) > 1 && _currentPoint != _player)
        {
            Move();
        }
        else
        {
            ChangePatrolPoint();
        }
    }

    private void ChangePatrolPoint()
    {
        _currentPoint = _patrolPoints[Random.Range(0, _patrolPoints.Count)];
        AdjustSpriteFlip();
    }

    private void AdjustSpriteFlip()
    {
        _spriteRenderer.flipX = _currentPoint.position.x > transform.position.x;
    }

    private void Move()
    {
        _rigidbody.position = Vector2.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);
    }

    private void ChasePlayer()
    {
        _currentPoint = _player;
        Move();
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }
}
