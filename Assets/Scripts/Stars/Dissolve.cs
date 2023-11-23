using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    private Material material;
    private ScoreCounter sc;
    //-------------------------------
    private float lerpValue;
    private float dissolveValue = 1;
    private bool isDissolve;
    //================================
    

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        sc = GameObject.Find("StarsManager").GetComponent<ScoreCounter>();
    }

    private void Update()
    {
        if (isDissolve)
        {
            lerpValue += Time.deltaTime;
            dissolveValue = Mathf.Lerp(1, 0, lerpValue);
            material.SetFloat("_Fade", dissolveValue);
        }
        if (dissolveValue <= 0.01f)
        {
            lerpValue = 0;
            isDissolve = false;
            Destroy(gameObject);
        }
        if (sc.takeInCounter >= 150)
        {
            Application.Quit();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("StarDestroy").GetComponent<AudioSource>().Play();
            sc.takeInCounter += 0.1f;
            isDissolve = true;
            GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize += 0.1f;
            var tempX = GameObject.Find("BlackHole").transform.localScale.x;
            var tempY = GameObject.Find("BlackHole").transform.localScale.y;
            GameObject.Find("BlackHole").transform.localScale = new Vector3(tempX + 0.005f, tempY + 0.005f);
        }
    }
}
