using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillMove : MonoBehaviour
{
    public float speed;
    void Start()
    {
        transform.parent = null;
    }

    void Update()
    {
        // Moves forward
        //transform.Translate(transform.forward * speed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}