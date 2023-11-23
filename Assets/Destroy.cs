using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private float gameTime;
    private void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime >= 15)
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        gameTime = 0;
    }
}
