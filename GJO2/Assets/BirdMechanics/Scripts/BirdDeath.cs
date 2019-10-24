using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDeath : MonoBehaviour {
    public PlayerController pc;
    public bool Dead;
   // public GameObject explosionParticleEffect;
    private void OnTriggerEnter(Collider collider) {    
        if (collider.gameObject.tag == "Plane"){
            pc.KillBird();
            Dead = true;
            this.gameObject.SetActive(false);
      //      Instantiate(explosionParticleEffect, this.transform.position, Quaternion.identity);

        }
    }
}
