using UnityEngine;
using UnityEngine.UI;

public class BarDisplay : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private Health _carier;

    private void OnEnable()
    {
        _carier.ValueChanged += SetBarValue;
    }

    private void OnDisable()
    {
        _carier.ValueChanged -= SetBarValue;
    }

    private void SetBarValue(float currentValue, float maxValue)
    {
        _bar.value = currentValue / maxValue;
    }
}
