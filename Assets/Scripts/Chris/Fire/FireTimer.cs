using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTimer : MonoBehaviour
{
    public int time;
    public int interval;
    public int changeTime;
    public bool timeDone;

    public void StartTimer()
    {
        time = 0;
        StartCoroutine(Timer());
    }

    public void StopTimer()
    {
        StopCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (time <= changeTime)
        {
            yield return new WaitForSecondsRealtime(interval);
            time++;
        }
        timeDone = true;
    }
}
