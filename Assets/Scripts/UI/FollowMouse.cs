using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class FollowMouse : MonoBehaviour {
 
    // Use this for initialization
    void Start () {
		
    }
	
    // Update is called once per frame
    void Update () {
        FollowMouseRotate();
        FollowMouseMove();
    }
 
    //物体跟随鼠标旋转
    private void FollowMouseRotate()
    {
        //获取鼠标的坐标，鼠标是屏幕坐标，Z轴为0，这里不做转换  
        Vector3 mouse = Input.mousePosition;
        //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一直  
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        //屏幕坐标矢量相减，得到指向鼠标点的目标矢量，即黄色线段  
        Vector3 direction = mouse - obj;
        //将Z轴置0,保持在2D平面内  
        direction.z = 0f;
        //将目标矢量长度变成1，即单位矢量，这里的目的是只使用矢量的方向，不需要长度，所以变成1  
        direction = direction.normalized;
        //物体自身的Y轴和目标矢量保持一直，这个过程XY轴都会变化数值  
        transform.up = direction;
    }
 
    //跟随鼠标移动
    private void FollowMouseMove()
    {
        float moveSpeed = 3.0f;
        if (Input.GetMouseButton(0))    //如果按下鼠标左键，移动速度变快
        {
            moveSpeed = 6.0f;
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }
}
