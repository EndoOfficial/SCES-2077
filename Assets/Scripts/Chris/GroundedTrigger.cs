using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedTrigger : MonoBehaviour
{
    bool grounded;
    private void OnTriggerStay(Collider other)
    {
        grounded = true;
        GameEvents.isGrounded?.Invoke(grounded);
    }

    private void OnTriggerExit(Collider other)
    {
        grounded = false;
        GameEvents.isGrounded?.Invoke(grounded);
    }
}
