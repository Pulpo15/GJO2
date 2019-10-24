using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneScore : MonoBehaviour
{    
    public Text scoreText;

    private int initialScore;
    private int score;
    //private float scoreBirdMultiplier = 1f; // Everytime a bird dies, scoreBirdMultiplier += 0.33f
    private float scoreInitialScale = 100f;
    private float scoreCurrentScale;    
    private float scoreMultiplier;
    private float scoreInitialCooldown;
    private float scoreCurrentCooldown;
    private float scoreCooldownMultiplier = 1.2f;
    private Timer timer;
    
    private const float minCooldownMultiplier = 0.2f;
    private const int scoreMinimum = 0;
    private const float scoreMaxScale = 60f;

    // Proportional values
    private const float mathConstantScore = 0.1f;
    private const float mathConstantScoreScale = 0.01f;
    private const float mathConstantCooldown = 0.08f;
    // ----------------------------------------------------

    private float time;

    void Start()
    {
        timer = FindObjectOfType<Timer>();

        initialScore = (int)timer.initialTime * (int)scoreInitialScale;
        score = initialScore;        
        scoreMultiplier = timer.initialTime * mathConstantScore;

        scoreInitialCooldown = timer.initialTime * mathConstantCooldown;
        scoreCurrentCooldown = scoreInitialCooldown * scoreCooldownMultiplier;        
    }

    void Update()
    {
        scoreCurrentCooldown -= timer.frameTimeWithScaleTime;

        if (scoreCurrentScale < scoreMaxScale) scoreCurrentScale += scoreInitialScale * mathConstantScoreScale * timer.frameTimeWithScaleTime;

        if (timer.timeInSecondsShowed > 0) UpdateScore(scoreCurrentCooldown);
    }

    void UpdateScore(float currentCooldown)
    {
        string scoreTextUpdate;

        if (currentCooldown < 0)
        {
            if (scoreCooldownMultiplier <= minCooldownMultiplier) scoreCooldownMultiplier = minCooldownMultiplier;
            else scoreCooldownMultiplier -= 0.2f;

            score -= (int)scoreMultiplier * (int)scoreCurrentScale;
            scoreCurrentCooldown = scoreInitialCooldown * scoreCooldownMultiplier;

            if (score <= 0) score = 0;
        }

        scoreTextUpdate = score.ToString("0");

        scoreText.text = scoreTextUpdate;
    }

    void AddScore(int value)
    {
        score += value;

        scoreText.text = score.ToString("0");
    }
}
