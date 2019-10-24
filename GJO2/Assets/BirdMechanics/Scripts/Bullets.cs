using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.name == "Plane")
            Destroy(gameObject);
    }
}
