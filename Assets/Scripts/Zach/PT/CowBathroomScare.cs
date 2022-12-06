using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBathroomScare : MonoBehaviour
{
    public Transform endPoint;
    private float scareTime = 1;
    public GameObject Cow;

    private void OnTriggerEnter(Collider other)
    {
        LeanTween.move(Cow, endPoint, scareTime)
            .setEaseInOutQuart();
        //play audio
        //slam door
    }

}
