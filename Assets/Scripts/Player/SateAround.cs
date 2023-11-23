using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SateAround : MonoBehaviour
{
    private Transform targetTaTrans;
    private Vector3 dir;
    [Header("旋转半径和速度")]
    public float radius;
    public float speed;
    private GameObject o;

    private void Awake()
    {
        o = GameObject.Find("BlackHole");
        targetTaTrans = GameObject.Find("BlackHole").GetComponent<Transform>();
    }
    private void Start()
    {
        dir = this.transform.position - targetTaTrans.position;
    }
    private void Update()
    {
        transform.position = targetTaTrans.position + dir.normalized * radius;
        this.transform.RotateAround(targetTaTrans.position,Vector3.forward,speed *Time.deltaTime );
        dir = transform.position - targetTaTrans.position;
        
        Vector3 v = o.transform.position - transform.position; //首先获得目标方向
        v.z = 0; //这里一定要将z设置为0
        float angle = Vector3.SignedAngle(Vector3.up, v, Vector3.forward); //得到围绕z轴旋转的角度
        Quaternion rotation = Quaternion.Euler(0, 0, angle); //将欧拉角转换为四元数
        transform.rotation = rotation;
    }
}
