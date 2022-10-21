using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void DetectPlayerDelegate(bool detect);
    public static DetectPlayerDelegate DetectPlayer;// Detects the Player

    public delegate void PlayerDamageDelegate(int damage); 
    public static PlayerDamageDelegate DamagePlayer;// Damages the Player

    public delegate void PlayerEnemyDelegate(int damage, GameObject target); // Damages the Enemy
    public static PlayerEnemyDelegate DamageEnemy;

    public delegate void RageIncreaseDelegate(float rage);
    public static RageIncreaseDelegate RageIncrease;

    public delegate void CurrentHealthDelegate(int health);
    public static CurrentHealthDelegate CurrentHealth; // [REMOVE UNUSED]

    public delegate void BillDeathDelegate(GameObject bill, GameObject spawner);
    public static BillDeathDelegate BillDeath; // when the Big Bills die

    public static Action PlayerDeath; // Player Dies

    public static Action Nicotine;

    public static Action AOE; // Fish AOE

    public static Action LevelWin; // when the Level is won
    public delegate void OnPauseGameDelegate(bool paused);
    public static OnPauseGameDelegate OnPauseGame;
    public delegate void OnGameOverDelegate(bool gameover);
    public static OnGameOverDelegate OnGameOver;

}