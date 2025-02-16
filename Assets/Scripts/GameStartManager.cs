using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenuPanel; 
    public GameObject ball;
    public GameObject obstacleSpawner; 

    void Start()
    {
        Time.timeScale = 0; // Pause the game initially
        startMenuPanel.SetActive(true); // Show start modal

        // Hide ball and obstacles at the start
        if (ball != null) ball.SetActive(false);
        if (obstacleSpawner != null) obstacleSpawner.SetActive(false);
    }

    public void StartGame()
    {
        startMenuPanel.SetActive(false); // Hide modal
        Time.timeScale = 1; // Resume game

        // Show ball and obstacles when the game starts
        if (ball != null) ball.SetActive(true);
        if (obstacleSpawner != null) obstacleSpawner.SetActive(true);
    }
}