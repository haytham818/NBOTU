using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class scenetoscene2 : MonoBehaviour
{


    private Animator anim;
    private PlayInputController playControl;


    private void Awake()
    {
        anim = GetComponent<Animator>();
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
        Debug.Log("Test");
        StartCoroutine(Wait());
    }



    IEnumerator Wait()
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("SampleScene");
    }
   
    
}

