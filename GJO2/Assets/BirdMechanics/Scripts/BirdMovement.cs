using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    PlayerController.JoyStick js;
    public float speed;
    Rigidbody rb;
    public bool controlOnKeyboard;
    public bool running;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    public void SetJoyStick(PlayerController.JoyStick value) {
        js = value;
    }

    void BasicMovement(string Horizontal, string Vertical, Rigidbody Player) {

        #region Rotation

        //if direction Right == 0,180,0
        //if direction Left == 0,0,0
        //if direction up == 0,0,-90
        //if directiondown == 0,0,90


        float x;
        float y;
        if (controlOnKeyboard)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

        }
        else 
        {
            x = Input.GetAxis(Horizontal);
            y = Input.GetAxis(Vertical);
        }

        if (x != 0.0 || y != 0.0) {
            float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            Player.rotation = Quaternion.AngleAxis(180.0f - angle, new Vector3(0, 200, -200));
        }

        #endregion

        //Movement
        float HorizontalMovement;
        float VerticalMovement;

        if (controlOnKeyboard && running)
        {
            HorizontalMovement = Input.GetAxis("Horizontal");
            VerticalMovement = Input.GetAxis("Vertical");

        }
        else if (running)
        {
            HorizontalMovement = Input.GetAxis(Horizontal);
            VerticalMovement = Input.GetAxis(Vertical);
        }
        else
        {
            HorizontalMovement = 0;
            VerticalMovement = 0;
        }

        Player.velocity = new Vector3(HorizontalMovement * speed, Player.velocity.y);
        Player.velocity = new Vector3(Player.velocity.x, VerticalMovement * speed);

        Physics.IgnoreLayerCollision(8,8);
    }

    void Update() {
        BasicMovement(js.ToString()+"Horizontal", js.ToString()+"Vertical", rb);
    }
}
