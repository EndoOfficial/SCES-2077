using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWind : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectToRotate;

    // Update is called once per frame
    void Update()
    {
        objectToRotate.transform.Rotate(0f, 0.0f, 20f, Space.Self);
    }
}
