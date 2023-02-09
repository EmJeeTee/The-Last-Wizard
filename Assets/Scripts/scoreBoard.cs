using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data.SqlClient;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class scoreBoard : MonoBehaviour
{
    public TextMeshProUGUI _playerName;
    public TextMeshProUGUI _playerScore;
    public TextMeshProUGUI _playerDeathCount;
    private string cs;

    void Start()
    {
        //cs = @"Data Source =DESKTOP-2G5F79P,1433; Initial Catalog=kaan; User ID =sa; Password =user;";
        cs = @"Data Source =127.0.0.1; Initial Catalog=theLastWizard; User ID =user; Password =beykoz;";
        fromSql();
    }


    public void fromSql()
    {
        SqlConnection sqlConn = new SqlConnection(cs);
        sqlConn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlConn;
        cmd.CommandText = "SELECT oyuncuAdı, oyuncuSkor, oyuncuÖlümSayısı FROM Oyuncu ORDER BY  oyuncuSkor DESC;";
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            _playerName.text += reader["oyuncuAdı"].ToString();
            _playerName.text = _playerName.text.Remove(_playerName.text.Length - 1) + "\n";
            _playerScore.text += reader["oyuncuSkor"].ToString() + "\n";
            _playerDeathCount.text += reader["oyuncuÖlümSayısı"].ToString() + "\n";
        }

        reader.Close();
        sqlConn.Close();
    }

    public void girisEkrani()
    {
        SceneManager.LoadScene("Giris");
    }

    public void cikis()
    {
        Application.Quit();
    }
}