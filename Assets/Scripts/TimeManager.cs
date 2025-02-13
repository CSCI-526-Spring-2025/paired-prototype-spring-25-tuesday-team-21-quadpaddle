using UnityEngine;
using TMPro;  // For TextMeshPro

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // Drag TimerText from the UI
    private float elapsedTime = 0f;
    private bool isGameOver = false;
    private string finalTime;

    void Update()
    {
        if (!isGameOver)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        finalTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = finalTime;
    }

    public string GetFinalTime()
    {
        return finalTime;
    }

    public void StopTimer()
    {
        isGameOver = true;  // Stops the timer when game over
    }
}