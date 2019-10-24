using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float movementspeed;
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.up * Time.deltaTime * movementspeed / 50);
        }
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.down * Time.deltaTime * movementspeed / 50);
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.left * Time.deltaTime * movementspeed / 50);

        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * Time.deltaTime * movementspeed / 50);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.up * Time.deltaTime * movementspeed / 70);
            transform.Translate(Vector3.left * Time.deltaTime * movementspeed / 70);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.up * Time.deltaTime * movementspeed / 70);
            transform.Translate(Vector3.right * Time.deltaTime * movementspeed / 70);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.down * Time.deltaTime * movementspeed / 70);
            transform.Translate(Vector3.left * Time.deltaTime * movementspeed / 70);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.down * Time.deltaTime * movementspeed / 70);
            transform.Translate(Vector3.right * Time.deltaTime * movementspeed / 70);
        }

    }
}
