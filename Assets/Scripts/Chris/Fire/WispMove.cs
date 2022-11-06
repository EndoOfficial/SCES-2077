using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WispMove : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    public int interval;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        agent.speed = 8;
        StartCoroutine(repeat());
    }

    private IEnumerator repeat()
    {
        while (true)
        {
            agent.destination = player.transform.position;
            yield return new WaitForSecondsRealtime(interval);
        }
    }
}
