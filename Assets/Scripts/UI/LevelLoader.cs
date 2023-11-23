using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    
    private PlayInputController playControl;
    
    
    private void Awake()
    {
        playControl = new PlayInputController();
        playControl.UI.InterAction.performed += InterAction;
    }

    private void OnEnable()
    {
        playControl.Enable();
    }

    private void OnDisable()
    {
        playControl.Disable();
    }
    private void InterAction(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene("StoreCG");
    }
    
}
