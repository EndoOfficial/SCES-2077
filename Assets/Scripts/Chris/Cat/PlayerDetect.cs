using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    bool range;
    public float distance;
    public GameObject player;
    private void Start()
    {
        StartCoroutine(Repeat());
    }

    private IEnumerator Repeat()
    {
        while (true)
        {
            range = Vector3.Distance(transform.position, player.transform.position) < distance; // checks if player is within distance
            if (range)
            {
                GameEvents.DetectPlayer?.Invoke(range);
            }
            if (!range)
            {
                GameEvents.DetectPlayer?.Invoke(range);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
