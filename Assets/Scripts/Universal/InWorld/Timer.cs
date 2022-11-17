using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public float StartTime;
    private bool Finished = false;

    public string minutes;
    public string seconds;

    private void Start()
    {
        StartTime = Time.time;
    }

    private void Update()
    {
        if (Finished)
            return;

        float t = Time.time - StartTime;

        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f2");

        TimerText.text = minutes + ":" + seconds;
    }

    public enum Levels
    {
        SyringeLevel,
    }
    public void Finnish()
    {
        Finished = true;
        TimerText.color = Color.red;
    }
}
