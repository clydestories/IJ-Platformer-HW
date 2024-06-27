using UnityEngine;

public class LoseWindow : Window
{
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnEnable()
    {
        _playerHealth.Died += Show;
    }

    private void OnDisable()
    {
        _playerHealth.Died -= Show;
    }

    protected override void Show()
    {
        base.Show();
        Time.timeScale = 0f;
    }
}
