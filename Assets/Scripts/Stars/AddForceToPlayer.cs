using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;

public class AddForceToPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayInputController pc;
    private Dissolve dissolve;
    public List<GameObject> enemies;
    private ScoreCounter sc;

    private Vector3 position;
    //---------------------------------
    private void Awake()
    {
        position = transform.position;
        rb = GetComponent<Rigidbody2D>();
        pc = new PlayInputController();
        dissolve = GetComponent<Dissolve>();
        sc = GameObject.Find("StarsManager").GetComponent<ScoreCounter>();
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
    }
     
    private Vector3 GetPosition()
    {
        Vector3 tempPosition = GameObject.Find("BlackHole").transform.position;
        return -(transform.position - tempPosition).normalized;
    }
     private void OnTriggerStay2D(Collider2D other)
     {
         if (other.CompareTag("Satellite"))
         {
             //Debug.Log("Will Give Force");
             rb.AddForce(GetPosition() * 10,ForceMode2D.Force);
             CreatEnemy();
         }
     }

     private void CreatEnemy()
     {
         StartCoroutine(ToCreatEnemy());
     }

     IEnumerator ToCreatEnemy()
     {
         var randomIndex = UnityEngine.Random.Range(0, enemies.Count);
         var random = UnityEngine.Random.Range(0,1000);
         yield return new WaitForSeconds(0.8f);
         if (random == 5)
         {
             Instantiate(enemies[randomIndex],position, Quaternion.identity);
         }
     }
}
