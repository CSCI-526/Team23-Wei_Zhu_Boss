using TMPro;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public static LivesManager Instance { get; private set; }

    [SerializeField, Min(1)] private int startingLives = 5;
    [SerializeField] private TMP_Text livesText;

    public int CurrentLives { get; private set; }
    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        Instance = this;
        CurrentLives = startingLives;
        UpdateLivesUI();
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public void LoseLife()
    {
        if (IsGameOver)
            return;

        CurrentLives = Mathf.Max(0, CurrentLives - 1);
        UpdateLivesUI();

        if (CurrentLives == 0)
            EndGame();
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = $"Lives: {CurrentLives}";
    }

    private void EndGame()
    {
        IsGameOver = true;
        Debug.Log("Game Over! No lives remaining.");
        Time.timeScale = 0f;
    }
}
