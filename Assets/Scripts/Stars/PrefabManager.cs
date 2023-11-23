using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PrefabManager : MonoBehaviour
{
    public List<GameObject> stars;
    List<Vector2> allPos = new List<Vector2>();//存储生成的位置
    private int randomIndex;
    public float spawnRaduis;
    public int starCount;

    private void Awake()
    {
        GenerateRandomPos();
    }

    private void Start()
    {
        for (int i = 0; i < starCount; i++)
        {
            randomIndex = UnityEngine.Random.Range(0, stars.Count);
            Instantiate(stars[randomIndex],allPos[i], Quaternion.identity);
        }
    }

    private void GenerateRandomPos()
    {
        int count = starCount;//生成点的个数
        //四个区域的单位顶点
        Vector2[] allArea = { new Vector2(spawnRaduis, spawnRaduis), new Vector2(spawnRaduis, -spawnRaduis), new Vector2(-spawnRaduis, spawnRaduis), new Vector2(-spawnRaduis, -spawnRaduis) };
        for(int i=0;i<count;i++)
        {
            Vector2 pos = UnityEngine.Random.insideUnitCircle;//随机一个圆内的位置出来
            float x = (pos.x);
            float y = (pos.y);
            int index = i % allArea.Length;//计算allArea的下标
            Vector2 point = new Vector2(x, y) * allArea[index];//确定这个点所在的区域
            allPos.Add(point);//把点存起来
        }
    }
    
}
