using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] Text timeText;
    [Tooltip("timeRemaining are in Seconds. So 600 seconds are 10 minutes")]
    public float timeRemaining = 600;
    private bool timerIsRunning = false;

    [Header("Game Over Canvas")]
    [SerializeField] GameObject GameOverCanvas;

    private void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        else
        {
            StartCoroutine(GameIsOver());
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator GameIsOver()
    {
        GameOverCanvas.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("PointsScene");
    }
}
