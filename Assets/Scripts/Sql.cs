using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System.Xml.Schema;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sql : MonoBehaviour
{
    private string cs;
    public TextMeshProUGUI _toSql;
    public static int veri;
    private string sceneName;
    public TextMeshProUGUI hataliGiris;
    public TextMeshProUGUI olusturHesap;
    public TextMeshProUGUI girisHesap;
    void Start()
    {
        //cs = @"Data Source =DESKTOP-2G5F79P,1433; Initial Catalog=kaan; User ID =sa; Password =user;";
        cs = @"Data Source =127.0.0.1; Initial Catalog=theLastWizard; User ID =user; Password =beykoz;";
    }

    private void Awake()
    {
        sceneName = "Scene_Biome_Desert";
    }

    public void temp()
    {
        if (_toSql.text.Length < 2)
        {
            hataliGiris.text = "Kullanıcı adı girişi hatalı.Lütfen gecerli bir kullanıcı adı giriniz.";
        }
        else
        {
            Destroy(hataliGiris);
            fromSql(_toSql);
            bum(_toSql);
            StartCoroutine(loadScene(sceneName));
        }
    }

    public void ToSql()
    {
        SqlConnection SqlConn = new SqlConnection(cs);
        SqlConn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Oyuncu VALUES(1,'" + _toSql.text + "',0,0)",SqlConn);
        cmd.ExecuteNonQuery();
        girisHesap.text = _toSql.text + " isimli kullanıcı oluşturuldu. " + _toSql.text + " isimli kullanıcı ile giriş yapılıyor.";
        SqlConn.Close();
    }

    public void fromSql(TextMeshProUGUI x)
    {
        SqlConnection sqlConn = new SqlConnection(cs);
        sqlConn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlConn;
        x.text = x.text + "?";
        cmd.CommandText = "SELECT oyuncuAdı FROM Oyuncu WHERE oyuncuAdı = '"+x.text+"'";
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read() == false)
        {
            ToSql();
            Destroy(olusturHesap);
        }
        olusturHesap.text = _toSql.text + " isimli kullanıcı ile giriş yapılıyor.";
        reader.Close();
        sqlConn.Close();
    }
    
    public void bum(TextMeshProUGUI a)
    {
        SqlConnection SqlConn = new SqlConnection(cs);
        SqlConn.Open();
        SqlCommand cmd = new SqlCommand("SELECT oyuncuID FROM Oyuncu WHERE oyuncuAdı = '"+a.text+"'",SqlConn);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read() == true)
        {
            veri = reader.GetInt32(0);
        }
        reader.Close();
        SqlConn.Close();
    }
    
    public IEnumerator loadScene(string sceneName)
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(sceneName);
    }
    
}
