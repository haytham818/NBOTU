using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeOver : MonoBehaviour
{


    public float timeUp;
    public float time;
    
    private void Update()
    {
        time += Time.deltaTime;
        TimeIsUp();
    }

    private void TimeIsUp()
    {
        if (time >= timeUp)
        {
            SceneManager.LoadScene("ThanksForPlaying");
        }
    }
    
}
