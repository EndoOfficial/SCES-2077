using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public float StartTime;
    private Scene C_Scene;
    public string SceneName;
    private bool Finished = false;

    public string minutes;
    public string seconds;

    public LevelTimes TimesLibrary;
    public ScriptableObject TimesSO;

    private void Start()
    {
        //StartTime = Time.time;

       
        //TimerText.text = PlayerPrefs.GetString("LevelTime", seconds);
        //SceneName = PlayerPrefs.GetString("LevelName", SceneName);

        //Debug.Log(StartTime);
        //Debug.Log(SceneName);

        TimerText.text = StartTime.ToString("f2");
        
    }

    
    private void Update()
    {
        

        if (Finished)
            return;

        float t = Time.time - StartTime;

        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f2");

        TimerText.text = minutes + ":" + seconds;
    }
    
    public void Finnish()
    {
        Finished = true;
        //PlayerPrefs.SetString("LevelTime", seconds);        
        C_Scene = SceneManager.GetActiveScene();
        SceneName = C_Scene.name;
        //PlayerPrefs.SetString("LevelName", SceneName);
        TimerText.color = Color.red;
    }
}
