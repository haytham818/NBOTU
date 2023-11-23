using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DialogControl : MonoBehaviour
{
    private PlayInputController playControl;
    public List<GameObject> dialogs = new List<GameObject>();
    private int currentDialog = 0;


    private void Awake()
    {
        playControl = new PlayInputController();
        playControl.UI.InterAction.started += SwitchText;
    }
    
    private void OnEnable()
    {
        playControl.Enable();
    }

    private void OnDisable()
    {
        playControl.Disable();
    }
    
    
    
    private void SwitchText(InputAction.CallbackContext obj)
    {
        GameObject.Find("Music Player").GetComponent<AudioSource>().Play();
        if (currentDialog < dialogs.Count-1)
        {
            dialogs[currentDialog].SetActive(false);
            dialogs[currentDialog+1].SetActive(true);
            currentDialog++;
        }
        else
        {
            Debug.Log("jiehsu1");
            SceneManager.LoadScene("Gameplay");
        }
    }
    
}
