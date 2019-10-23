using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("UI")]
    public Text roundUI;

    [Header("Players")]
    public PlayerController[] players;

    //StartButton
    bool readyToStart;
    int connectedPlayers;
    int playersPressingB;
    int round = 0;


    public void ReadyToStart()
    {
        connectedPlayers = Input.GetJoystickNames().Length - 1;
    }
    public void StartGame()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].UnfreezeMovement();
        }
    }
    private void Update()
    {
        if (readyToStart && playersPressingB == connectedPlayers)
        {
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            round++;
            SetRound();
        }
    }

    public void SetRound()
    {
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
