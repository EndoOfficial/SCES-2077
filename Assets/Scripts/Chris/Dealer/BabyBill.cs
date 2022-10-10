using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBill : MonoBehaviour
{
    private float moveDistance = 2f;

    public void SetParentPos(Vector3 pos)
    {
        var moveDirection = (transform.position - pos).normalized;
        var moveTarget = transform.position + (moveDirection * moveDistance);
        LeanTween.move(gameObject, moveTarget, 1f);
    }
}
