using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCtol : MonoBehaviour
{
    private Animator anim1;
    private Animator anim2;
    private Animator anim3;
    private Animator anim4;
    private Animator anim5;
    private Animator anim6;

    
    private void Awake()
    {
        anim1 = GameObject.Find("NBOTU1").GetComponent<Animator>();
        anim2 = GameObject.Find("恩博图 2").GetComponent<Animator>();
        anim3 = GameObject.Find("3").GetComponent<Animator>();
        anim4 = GameObject.Find("4").GetComponent<Animator>();
        anim5 = GameObject.Find("5").GetComponent<Animator>();
        anim6 = GameObject.Find("6").GetComponent<Animator>();
        

    }

    private void OnEnable()
    {
        StartCoroutine(Wait());
    }


    private IEnumerator Wait()
    {
        anim1.SetBool("Can1Run",true);
        yield return new WaitForSeconds(1f);
        anim2.SetBool("Can2Run",true);
        yield return new WaitForSeconds(1f);
        anim3.SetBool("Can3Run",true);
        yield return new WaitForSeconds(0.8f);
        anim4.SetBool("Can4Run",true);
        yield return new WaitForSeconds(0.8f);
        anim5.SetBool("Can5Run",true);
        yield return new WaitForSeconds(0.8f);
        anim6.SetBool("Can6Run",true);
    }
}
