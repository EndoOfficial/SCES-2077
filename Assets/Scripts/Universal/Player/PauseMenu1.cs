using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{
   
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    public string previousLevel;

    //Update is called once per frame
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
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameEvents.OnPauseGame?.Invoke(false);
    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        GameEvents.OnPauseGame?.Invoke(true);
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
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
    public void QuitGame()
    {
        Debug.Log("Quitting game....");
        Application.Quit();
    }
}

