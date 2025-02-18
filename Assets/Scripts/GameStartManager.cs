using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenuPanel; 
    public GameObject ball;
    public GameObject obstacleSpawner; 

    void Start()
    {
        Time.timeScale = 0;
        startMenuPanel.SetActive(true);

        if (ball != null) ball.SetActive(false);
        if (obstacleSpawner != null) obstacleSpawner.SetActive(false);
    }

    public void StartGame()
    {
        startMenuPanel.SetActive(false); 
        Time.timeScale = 1; 

        if (ball != null) ball.SetActive(true);
        if (obstacleSpawner != null) obstacleSpawner.SetActive(true);
    }
}