using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarDisplay : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private Health _carier;
    [SerializeField] private float _delay = 0.01f;
    [SerializeField] private float _step = 0.01f;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _carier.ValueChanged += SetBarValue;
    }

    private void OnDisable()
    {
        _carier.ValueChanged -= SetBarValue;
    }

    private IEnumerator SmoothenValue(float value)
    {
        var wait = new WaitForSeconds(_delay);

        while (_bar.value != value)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, value, _step);
            yield return wait;
        }

        _coroutine = null;
    }

    private void SetBarValue(float currentValue, float maxValue)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SmoothenValue(currentValue / maxValue));
    }
}
