using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LivesControll : MonoBehaviour
{
    private void Update()
    {
        switch (Player.health)
        {
            case 3:
                break;
            case 2:
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 1:
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case 0:
                //SceneManager.LoadScene(4);
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
