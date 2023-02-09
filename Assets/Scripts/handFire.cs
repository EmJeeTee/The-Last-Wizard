using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class handFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public float speed;
    public float playTime;
    public float coolDownTime;
    private float nextFireTime = 0.0f;
    public GameObject impactEffect;
    public GameObject Player;

    private void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        Player = GameObject.Find("Player_Isometric_Witch");
    }

    void Update ()
    {
        Vector2 asaPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - asaPosition;
        transform.right = direction;
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Shoot());
                if (Player != null)
                {
                    control();
                }
                nextFireTime = Time.time + coolDownTime;
            }
        }
    }

    IEnumerator Shoot ()
    {
        GameObject newFireBall = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        newFireBall.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        yield return new WaitForSeconds(playTime);
        Destroy(newFireBall);

        //GameObject impactEffectObject = Instantiate(impactEffect, newFireBall.transform.position, newFireBall.transform.rotation);
        //yield return new WaitForSeconds(0.1f);
        //Destroy(impactEffectObject);
    }

    void control()
    {
        if (Player.GetComponent<Player>().point >= 0)
        {
            if (Player != null)
            {
                coolDownTime = 0.5f;
            }
        }
        if (Player.GetComponent<Player>().point >= 10000 && Player.GetComponent<Player>().point <= 20000)
        {
            if (Player != null)
            {
                coolDownTime = 0.375f;
            }
        }
        if (Player.GetComponent<Player>().point > 20000)
        {
            if (Player != null)
            {
                coolDownTime = 0.25f;
            }
        }
    }
}
