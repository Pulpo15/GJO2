using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShoot : MonoBehaviour
{
    public GameObject BulletPrefab;
    public ParticleSystem Particles;

    PlayerController.JoyStick js;

    public void SetJoyStick(PlayerController.JoyStick value)
    {
        js = value;
    }

    void Update()
    {

        if (Input.GetButtonDown(js.ToString() + "Shoot"))
        {
            float BulletSpeed = 900f;
            GameObject Clone = Instantiate(BulletPrefab, transform.position, transform.rotation);
            Clone.GetComponent<Rigidbody>().AddRelativeForce(Vector2.down * BulletSpeed);
            Particles.Play();
            Destroy(Clone, 5.0f);
        }

    }
}
