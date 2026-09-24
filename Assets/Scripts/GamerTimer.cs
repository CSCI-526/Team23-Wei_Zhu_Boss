using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float gameDuration = 60f;
    public TMP_Text timerText;

    private float timeRemaining;
    private bool gameEnded = false;

    void Start()
    {
        timeRemaining = gameDuration;
        UpdateTimerUI();
    }

    void Update()
    {
        if (gameEnded)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            EndGame();
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        timerText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }

    void EndGame()
    {
        gameEnded = true;

        Debug.Log("Game Over!");

        // 暂停整个游戏
        Time.timeScale = 0f;
    }
}