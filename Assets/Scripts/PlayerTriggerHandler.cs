using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class PlayerTriggerHandler : MonoBehaviour
{
    private Wallet _wallet;
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _wallet = GetComponentInParent<Wallet>();
        _playerHealth = GetComponentInParent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _wallet.AddCoin();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Healer healer))
        {
            _playerHealth.Heal(healer.Amount);
            Destroy(collision.gameObject);
        }
    }
}
