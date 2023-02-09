using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data.SqlClient;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class currentLevel : MonoBehaviour
{
    public TextMeshProUGUI _oyunID;
    private string cs;
    private GameObject player;
    
    void Start()
    {
        //cs = @"Data Source =DESKTOP-2G5F79P,1433; Initial Catalog=kaan; User ID =sa; Password =user;";
        cs = @"Data Source =127.0.0.1; Initial Catalog=theLastWizard; User ID =user; Password =beykoz;";
        player = GameObject.Find("Player_Isometric_Witch");
    }

    private void Update()
    {
        if (player != null)
        {
            fromSql();
        }
    }

    public void fromSql()
    {
        SqlConnection sqlConn = new SqlConnection(cs);
        sqlConn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlConn;
        cmd.CommandText = "SELECT * FROM Oyuncu WHERE oyuncuID =" +  player.GetComponent<Player>().playerID;
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        { 
            _oyunID.text = "LEVEL: " + reader["oyunID"].ToString();
        }
        reader.Close();
        sqlConn.Close();
    }
}
