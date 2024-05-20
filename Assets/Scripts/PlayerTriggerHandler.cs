using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class PlayerTriggerHandler : MonoBehaviour
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponentInParent<Wallet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _wallet.AddCoin();
            Destroy(collision.gameObject);
        }
    }
}
