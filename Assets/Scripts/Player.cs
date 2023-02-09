using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data.SqlClient;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static float health = 100.0f;
    private string cs;
    public int point = 0;
    public int temp;
    [SerializeField] private TextMeshProUGUI _text;
    public int playerID;
    private static string query;
    private static string query_;
    private static string olumSayisiArttirma;
    private int dbPoint;
    private string sceneName;
    public HealthBar HealthBar;
    public float killCount;
    public SpriteRenderer _SpriteRenderer;
    public Enemy enemy;
    private int durum = 1;
    public int olusturuldu = 0;
    
    private void Start()
    {
        StartCoroutine(pointPlus());
        //cs = @"Data Source =DESKTOP-2G5F79P,1433; Initial Catalog=kaan; User ID =sa; Password =user;";
        cs = @"Data Source =127.0.0.1; Initial Catalog=theLastWizard; User ID =user; Password =beykoz;";
        EnemyStatuControl();
        point += temp;
    }

    private void Awake()
    {
        playerID = Sql.veri;
        sceneName = "scoreBoard";
        HealthBar.SetMaxHealt(health);
        olusturuldu = 1;
    }

    private void Update()
    {
        _text.text = point.ToString();
        HealthBar.SetHealth(health);
        canArttırma();
        EnemyStatuControl();
    }

    public void takeDamage(float damage)
    {
        StartCoroutine(healthDebuff());
        health -= damage;
        if (health <= 0.0f)
        {
            Destroy(gameObject);
            UpdateStatu();
            SceneManager.LoadScene(sceneName);
            health = 100.0f;
        }
    }

    IEnumerator pointPlus()
    {
        yield return new WaitForSeconds(0.3f);
        point++;
        StartCoroutine(pointPlus());
    }

    void UpdateStatu()
    {
        SqlConnection SqlConn = new SqlConnection(cs);
        SqlConn.Open();
        query = "UPDATE Oyuncu SET oyuncuSkor = " + point + " WHERE oyuncuID =" + playerID + "AND oyuncuSkor <" + point;
        olumSayisiArttirma = "UPDATE Oyuncu SET oyuncuÖlümSayısı = oyuncuÖlümSayısı + 1 WHERE oyuncuID =" + playerID;
        SqlCommand cmd = new SqlCommand(query,SqlConn);
        SqlCommand _cmd = new SqlCommand(olumSayisiArttirma, SqlConn);
        cmd.ExecuteNonQuery();
        _cmd.ExecuteNonQuery();
        SqlConn.Close();
    }
    
    
    void canArttırma()
    {
        if ((killCount / 6) != 1)
        {
        }
        else
        {
            if (health == 100.0f)
            {
            }
            else
            {
                health += 10.0f;
                StartCoroutine(healthBuff());
            }
            killCount = 0.0f;

        }
    }

    private IEnumerator healthBuff()
    {
        _SpriteRenderer.color = Color.green;
        yield return new WaitForSecondsRealtime(1f);
        _SpriteRenderer.color = Color.white;
    }
    
    private IEnumerator healthDebuff()
    {
        _SpriteRenderer.color = Color.red;
        yield return new WaitForSecondsRealtime(0.2f);
        _SpriteRenderer.color = Color.white;
    }

    void EnemyStatuControl()
    {
        SqlConnection SqlConn = new SqlConnection(cs);
        SqlConn.Open();

        if(point >= 0)
        {
            if (enemy != null)
            {
                durum = 1;
                enemy.GetComponent<Enemy>().damage = 10.0f;
                enemy.GetComponent<Enemy>().health = 80.0f;
            }
        }
        if (point >= 10000 && point <= 20000)
        {
            if (enemy != null)
            {
                durum = 2;
                enemy.GetComponent<Enemy>().damage = 20.0f;
                enemy.GetComponent<Enemy>().health = 160.0f;
            }
        }

        if (point > 20000)
        {
            if (enemy != null)
            {
                durum = 3;
                enemy.GetComponent<Enemy>().damage = 30.0f;
                enemy.GetComponent<Enemy>().health = 240.0f;

            }
        }
        
        query = "UPDATE Oyuncu SET oyunID = " + durum + " WHERE oyuncuID =" + playerID + "AND oyuncuSkor <" + point;
        query_ = "SELECT oyuncuSkor FROM Oyuncu WHERE oyuncuID =" + playerID;
        SqlCommand cmd = new SqlCommand(query,SqlConn);
        SqlCommand cmd_ = new SqlCommand(query_,SqlConn);
        SqlDataReader reader = cmd_.ExecuteReader();
        if (reader.Read())
        {
            temp = reader.GetInt32(i:0);
        }
        reader.Close();
        cmd.ExecuteNonQuery();
        SqlConn.Close();
    }
}
