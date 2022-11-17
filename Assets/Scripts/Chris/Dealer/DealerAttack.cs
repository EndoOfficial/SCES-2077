using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerAttack : MonoBehaviour
{
    public GameObject bigBill;
    public GameObject babyBill;
    public GameObject bigSpawn;
    public GameObject[] babySpawn;
    public GameObject[] deathSpawn;
    private Animator anim;
    public int chance;
    public float delay;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Delay());
    }

    public void Attack()
    {
        Instantiate(bigBill, bigSpawn.transform.position, bigSpawn.transform.rotation);
        anim.ResetTrigger("NormalAttack");
        StartCoroutine(Delay());
    }

    public void Flurry()
    {
        for (int i = 0; i < babySpawn.Length; i++)
        {
            Instantiate(babyBill, babySpawn[i].transform);
        }
        anim.ResetTrigger("Flurry");
        StartCoroutine(Delay());
    }

    public void Death()
    {
        for (int i = 0; i < deathSpawn.Length; i++)
        {
            Instantiate(babyBill, deathSpawn[i].transform);
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(delay + Random.Range(0, 2));
        float rand = Random.Range(0, 100);
        if (rand <= chance)
        {
            anim.SetTrigger("Flurry");
        }
        else if (rand > chance)
        {
            anim.SetTrigger("NormalAttack");
        }
    }
}
