using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Text;

namespace FriendOrganizer.DataAccess
{
    public class Connection
    {
        static string connectionString = "Data Source='TestDB.sdf';";

        public void ConnectToDB()
        {
            if (!File.Exists("TestDB.sdf"))
            {
                SqlCeConnection connection = null;
                try
                {
                    SqlCeEngine en = new SqlCeEngine(connectionString);
                    en.CreateDatabase();

                    connection = new SqlCeConnection(connectionString);
                    connection.Open();

                    SqlCeCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "CREATE TABLE Accounts(Account_Type nvarchar(20), Posting_Type nvarchar(20)) ";
                    cmd.ExecuteNonQuery();

                    SqlCeCommand insert = connection.CreateCommand();
                    insert.CommandText = "INSERT INTO Accounts(Account_Type, Posting_Type) VALUES('Cash', 'Asset')";
                    insert.ExecuteNonQuery();

                    insert = connection.CreateCommand();
                    insert.CommandText = "INSERT INTO Accounts(Account_Type, Posting_Type) VALUES('Sales', 'Revenue')";
                    insert.ExecuteNonQuery();
                }
                finally
                {
                    if(connection != null)
                    {
                        connection.Close();
                    }
                    
                }
            }
            
        }

        public string getDBData()
        {
            string text = "";
            SqlCeConnection connection = new SqlCeConnection(connectionString);
            try
            {
                connection.Open();
                SqlCeCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Accounts";
                SqlCeDataReader data = cmd.ExecuteReader();
                StringBuilder table = new StringBuilder();
                table.AppendLine($"  {data.GetName(0)}       {data.GetName(1)}   ");
                table.AppendLine("-----------------------------------------");
                while(data.Read())
                {
                    table.AppendLine($"        {data.GetString(0)}               {data.GetString(1)}   ");
                }

                text = table.ToString();
            }
            finally
            {
                connection.Close();
            }
            return text;
        }
    }
}
