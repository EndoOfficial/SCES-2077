using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    public int KillWait;
    private int DeadBottles;
    private GameObject[] Bottles;
    public int BottleLength;
    // array of the bottles

    private void Start()
    {
        Bottles = GameObject.FindGameObjectsWithTag("Enemy"); // forms array
        BottleLength = Bottles.Length; // forms array
        // since the bottles are the only thing starting in
        // the scene with the enemy tag I deemed this as fine
    }

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
        DeadBottles++;
        if (DeadBottles == BottleLength)
        {
            yield return new WaitForSeconds(KillWait);
            GameEvents.BottleDeath?.Invoke();
        }

        //for (int i = 0; i < Bottles.Length;)
        //{
        //    if (Bottles[i] == null) // checks if any of the array are null
        //    {
        //        DeadBottles ++;
        //        if (DeadBottles == Bottles.Length) // if all are null
        //        {
        //            yield return new WaitForSeconds(KillWait);
        //            GameEvents.BottleDeath?.Invoke(); // plays all pill's death animations
        //        }
        //    }
        //    // the -1 is because this is checked before i is increased this 
        //    // is becuase if it is checked after, the loop won't run again
        //    if (i == Bottles.Length - 1)
        //    {
        //        DeadBottles = 0; // resets dead bottle count to accurately keep track
        //    }
        //    // i is increased after everything because otherwise it won't
        //    // check the first item in the array if done first
        //    i++;
        //    yield return new WaitForSeconds(.25f);
        //}
    }
}

