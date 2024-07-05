using UnityEngine;
using UnityEngine.UI;

public class AbilityDisplay : MonoBehaviour
{
    [SerializeField] private VampirismAbility _ability;
    [SerializeField] private Image _graphic;

    private void OnEnable()
    {
        _ability.ValueChanged += SetValue;
    }

    private void OnDisable()
    {
        _ability.ValueChanged -= SetValue;
    }

    private void SetValue(float currentValue, float maxValue)
    {
        _graphic.fillAmount = currentValue/maxValue;
    }
}
