using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowWobble : MonoBehaviour
{
    public float frequency;
    public float amplitude;
    private Vector3 pos;
    // Update is called once per frame
    void Start()
    {
        gameObject.transform.position = new Vector3(transform.position.x + LeanTween.easeOutCubic(-20, 20, 2), transform.position.y, transform.position.z);
    }
}
