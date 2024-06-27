using System;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private List<KeyCode> _jumpKeys = new();
    [SerializeField] private List<KeyCode> _attackKeys = new();

    private float _direction = 0f;

    public event Action<float> Moved;
    public event Action Jumped;
    public event Action Attacked;

    private void Update()
    {
        _direction = Input.GetAxis(Horizontal);

        foreach (KeyCode key in _jumpKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Jumped?.Invoke();
                break;
            }
        }

        foreach (KeyCode key in _attackKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Attacked?.Invoke();
                break;
            }
        }

        Moved?.Invoke(_direction);
    }
}
