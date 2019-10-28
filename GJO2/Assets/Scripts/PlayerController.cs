using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Controls
    public enum JoyStick
    {
        J1,
        J2,
        J3,
        J4,
        J5
    }

    [Header("Controls")]
    public bool ControlOnKeyboard;
    [Tooltip("Decides which joystick is connected to this player.")]
    public JoyStick playerJoyStick;
    #endregion

    public Vector3 planeStartPos;
    public Vector3 birdStartPos;

    [HideInInspector] public bool plane;
    public bool birdDead;
    PlayerMovement bm;
    //BirdShoot bs;
    #region Graphics
    [Header("Graphics")]
    [Tooltip("Gameobject containing the plane's graphics/3D model")]
    public GameObject planeGraphics;
    [Tooltip("Gameobject containing the bird's graphics/3D model")]
    public GameObject birdGraphics;
    #endregion
    [HideInInspector]public GameController gc; //GameController reference
    [HideInInspector] public PlayerScore scoreScript; //Scorescript reference

    private void Start()
    {
        bm = GetComponent<PlayerMovement>();
        bm.SetJoyStick(playerJoyStick);
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        scoreScript = GetComponent<PlayerScore>();
    }
    public void SetAsPlane()
    {
        this.gameObject.transform.position = planeStartPos;
        plane = true;
        planeGraphics.SetActive(true);
        birdGraphics.SetActive(false);
        bm.speed = gc.planeSpeed;
        scoreScript.plane = true;
    }
    public void SetAsBird()
    {
        this.gameObject.transform.position = birdStartPos;
        plane = false;
        planeGraphics.SetActive(false);
        birdGraphics.SetActive(true);
        bm.speed = gc.birdSpeed;
        scoreScript.plane = false;
    }

    public void KillBird()
    {
        birdDead = true;
    }
    public void UnfreezeMovement()
    {
        birdDead = false;
        bm.running = true;
    }
    public void FreezeMovement()
    {
        bm.running = false;
    }

}
