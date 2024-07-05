using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class PlayerTriggerHandler : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ICollectable collectable))
        {
            Collect((dynamic)collectable);
        }
    }

    private void Collect(Coin coin)
    {
        _wallet.AddCoins(coin.Use());
    }

    private void Collect(Healer healer)
    {
        _playerHealth.Heal(healer.Use());
    }
}