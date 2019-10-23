using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScore : MonoBehaviour
{
    public int initialScore;
    public int scoreInitialCooldown;
    public int scoreMultiplier;
    public Text scoreText;

    private int score;
    private float scoreScale = 1;
    private float scoreCurrentCooldown;
    private float scoreCooldownMultiplier = 10f;

    private Timer timer;
    
    void Start()
    {
        timer = FindObjectOfType<Timer>();

        scoreCurrentCooldown = scoreInitialCooldown * scoreCooldownMultiplier;
    }

    void Update()
    {
        scoreCooldownMultiplier -= timer.frameTimeWithScaleTime;
        scoreCurrentCooldown -= timer.frameTimeWithScaleTime;
        scoreScale += timer.frameTimeWithScaleTime;
        UpdateScore(scoreCurrentCooldown);
    }

    void UpdateScore(float currentCooldown)
    {
        string scoreTextUpdate;

        if (currentCooldown < 0)
        {            
            score += scoreMultiplier * (int)scoreScale;
            scoreCurrentCooldown = scoreInitialCooldown * scoreCooldownMultiplier;

            Debug.Log(scoreScale);
            Debug.Log(scoreCooldownMultiplier);
        }

        scoreTextUpdate = score.ToString("0");

        scoreText.text = scoreTextUpdate;
    }
}
