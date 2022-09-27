using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
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
        
    }
}
