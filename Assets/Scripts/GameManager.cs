using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.AllCoinsCollected += Win;
    }

    private void OnDisable()
    {
        _wallet.AllCoinsCollected -= Win;
    }

    public void Win()
    {
        _winScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
