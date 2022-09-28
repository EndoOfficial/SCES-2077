using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void isGroundedDelegate(bool grounded);
    public static isGroundedDelegate isGrounded;

    public static Action AOE;
    public static Action DetectPlayer;
}
