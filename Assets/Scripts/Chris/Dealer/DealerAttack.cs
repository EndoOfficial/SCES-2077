using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerAttack : MonoBehaviour
{
    public GameObject bigBill;
    public GameObject babyBill;
    public GameObject bigSpawn;
    public GameObject[] babySpawn;

    private void Start()
    {
        StartCoroutine(Delay());
    }

    public void Attack()
    {
        Instantiate(bigBill, bigSpawn.transform);
    }

    public void Flurry()
    {

    }

    private IEnumerator Delay()
    {
        yield return null;
    }
}
