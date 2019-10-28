using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGameScript : MonoBehaviour
{
    [Tooltip("The buildindex of the scene, that should be loaded when the game starts.")]
    public int sceneToLoad;

    public Animator anim;

    public Image[] playerSlotIcons;

    private void Update()
    {
        
    }
    
    IEnumerator StartGame()
    {
        //SceneChange
        anim.Play("Transition");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

}
