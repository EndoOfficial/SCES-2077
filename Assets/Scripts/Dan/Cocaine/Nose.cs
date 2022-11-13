using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nose : MonoBehaviour
{
    public int Wait;
    private bool hit;
    public GameObject[] CocainePuffs;
    void Start()
    {
        CocainePuffs = GameObject.FindGameObjectsWithTag("CocainePuff");
    }
    private void OnEnable()
    {
        GameEvents.DamageEnemy += TakeDamage;
    }
    private void OnDisable()
    {
        GameEvents.DamageEnemy -= TakeDamage;
    }
    protected virtual void TakeDamage(int damage, GameObject target)
    {
        if (gameObject == target && hit == false)
        {
            hit = true;
            StartCoroutine(Delay());
        }
    }
    private IEnumerator Delay()
    {
        for (int i = 0; i < CocainePuffs.Length;)
        {
            CocainePuffs[i].tag = ("CocainePuff"); // Reset tag of current index
            CocainePuffs[i].GetComponent<Cocaine>().cokeParticle.Stop(); // stops particle system
            CocainePuffs[i].GetComponent<Cocaine>().particleActivated = false; // stops dealing damage
            i++; // counts up by one
        }
        yield return new WaitForSeconds(Wait);
        hit = false;
    }
}
