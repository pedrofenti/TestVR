using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCanvasController : MonoBehaviour
{
    [Tooltip("Less or equal to 5")]
    [SerializeField] float timer;
    private string timeRemaining;

    [SerializeField] Text text;

    [SerializeField] string LevelName;
    [SerializeField] bool changeToLevel;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer > 4) timeRemaining = "5";
        else if (timer > 3) timeRemaining = "4";
        else if (timer > 2) timeRemaining = "3";
        else if (timer > 1) timeRemaining = "2";
        else if (timer > 0) timeRemaining = "1";
        else timeRemaining = "0";

        text.text = timeRemaining;

        if (timeRemaining == "0") 
            if (changeToLevel == false) Destroy(gameObject);
            else SceneManager.LoadScene(LevelName);
    }
}
