using UnityEngine;
using System.Data;
using System.Data.SqlClient;
using Mono.Data.Sqlite;
using System.IO;

public class SQLiteTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //Open Database
        IDbConnection dbcon = OpenConnection();

        CreatePlayerDataTable(dbcon);

        InsertPlayerDataTable(dbcon, "test", "sdfj82929js");
        
        //Read and print all values in table
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;
        string query ="SELECT * FROM player_data";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();
        
        while (reader.Read()){
            Debug.Log("id: " + reader[0].ToString());
            Debug.Log("val: " + reader[1].ToString());
        }
        
        
        //Close connection
        CloseConnection(dbcon);
    }

    string CreateDatabase()
    {
        //Create Database
        string connection = "URI=file:" + Application.persistentDataPath + "/Lernspiel";
        
        return connection;
    }
    

    IDbConnection OpenConnection()
    {
        string connection = CreateDatabase();
        Debug.Log(connection);
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();
        
        return dbcon;
    }

    void CloseConnection(IDbConnection dbcon)
    {
        dbcon.Close();
    }

    void CreatePlayerDataTable(IDbConnection dbcon)
    {
        //Create table
        IDbCommand dbcmd = dbcon.CreateCommand();
        string q_createTable = 
            "CREATE TABLE IF NOT EXISTS player_data (id INTEGER PRIMARY KEY AUTOINCREMENT, username TEXT , device_id TEXT )";
  
        dbcmd.CommandText = q_createTable;
        dbcmd.ExecuteReader();
    }

    void InsertPlayerDataTable(IDbConnection dbcon, string test, string device)
    {
        //Insert values in table
        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = "INSERT INTO player_data (username, device_id) VALUES (test, device)";


        cmnd.ExecuteNonQuery();
    }
}
