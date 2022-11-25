using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    int i = 2;
    public Camera MainCamera1;
    public Camera MainCamera2;
    public Camera MainCamera3;
    public Camera MainCamera4;

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
        RandomArea();
        OptionsCamera.enabled = false;
        CreditCamera.enabled = false;
    }
    public void SwaptoOptions()
        {

            OptionsCamera.enabled = true;
            CreditCamera.enabled = false;
            TurnOffAreas();
            OptionsCanvas.SetActive(true);
            CreditCanvas.SetActive(false);

    }
        public void SwaptoMain()
        {

        RandomArea();
        OptionsCamera.enabled = false;
        CreditCamera.enabled = false;
        MainCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
        CreditCanvas.SetActive(false);
    }
        public void SwaptoCredits()
        {

        TurnOffAreas();
        OptionsCamera.enabled = false;
        CreditCamera.enabled = true;
        TurnOffAreas();
        OptionsCanvas.SetActive(false);
        CreditCanvas.SetActive(true);
    }


    public void RandomArea()
    {
        i = Random.Range(1, 5);
        Debug.Log(i);
        if (i == 1)
        {
            MainCamera1.enabled = true;
            MainCamera2.enabled = false;
            MainCamera3.enabled = false;
            MainCamera4.enabled = false;
        }
        if (i == 2)
        {
            MainCamera1.enabled = false;
            MainCamera2.enabled = true;
            MainCamera3.enabled = false;
            MainCamera4.enabled = false;
        }
        if (i == 3)
        {
            MainCamera1.enabled = false;
            MainCamera2.enabled = false;
            MainCamera3.enabled = true;
            MainCamera4.enabled = false;
        }
        if (i == 4)
        {
             MainCamera1.enabled = false;
             MainCamera2.enabled = false;
             MainCamera3.enabled = false;
             MainCamera4.enabled = true;
        }



    }
    
    public void TurnOffAreas()
    {
        MainCamera1.enabled = false;
        MainCamera2.enabled = false;
        MainCamera3.enabled = false;
        MainCamera4.enabled = false;
        MainCanvas.SetActive(false);
    }
       

}
