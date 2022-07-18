using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvasController : MonoBehaviour
{
    private float timer = 3;
    private string timeRemaining;

    [SerializeField] Text text;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer > 2) timeRemaining = "3";
        else if (timer > 1) timeRemaining = "2";
        else if (timer > 0) timeRemaining = "1";
        else timeRemaining = "0";

        text.text = timeRemaining;
    }
}
