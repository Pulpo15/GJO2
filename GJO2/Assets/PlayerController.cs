using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum JoyStick
    {
        J1,
        J2,
        J3,
        J4,
        J5
    }
    [Header("Joystick")]
    public JoyStick playerJoyStick;
    [HideInInspector] public bool plane;

    BirdMovement bm;
    //BirdShoot bs;
    [Header("Graphics")]
    public GameObject planeGraphics;
    public GameObject birdGraphics;

    private GameController gc;

    private void Start()
    {
        bm = GetComponent<BirdMovement>();
        bm.SetJoyStick(playerJoyStick);
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //bs.SetJoyStick(playerJoyStick);
    }
    public void SetAsPlane()
    {
        plane = true;
        planeGraphics.SetActive(true);
        birdGraphics.SetActive(false);
        bm.speed = gc.planeSpeed;
    }
    public void SetAsBird()
    {
        plane = false;
        planeGraphics.SetActive(false);
        birdGraphics.SetActive(true);
        bm.speed = gc.birdSpeed;
    }
    public void UnfreezeMovement()
    {
        bm.enabled = true;
    }
    public void FreezeMovement()
    {
        bm.enabled = false;
    }

}
