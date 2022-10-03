using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paper"))
        {
            foreach (Transform child in other.transform)
            {
                child.parent = null;
            }
            Destroy(other.gameObject);
        }
    }
}