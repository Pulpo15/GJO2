using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    
    [Header("Initial stats")]
    public int initialBirdScore;                //How many points birds start with every round.
    public int initialPlaneScore;               //How many points planes start with every round.
    public int initialPointsPerSecond;          //How many points you get per second in the start of a round.
    
    private float pointsPerSecond;              //Amount of points player receives per second.
    public float pointsPerSecondMultiplier;     //How much points per second is multiplied with every second.

    [Header("Current Score")]
    public float roundScore;  //Amount of points earned in one round.
    public int totalScore;    //Total amount of points earned.
    
    public bool plane;                                 //Is the player currently a plane or a bird?
    public bool running;                               //Are you currently in a round?

    private float time = 0.0f;

    public void NewRoundScoreSetup()
    {
        totalScore += Mathf.RoundToInt(roundScore);
        pointsPerSecond = initialPointsPerSecond;
        if (plane)
        {
            roundScore = initialPlaneScore;
        }
        else
        {
            roundScore = initialBirdScore;
        }
        
    }

    void FixedUpdate()
    {
        if (running)
        {
            time += Time.deltaTime;
            if (time >= 1f)//Runs every second
            {
                time = 0.0f;
                if (plane)
                {
                    Debug.Log("Plane pps");
                    roundScore -= pointsPerSecond;
                }
                else
                {
                    Debug.Log("Bird pps");
                    roundScore += pointsPerSecond;
                }
                pointsPerSecond += pointsPerSecond * pointsPerSecondMultiplier;
            }
        }
    }

    public float GetRoundScore()
    {
        return roundScore;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }
    public void RaiseRoundScore(int value)
    {
        roundScore += value;
    }
}