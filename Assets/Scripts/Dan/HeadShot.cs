using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HeadShot : MonoBehaviour
{
    public WeakPoints LeftKnee;
    public WeakPoints RightKnee;
    public WeakPoints Head;
    public bool left;
    public bool right;
    public bool head;

    private void Start()
    {
        LeftKnee = LeftKnee.GetComponent<WeakPoints>();
        RightKnee = RightKnee.GetComponent<WeakPoints>();
        Head = Head.GetComponent<WeakPoints>();
        left = false;
        right = false;
        head = false;
    }
    public void Update()
    {
        if (LeftKnee.leftShot == true)
        {
            left = true;
            StartCoroutine(Left());
        }

        if (RightKnee.rightShot == true)
        {
            right = true;
            StartCoroutine(Right());
        }

        if (left == true && right == true)
        {
            HeadShotOpen();
        }

        if (head && Head.headShot == true)
        {
            Murked();
        }
    }
    public void HeadShotOpen()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        left = false;
        right = false;
        StopAllCoroutines();
        head = true;
        StartCoroutine(GetUp());

    }
    private IEnumerator GetUp()
    {
        yield return new WaitForSeconds(10f);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        head = false;
        LeftKnee.Recover();
        RightKnee.Recover();
    }

    private IEnumerator Left()
    {
        LeftKnee.leftShot = false;
        yield return new WaitForSeconds(5f);
        left = false;
        LeftKnee.Recover();
    }

    private IEnumerator Right()
    {
        RightKnee.rightShot = false;
        yield return new WaitForSeconds(5f);
        right = false;
        RightKnee.Recover();
    }

    public void Murked()
    {
        Destroy(gameObject);
    }
}