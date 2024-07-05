using System;
using Unity.Burst;
using UnityEngine;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private Health _caster;
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;

    private readonly float _maxCharge = 6f;
    private readonly float _minUseCharge = 0f;

    private bool _isActive = false;
    private float _charge;

    public event Action<float, float> ValueChanged;
    public event Action StartedUsing;
    public event Action StoppedUsing;

    private void Start()
    {
        _charge = _maxCharge;
    }

    private void Update()
    {
        if (_isActive)
        {
            if (_charge > _minUseCharge)
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
        _isActive = true;
        StartedUsing?.Invoke();
    }

    public void StopAbility()
    {
        _isActive = false;
        StoppedUsing?.Invoke();
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
                _charge -= Time.deltaTime;
                ValueChanged?.Invoke(_charge, _maxCharge);
            }
        }
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
