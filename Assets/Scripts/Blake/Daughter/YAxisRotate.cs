using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YAxisRotate : MonoBehaviour
{
    public Transform target;
    public bool Randomise;
    public float Speed;
    public float WaitChange = 0;
    private float MinSpeed = 5;
    private float MaxSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spin());
    }

    private IEnumerator Spin()
    {
        if (Randomise)
        {
            Speed = Random.Range(MinSpeed, MaxSpeed);

            if (Speed >= 10f && Speed <= 15f)
            {
                WaitChange = 2f;

                MaxSpeed = 20;
                MinSpeed = 5;
            }
            else if (Speed > 15f)
            {
                WaitChange = 1.5f;

                MaxSpeed = 10;
                MinSpeed = 5;
            }
            else
            {
                WaitChange = 3f;

                MaxSpeed = 20;
                MinSpeed = 10;
            }
        }
        yield return new WaitForSeconds(WaitChange);
        StartCoroutine(Spin());
    }
    private void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, Speed * Time.deltaTime);
    }
}