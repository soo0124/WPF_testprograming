using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace RCS_Setting_Program
{
    public class MyDB
    {
        public bool IsConnect(string connectString) //DB 연결
        {
            bool result = false;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectString))
                {
                    conn.Open();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return result;
        }

        public DataTable ExecuteDataTable(string connectString, string sql) //DB Datatable 불러오기
        {
            DataTable DT = null;

            try
            {
                DT = MySqlHelper.ExecuteDataset(connectString, sql).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return DT;
        }
    }
}
