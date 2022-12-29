using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace SH_company.Models
{
    public class ProjectDB
    {
        private MySqlConnection dbConn;
        private string connectDB_Path;
        DataTable dataTable = new DataTable();

        public ProjectDB(string pDBIp, string pDBPort, string pDBName, string pDBUser, string pDBPasswd)
        {
            connectDB_Path = $"Server=" + pDBIp + ";" +
                              "Uid=" + pDBUser + ";" +
                              "Database=" + pDBName + ";" +
                              "Port=" + pDBPort + ";" +
                              "pwd=" + pDBPasswd + ";" +
                              "allow user variables=true;";
        }

        public Boolean createDataBase(string database)
        {
            bool result = false;

            using (dbConn = new MySqlConnection (connectDB_Path))
            {
                try
                {
                    dbConn.Open();

                    MySqlCommand cmd = dbConn.CreateCommand();

                    string createQuery = $"CREATE DATABASE `{database}`";

                    cmd.CommandText = createQuery;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.ExecuteReader();

                    cmd.Dispose();

                    dbConn.Close();
                    dbConn.Dispose();

                    result = true;
                }
                catch (Exception)
                {

                    result = false;
                }
            }

            return result;
        }

        public Boolean createTable(string tableName)
        {
            bool result = false;

            using (dbConn = new MySqlConnection(connectDB_Path))
            {
                try
                {
                    dbConn.Open();

                    MySqlCommand cmd = dbConn.CreateCommand();

                    string createQuery = $"CREATE TABLE IF NOT EXISTS `rcsplace` (" +
                                         "`no` INT NOT NULL," +
                                         "`place` VARCHAR(20) NULL DEFAULT NULL," +
                                         "`sale` VARCHAR(10) NULL DEFAULT NULL," +
	                                     "`construct` VARCHAR(10) NULL DEFAULT NULL," +
	                                     "`service` VARCHAR(10) NULL DEFAULT NULL," +
	                                     "`roomcount` INT NULL," +
                                         "PRIMARY KEY(`no`)" + ") COLLATE = 'armscii8_bin'; ";

                    cmd.CommandText = createQuery;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.ExecuteReader();

                    cmd.Dispose();

                    dbConn.Close();
                    dbConn.Dispose();

                    result = true;
                }
                catch (MySqlException ex1)
                {
                    MessageBox.Show(ex1.Message);
                    result = false;
                }
                catch (AggregateException ex2)
                {
                    MessageBox.Show(ex2.Message);
                    result = false;
                }
            }

            return result;
        }


        public Boolean insertPlace(string place, string sales, string construction, string service, int intRoomCount)
        {
            bool result = false;

            using (dbConn = new MySqlConnection(connectDB_Path))
            {
                try
                {
                    dbConn.Open();

                    MySqlCommand cmd = dbConn.CreateCommand();

                    string insertQuery = $"INSERT INTO rcsplace(place, sale ,pm ,asas ,roomcount) VALUES ('{place}', '{sales}', '{construction}', '{service}', '{intRoomCount}');";

                    cmd.CommandText = insertQuery;
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteReader();

                    cmd.Dispose();

                    dbConn.Close();
                    dbConn.Dispose();

                    result = true;
                }
                catch (MySqlException ex1)
                {
                    MessageBox.Show(ex1.Message);
                    result = false;
                }
                catch (AggregateException ex2)
                {
                    MessageBox.Show(ex2.Message);
                    result = false;
                }
            }

            return result;
        }

        public Boolean deletePlace(string select)
        {
            bool result = false;

            using (dbConn = new MySqlConnection(connectDB_Path))
            {
                try
                {
                    dbConn.Open();


                    MySqlCommand cmd = dbConn.CreateCommand();

                    string deleteQuery = $"DELETE FROM rcsplace WHERE no={select};" +
                                          "SET @COUNT=0;" +
                                          "UPDATE rcsplace SET NO=@COUNT:=@COUNT+1;";
                                             

                    cmd.CommandText = deleteQuery;
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteReader();
                    cmd.Dispose();

                    dbConn.Close();
                    dbConn.Dispose();

                    result = true;
                }
                catch (MySqlException ex1)
                {
                    MessageBox.Show(ex1.ToString());
                    result = false;
                }
                catch (AggregateException ex2)
                {
                    MessageBox.Show(ex2.Message);
                    result = false;
                }
            }

            return result;
        }

        public DataTable showPlace()
        {

            using(dbConn = new MySqlConnection(connectDB_Path))
            {
                try
                {
                    dbConn.Open();

                    //MySqlCommand cmd = dbConn.CreateCommand();

                    string readTable = $"SELECT * FROM rcsplace ORDER BY No;";

                    //cmd.CommandText = readTable;
                    //cmd.CommandType = CommandType.Text;

                    MySqlDataAdapter adapter = new MySqlDataAdapter(readTable, dbConn);

                    dataTable.Clear();

                    adapter.Fill(dataTable);

                    dbConn.Close();
                    dbConn.Dispose();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return dataTable;
        }
    }
}
