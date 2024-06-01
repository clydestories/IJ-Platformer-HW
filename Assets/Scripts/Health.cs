using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private BarDisplay _healthBar;

    private float _health;

    public event Action Died;
    //health as property
    //maxhealth as property

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            Die();
        }

        if (_healthBar != null)
        {
            _healthBar.SetBarValue(_health, _maxHealth);
        }
    }

    public void Heal(float amount)
    {
        _health += amount;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }

        if (_healthBar != null)
        {
            _healthBar.SetBarValue(_health, _maxHealth);//event
        }
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
