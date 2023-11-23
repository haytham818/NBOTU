using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Around : MonoBehaviour
{
    private Transform trans;
    public float zAngle;
    
    
    private void Awake()
    {
        trans = GetComponent<Transform>(); 
    }

    private void Update()
    {
        
    }


    private void Round()
    {
        zAngle += 10f*Time.deltaTime;
        transform.Rotate(0, 0, zAngle, Space.Self);
    }
    
    
}
