using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{
   
    public bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    public string previousLevel;
    public GameObject OptionMenuUi;
    public GameObject HintScreen;
    public GameObject HintImage;

    //Update is called once per frame

    private void Start()
    {
        HintScreen = GameObject.Find("HintScreen");
        HintImage = GameObject.Find("HintImage");
        HintScreen.SetActive(false);
        pauseMenuUi.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {                
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUi.SetActive(false);
        OptionMenuUi.SetActive(false);
        HintScreen.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameEvents.OnPauseGame?.Invoke(false);

    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        GameEvents.OnPauseGame?.Invoke(true);
        OptionMenuUi.SetActive(false);
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        HintScreen.SetActive(false);

    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    //LoadMenu() was really misleading so im renaming the function - Zach
    public void LoadPreviousArea()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(previousLevel);
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Quitting to menu");
        SceneManager.LoadScene("MainMenu");        
    }

    public void QuitGame()
    {

        Time.timeScale = 1f;
        Application.Quit();
        Debug.Log("Quitting game....");
    }

    public void Hint()
    {

        HintScreen.SetActive(true);
        pauseMenuUi.SetActive(false);

    }
    public void Options()
    {
        pauseMenuUi.SetActive(false);
        OptionMenuUi.SetActive(true);
        HintScreen.SetActive(false);
    }

    public void UnOptions()
    {

        pauseMenuUi.SetActive(true);
        OptionMenuUi.SetActive(false);
        HintScreen.SetActive(false);
    }
}

