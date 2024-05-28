using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class PlayerTriggerHandler : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _wallet.AddCoin();
            Destroy(collision.gameObject);
        }
    }
}
