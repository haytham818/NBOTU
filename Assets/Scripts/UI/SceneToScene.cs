using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneToScene : MonoBehaviour
{

    private Animator anim;
    private PlayInputController playControl;


    private void Awake()
    {
        playControl = new PlayInputController();
        anim = GetComponent<Animator>();
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
        GameObject.Find("Music Player").GameObject().GetComponent<AudioSource>().Play();
        StartCoroutine(Wait());
    }
    
    IEnumerator Wait()
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(0.8f);

        SceneManager.LoadScene("StoreCG");
    }
   
    
}
