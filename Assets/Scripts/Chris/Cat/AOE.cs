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

    private void OnEnable()
    {
        GameEvents.AOE += aoe;
    }
    private void OnDisable()
    {
        GameEvents.AOE -= aoe;
    }

    private void aoe()
    {
        _aoe = Physics.CheckSphere(transform.position, radius, Player);
        if (_aoe)
        {
            GameEvents.PlayerDanage?.Invoke(damage);
        }
    }
}