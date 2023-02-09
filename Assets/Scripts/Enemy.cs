using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 80.0f;
    public float damage = 10.0f;
    [SerializeField] private Animator _animator;
    //public AnimationClip deathEffect;
    //public AnimationClip takeDamageEffect;
    public GameObject Player;
    private SpriteRenderer _SpriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        //Player = GameObject.FindGameObjectWithTag("Player");
        Player = GameObject.Find("Player_Isometric_Witch");
    }

    public void TakeDamage(float damage)
    {
        StartCoroutine(healthDebuff());
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(healthDebuff());
            Destroy(gameObject);
            Player.GetComponent<Player>().killCount++;
        }
    }
    
    private IEnumerator healthDebuff()
    {
        _SpriteRenderer.color = Color.red;
        yield return new WaitForSecondsRealtime(0.5f);
        _SpriteRenderer.color = Color.white;
    }
}

    
