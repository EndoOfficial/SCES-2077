using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillMove : MonoBehaviour
{
    public float speed;

    void Update()
    {
        // Moves forward
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}