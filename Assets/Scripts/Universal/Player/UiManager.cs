using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI rageText;
    public TextMeshProUGUI healthText;
    private void OnEnable()
    {
        GameEvents.RageIncrease += UpdateRage;
        GameEvents.Health += UpdateHealth;
    }
    private void OnDisable()
    {
        GameEvents.RageIncrease -= UpdateRage;
        GameEvents.Health -= UpdateHealth;
    }
    public void UpdateRage(float rage)
    {
        rageText.text = "Rage: " + rage.ToString();
    }
    public void UpdateHealth(float health)
    {
        healthText.text = "PlayerHp: " + health;
    }
}
