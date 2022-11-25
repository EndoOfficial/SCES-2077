using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "xp", menuName = "PlayerXP")]
public class xpData : ScriptableObject
{
    private int currentXP;
    private int nextXP;
    private int currentLevel;
    private void OnEnable()
    {
        GameEvents.GetXP += GetXP;
    }
    private void OnDisable()
    {
        GameEvents.GetXP -= GetXP;

    }

    private void GetXP(int xpPoints)
    {
        currentXP += xpPoints;
        GameEvents.XPtoUI?.Invoke(currentXP, nextXP, currentLevel);
    }
}
