using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatTimer : MonoBehaviour
{
    public bool TimesUp = false;
    public void Timer()
    {
        TimesUp = false;
        StartCoroutine(RetreatTime());
        Debug.Log("StartTimer");
    }
    private IEnumerator RetreatTime()
    {
        if (!TimesUp)
        {
            yield return new WaitForSeconds(1f);
            TimesUp = true;
            Debug.Log("StopTimer");
        }
    }
}
