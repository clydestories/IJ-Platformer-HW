using UnityEngine;

[RequireComponent (typeof(PlayerAnimationHandler))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackDamage;
    
    private PlayerAnimationHandler _playerAnimations;

    private void Awake()
    {
        _playerAnimations = GetComponent<PlayerAnimationHandler>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerAnimations.StartAttackEffect();

            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _attackRadius);

            foreach (Collider2D hit in hits)
            {
                if (hit.TryGetComponent(out EnemyHealth enemy))
                {
                    Attack(enemy);
                }
            }
        }
    }

    private void Attack(EnemyHealth enemy)
    {
        enemy.TakeDamage(_attackDamage);
    }
}
