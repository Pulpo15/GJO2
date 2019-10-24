using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGameScript : MonoBehaviour
{
    //This scripts is hardcoded, but it doesn't need to be edited so that's fine.


    [Tooltip("The buildindex of the scene, that should be loaded when the game starts.")]
    public int sceneToLoad;

    public Animator anim;

    public GameObject[] GOS;

    private void Update()
    {
        if (Input.GetButton("J1B"))
        {
            GOS[0].GetComponent<Image>().color = Color.green;
        }
        else
        {
            GOS[0].GetComponent<Image>().color = Color.white;
        }

        if (Input.GetButton("J2B"))
        {
            GOS[1].GetComponent<Image>().color = Color.green;
        }
        else
        {
            GOS[1].GetComponent<Image>().color = Color.white;
        }

        if (Input.GetButton("J3B"))
        {
            GOS[2].GetComponent<Image>().color = Color.green;
        }
        else
        {
            GOS[2].GetComponent<Image>().color = Color.white;
        }

        if (Input.GetButton("J4B"))
        {
            GOS[3].GetComponent<Image>().color = Color.green;
        }
        else
        {
            GOS[3].GetComponent<Image>().color = Color.white;
        }

        if (Input.GetButton("J5B"))
        {
            GOS[4].GetComponent<Image>().color = Color.green;
        }
        else
        {
            GOS[4].GetComponent<Image>().color = Color.white;
        }

        if(Input.GetButton("J1B") && Input.GetButton("J2B") && Input.GetButton("J3B") && Input.GetButton("J4B") && Input.GetButton("J5B") || Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartGame());
        }
    }
    
    IEnumerator StartGame()
    {
        //SceneChange
        anim.Play("Transition");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

}
