using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CokeCheck : MonoBehaviour
{
    public bool allPuffed;
    public int CocainePuffs;
    void Start()
    {
        CocainePuffs = GameObject.FindGameObjectsWithTag("CocainePuff").Length;
        StartCoroutine(Checker());
    }
    private IEnumerator Checker()
    {
        CocainePuffs = GameObject.FindGameObjectsWithTag("CocainePuff").Length;
        if (CocainePuffs == 0)
        {
            allPuffed = true;
        }
        if(CocainePuffs > 0)
        {
            allPuffed=false;
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Checker());
    }
}
