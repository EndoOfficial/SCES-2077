using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YAxisLookAtPlayer : MonoBehaviour
{
    private float angle;
    private GameObject Target;
    public Vector3 TargetPos;
    public Vector3 ThisPos;
    private void Start()
    {
        Target = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        TargetPos = Target.transform.position;
        ThisPos = transform.position;
        TargetPos.x = TargetPos.x - ThisPos.x;
        TargetPos.z = TargetPos.z - ThisPos.z;
        angle = Mathf.Atan2(TargetPos.x, TargetPos.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }
}
