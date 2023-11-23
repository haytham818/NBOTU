using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerControll : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayInputController pc;
    private SateAround sateAround;

    private CinemachineImpulseSource cinemachineImpulseSource;
    //_____________________________________________
    [FormerlySerializedAs("ColdTime")] public float coldTime;
    //---------------------------------------------
    public float boostForce;
    public float boostTime;
    //---------------------------------------------
    public float boostStartTime;
    public float boostEndTime;
    public float holdTimeCounter;
    //---------------------------------------------
    private bool isBoost;

    private bool isBoostOver;
    //_____________________________________________
    private float sateNowSpeed;
    //---------------------------------------------
    private float lerpValue = 0;
    private float lerpValue1 = 0;
    private float nowRaduis;
    private float nowRaduis1;
    private float targetRaduis;
    private float targetRaduis1;

    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private CinemachineVirtualCamera cinemachineVirtualCamera1;
    //-----------------------------
    //TODO:自动Boost
    //TODO:卫星半径变大

    private void Awake()
    {
        cinemachineVirtualCamera1 = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        cinemachineVirtualCamera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        rb = GetComponent<Rigidbody2D>();
        sateAround = GameObject.Find("Satellite").GetComponent<SateAround>();
        cinemachineImpulseSource = GameObject.Find("CameraShake").GetComponent<CinemachineImpulseSource>();
        //------------------------------------------------
        pc = new PlayInputController();
        //------------------------------------------------
        pc.Player.Boost.started += OnBoost;
        pc.Player.Boost.canceled += OnBoostOver;
    }
    

    private void OnEnable()
    {
        pc.Enable();
    }

    private void OnDisable()
    {
        pc.Disable();
    }

    private void Update()
    {
        GetPosition();
        //Debug.Log(lerpValue);
        //Debug.Log(isStarDissolve);
        if (isBoost)
        {
            lerpValue += Time.deltaTime * 2;//
            sateAround.radius = Mathf.Lerp(nowRaduis,targetRaduis,lerpValue);//半径增大
            sateAround.speed = Mathf.Lerp(sateNowSpeed, 0, lerpValue * 0.5f);
        }
        if (isBoostOver)
        {
            lerpValue1 += Time.deltaTime * 2;//
            sateAround.radius = Mathf.Lerp(nowRaduis1, targetRaduis1, lerpValue1);//半径减小
        }
        if (transform.localScale.x <= 0.15 && transform.localScale.y <= 0.15)
        {
            SceneManager.LoadScene("Gameplay");
        }
        if (cinemachineVirtualCamera.m_Lens.OrthographicSize <= 15)
        {
            cinemachineVirtualCamera1.m_Lens.OrthographicSize = 15;
        }
    }
    
    private Vector3 GetPosition()
    {
        Vector3 tempVector3 = sateAround.transform.position;//每帧获取Satellite的位置
        return -(transform.position- tempVector3).normalized;//返回Player与Satellite的位置差矢量
    }
    
    private void OnBoost(InputAction.CallbackContext obj)
    { 
        cinemachineImpulseSource.GenerateImpulse();
        GameObject.Find("Takein").GetComponent<AudioSource>().Play();
        sateNowSpeed = sateAround.speed;
        nowRaduis = 10;
        targetRaduis = 20;
        lerpValue1 = 0;
        isBoostOver = false;
        isBoost = true;
        boostStartTime = Time.time;//记录按键时间
    }
    
    private void OnBoostOver(InputAction.CallbackContext obj)
    {
        GameObject.Find("BlackHoleMove").GetComponent<AudioSource>().Play();
        isBoostOver = true;
        boostEndTime = Time.time;//记录松开键的时间
        boostTime = boostEndTime - boostStartTime;//计算按住键的时间
        nowRaduis1 = 20;
        targetRaduis1 = 10;
        if (boostTime >= 3.1f)
        {
            boostTime = 3;
        }
        Boost();
        
    }
    private void Boost()
    {
        StartCoroutine(BoostAndStop());
    }
    
    IEnumerator BoostAndStop()
    {
        rb.AddForce(GetPosition() * (boostForce * boostTime) , ForceMode2D.Impulse);//根据按键的时长改变施加给Player的力
        pc.Disable();
        yield return new WaitForSeconds(0.5f);
        boostTime = 0;//归零 
        lerpValue = 0;//归零lerp插值t               
        sateAround.speed = sateNowSpeed;
        isBoost = false;                                                                    
        yield return new WaitForSeconds(coldTime);
        pc.Enable();
    }
    //---------------------------------------
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("laser"))
        {
            var tempX = GameObject.Find("BlackHole").transform.localScale.x;
            var tempY = GameObject.Find("BlackHole").transform.localScale.y;
            GameObject.Find("BlackHole").transform.localScale = new Vector3(tempX - 0.0005f, tempY - 0.0005f);
            GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize -= 0.01f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("laser"))
        {
            cinemachineImpulseSource.GenerateImpulse();
        }
    }
}
