using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStates : MonoBehaviour
{
    public GameObject Cat1;
    public GameObject Cat2;
    private bool catBool;

    public GameObject Dealer1;
    public GameObject Dealer2;
    private bool dealerBool;

    public GameObject Addict1;
    public GameObject Addict2;
    private bool addictBool;

    private string levelName;
    private void Awake()
    {
        levelName = PlayerPrefs.GetString("LevelName");
        Debug.Log(levelName);
        if (levelName == "Cat")
        {
            PlayerPrefs.SetString("catBool", "catT");
            Debug.Log("set catBool to catT");
        }
        
        if (PlayerPrefs.GetString("catBool") == "catT")
        {
            catBool = true;
            Debug.Log("catBool = " + catBool);
        }

        if (PlayerPrefs.GetString("catBool") == "catF")
        {
            catBool = false;
            Debug.Log("catBool = " + catBool);
        }

        if (PlayerPrefs.GetString("dealerBool") == "dealerT")
        {
            dealerBool = true;
        }

        if (PlayerPrefs.GetString("dealerBool") == "dealerF")
        {
            dealerBool = false;
        }

        if (catBool)
        {
            Cat1.SetActive(false);
            Cat2.SetActive(true);
            Debug.Log("Cat Change");
        }
    }
}
