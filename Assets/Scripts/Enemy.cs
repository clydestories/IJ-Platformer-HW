using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeField] private float _speed;

    private Transform _currentPoint;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ChangePatrolPoint();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, _currentPoint.position) > 1)
        {
            Move();
        }
        else
        {
            ChangePatrolPoint();
        }
    }

    private void Move()
    {
        _rigidbody.position = Vector2.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);
    }

    private void ChangePatrolPoint()
    {
        _currentPoint = _patrolPoints[Random.Range(0, _patrolPoints.Count)];
        AdjustSpriteFlip();
    }

    private void AdjustSpriteFlip()
    {
        if (_currentPoint.position.x > transform.position.x)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}
