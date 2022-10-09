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
    public static PlayerDanageDelegate PlayerDamage;

    public delegate void RageIncreaseDelegate(float rage);
    public static RageIncreaseDelegate RageIncrease;

    public delegate void HealthDelegate(float health);
    public static HealthDelegate Health;

    public static Action PlayerDeath;

    public static Action Nicotine;

    public static Action AOE;
}