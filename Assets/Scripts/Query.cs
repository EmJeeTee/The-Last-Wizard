using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;


public class Query : MonoBehaviour
{
    private string queryDatabase;
    private string cs,cs_new;
    private string createTable;
    private queryCreateTable x;
    private void Start()
    {
        queryDatabase = "CREATE DATABASE theLastWizard";
        cs = @"Data Source =127.0.0.1; User ID =user; Password =beykoz;";
        createTable = "CREATE TABLE Oyun(" +
                      "oyunID INT IDENTITY(1,1)," +
                      "oyunLevel TINYINT NOT NULL," +
                      "canSeviyesi INT," +
                      "saldırıGücüSeviyesi INT," +
                      "CONSTRAINT pk_oyunID PRIMARY KEY(oyunID)" +
                      ");" +
                      "CREATE TABLE Oyuncu (" +
                      "oyuncuID INT IDENTITY(1,1)," +
                      "oyunID INT," +
                      "oyuncuAdı NVARCHAR(50) NOT NULL," +
                      "oyuncuSkor INT," +
                      "oyuncuÖlümSayısı INT," +
                      "CONSTRAINT pk_oyuncuID PRIMARY KEY(oyuncuID)," +
                      "CONSTRAINT fk_oyunID FOREIGN KEY(oyunID) REFERENCES Oyun(oyunID)" +
                      ");" +
                      "INSERT INTO Oyun VALUES(1,80,10)" +
                      "INSERT INTO Oyun VALUES(2,160,20)" +
                      "INSERT INTO Oyun VALUES(3,240,30)";
        
        cs_new = @"Data Source =127.0.0.1; Initial Catalog=theLastWizard; User ID =user; Password =beykoz;";
        
        
        deneme();
    }

    void deneme()
    {
        SqlConnection SqlConn = new SqlConnection(cs);
        SqlConn.Open();
        SqlCommand cmd = new SqlCommand(queryDatabase, SqlConn);
        cmd.ExecuteNonQuery();
        SqlConn.Close();
        deneme_new();
    }

    void deneme_new()
    {
        SqlConnection SqlConn = new SqlConnection(cs_new);
        SqlConn.Open();
        SqlCommand cmd = new SqlCommand(createTable, SqlConn);
        cmd.ExecuteNonQuery();
        SqlConn.Close();
    }
}
