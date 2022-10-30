using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStates : MonoBehaviour
{
    // cat objects
    public GameObject Cat1;
    public GameObject Cat2;

    //dealer objects
    public GameObject Dealer1;
    public GameObject Dealer2;

    // addict objects
    public GameObject Addict1;
    public GameObject Addict2;

    private string levelName;

    private void Awake()
    {
        levelName = PlayerPrefs.GetString("LevelName"); // get the completed level's name
        Debug.Log(levelName);
        if (levelName == "Cat")
        {
            // set catBool to T
            PlayerPrefs.SetString("catBool", "T");
            Debug.Log("set catBool to catT");
        }
        else
        {
            // set catBool to F
            PlayerPrefs.SetString("catBool", "F");
            Debug.Log("set catBool to catF");
        }

        if(levelName == "Addict")
        {
            // set addictBool to T
            PlayerPrefs.SetString("addictBool", "T");
            Debug.Log("set addictBool to addictT ");
        }
        else
        {
            // set addictBool to F
            PlayerPrefs.SetString("addictBool", "F");
            Debug.Log("set addictBool to addictF ");
        }
        
        if(levelName == "Dealer")
        {
            // set dealerBool to T
            PlayerPrefs.SetString("dealerBool", "T");
            Debug.Log("set dealerBool to dealerT ");
        }
        else
        {
            // set dealerBool to F
            PlayerPrefs.SetString("dealerBool", "F");
            Debug.Log("set dealerBool to dealerF ");
        }
        
        if (PlayerPrefs.GetString("catBool") == "T")
        {
            // cat changes position
            Cat1.SetActive(false);
            Cat2.SetActive(true);
            Debug.Log("Cat Change");
        }

        if (PlayerPrefs.GetString("catBool") == "F")
        {

        }

        if (PlayerPrefs.GetString("dealerBool") == "T")
        {
            //Dealer changes position
            //Dealer1.SetActive(false);
            //Dealer2.SetActive(true);
            Debug.Log("Dealer Change");
        }

        if (PlayerPrefs.GetString("dealerBool") == "F")
        {

        }
        
        if (PlayerPrefs.GetString("addictBool") == "T")
        {
            //addict changes position
            Addict1.SetActive(false);
            Addict2.SetActive(true);
            Debug.Log("Addict Change");
        }

        if (PlayerPrefs.GetString("addictBool") == "F")
        {

        }
    }
}
