using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "LevelTimes", fileName = "Times")] // This is the name of the level times
public class LevelTimes : ScriptableObject
{
    

    [System.Serializable]
    public class Times
    {
        public string LevelName;
        public string Time;
    }

    public Times[] times;
}
