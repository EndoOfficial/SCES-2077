using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject Paper;
    public float spawnTime = 1f;
    public Vector3 origin = Vector3.zero;
    public float radius = 5;
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        
    }

    void Spawn()
    {
        Vector3 randomPosition = origin + Random.insideUnitSphere * radius;
        Instantiate(Paper, randomPosition, Quaternion.identity);
    }

}
