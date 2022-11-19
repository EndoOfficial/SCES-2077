using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public GameObject GameOverMenuUi;
    //public TextMeshProUGUI HealthText;
    private void OnEnable()
    {

        GameEvents.OnGameOver += OnGameOver;
    }
    private void OnDisable()
    {

        GameEvents.OnGameOver -= OnGameOver;
    }

    public void OnGameOver(bool gameover)
    {
        //FindObjectOfType<AudioManager>().Play("GameOver");
        Cursor.lockState = CursorLockMode.None;
        GameOverMenuUi.SetActive(true);
        //GameObject slider = gameObject.transform.Find("Slider").gameObject;
        //Destroy(slider);
        
    }
    //public void CurrentHealth(int health)
    //{
    //    HealthText.text = "PlayerHp: " + health.ToString();
    //}

}
