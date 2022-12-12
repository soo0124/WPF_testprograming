using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_DB.MODELS
{
    public delegate void DBReceiveHandler(IDataRecord dataRecord);

    public class MariaDB
    {
        public MySqlConnection DBCONN;

        private string connectionPath;

        //public event DBReceiveHandler DBReceive;

        DataTable dataTable = new DataTable();

        public MariaDB(string pDBIp, string pDBPort, string pDBName, string pDBUser, string pDBPasswd)
        {
            connectionPath = $"Server=" + pDBIp + ";" +
                              "Uid=" + pDBUser + ";" +
                              "Database=" + pDBName + ";" +
                              "Port=" + pDBPort + ";" +
                              "pwd=" + pDBPasswd;
        }


        public Boolean Access_Insert(int intNo, int intCode, int boolDiv, string dateTime)
        {
            Boolean result = false;

            using (MySqlConnection conn = new MySqlConnection(connectionPath))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = conn.CreateCommand();

                    String insertSql = $"INSERT INTO access VALUES ('{intNo}', '{intCode}', '{boolDiv}', '{dateTime}');";

                    cmd.CommandText = insertSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteReader(); //실행 

                    cmd.Dispose();  //힙에있는 실행내용을 지운다. gc 우선순위 명령

                    conn.Close();
                    conn.Dispose();

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

        public DataTable Access_Read()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionPath))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = conn.CreateCommand();

                    String readSql = $"SELECT * FROM access ORDER BY No;";

                    cmd.CommandText = readSql;
                    cmd.CommandType = CommandType.Text;

                    MySqlDataAdapter adapter = new MySqlDataAdapter(readSql, conn);

                    dataTable.Clear();

                    adapter.Fill(dataTable);

                    conn.Close();
                    conn.Dispose();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            return dataTable;
        }
    }
}
