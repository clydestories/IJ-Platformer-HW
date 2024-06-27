using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Window : MonoBehaviour
{
    private readonly float _enabledAlphaAmount = 1f;

    [SerializeField] private string _message;
    [SerializeField] private TextMeshProUGUI _text;

    private CanvasGroup _group;

    private void Awake()
    {
        _group = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _text.text = _message;
    }

    protected virtual void Show()
    {
        _group.alpha = _enabledAlphaAmount;
    }
}
