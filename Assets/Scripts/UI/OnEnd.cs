using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnEnd : MonoBehaviour
{
    private PlayInputController playControl;
    
    private void Awake()
    {
        playControl = new PlayInputController();
        playControl.Player.Boost.started += Quit;
    }


    private void OnEnable()
    {
        playControl.Enable();
    }

    private void OnDisable()
    {
        playControl.Disable();
    }


    private void Quit(InputAction.CallbackContext obj)
    {
        StartCoroutine(Wait());
    }


    IEnumerator Wait()
    {
        GameObject.Find("Music Player").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.0f);
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
    
}
