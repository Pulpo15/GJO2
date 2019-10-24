using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{  
    public int initialTime;
    public float timeScale;
    [HideInInspector]
    public float frameTimeWithScaleTime = 0f;
    [HideInInspector]
    public float timeInSecondsShowed = 0f;

    private Text timer;    
    private float initialTimeScale;


    void Start()
    {
        initialTimeScale = timeScale;

        //timer = GetComponent<Text>();
        
        timeInSecondsShowed = initialTime;    
    }

    void Update()
    {
        frameTimeWithScaleTime = Time.deltaTime * timeScale;

        timeInSecondsShowed -= frameTimeWithScaleTime;

        if (frameTimeWithScaleTime > 0) UpdateTimer(timeInSecondsShowed);
    }

    void UpdateTimer(float timeInSeconds)
    {
        int minutes = 0;
        int seconds = 0;

        string timerText;

        if (timeInSeconds < 0) timeInSeconds = 0;

        minutes = (int)timeInSeconds / 60;
        seconds = (int)timeInSeconds % 60;

        timerText = minutes.ToString("00") + ":" + seconds.ToString("00");

        //timer.text = timerText;       
    }    
}
