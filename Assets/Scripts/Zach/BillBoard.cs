using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform camTransform; //Camera's position

    void Update()
    {
        transform.rotation = camTransform.rotation; // faces towards that position
    }
}

