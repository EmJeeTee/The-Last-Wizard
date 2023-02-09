using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

public class spawnEnemy : MonoBehaviour
{
    public GameObject _enemy;

    private void Start()
    {
        StartCoroutine(spawnEnemyA(_enemy));
        StartCoroutine(spawnEnemyB(_enemy));
        StartCoroutine(spawnEnemyC(_enemy));
        StartCoroutine(spawnEnemyD(_enemy));
    }
    

    IEnumerator spawnEnemyA(GameObject _enemy)
    {
        Random random = new Random();
        int x = random.Next(3,6);
        yield return new WaitForSeconds(x);
        GameObject newEnemy = Instantiate(_enemy, new Vector3(0.84f,4.66f,0), Quaternion.identity);
        StartCoroutine(spawnEnemyA(_enemy));

    }
    IEnumerator spawnEnemyB(GameObject _enemy)
    {
        Random random = new Random();
        int x = random.Next(3,6);
        yield return new WaitForSeconds(x);
        GameObject newEnemy = Instantiate(_enemy, new Vector3(-9.54f,-0.19f,0), Quaternion.identity);
        StartCoroutine(spawnEnemyB(_enemy));

    }
    IEnumerator spawnEnemyC(GameObject _enemy)
    {
        Random random = new Random();
        int x = random.Next(3,6);
        yield return new WaitForSeconds(x);
        GameObject newEnemy = Instantiate(_enemy, new Vector3(9.01f,2.54f,0), Quaternion.identity);
        StartCoroutine(spawnEnemyC(_enemy));

    }
    IEnumerator spawnEnemyD(GameObject _enemy)
    {
        Random random = new Random();
        int x = random.Next(3,6);
        yield return new WaitForSeconds(x);
        GameObject newEnemy = Instantiate(_enemy, new Vector3(0.48f,-5.07f,0), Quaternion.identity);
        StartCoroutine(spawnEnemyD(_enemy));

    }
    
}
