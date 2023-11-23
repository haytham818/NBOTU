using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollCheckSet : MonoBehaviour
{
    private CircleCollider2D circleCollider2D;
    private GameObject blackHole;
    private GameObject satellite;
    private void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        blackHole = GameObject.Find("BlackHole");
        satellite = GameObject.Find("Satellite");
    }
    private void Update()
    {
        transform.position = blackHole.transform.position;
        circleCollider2D.radius = (blackHole.transform.position - satellite.transform.position).magnitude * 2;
    }
    
}
