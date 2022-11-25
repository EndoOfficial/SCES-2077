using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public Camera MainCamera;
    public Camera OptionsCamera;
    public Camera CreditCamera;
    public GameObject MainCanvas;
    public GameObject OptionsCanvas;
    public GameObject CreditCanvas;
    public void Start()
    {
        MainCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
        CreditCanvas.SetActive(false);
        MainCamera.enabled = true;
        OptionsCamera.enabled = false;
        CreditCamera.enabled = false;
    }
    public void SwaptoOptions()
        {

            MainCamera.enabled = false;
            OptionsCamera.enabled = true;
            CreditCamera.enabled = false;
            MainCanvas.SetActive(false);
            OptionsCanvas.SetActive(true);
            CreditCanvas.SetActive(false);

    }
        public void SwaptoMain()
        {

        MainCamera.enabled = true;
        OptionsCamera.enabled = false;
        CreditCamera.enabled = false;
        MainCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
        CreditCanvas.SetActive(false);
    }
        public void SwaptoCredits()
        {

        MainCamera.enabled = false;
        OptionsCamera.enabled = false;
        CreditCamera.enabled = true;
        MainCanvas.SetActive(false);
        OptionsCanvas.SetActive(false);
        CreditCanvas.SetActive(true);
    }



}
