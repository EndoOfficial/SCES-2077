using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public LayerMask Player;
    public float radius;
    public int damage;

    public bool hit;
    void Update()
    {
        if (Physics.CheckSphere(transform.position, radius, Player))
        {
            if (!hit)
            {
                hit = true;
                GameEvents.DamagePlayer?.Invoke(damage);
            }
        }
        else
        {
            hit = false;
        }
    }
}
