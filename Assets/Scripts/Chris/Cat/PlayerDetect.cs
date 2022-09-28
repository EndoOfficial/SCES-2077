using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    bool range;
    public float distance;
    public LayerMask player;
    private void Update()
    {
        range = Physics.CheckSphere(gameObject.transform.position, distance, player);
        if (range)
        {
            GameEvents.DetectPlayer?.Invoke();
        }
    }
}
