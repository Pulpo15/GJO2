using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
 


    void Update()
    {
      /*  float J1H;
        float J1V;

        J1H = Input.GetAxis("J1Horizontal");
       

        J1V = Input.GetAxis("J1Vertical");
        Debug.Log("Joystick 1: " + J1H + ", " + J1V);
        float J2H;
        float J2V;

        J2H = Input.GetAxis("J2Horizontal");


        J2V = Input.GetAxis("J2Vertical");

        Debug.Log("Joystick 2: " + J2H + ", " + J2V);
        */
        if (Input.GetButtonDown("J1Shoot"))
        {
            Debug.Log("J1: shoot");
        }
        if (Input.GetButtonDown("J2Shoot"))
        {
            Debug.Log("J2: shoot");
        }
    }
}
