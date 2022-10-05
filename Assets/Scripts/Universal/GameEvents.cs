using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void isGroundedDelegate(bool grounded);
    public static isGroundedDelegate isGrounded;

    public delegate void DetectPlayerDelegate(bool detected);
    public static DetectPlayerDelegate DetectPlayer;

    public delegate void PlayerDanageDelegate(int damage);
    public static PlayerDanageDelegate PlayerDanage;

    public static Action AOE;
}