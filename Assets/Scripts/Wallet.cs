using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private CoinDisplay _coinDisplay;
    [SerializeField] private Transform _coinsContainer;

    private int _allCoinsAmount;
    private int _coins;

    public event Action AllCoinsCollected;

    private void Start()
    {
        _allCoinsAmount = _coinsContainer.childCount;
    }

    public void AddCoin()
    {
        _coins++;
        _coinDisplay.UpdateVisual(_coins);

        if (_coins == _allCoinsAmount)
        {
            AllCoinsCollected?.Invoke();
        }
    }
}
