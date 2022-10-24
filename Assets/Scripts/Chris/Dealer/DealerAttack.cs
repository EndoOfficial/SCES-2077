using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerAttack : MonoBehaviour
{
    public GameObject bigBill;
    public GameObject babyBill;
    public GameObject bigSpawn;
    public GameObject[] babySpawn;
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
        StartCoroutine(Delay());
    }

    public void Flurry()
    {
        for (int i = 0; i < babySpawn.Length; i++)
        {
            Instantiate(babyBill, babySpawn[i].transform);
        }
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(delay + Random.Range(-2, 2));
        if (Random.Range(0, 100) < chance)
        {
            anim.SetTrigger("Flurry");
}
        else
        {
            anim.SetTrigger("NormalAttack");
        }
    }
}
