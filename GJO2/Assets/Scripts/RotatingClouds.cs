﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingClouds : MonoBehaviour
{

    public int speed;
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
    }
}