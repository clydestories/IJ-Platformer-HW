using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeField] private float _speed;

    private Transform _currentPoint;
    private Quaternion _rotationLookingLeft = Quaternion.Euler(0, 0, 0);
    private Quaternion _rotationLookingRight = Quaternion.Euler(0, 180, 0);

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
        transform.position = Vector2.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);
    }

    private void ChangePatrolPoint()
    {
        _currentPoint = _patrolPoints[Random.Range(0, _patrolPoints.Count)];
        FaceTarget();
    }

    private void FaceTarget()
    {
        if (_currentPoint.position.x > transform.position.x)
        {
            transform.rotation = _rotationLookingRight;
        }
        else
        {
            transform.rotation = _rotationLookingLeft;
        }
    }
}
