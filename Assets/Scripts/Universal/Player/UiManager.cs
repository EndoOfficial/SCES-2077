using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UiManager : MonoBehaviour
{
    public GameObject GameOverMenuUi;

    public Text currentXPText;
    public Text nextXPText;
    public Text currentLevelText;

    public GameObject Wave1TXT;
    public GameObject GameWinTXT;

    //public TextMeshProUGUI HealthText;
    private void OnEnable()
    {
        GameEvents.OnGameOver += OnGameOver;
        GameEvents.XPtoUI += XPtoUI;
        GameEvents.NewWave += Wave1;
        GameEvents.WaveWin += OnWaveWin;
    }
    private void OnDisable()
    {
        GameEvents.OnGameOver -= OnGameOver;
        GameEvents.XPtoUI += XPtoUI;
        GameEvents.NewWave -= Wave1;
        GameEvents.WaveWin -= OnWaveWin;
    }

    private void XPtoUI(int currentXP, int nextXP, int currentLevel)
    {
        currentXPText.text = currentXP.ToString();
        nextXPText.text = nextXP.ToString();
        currentLevelText.text = currentLevel.ToString();
    }

    public void OnGameOver(bool gameover)
    {
        //FindObjectOfType<AudioManager>().Play("GameOver");
        Cursor.lockState = CursorLockMode.None;
        GameOverMenuUi.SetActive(true);
        //GameObject slider = gameObject.transform.Find("Slider").gameObject;
        //Destroy(slider);
        
    }

    public void Wave1()
    {
        Wave1TXT.SetActive(true);
        StartCoroutine(WaveTxtDissapear());
        
        
    }

    IEnumerator WaveTxtDissapear()
    {
        yield return new WaitForSeconds(4);
        Wave1TXT.SetActive(false);
    }
    public void OnWaveWin()
    {
        GameWinTXT.SetActive(true);
        StartCoroutine(WinWaveDis());
    }

    IEnumerator WinWaveDis()
    {
        yield return new WaitForSeconds(4);
       GameWinTXT.SetActive(false);
    }
    //public void CurrentHealth(int health)
    //{
    //    HealthText.text = "PlayerHp: " + health.ToString();
    //}

}
