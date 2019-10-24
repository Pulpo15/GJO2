using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("UI")]
    public Text roundUI;
    public Text timerUI;
    public Animator UIAnimator;
    public Text[] UIScores;

    [Header("Players")]
    public PlayerController[] players;
    public float birdSpeed;
    public float planeSpeed;

    [Header("Other")]
    public float timePerRound;

    float timer;
    int round = 0;
    bool inRound = false;
    bool readyToSkip = false;

    public void Start()
    {
        StartCoroutine(StartGame());
        timer = timePerRound;
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < players.Length; i++)
        {
            players[i].UnfreezeMovement();
        }
        NewRound();
    }
    private void Update()
    {
        if ((Input.GetButtonDown("A-Button") || Input.GetKeyDown(KeyCode.Space)) && readyToSkip)
        {
            NewRound();
            readyToSkip = false;
        }

        if (inRound)
        {
            timerUI.gameObject.SetActive(true);
            timer -= Time.deltaTime;
            timerUI.text = Mathf.RoundToInt(timer).ToString();
        }
        else
        {
            timerUI.gameObject.SetActive(false);
        }
        if (timer <= 0)
        {
            Debug.Log("Round over");
            timer = timePerRound;
            inRound = false;
            StartCoroutine(EndRound());
        }
    }

    public void NewRound()
    {
        Debug.Log("New round");
        if(round != 0)
        {
            UIAnimator.Play("ScoreClose");
        }
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
                players[i - 1].scoreScript.running = true;
                players[i - 1].scoreScript.NewRoundScoreSetup();
            } //Loops through players. And sets joystick 1 as the airplane in round 1, etc.
        }

        inRound = true;
    }

    IEnumerator EndRound()
    {
        Debug.Log("Setting score");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].scoreScript.running = false;
        }
        for (int i = 0; i < 5; i++)
        {
            float a = players[i].scoreScript.roundScore;
            UIScores[i].text = Mathf.RoundToInt(a).ToString();
        }

        UIAnimator.Play("ScoreOpen");
        yield return new WaitForSeconds(2.5f);
        readyToSkip = true;

    }
}
