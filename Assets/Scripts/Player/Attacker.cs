using UnityEngine;

[RequireComponent (typeof(PlayerAnimator))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackDamage;

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _attackRadius);

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out EnemyHealth enemy))
            {
                enemy.TakeDamage(_attackDamage);
            }
        }
    }
}
