using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI rageText;
    private void OnEnable()
    {
        GameEvents.RageIncrease += UpdateRage;
    }
    private void OnDisable()
    {
        GameEvents.RageIncrease -= UpdateRage;
    }
    public void UpdateRage(float rage)
    {
        rageText.text = "Rage: " + rage.ToString();
    }
}
