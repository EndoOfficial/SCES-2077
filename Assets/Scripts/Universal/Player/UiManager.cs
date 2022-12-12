using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UiManager : MonoBehaviour
{
    public GameObject GameOverMenuUi;

    public GameObject Wave1TXT;
    public GameObject GameWinTXT;

    //public TextMeshProUGUI HealthText;
    private void OnEnable()
    {
        GameEvents.OnGameOver += OnGameOver;
        GameEvents.NewWave += Wave1;
        GameEvents.WaveWin += OnWaveWin;
    }
    private void OnDisable()
    {
        GameEvents.OnGameOver -= OnGameOver;
        GameEvents.NewWave -= Wave1;
        GameEvents.WaveWin -= OnWaveWin;
    }

    public void OnGameOver(bool gameover)
    {
        //FindObjectOfType<AudioManager>().Play("GameOver");
        
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
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
