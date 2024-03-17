using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class Car : MonoBehaviour
{
    private SplineFollower splineFollower => GetComponent<SplineFollower>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Ground")
            splineFollower.follow = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Ground")
            splineFollower.follow = true;
    }
}