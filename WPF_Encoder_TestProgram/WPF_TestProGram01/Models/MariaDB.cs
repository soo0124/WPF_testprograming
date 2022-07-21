using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_TestProgram01.Models
{
    public class MariaDB
    {
        public MySqlConnection DBCONN;

        private string connectionPath;

        public MariaDB(string pDBIp, string pDBPort, string pDBName, string pDBUser, string pDBPasswd )
        {
            connectionPath = $"Server=" + pDBIp + ";" +
                              "Uid=" + pDBUser + ";" +
                              "Database=" + pDBName + ";" +
                              "Port=" + pDBPort + ";" +
                              "pwd=" + pDBPasswd;
        }

        public Boolean AddDB(int pIntA, int pIntB, int pIntC)
        {
            Boolean result = false;

            using (MySqlConnection conn = new MySqlConnection(connectionPath))
            {
                try
                {
                    conn.Open(); //접근

                    MySqlCommand cmd = conn.CreateCommand();

                    String sql = $"INSERT INTO abc VALUES ({pIntA}, {pIntB}, {pIntC})";

                    cmd.CommandText = sql;
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

        public Boolean AddDB(string pSendTime, string pSendMsg, string pRcvMsg, string pRcvTime)
        {
            Boolean result = false;

            using (MySqlConnection conn = new MySqlConnection(connectionPath))
            {
                try
                {
                    conn.Open(); //접근

                    MySqlCommand cmd = conn.CreateCommand();

                    String sql = $"INSERT INTO encoder VALUES ('{pSendTime}', '{pSendMsg}', '{pRcvMsg}', '{pRcvTime}')";

                    cmd.CommandText = sql;
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


    }
}
