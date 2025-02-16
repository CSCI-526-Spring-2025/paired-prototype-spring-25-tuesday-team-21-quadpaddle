using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;  
    public TextMeshProUGUI timeText; 
    public GameObject obstacleSpawner; 
    public void ShowGameOver()
    {
        if (obstacleSpawner != null) obstacleSpawner.SetActive(false);
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }

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