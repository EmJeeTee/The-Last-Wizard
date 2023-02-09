using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBuff : MonoBehaviour
{
    public Slider slider;
    public GameObject player;
    
    

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.Find("Player_Isometric_Witch");
        SetMaxValue();
    }
    
    public void SetMaxValue()
    {
        slider.maxValue = 6f;
        slider.value = 0f;
    }

    public void SetValue(float x)
    {
        slider.value = x;
    }

    private void Update()
    {
        if (player != null)
        {
            SetValue(player.GetComponent<Player>().killCount);
        }
    }
}
