using System.Collections;
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
        float speed = 4.5f;
        float HorizontalMovement = speed * Input.GetAxis(Horizontal);
        float VerticalMovement = speed * Input.GetAxis(Vertical);

        Player.velocity = new Vector3(HorizontalMovement * speed, Player.velocity.y);
        Player.velocity = new Vector3(Player.velocity.x, VerticalMovement * speed);
    }

    //void J2Movement() {
    //    float speed = 4.5f;
    //    float HorizontalMovement = speed * Input.GetAxis("J2Horizontal");
    //    float VerticalMovement = speed * Input.GetAxis("J2Vertical");

    //    J2RB.velocity = new Vector3(HorizontalMovement * speed, J2RB.velocity.y);
    //    J2RB.velocity = new Vector3(J2RB.velocity.x, VerticalMovement * speed);
    //}


    void Update() {
        BasicMovement("J1Horizontal", "J1Vertical", J1RB);
        BasicMovement("J2Horizontal", "J2Vertical", J2RB);
        //J2Movement();

    }
}
