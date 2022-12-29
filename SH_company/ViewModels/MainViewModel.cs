using SH_company.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Xml;
using System.Collections.ObjectModel;

namespace SH_company.ViewModels
{
    public partial class MainViewModel
    {
        private ProjectDB database;

        public MainViewModel()
        {
            rcsPlace = new ObservableCollection<RcsModel>();

            timer_function();
            Show_DataBase();
        }


        //--------------------------- Timer Logic ---------------------------//
        private void timer_function()
        {
            Timer dateTimer = new Timer();

            dateTimer.Interval = 60000;
            dateTimer.Elapsed += new ElapsedEventHandler(date_Elapsed);
            dateTimer.Start();

            Timer weatherTimer = new Timer();

            weatherTimer.Interval = 3000;
            weatherTimer.Elapsed += new ElapsedEventHandler(weather_Elapsed);
            weatherTimer.Start();

        }

        private void date_Elapsed(object sender, ElapsedEventArgs e)
        {
            YMD = DateTime.Now.ToString("yyyy" + "년 " + "MM" + "월 " + "dd" + "일");
            HMS = DateTime.Now.ToString("HH" + "시 " + "mm" + "분");
        }

        private void weather_Elapsed(object sender, ElapsedEventArgs e)
        {
            XmlDocument xml = new XmlDocument();

            xml.Load(weatherURL);

            XmlNodeList xmlList = xml.GetElementsByTagName("local");

            foreach (XmlNode xmlNode in xmlList)
            {
                if (xmlNode.Attributes["stn_id"].Value == "108")
                {
                    switch (xmlNode.Attributes["desc"].Value)
                    {
                        case "흐림": weather = "../Resources/black.png"; break;

                        case "구름많음": weather = "../Resources/Cloud.png"; break;

                        case "비": weather = "../Resources/rain.png"; break;

                        case "맑음": weather = "../Resources/Sun.png"; break;

                        case "눈": weather = "../Resources/Snow.png"; break;

                        default: weather = "../Resources/cold.png"; break;
                    }
                }
            }
        }

        private void Show_DataBase()
        {
            database = new ProjectDB("localhost", "3306", "place", "root", "racos5117");

            DataTable dataTable = new DataTable();

            dataTable = database.showPlace();

            string a, b, c, d, e, f;

            rcsPlace.Clear();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                a = dataTable.Rows[i]["no"].ToString();
                b = dataTable.Rows[i]["place"].ToString();
                c = dataTable.Rows[i]["sale"].ToString();
                d = dataTable.Rows[i]["pm"].ToString();
                e = dataTable.Rows[i]["asas"].ToString();
                f = dataTable.Rows[i]["roomcount"].ToString();

                rcsPlace.Add(new RcsModel(a, b, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), c, d, e, f));
            }
        }

        public void Btn_PlaceSave(object sender, RoutedEventArgs e)
        {
            database = new ProjectDB("localhost", "3306", "place", "root", "racos5117");

            database.insertPlace(txt_place, txt_sale, txt_pm, txt_as, txt_roomCnt);

            Show_DataBase();
        }

        public void Btn_PlaceDelete(object sender, RoutedEventArgs e)
        {
            database = new ProjectDB("localhost", "3306", "place", "root", "racos5117");

            //var t = MySql.Data.MySqlClient.MySqlHelper.ExecuteNonQuery(
            //    "server=127.0.0.1;port=3306;uid=root;pwd=racos5117;",
            //    $"DELETE FROM rcsplace WHERE no ={testbtn}; " +
            //    "SET @COUNT=0;" +
            //    "UPDATE rcsplace SET NO=@COUNT:=@COUNT+1"
            //    );

            //var a = 123;

            database.deletePlace(testbtn);

            Show_DataBase();
        }
    }
}
