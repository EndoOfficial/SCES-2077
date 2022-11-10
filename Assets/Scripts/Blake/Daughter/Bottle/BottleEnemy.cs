using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleEnemy : Enemy
{
    public GameObject[] pill;
    private int Pillnum;
    public float spawnlimit;
    private float spawncount;
    private float randomizer;
    private float range = 1;
    private void Explosion()
    {
        StartCoroutine(Explode());
    }
    private IEnumerator Explode()
    {
        if (spawncount < spawnlimit)
        {
            randomizer = Random.Range(-range, range);
            spawncount += 1;
            Pillnum = Random.Range(0, pill.Length);
            Instantiate(pill[Pillnum], new Vector3(transform.position.x + randomizer, 3 + randomizer, transform.position.z + randomizer), Quaternion.identity);
            if (spawncount >= spawnlimit)
            {
                Destroy(gameObject);
            }
            StartCoroutine(Explode());
            yield return null;
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }
}
