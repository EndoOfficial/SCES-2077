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
            GameEvents.DamagePlayer?.Invoke(damage);
            hit = true;
        }
        else
        {
            hit = false;
        }
    }
}
