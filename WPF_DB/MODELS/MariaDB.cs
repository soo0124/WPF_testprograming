using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_DB.MODELS
{
    public class MariaDB
    {
        public static DataSet ExecuteDataSet(string ConnectionString, string SQL)
        {
            return MySqlHelper.ExecuteDataset(ConnectionString, SQL);
        }

        public static DataTable ExecuteDataTable(string ConnectionString, string SQL)
        {
            return MySqlHelper.ExecuteDataset(ConnectionString, SQL).Tables[0];
        }

        public static int ExecuteNonQuery(string ConnectionString, string SQL)
        {
            return MySqlHelper.ExecuteNonQuery(ConnectionString, SQL);
        }
    }
}
