using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoints : MonoBehaviour
{
    public bool leftShot;
    public bool rightShot;
    public bool headShot;
    public HeadShot Head;
    private void Start()
    {
        Head = Head.GetComponent<HeadShot>();
    }

    public void Shot()
    {
        if (CompareTag("LeftKnee"))
        {
            Head.left = true;
            gameObject.SetActive(false);
        }

        if (CompareTag("RightKnee"))
        {
            Head.right = true;
            gameObject.SetActive(false);
        }

        if  (Head.head && CompareTag("Head"))
        {
            headShot = true;
        }

    }
    public void Recover()
    {
        gameObject.SetActive(true);
    }
}