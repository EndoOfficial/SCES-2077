using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private MeshRenderer heartObj;

    private void OnEnable()
    {
        GameEvents.LevelWin += LevelWin;
    }

    private void OnDisable()
    {
        GameEvents.LevelWin -= LevelWin;

    }

    private void LevelWin()
    {
        heartObj.enabled = true; // enable the heart mesh
    }

    private void Start()
    {
        heartObj = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        transform.Rotate(0, 0.5f, 0); // makes the object rotate
    }
}
