using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private CoinDisplay _coinDisplay;
    
    private int _allCoinsAmount;
    private int _coins;

    public event Action AllCoinsCollected;

    private void Start()
    {
        _allCoinsAmount = FindObjectsOfType<Coin>().Length;
    }

    public void AddCoin()
    {
        _coins++;
        _coinDisplay.UpdateCoins(_coins);

        if (_coins == _allCoinsAmount)
        {
            AllCoinsCollected?.Invoke();
        }
    }
}
