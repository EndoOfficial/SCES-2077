using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillMove : MonoBehaviour
{
    public float speed;
    public bool isDead = false;

    void Update()
    {
        if (!isDead)
        {
            transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        }
    }
}