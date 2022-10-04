using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paper"))
        {
            var child = other.transform.Find("Player");
            Destroy(other.gameObject);
        }
    }
}