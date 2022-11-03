using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCycle : MonoBehaviour
{
    public GameObject[] TextToCycle;
    private int Cycle;
    public float CycleDelay;
    void Start()
    {
        Cycle = TextToCycle.Length - 1;
        StartCoroutine(StartCycle());
    }
    private IEnumerator StartCycle()
    {
        for (int i = 0; i < Cycle;)
        {
            yield return new WaitForSeconds(CycleDelay);
            TextToCycle[i].SetActive(false);
            i++;
            TextToCycle[i].SetActive(true);

            if (i >= Cycle)
            {
                yield return new WaitForSeconds(CycleDelay);
                TextToCycle[i].SetActive(false);
                i = 0;
                TextToCycle[i].SetActive(true);
            }
        }
    }
}
