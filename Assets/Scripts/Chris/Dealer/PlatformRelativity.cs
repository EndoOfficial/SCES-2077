using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRelativity : MonoBehaviour
{
    private GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        target = other.gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        if (target.CompareTag("Player"))
        {
            target.transform.parent = transform;
        }
    }
}
