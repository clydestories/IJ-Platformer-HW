using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _health;

    public event Action Died;
    public event Action<float, float> ValueChanged;

    public float Value
    {
        get
        {
            return _health;
        }
        private set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);
        }
    }

    private void Start()
    {
        _health = _maxHealth;
        ValueChanged?.Invoke(Value, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            throw new Exception("Damage of a negative amount");
        }

        Value -= damage;

        if (_health == 0)
        {
            Die();
        }

        ValueChanged?.Invoke(Value, _maxHealth);
    }

    public void Heal(float amount)
    {
        if (amount < 0)
        {
            throw new Exception("Heal of a negative amount");
        }

        Value += amount;

        ValueChanged?.Invoke(Value, _maxHealth);
    }

    protected virtual void Die()
    {
        Died?.Invoke();

        MonoBehaviour[] components = GetComponentsInChildren<MonoBehaviour>();

        foreach (var component in components)
        {
            component.enabled = false;
        }
    }
}
