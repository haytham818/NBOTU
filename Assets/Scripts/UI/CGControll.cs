using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CGControll : MonoBehaviour
{
    public bool isAniming;
    private void Awake()
    {
        isAniming = true;
    }

    private void EXitScene()
    {
        if (isAniming == false)
        {
            SceneManager.LoadScene("StartAnimation");
        }
    }
}
