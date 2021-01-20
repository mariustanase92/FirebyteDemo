using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Basket : MonoBehaviour
{
    
    private Transform basketPos;

    private void Awake()
    {   
        basketPos = GetComponent<Transform>();
    
    } 
}
