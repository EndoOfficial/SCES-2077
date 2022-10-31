using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTimer : MonoBehaviour
{
    public int time;
    public int interval;
    public int changeTime;

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
        while (true)
        {
            yield return new WaitForSecondsRealtime(interval);
            time++;
        }
    }
}
