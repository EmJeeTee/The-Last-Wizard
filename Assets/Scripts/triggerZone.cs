using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class triggerZone : MonoBehaviour
{
    private GameObject Player;
    public GameObject Enemy;
    private float enemyDamage;

    private void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        //Enemy = GameObject.FindGameObjectWithTag("enemy");
        Player = GameObject.Find("Player_Isometric_Witch");
        Enemy = GameObject.Find("Enemy(Clone)");

    }

    private void Update()
    {
        if (Enemy != null)
        {
            enemyDamage = Enemy.GetComponent<Enemy>().damage;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Player _player = other.GetComponent<Player>();
        if (other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Decorations") && !other.gameObject.CompareTag("enemy"))
        {
            if(/*Enemy != null &&*/ Player != null)
            {
                //Player.GetComponent<Player>().takeDamage(Enemy.GetComponent<Enemy>().damage);
            Player.GetComponent<Player>().takeDamage(enemyDamage);
            Player.GetComponent<Player>().killCount = 0.0f;
            }
            Destroy(gameObject);
        }
    }
}
