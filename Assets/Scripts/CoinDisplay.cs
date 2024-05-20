using System.Collections;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsAmount;
    [SerializeField] private AnimationCurve _colorBehaviour;
    [SerializeField] private Color _startingColor;
    [SerializeField] private Color _endingColor;
    [SerializeField] private float _delay;
    [SerializeField] private float _colorChangeDuration;

    private Coroutine _coroutine;

    public void UpdateCoins(int amount)
    {
        _coinsAmount.text = amount.ToString();

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(ChangeColor());
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(ChangeColor());
        }
    }

    private IEnumerator ChangeColor()
    {
        var wait = new WaitForSeconds(_delay);
        for (float i = _colorChangeDuration; i > 0; i -= _delay)
        {
            Debug.Log("qwe");
            _coinsAmount.color = Color.Lerp(_startingColor, _endingColor, _colorBehaviour.Evaluate(i));
            yield return wait;
        }

        _coroutine = null;
    }
}
