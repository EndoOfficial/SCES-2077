using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWheat : MonoBehaviour
{
    public Vector3 closestWheatPatch;
    public bool inWheat;

    public void FindWheat()
    {
        StartCoroutine(Repeat());
    }

    private IEnumerator Repeat()
    {
        while (true)
        {
            float dist = float.PositiveInfinity;
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Wheat");

            foreach (var obj in taggedObjects)
            {
                var d = (transform.position - obj.transform.position).sqrMagnitude;
                if (d < dist)
                {
                    closestWheatPatch = obj.transform.position;
                    dist = d;
                }
            }
            if(taggedObjects.Length == 0)
            {
                closestWheatPatch = GameObject.FindGameObjectWithTag("Player").transform.position;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
