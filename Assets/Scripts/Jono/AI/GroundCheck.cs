using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool Grounded;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            Grounded = true;            
        }
    }

    void OnTriggerExit(Collider target)
    {
        if (target.tag == "Ground")
        {
            Grounded = false;
        }
    }
}
