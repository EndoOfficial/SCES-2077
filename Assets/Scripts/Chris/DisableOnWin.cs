using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnLose : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnGameOver += onGameOver;
    }
    private void OnDisable()
    {
        GameEvents.OnGameOver += onGameOver;
    }

    private void onGameOver(bool temp)
    {
        gameObject.SetActive(false);
    }
}
