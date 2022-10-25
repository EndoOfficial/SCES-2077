using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YAxisLookAtPlayer : MonoBehaviour
{
    private Transform player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        //Quaternion lookRotation = Quaternion.LookRotation(new Vector3(player.position.x, 0, player.position.z) - new Vector3(transform.position.x, 0, transform.position.z));
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, TurnSpeed * Time.deltaTime);
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }
}
