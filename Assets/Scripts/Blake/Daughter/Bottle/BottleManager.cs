using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    public int DeadBottles;
    public GameObject[] Bottles;

    private void Start()
    {
        StartCoroutine(Checker());
    }
    private IEnumerator Checker()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < Bottles.Length; i++)
        {
            if (Bottles[i] == null)
            {
                DeadBottles ++ ;
                if (DeadBottles == Bottles.Length)
                {
                    StopCoroutine(Checker());
                    GameEvents.BottleDeath?.Invoke();
                }
            }
            if (i == Bottles.Length)
            {
                DeadBottles = 0;
                i = 0;
            }
        }
    }
}