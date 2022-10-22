using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BillEnemy : Enemy
{
    public BabyBill baby;
    public GameObject[] spawners;
    public List<GameObject> temp;

    protected override void Die()
    {
        for(int i = 0; i < spawners.Length; i++)
        {
            //instantiate baby Bills on all the spawn Points
           BabyBill babyBill = Instantiate(baby, spawners[i].transform.position, Quaternion.identity);
           babyBill.SetParentPos(transform.position);
        }
        base.Die();
    }
}