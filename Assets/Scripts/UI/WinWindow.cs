using UnityEngine;

public class WinWindow : Window
{
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.AllCoinsCollected += Show;
    }

    private void OnDisable()
    {
        _wallet.AllCoinsCollected -= Show;
    }

    protected override void Show()
    {
        base.Show();
        Time.timeScale = 0f;
    }
}
