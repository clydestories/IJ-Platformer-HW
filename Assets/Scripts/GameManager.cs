using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.AllCoinsCollected.AddListener(Win);
    }

    public void Win()
    {
        _winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        _wallet.AllCoinsCollected.RemoveListener(Win);
    }
}
