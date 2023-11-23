using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject laser;
    private float lerpValue;
    private float dissolveValue;
    private Material material;
    private float gameTime;
    public bool isCheck;
    private Animator animator;
    private Animator animator1;

    private void Awake()
    {
        animator1 = laser.GetComponent<Animator>();
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Start()
    {
        
    }

    private void OnDisable()
    {
        gameTime = 0;
        isCheck = false;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime >= 15)
        {
            lerpValue += Time.deltaTime;
            dissolveValue = Mathf.Lerp(1, 0, lerpValue);
            material.SetFloat("_Fade", dissolveValue);
            if (dissolveValue <= 0.01f)
            {
                Destroy(gameObject);
                isCheck = false;
            }
        }
        Vector3 v = GameObject.Find("BlackHole").transform.position - transform.position; //首先获得目标方向
        v.z = 0; //这里一定要将z设置为0
        float angle = Vector3.SignedAngle(Vector3.up, v, Vector3.forward); //得到围绕z轴旋转的角度
        Quaternion rotation = Quaternion.Euler(0, 0, angle); //将欧拉角转换为四元数
        if (isCheck)
        {
            transform.rotation = rotation ;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("EnemyComeOut").GetComponent<AudioSource>().Play();
            laser.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCheck = false;
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        animator1.SetTrigger("Out");
        yield return new WaitForSeconds(1f);
        laser.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        
    }
}
