using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    PlayerController.JoyStick js;
    public float speed;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    public void SetJoyStick(PlayerController.JoyStick value)
    {
        js = value;
    }

    void BasicMovement(string Horizontal, string Vertical, Rigidbody Player) {


        #region Rotation
        //rotation
        //float h1 = Input.GetAxis(Horizontal + "Rotation"); // set as your inputs 
        //float v1 = Input.GetAxis(Vertical + "Rotation");

        //Vector3 targetPostition = new Vector3(h1,
        //                                v1, 
        //                                this.transform.position.z);
        //this.transform.LookAt(targetPostition);

        
        //float x = Input.GetAxis(Horizontal + "Rotation");
        //float y = Input.GetAxis(Vertical + "Rotation");
        //if (x != 0.0 || y != 0.0) {
        //    float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        //    Player.rotation = Quaternion.AngleAxis(-90.0f - angle, new Vector3(-1,0,0));
        //    Debug.Log(angle);
        //}
        #endregion

        //movement
        float HorizontalMovement = Input.GetAxis(Horizontal);
        float VerticalMovement = Input.GetAxis(Vertical);


        Player.velocity = new Vector3(HorizontalMovement * speed, Player.velocity.y);
        Player.velocity = new Vector3(Player.velocity.x, VerticalMovement * speed);

        Physics.IgnoreLayerCollision(8,8);
    }

    void Update() {
        BasicMovement(js.ToString()+"Horizontal", js.ToString()+"Vertical", rb);
    }
}
