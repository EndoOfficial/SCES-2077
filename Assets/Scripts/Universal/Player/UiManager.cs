using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI rageText;
    public GameObject GameOverMenuUi;
    //public TextMeshProUGUI HealthText;

    private void OnEnable()
    {
        GameEvents.RageIncrease += UpdateRage;
        GameEvents.OnGameOver += OnGameOver;
        //GameEvents.CurrentHealth += CurrentHealth;
    }
    private void OnDisable()
    {
        GameEvents.RageIncrease -= UpdateRage;
        GameEvents.OnGameOver -= OnGameOver;
        //GameEvents.CurrentHealth -= CurrentHealth;
    }
    public void UpdateRage(float rage)
    {
        rageText.text = "Rage: " + rage.ToString();
    }
    public void OnGameOver(bool gameover)
    {
        GameOverMenuUi.SetActive(true);
    }
    //public void CurrentHealth(int health)
    //{
    //    HealthText.text = "PlayerHp: " + health.ToString();
    //}

}
