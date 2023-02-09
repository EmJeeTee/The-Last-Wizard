using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class fireBall : MonoBehaviour {

    public float damage = 80.0f;
    private Rigidbody2D rb;
    //public GameObject impactEffect;
    //public GameObject impactEffect;
    private GameObject playerPoint;
    private string enemyy;
    private string decorations;
    private string ground;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerPoint = GameObject.FindGameObjectWithTag("Player");
        //int puan = playerPoint.GetComponent<Player>().point;
        playerPoint = GameObject.Find("Player_Isometric_Witch");
        enemyy = "enemy";
        decorations = "Decorations";
        ground = "ground";
    }

    /*private void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.x, rb.velocity.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }*/

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        
        
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (hitInfo.gameObject.tag == enemyy  || hitInfo.gameObject.tag == decorations || hitInfo.gameObject.tag == ground)
        {
            Destroy(gameObject);
            if (hitInfo.gameObject.tag == enemyy)
            {
                playerPoint.GetComponent<Player>().point += 100;
                //playerPoint.GetComponent<Player>().killCount++;
            }
            //StartCoroutine(destroyFireBall());
           // GameObject effect = Instantiate(impactEffect, hitInfo.transform.position, Quaternion.identity);
            //Destroy(gameObject);
            //StartCoroutine(sleep());
            //Destroy(effect);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);
    }

    /*IEnumerator sleep()
    {
        yield return new WaitForSeconds(0.1f);
    }*/
	
}