using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    PlayerController.JoyStick js;
    [HideInInspector] public float speed;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    public void SetJoyStick(PlayerController.JoyStick value)
    {
        js = value;
    }

    void BasicMovement(string Horizontal, string Vertical, Rigidbody Player) {
        float x = Input.GetAxis(Horizontal + "Rotation");
        float y = Input.GetAxis(Vertical + "Rotation");
        if (x != 0.0 || y != 0.0) {
            float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            Player.rotation = Quaternion.AngleAxis(-90.0f - angle, new Vector3(0,0,-1));
        }

        float speed = 3f;
        float HorizontalMovement = speed * Input.GetAxis(Horizontal);
        float VerticalMovement = speed * Input.GetAxis(Vertical);

        Player.velocity = new Vector3(HorizontalMovement * speed, Player.velocity.y);
        Player.velocity = new Vector3(Player.velocity.x, VerticalMovement * speed);

        Physics.IgnoreLayerCollision(8,8);
    }

    void Update() {
        BasicMovement(js.ToString()+"Horizontal", js.ToString()+"Vertical", rb);
    }
}
