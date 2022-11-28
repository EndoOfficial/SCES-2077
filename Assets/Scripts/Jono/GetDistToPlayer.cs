using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDistToPlayer : MonoBehaviour
{
    public GameObject Player;
    public float PlayerDist;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDist = Vector3.Distance(transform.position, Player.transform.position);        
    }
}
