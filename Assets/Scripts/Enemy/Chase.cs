using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    private Rigidbody2D rb;
    public float chaseSpeed;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    

    private Vector3 GetPosition()
    {
        Vector3 tempPosition = GameObject.Find("BlackHole").transform.position;
        return -(transform.position - tempPosition).normalized;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rb.velocity = new Vector2(GetPosition().x * chaseSpeed, GetPosition().y * chaseSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;
        }
    }
}
