using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceOptim : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void OnBecameVisible()
    {
        gameObject.SetActive(true);
    }
}
