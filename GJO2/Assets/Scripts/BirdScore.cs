using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScore : MonoBehaviour
{
    public int initialScore;    
    public Text scoreText;

    private int score;
    private float scoreInitialScale = 1f;
    private float scoreCurrentScale;
    private float scoreMultiplier;
    private float scoreInitialCooldown;
    private float scoreCurrentCooldown;
    private float scoreCooldownMultiplier = 1f;    
    private Timer timer;

    private const float minCooldownMultiplier = 0.2f;  

    // Proportional values
    private const float mathConstantScore = 0.1f;
    private const float mathConstantCooldown = 0.08f;

    private float time;

    void Start()
    {
        timer = FindObjectOfType<Timer>();

        scoreMultiplier = timer.initialTime * mathConstantScore;        

        scoreInitialCooldown = timer.initialTime * mathConstantCooldown;
        scoreCurrentCooldown = scoreInitialCooldown * scoreCooldownMultiplier;

        // DEBUGS
        Debug.Log("Initial cooldown: " + scoreInitialCooldown);
        Debug.Log("Initial cooldown multiplier :" + scoreCooldownMultiplier);
        Debug.Log("Initial score multiplier: " + scoreMultiplier);
        Debug.Log("Initial score scale: " + scoreCurrentScale);
    }

    void Update()
    {        
        scoreCurrentCooldown -= timer.frameTimeWithScaleTime;
        scoreCurrentScale += scoreInitialScale * mathConstantScore * timer.frameTimeWithScaleTime;

        if (timer.timeInSecondsShowed > 0) UpdateScore(scoreCurrentCooldown);
    }

    void UpdateScore(float currentCooldown)
    {
        string scoreTextUpdate;

        if (currentCooldown < 0)
        {            
            if (scoreCooldownMultiplier <= minCooldownMultiplier) scoreCooldownMultiplier = minCooldownMultiplier;
            else scoreCooldownMultiplier -= 0.2f;

            score += (int)scoreMultiplier * (int)scoreCurrentScale;
            scoreCurrentCooldown = scoreInitialCooldown * scoreCooldownMultiplier;            

            Debug.Log("Current cooldown :" + scoreCurrentCooldown);
            Debug.Log("Current cooldown multiplier: " + scoreCooldownMultiplier);
            Debug.Log("Current score scale: " + scoreCurrentScale);
        }

        scoreTextUpdate = score.ToString("0");

        scoreText.text = scoreTextUpdate;
    }
}
