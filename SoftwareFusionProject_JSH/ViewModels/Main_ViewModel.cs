using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Threading;
using LiveCharts;
using SoftwareFusionProject_JSH.Models;
using WPF_DB.MODELS;

namespace SoftwareFusionProject_JSH.ViewModels
{
    public partial class Main_ViewModel : Notify
    {
        private SerialTest serialD;
        private SerialTest serialR;
        private MariaDB mariaDB;

        public ChartValues<float> detectValues { get; set; }
        public ChartValues<float> detectValues_AVR { get; set; }
        public ObservableCollection<Acess> accessLog { get; set; }
        List<float> movingData = new List<float>();

        List<float> bufferD = new List<float>();
        int count;

        public Main_ViewModel()
        {
            serialD = new SerialTest("D");
            serialR = new SerialTest("R");
            mariaDB = new MariaDB("localhost", "3306", "lecture", "root", "racos5117");

            Initializing();

            serialD.ByteReceive += PortByteReceived_D;
            serialR.ByteReceive += PortByteReceived_R;

            Timer timer = new Timer();

            timer.Interval = 3000; //3초
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();

        }

        public void Initializing()
        {
            foreach(string port in SerialPort.GetPortNames())
            {
                portLists.Add(port);
            }

            detectValues = new ChartValues<float>();
            detectValues_AVR = new ChartValues<float>();
            accessLog = new ObservableCollection<Acess>();
        }

        public void D_Connect(object sender, RoutedEventArgs e)
        {
            if(!serialD.IsOpen)
            {
                serialD.OpenPort(selectPortD, 115200, 8, StopBits.One, Parity.None);
                detectConnect = true;
            }
            else
            {
                serialD.ClosePort();
                detectConnect = false;
            }
        }

        public void R_Connect(object sender, RoutedEventArgs e)
        {
            if (!serialR.IsOpen)
            {
                serialR.OpenPort(selectPortR, 9600, 8, StopBits.One, Parity.None);
                readerConnect = true;
            }
            else
            {
                serialR.ClosePort();
                readerConnect = false;
            }
        }

        public void PortByteReceived_D(byte[] packet)
        {
            string hexString;
            int intValue = 0;
            float rawData = 0;

            hexString = ConvertHelper.ByteToHex(packet);
            intValue = int.Parse(hexString.Substring(4, 4), System.Globalization.NumberStyles.HexNumber);
            rawData = float.Parse(intValue.ToString());

            if(++count > 5)
            {
                count = 0;

                detectValues.Add(rawData);
                movingData.Add(rawData);

                if(movingData.Count == 3)
                {
                    detectValues_AVR.Add(movingData.Average());
                    movingData.RemoveAt(0);
                }

                if(detectValues.Count > 20)
                {
                    detectValues.RemoveAt(0);
                    detectValues_AVR.RemoveAt(0);
                }
            }
        }

        public void PortByteReceived_R(byte[] packet)
        {
            accessStatus = Encoding.Default.GetString(packet);
            AccessList_Insert();
        }

        public void Btn_ChangePage(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;

            switch (btn.Name)
            {
                case "setting":
                    frameSource = new Uri("SetupView.xaml", UriKind.Relative);
                    break;

                case "lecture":
                    frameSource = new Uri("Lecture.xaml", UriKind.Relative);
                    break;
            }
        }

        public void AccessList_Insert()
        {
            DateTime date = DateTime.Now;

            mariaDB.Access_Insert(1, Int32.Parse(accessStatus.Substring(1, 8)), 1, date.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
            {
                DataTable dataTable = new DataTable();

                dataTable = mariaDB.Access_Read();

                string a,b,c,d;

                accessLog.Clear();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    a = dataTable.Rows[i]["No"].ToString();
                    b = dataTable.Rows[i]["Code"].ToString();
                    c = dataTable.Rows[i]["Division"].ToString();
                    d = dataTable.Rows[i]["Time"].ToString();
                    
                    accessLog.Add(new Acess(a,b,c,d));
                }
            }));
        }
    }
}
