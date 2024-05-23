using UnityEngine;
using UnityEngine.UI;

public class BarDisplay : MonoBehaviour
{
    [SerializeField] private Slider _bar;

    public void SetBarValue(float currentValue, float maxValue)
    {
        _bar.value = currentValue / maxValue;
    }
}
