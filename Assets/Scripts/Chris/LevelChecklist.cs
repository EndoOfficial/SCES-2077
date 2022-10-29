using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChecklist : ScriptableObject
{
    private void OnEnable()
    {
        GameEvents.LevelWin += LevelWin;
    }

    private void OnDisable()
    {
        GameEvents.LevelWin -= LevelWin;
    }

    private void LevelWin(string level)
    {
        
    }
}
