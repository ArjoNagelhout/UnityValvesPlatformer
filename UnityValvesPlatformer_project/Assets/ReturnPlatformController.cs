﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPlatformController : MonoBehaviour
{
    public Animator animator;
    public ValvesController valvesController;
    public ValveController valveController;


    public float minPercentage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (valveController.active && valvesController.currentPercentage >= minPercentage) {

            animator.SetBool("still", false);
            
        }
        else
        {
            animator.SetBool("still", true);
            
        }
    }
}
