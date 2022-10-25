using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleEnemy : Enemy
{
    public GameObject pill;
    public float spawnlimit;
    private float spawncount;
    private float randomizer;
    public float range;
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
            Instantiate(pill, new Vector3(transform.position.x + randomizer, 3 + randomizer, transform.position.z + randomizer), Quaternion.identity);
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
