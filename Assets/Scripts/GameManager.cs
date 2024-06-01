using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Health _player;

    private void OnEnable()
    {
        _wallet.AllCoinsCollected += Win;
        _player.Died += Lose;
    }

    public void Win()
    {
        _winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Lose()
    {
        _loseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        _wallet.AllCoinsCollected -= Win;
        _player.Died -= Lose;
    }
}
