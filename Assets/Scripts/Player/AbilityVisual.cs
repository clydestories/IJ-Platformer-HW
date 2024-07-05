using UnityEngine;

[RequireComponent (typeof(Renderer))]
public class AbilityVisual : MonoBehaviour
{
    [SerializeField] private VampirismAbility _ability;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _ability.StartedUsing += TurnOn;
        _ability.StoppedUsing += TurnOff;
    }

    private void OnDisable()
    {
        _ability.StartedUsing -= TurnOn;
        _ability.StoppedUsing -= TurnOff;
    }

    private void TurnOn()
    {
        _renderer.enabled = true;
    }

    private void TurnOff()
    {
        _renderer.enabled = false;
    }
}