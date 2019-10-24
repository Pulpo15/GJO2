using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    private Rigidbody rb;

    private int cooldown = 2;
    private float currentCooldown;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentCooldown = cooldown;
    }
    
    void Update()
    {
        currentCooldown -= Time.deltaTime * 1;

        if (currentCooldown < 0) rb.AddForce(Vector3.down);
        else rb.AddForce(Vector3.up);
    }
}
