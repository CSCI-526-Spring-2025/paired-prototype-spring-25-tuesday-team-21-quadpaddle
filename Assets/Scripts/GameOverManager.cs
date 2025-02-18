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
        TimerManager timerManager = FindObjectOfType<TimerManager>();
        if (timerManager != null)
        {
            float finalTime = timerManager.GetFinalTime();
            int score = Mathf.RoundToInt(finalTime * 100 / 100f) * 100;
            timeText.text = "Score: " + score.ToString();
        }


        Time.timeScale = 0; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1; 
        gameOverPanel.SetActive(false); 
        Debug.Log("Restarting Game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}