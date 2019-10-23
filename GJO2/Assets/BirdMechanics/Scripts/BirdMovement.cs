﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{

    public Rigidbody J1RB;
    public Rigidbody J2RB;
    public Rigidbody J3RB;
    public Rigidbody J4RB;

    void Start() {
        
    }

    void BasicMovement(string Horizontal, string Vertical, Rigidbody Player) {
        float x = Input.GetAxis(Horizontal);
        float y = Input.GetAxis(Vertical);
        if (x != 0.0 || y != 0.0) {
            float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            Player.rotation = Quaternion.AngleAxis(-90.0f - angle, Vector3.up);
        }

        float speed = 3f;
        float HorizontalMovement = speed * Input.GetAxis(Horizontal);
        float VerticalMovement = speed * Input.GetAxis(Vertical);

        Player.velocity = new Vector3(HorizontalMovement * speed, Player.velocity.y);
        Player.velocity = new Vector3(Player.velocity.x, VerticalMovement * speed);
    }

    void Update() {
        BasicMovement("J1Horizontal", "J1Vertical", J1RB);
        BasicMovement("J2Horizontal", "J2Vertical", J2RB);
        BasicMovement("J3Horizontal", "J3Vertical", J3RB);
        BasicMovement("J4Horizontal", "J4Vertical", J4RB);

    }
}