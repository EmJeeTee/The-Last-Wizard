using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_movement : MonoBehaviour
{
    private GameObject player;
    public Animator anim;
    public float moveSpeed;

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.Find("Player_Isometric_Witch");
    }

    private void Start()
    {
        //target = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
         if (player != null)
        {
            Vector3 target = player.GetComponent<Player>().transform.position;
            Move(target);
       }

        if (player != null)
        {
            control();
        }
        //if (transform.position.x )
    }

    void Move(Vector2 targetPosition)
    {
        anim.SetBool("canWalk",true);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    void control()
    {
        if (player.GetComponent<Player>().point >= 0)
        {
            moveSpeed = 1.7f;
        }
        if (player.GetComponent<Player>().point >= 10000 && player.GetComponent<Player>().point <= 20000)
        {
            moveSpeed = 1.4f;
        }
        if (player.GetComponent<Player>().point > 20000)
        {
            moveSpeed = 1.1f;
        }
    }
}
