using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    [Header("Initial stats")]
    public int maxSurviveScore;                 //The maximum amount of points you can get, from being alive.
    public int minSurviveScore;                 //The minimum amount of points you can get, from being alive.
    public int initialPointsPerSecond;          //How many points you get per second in the start of a round.

    private float pointsPerSecond;              //Amount of points player receives per second.
    public float pointsPerSecondMultiplier;     //How much points per second is multiplied with every second.

    public int birdPointDead;

    [Header("Current Score")]
    public float roundScore;                    //Amount of points earned in one round.
    public float roundBirdScore;                //Amount of points received from killing birds;
    public int totalScore;                      //Total amount of points earned.

    public bool plane;                          //Is the player currently a plane or a bird?
    public bool running;                        //Are you currently in a round?

    private float time = 0.0f;
    PlayerController pc;

    int birdsKilled = 0;

    private void Awake()
    {
        pc = GetComponent<PlayerController>();
    }

    public void NewRoundScoreSetup()
    {
        birdsKilled = 0;
        totalScore += Mathf.RoundToInt(roundScore);
        totalScore += Mathf.RoundToInt(roundBirdScore);
        pointsPerSecond = initialPointsPerSecond;
        if (plane)
        {
            roundScore = maxSurviveScore;
        }
        else
        {
            roundScore = minSurviveScore;
        }
        roundBirdScore = 0;

    }

    void FixedUpdate()
    {
        if (running)
        {if(birdsKilled == 4)
            {
                pc.gc.SkipRound();
            }
            time += Time.deltaTime;
            if (time >= 1f)//Runs every second
            {
                time = 0.0f;
                if (plane)
                {

                    roundScore -= pointsPerSecond;
                    if (roundScore <= minSurviveScore)
                    {
                        roundScore = minSurviveScore;
                    }
                }
                else if (pc.birdDead == false)
                {
                    if (roundScore >= maxSurviveScore)
                    {
                        roundScore = maxSurviveScore;
                    }
                    else
                    {
                        roundScore += pointsPerSecond;
                    }
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
    public void BirdKill()
    {
        birdsKilled++;
        roundBirdScore += birdPointDead;
    }
}