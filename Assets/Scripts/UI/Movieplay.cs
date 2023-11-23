using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Movieplay : MonoBehaviour
{
    private VideoPlayer video2;
    private void Awake()
    {
        video2 = GetComponent<VideoPlayer>();
        video2.loopPointReached += test; //设置委托
    }
    void test(VideoPlayer video)//video = video2
    {
        Debug.Log("播放完毕");
        SceneManager.LoadScene("Dialog");
    }
}
