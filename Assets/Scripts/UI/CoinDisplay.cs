using System.Collections;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsAmount;
    [SerializeField] private AnimationCurve _colorBehaviour;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Color _startingColor;
    [SerializeField] private Color _endingColor;
    [SerializeField] private float _delay;
    [SerializeField] private float _colorChangeDuration;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _wallet.ValueChanged += UpdateVisual;
    }

    private void OnDisable()
    {
        _wallet.ValueChanged -= UpdateVisual;
    }

    public void UpdateVisual(int amount)
    {
        _coinsAmount.text = amount.ToString();

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        var wait = new WaitForSeconds(_delay);

        for (float i = _colorChangeDuration; i > 0; i -= _delay)
        {
            _coinsAmount.color = Color.Lerp(_startingColor, _endingColor, _colorBehaviour.Evaluate(i));
            yield return wait;
        }

        _coroutine = null;
    }
}
