using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bim : MonoBehaviour
{
    [SerializeField] private GameObject obj1, onj2;
    
    [SerializeField] private bool i;
    
    private PlayInputController pc;
    private void Update()
    {
        pc = new PlayInputController();
        pc.Player.Boost.started += Bimpact;
    }

    private void Bimpact(InputAction.CallbackContext obj)
    {
        i = !i;
        obj1.SetActive(i);
        obj1.SetActive(i);
    }
}
