using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunts : MonoBehaviour
{
    private GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
         var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

}
