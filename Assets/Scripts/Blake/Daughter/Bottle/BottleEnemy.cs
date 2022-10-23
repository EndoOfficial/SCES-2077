using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleEnemy : Enemy
{
    public GameObject pill;
    public float spawncount;

    private void OnEnable()
    {
        GameEvents.DamageEnemy += TakeDamage;
    }
    private void OnDisable()
    {
        GameEvents.DamageEnemy -= TakeDamage;
    }

    protected override void Die()
    {
        StartCoroutine(Explode());

    }
    private IEnumerator Explode()
    {
        if (spawncount < 10)
        {
            spawncount += 1;
            yield return new WaitForSeconds(0.1f);
            Instantiate(pill, new Vector3(transform.position.x, 3, transform.position.z), Quaternion.identity);
            StartCoroutine(Explode());
            if (spawncount >= 10)
            {
                base.Die();
            }
        }
    }
}
