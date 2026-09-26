using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverOverlay;
    [SerializeField] private GameObject controlsText;

    private void Awake()
    {
        gameOverOverlay.SetActive(false);
    }

    private void Update()
    {
        if (gameOverOverlay.activeSelf ||
            LivesManager.Instance == null ||
            !LivesManager.Instance.IsGameOver)
        {
            return;
        }

        gameOverOverlay.SetActive(true);

        if (controlsText != null)
            controlsText.SetActive(false);
    }
}
