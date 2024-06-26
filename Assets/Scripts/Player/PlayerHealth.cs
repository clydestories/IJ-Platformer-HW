using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class PlayerHealth : Health
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            TakeDamage(enemy.Damage * Time.deltaTime);
        }
    }
}