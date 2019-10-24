using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShootJ4 : MonoBehaviour {
    public GameObject BulletPrefab;

    void Update() {

        if (Input.GetButtonDown("J4Shoot")) {
            float BulletSpeed = 900f;
            GameObject Clone = Instantiate(BulletPrefab, transform.position, transform.rotation);
            Clone.GetComponent<Rigidbody>().AddRelativeForce(Vector2.down * BulletSpeed);
            Destroy(Clone, 5.0f);
        }

    }
}
