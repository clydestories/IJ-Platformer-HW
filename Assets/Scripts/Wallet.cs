using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private CoinDisplay _coinDisplay;

    private int _coins;

    public void AddCoin()
    {
        _coins++;
        _coinDisplay.UpdateCoins(_coins);
    }
}
