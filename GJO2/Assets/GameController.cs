using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("UI")]
    public Text roundUI;
    public Text timerUI;

    [Header("Players")]
    public PlayerController[] players;

    [Header("Other")]
    public float timeBeforeStart;
    public float timePerRound;

    float timer;

    
    bool readyToStart = true;
    [HideInInspector] public int playersPressingB;
    int round = 0;

    public void StartGame()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].UnfreezeMovement();
        }
    }
    private void Update()
    {
        if (readyToStart == false)
        {

            timer -= Time.deltaTime;
            timerUI.text = Mathf.RoundToInt(timer).ToString();
            if (timer <= 0)
            {
                timer = timePerRound;
                NewRound();
            }
        }

        if (Time.time >= timeBeforeStart && readyToStart)
        {
            readyToStart = false;
        }
        if(playersPressingB == 5 && readyToStart)
        {
            readyToStart = false;
            StartGame();
        }
    }

    public void NewRound()
    {
        round++;
        roundUI.text = "Round: " + round.ToString();
        if(round == 6)
        {
            //Display table with who won.
        }
        else
        {
            for (int i = 1; i < players.Length + 1; i++)
            {
                if (round == i)
                {
                    players[i - 1].SetAsPlane();
                }
                else
                {
                    players[i - 1].SetAsBird();
                }
            } //Loops through players. And sets joystick 1 as the airplane in round 1, etc.
        }
    }
}
