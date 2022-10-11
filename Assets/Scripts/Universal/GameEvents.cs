using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void isGroundedDelegate(bool grounded); // checks to see if the fish is touching the ground
    public static isGroundedDelegate isGrounded;

    public delegate void DetectPlayerDelegate(bool detected);// Detects the Player
    public static DetectPlayerDelegate DetectPlayer;

    public delegate void PlayerDamageDelegate(int damage); // Damages the Player
    public static PlayerDamageDelegate DamagePlayer;

    public delegate void PlayerEnemyDelegate(int damage, GameObject target); // Damages the Enemy
    public static PlayerEnemyDelegate DamageEnemy;

    public delegate void RageIncreaseDelegate(float rage);
    public static RageIncreaseDelegate RageIncrease;

    public delegate void BillDeathDelegate(GameObject bill, GameObject spawner);
    public static BillDeathDelegate BillDeath;

    public static Action PlayerDeath; // Player Dies

    public static Action Nicotine;

    public static Action AOE; // Fish AOE

    public delegate void OnHealthChangedDelegate(int newHealth, int maxHealth);
    public static OnHealthChangedDelegate OnHealthChanged;
    

}