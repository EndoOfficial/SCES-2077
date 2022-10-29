using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public string sceneName;
  public string levelName;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
        PlayerPrefs.SetString("LevelName", levelName);
    }
}
