using UnityEngine;

public class Coin : Collectable<int>
{
    [SerializeField] int _coins;

    protected override int OnUsed()
    {
        return _coins;
    }
}
