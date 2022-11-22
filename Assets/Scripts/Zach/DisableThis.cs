using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableThis : MonoBehaviour
{
    private GameObject disablee;
    private void Start()
    {
        disablee = this.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        disablee.SetActive(false);
    }
}
