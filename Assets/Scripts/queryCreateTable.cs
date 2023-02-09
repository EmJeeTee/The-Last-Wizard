using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;

public class queryCreateTable : MonoBehaviour
{
    private string CreateTable;
    private string cs;
    private Query txt;
    void Start()
    {
        CreateTable = "CREATE TABLE Oyun(" +
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
        
        cs = @"Data Source =127.0.0.1; Initial Catalog=theLastWizard; User ID =user; Password =beykoz;";
    }

    public void deneme()
    {
        SqlConnection SqlConn = new SqlConnection(cs);
        SqlConn.Open();
        SqlCommand cmd = new SqlCommand(CreateTable, SqlConn);
        cmd.ExecuteNonQuery();
        SqlConn.Close();
    }
}
