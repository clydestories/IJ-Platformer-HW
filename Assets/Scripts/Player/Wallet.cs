using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Transform _coinsContainer;

    private int _allCoinsAmount;
    private int _coins;

    public event Action AllCoinsCollected;
    public event Action<int> ValueChanged;

    private void Start()
    {
        _allCoinsAmount = _coinsContainer.childCount;
    }

    public void AddCoins(int amount)
    {
        if (amount < 0)
        {
            throw new Exception("Negative amount of coins addition");
        }

        _coins += amount;
        ValueChanged?.Invoke(_coins);

        if (_coins == _allCoinsAmount)
        {
            AllCoinsCollected?.Invoke();
        }
    }
}
