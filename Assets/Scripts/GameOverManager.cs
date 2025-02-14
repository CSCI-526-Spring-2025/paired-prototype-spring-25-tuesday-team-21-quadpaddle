using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;  // Drag `GameOverModal` here
    public TextMeshProUGUI timeText;  // Drag `TimeText` from UI here

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        // Fetch the final time from TimerManager
        TimerManager timerManager = FindObjectOfType<TimerManager>();
        if (timerManager != null)
        {
            timeText.text = "Time Taken: " + timerManager.GetFinalTime();
        }

        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume game speed
        gameOverPanel.SetActive(false); // Hide the Game Over modal
        Debug.Log("Restarting Game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the scene
    }
}