using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPills : MonoBehaviour
{
    public Transform player;
    public GameObject PillToSpawn;
    public float SpawnDelay;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    public void StartSpawn()
    {
        Instantiate(PillToSpawn, new Vector3(transform.position.x, 3, transform.position.z), Quaternion.identity);
    }
}
