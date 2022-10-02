using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlatformSpawner : MonoBehaviour
{
    public GameObject Paper;
    public float spawnTime = 1f;
    private Vector3 origin;
    public float radius = 5;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        origin = transform.position;
    }

    void Spawn()
    {
        Vector3 randomPosition = origin + Random.insideUnitSphere * radius;
        randomPosition.y = origin.y + Random.Range(-1,1);
        randomPosition.z = origin.z;
        Instantiate(Paper, randomPosition, Quaternion.identity);
    }

}
