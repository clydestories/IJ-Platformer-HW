using UnityEngine;

public class Healer : Collectable<float>
{
    [SerializeField] float _health;

    protected override float OnUsed()
    {
        return _health;
    }
}
