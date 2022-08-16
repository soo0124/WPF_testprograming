using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RCS_Setting_Program.Models;

namespace RCS_Setting_Program.ViewModels
{
    static class Constants
    {
        public const string STX = "(";
        public const string ETX = ")";
        public const string CMD_MAIN = "!";
        public const string CMD_RCU = "@";
        public const string CMD_RELAY = "%";
    }

    public class Main_ViewModel : Notify
    {
        SerialCom serialCom;

        private bool _btnConnect;
        public bool btnConnect
        {
            get => _btnConnect;
            set => base.OnPropertyChanged(ref _btnConnect, value);
        }

        private ObservableCollection<String> _portLists = new ObservableCollection<string>(); //통신포트 리스트
        public ObservableCollection<String> portLists
        {
            get => _portLists;
            set => base.OnPropertyChanged(ref _portLists, value);
        }

        private string _selectPort; //선택한 포트
        public string selectPort
        {
            get => _selectPort;
            set => base.OnPropertyChanged(ref _selectPort, value);
        }

        private string _frameSource = "/Views/Main_View.xaml";
        public string frameSource
        {
            get => _frameSource;
            set => base.OnPropertyChanged(ref _frameSource, value);
        }

        private int _rcuAllCount = 30;
        public int rcuAllCount
        {
            get => _rcuAllCount;
            set => base.OnPropertyChanged(ref _rcuAllCount, value);
        }

        private int[] _dtcCount = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public int[] dtcCount
        {
            get => _dtcCount;
            set => base.OnPropertyChanged(ref _dtcCount, value);
        }

        private int _selectAllDTC;
        public int selectAllDTC
        {
            get => _selectAllDTC;
            set => base.OnPropertyChanged(ref _selectAllDTC, value);
        }

        private ObservableCollection<DTC_List> _dtcList = new ObservableCollection<DTC_List>();
        public ObservableCollection<DTC_List> dtcList
        {
            get => _dtcList;
            set => base.OnPropertyChanged(ref _dtcList, value);
        }

        public Main_ViewModel()
        {
            serialCom = new SerialCom();

            Init();
        }

        public void Init()
        {
            foreach(string port in SerialPort.GetPortNames())
            {
                portLists.Add(port);
            }
        }

        //SERIALPORT OPEN & CLOSE
        public void Click_Connection(object sender, RoutedEventArgs e)
        {
            if(!serialCom.IsOpen)
            {
                serialCom.OpenCom(selectPort, 19200, 8, StopBits.One, Parity.None);
                btnConnect = true;
            }
            else
            {
                serialCom.CloseCom();
                btnConnect = false;
            }
        }

        //DTC 개수 설정에 따른 LIST BOX CHANGE
        public void Changed_DTC(object sender, RoutedEventArgs e)
        {
            dtcList.Clear();

            for (int i = 1; i <= selectAllDTC; i++)
            {
                dtcList.Add(new DTC_List("DTC " + i, i));
            }
            
        }

        //MDU & DTC Transmit
        public void Click_TX_MduDtc(object sender, RoutedEventArgs e)
        {
            List<string> strPacket = new List<string>();

            strPacket.Add(Constants.STX);

            for (int i = 0; i < 4; i++)
            {
                strPacket.Add("?");
            }

            strPacket.Add(Constants.CMD_MAIN);
            strPacket.Add(Convert.ToString(selectAllDTC));
            strPacket.Add(rcuAllCount.ToString("D2")); 

            switch (dtcList.Count)
            {
                case 1:strPacket.Add(dtcList[0].rcuCount.ToString("D2")); break;

                default:
                    foreach(var obj in dtcList)
                    {
                        strPacket.Add(dtcList[obj.address-1].rcuCount.ToString("D2"));
                    }
                    break;        
            }

            strPacket.Add(Constants.ETX);

            byte[] bytes = strPacket.SelectMany(x=> Encoding.ASCII.GetBytes(x)).ToArray();
            
            serialCom.Send(bytes);
        }
    }
}
