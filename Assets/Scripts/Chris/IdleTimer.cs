using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IdleTimer : MonoBehaviour
{
    public float minWaitTime = 0f;
    public float maxWaitTime = 0f;

    public float RandomWaitTime => Random.Range(minWaitTime, maxWaitTime);
}