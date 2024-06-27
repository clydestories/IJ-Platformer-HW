using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Collectable<T> : MonoBehaviour, ICollectable<T>
{
    [SerializeField] private Effector _effect;
    [SerializeField] private Renderer _renderer;

    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    public T Use()
    {
        _collider.enabled = false;
        _renderer.enabled = false;

        if (_effect != null)
        {
            _effect.Play();
        }
        else
        {
            Destroy(gameObject);
        }

        return OnUsed();
    }

    protected abstract T OnUsed();
}
