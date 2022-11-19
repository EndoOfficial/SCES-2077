using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispSpawner : MonoBehaviour
{
    public GameObject wisp;

    public void startSpawn()
    {
        StartCoroutine(SpawnWisp());
    }

    public void stopSpawn()
    {
        StopCoroutine(SpawnWisp());
    }

    private IEnumerator SpawnWisp()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(.5f);
            var obj = Instantiate(wisp, transform.position, Quaternion.identity);
            obj.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
