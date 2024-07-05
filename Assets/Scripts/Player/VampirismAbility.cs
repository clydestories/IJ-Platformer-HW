using System;
using System.Collections;
using UnityEngine;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private Health _caster;
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;

    private readonly float _maxCharge = 6f;

    private bool _isActive = false;
    private float _charge;
    private Coroutine _ability;

    public event Action<float, float> ValueChanged;
    public event Action StoppedUsing;
    public event Action StartedUsing;

    private void Start()
    {
        _charge = _maxCharge;
    }

    private void Update()
    {
        if (_isActive)
        {
            if (_charge > 0)
            {
                Use();
            }
        }
        else
        {
            Recharge();
        }
    }

    public void StartAbility()
    {
        if (_ability == null)
        {
            _ability = StartCoroutine(Drain());
        }
    }

    private IEnumerator Drain()
    {
        StartedUsing?.Invoke();
        _isActive = true;
        yield return new WaitWhile(() => _charge > 0);
        StoppedUsing?.Invoke();
        _isActive = false;
        _ability = null;
    }

    private void Use()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius);

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out EnemyHealth enemy))
            {
                enemy.TakeDamage(_damage * Time.deltaTime);
                _caster.Heal(_damage * Time.deltaTime);
                break;
            }
        }

        _charge -= Time.deltaTime;
        ValueChanged?.Invoke(_charge, _maxCharge);
    }

    private void Recharge()
    {
        _charge += Time.deltaTime;

        if (_charge > _maxCharge)
        {
            _charge = _maxCharge;
        }

        ValueChanged?.Invoke(_charge, _maxCharge);
    }
}
