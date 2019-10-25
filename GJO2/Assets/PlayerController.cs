using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Controls")]
    public bool ControlOnKeyboard;
    public enum JoyStick
    {
        J1,
        J2,
        J3,
        J4,
        J5
    }
    [Header("Joystick")]
    [Tooltip("Decides which joystick is connected to this player.")]
    public JoyStick playerJoyStick;
    [HideInInspector] public bool plane;

    BirdMovement bm;
    //BirdShoot bs;
    [Header("Graphics")]
    [Tooltip("Gameobject containing the plane's graphics/3D model")]
    public GameObject planeGraphics;
    [Tooltip("Gameobject containing the bird's graphics/3D model")]
    public GameObject birdGraphics;

    private GameController gc; //GameController reference
    [HideInInspector] public PlayerScore scoreScript; //Scorescript reference

    private void Start()
    {
        bm = GetComponent<BirdMovement>();
        bm.SetJoyStick(playerJoyStick);
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        scoreScript = GetComponent<PlayerScore>();
    }
    public void SetAsPlane()
    {
        plane = true;
        planeGraphics.SetActive(true);
        birdGraphics.SetActive(false);
        bm.speed = gc.planeSpeed;
        scoreScript.plane = true;
    }
    public void SetAsBird()
    {
        plane = false;
        planeGraphics.SetActive(false);
        birdGraphics.SetActive(true);
        bm.speed = gc.birdSpeed;
        scoreScript.plane = false;
    }

    public void KillBird()
    {
        scoreScript.RaiseRoundScore(100);
    }
    public void UnfreezeMovement()
    {
        bm.running = true;
    }
    public void FreezeMovement()
    {
        bm.running = false;
    }

}
