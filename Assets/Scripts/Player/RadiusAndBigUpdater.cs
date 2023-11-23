using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadiusAndBigUpdater : MonoBehaviour
{
    private ScoreCounter scoreCounter;
    

    private void Awake()
    {
        scoreCounter = GameObject.Find("StarsManager").GetComponent<ScoreCounter>();
    }

    private void Update()
    {
        if (transform.localScale.x >= 1.15 && transform.localScale.y >=1.15)
        {
            SceneManager.LoadScene("ThanksForPlaying");
        }
    }
}
