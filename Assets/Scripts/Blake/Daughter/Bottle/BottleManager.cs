using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    private bool StartCheck;
    public int integer;
    public int DeadBottles;
    public GameObject[] Bottles;


    private void OnEnable()
    {
        GameEvents.BottleCount += Check;
    }
    private void OnDisable()
    {
        GameEvents.BottleCount -= Check;
    }
    private void Check()
    {
        StartCoroutine(Checker());
    }
    private IEnumerator Checker()
    {
        for (int i = 0; i < Bottles.Length;)
        {
            if (Bottles[i] == null)
            {
                DeadBottles++;
                if (DeadBottles == Bottles.Length)
                {
                    GameEvents.BottleDeath?.Invoke();
                }
            }
            i++;
            integer = i;
            if (i >= Bottles.Length)
            {
                StartCheck = false;
                DeadBottles = 0;
            }
            yield return null;
        }
    }
}