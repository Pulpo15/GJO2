using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    [Header("Music")]
    public AudioClip victorySound;
    public AudioClip gameMusic;
    AudioSource aS;

    [Header("Other")]
    public float timePerRound;
    [Tooltip("The scene the game should go to, when the game ends")]
    public int gameOverScene;

    float timer;
    int round = 0;
    bool inRound = false;
    bool readyToSkip = false;

    public void Start()
    {
        aS = GetComponent<AudioSource>();
        StartCoroutine(StartGame());
        timer = timePerRound;
        aS.clip = gameMusic;
        aS.loop = true;
        aS.Play();
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

    public void SkipRound()
    {
        timer = 0;
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
        if (round != 0)
        {
            UIAnimator.Play("ScoreClose");
        }
        round++;
        roundUI.text = "Round: " + round.ToString();

        if (round == 3)
        {
            StartCoroutine(EndRound());
            roundUI.gameObject.SetActive(false);
        }
        else if (round == 4)
        {
           SceneManager.LoadScene(gameOverScene);
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
                players[i - 1].UnfreezeMovement();
                players[i - 1].scoreScript.NewRoundScoreSetup();
            } //Loops through players. And sets joystick 1 as the airplane in round 1, etc.
        }

        inRound = true;
    }

    bool gameEnded;
    IEnumerator EndRound()
    {

        if (round != 3)
        {
            for (int i = 0; i < 2; i++)
            {
                float b = players[i].scoreScript.roundBirdScore;
                float a = players[i].scoreScript.roundScore;
                UIScores[i].text = Mathf.RoundToInt(a+b).ToString();
            }

        }
        Debug.Log("Setting score");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].scoreScript.running = false;
            players[i].FreezeMovement();
        }
        if (round == 3 && gameEnded==false)
        {
            gameEnded = true;
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < 2; i++)
            {
                players[i].scoreScript.NewRoundScoreSetup();
                float a = players[i].scoreScript.totalScore;
                UIScores[i].text = Mathf.RoundToInt(a).ToString();
            }
        }
        UIAnimator.Play("ScoreOpen");
        yield return new WaitForSeconds(2.5f);
        if(round == 2)
        {
            aS.clip = victorySound;
            aS.Play();
            yield return new WaitForSeconds(5f);
            //Do something cool here
        }
        readyToSkip = true;

    }
}
