//  [小鈎ハレ]  //
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float countdownTime = 60f;   // total time in seconds
    public Text timerText;

    private float currentTime;
    private bool timerActive = false;

    void Start()
    {
        currentTime = countdownTime;
        timerActive = true;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!timerActive || GameManager.instance == null) return;

        if (currentTime > 0f)
        {
            // Decrease time but clamp so it never goes negative
            currentTime = Mathf.Max(0f, currentTime - Time.deltaTime);
            UpdateTimerDisplay();

            // If we just hit 0 this frame, trigger game over
            if (currentTime <= 0f)
            {
                timerActive = false;
                GameManager.instance.LoseGame();
            }
        }
    }

    private void UpdateTimerDisplay()
    {
        float displayTime = Mathf.Max(0f, currentTime);  // double safety clamp

        int minutes = Mathf.FloorToInt(displayTime / 60f);
        int seconds = Mathf.FloorToInt(displayTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
