using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;  
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
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float GetFinalTime()
    {
        return elapsedTime;
    }

    public void StopTimer()
    {
        isGameOver = true; 
    }
}