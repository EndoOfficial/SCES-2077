using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    public bool _aoe;
    public float radius;
    public LayerMask Player;
    public int damage;

    public void aoe()
    {
        // checks to see if the player is close enough to damage
        _aoe = Physics.CheckSphere(transform.position, radius, Player);
        if (_aoe)
        {
            GameEvents.DamagePlayer?.Invoke(damage);
        }
    }
}