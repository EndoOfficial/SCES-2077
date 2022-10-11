using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBill : MonoBehaviour
{
    private float moveDistance = 4f;
    private float moveTime = 0.5f;

    public void SetParentPos(Vector3 parentPos)
    {
        var moveDirection = (transform.position - parentPos).normalized;
        var moveTarget = transform.position + (moveDirection * moveDistance);
        LeanTween.move(gameObject, moveTarget, moveTime);
    }
}
