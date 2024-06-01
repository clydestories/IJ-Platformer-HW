using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.AllCoinsCollected += Win;
    }

    private void OnDisable()
    {
        _wallet.AllCoinsCollected -= Win;
    }

    private void Win()
    {
        _winScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
