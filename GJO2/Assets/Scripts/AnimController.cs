using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public GameObject balloonLeft;
    public GameObject balloonRight;

    private Animator anim;

    private int cooldown = 1;
    private float currentCooldown;

    void Start()
    {
        anim = FindObjectOfType<Animator>();
        currentCooldown = cooldown;
    }
   
    void Update()
    {
        currentCooldown -= Time.deltaTime * 1;

        if (currentCooldown < 0) anim.SetBool("cooldown", true);
    }
}
