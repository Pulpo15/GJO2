using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDeath : MonoBehaviour
{
    public bool Dead;

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.name == "J2Bullet(Clone)"){
            gameObject.active = false;
            Dead = true;
        }
    }
}
