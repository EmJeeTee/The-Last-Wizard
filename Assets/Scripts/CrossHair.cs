using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossHair : MonoBehaviour
{

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Scene_Biome_Desert")
        {
            Cursor.visible = false;
            Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mouseCursorPos;
        }
        if(SceneManager.GetActiveScene().name == "Giris" || SceneManager.GetActiveScene().name == "scoreBoard")
        {
            Cursor.visible = true;
        }
    }
}
