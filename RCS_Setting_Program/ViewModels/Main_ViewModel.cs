﻿using System;
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
    public static class Constants
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


        //통신접속
        private bool _btnConnect;
        public bool btnConnect
        {
            get => _btnConnect;
            set => base.OnPropertyChanged(ref _btnConnect, value);
        }

        //통신포트 리스트
        private ObservableCollection<String> _portLists = new ObservableCollection<string>();
        public ObservableCollection<String> portLists
        {
            get => _portLists;
            set => base.OnPropertyChanged(ref _portLists, value);
        }

        //라이트스위치 리스트
        private ObservableCollection<Rcu_List> _rcuLists = new ObservableCollection<Rcu_List>();
        public ObservableCollection<Rcu_List> rcuLists
        {
            get => _rcuLists;
            set => base.OnPropertyChanged(ref _rcuLists, value);
        }

        //DTC 리스트
        private ObservableCollection<DTC_List> _dtcList = new ObservableCollection<DTC_List>();
        public ObservableCollection<DTC_List> dtcList
        {
            get => _dtcList;
            set => base.OnPropertyChanged(ref _dtcList, value);
        }

        //A접점 콤보박스 리스트
        private ObservableCollection<int> _relayAList = new ObservableCollection<int>() { 0, 1, 2, 3, 4, 5 };
        public ObservableCollection<int> relayAList
        {
            get => _relayAList;
            set => base.OnPropertyChanged(ref _relayAList, value);
        }


        //A접점 콤보박스 선택값
        private int _relayASelect;
        public int relayASelect
        {
            get => _relayASelect;
            set
            {
                if (base.OnPropertyChanged(ref _relayASelect, value)) //A접점 콤보박스값이 변경?
                {
                    if (value > 0)
                    {

                        for (int i = 0; i < rcuLists.Count; i++) //라이트스위치 개수만큼 (ADD한만큼)
                        {
                            foreach (var item in rcuLists[i].relayLists) //라이트스위치별 릴레이(32개)만큼)
                            {
                                item.circuitNo.Clear();

                                for (int j = 1; j < rcuLists[i].selectNum + 1; j++)
                                {
                                    item.circuitNo.Add(new MatchItem() { Value = j, Division = "L", Display = $"{j}번 회로" }); //선택한 회로수만큼 추가
                                }

                                for (int k = 1; k <= value; k++)
                                {
                                    item.circuitNo.Add(new MatchItem() { Value = 7, Division = "A", Display = $"A, {k}번" }); //A접점 추가
                                }

                                for (int h = 1; h <= relayBSelect; h++)
                                {
                                    item.circuitNo.Add(new MatchItem() { Value = 8, Division = "B", Display = $"B, {h}번" }); //B접점 추가
                                }
                            }
                        }


                    }
                    else //'0'을 선택?
                    {
                        for (int i = 0; i < rcuLists.Count; i++) //라이트스위치 개수만큼 (ADD한만큼)
                        {
                            foreach (var item in rcuLists[i].relayLists) //라이트스위치별 릴레이(32개)만큼)
                            {
                                item.circuitNo.Clear();

                                for (int j = 1; j < rcuLists[i].selectNum + 1; j++)
                                {
                                    item.circuitNo.Add(new MatchItem() { Value = j, Division = "L", Display = $"{j}번 회로" }); //선택한 회로수만큼 추가
                                }

                                for (int k = 1; k <= value; k++)
                                {
                                    item.circuitNo.Add(new MatchItem() { Value = 7, Division = "A", Display = $"A, {k}번" }); //A접점 추가
                                }

                                for (int h = 1; h <= relayBSelect; h++)
                                {
                                    item.circuitNo.Add(new MatchItem() { Value = 8, Division = "B", Display = $"B, {h}번" }); //B접점 추가
                                }
                            }
                        }
                    }
                }
            }
        }

        //B접점 콤보박스 리스트
        private ObservableCollection<int> _relayBList = new ObservableCollection<int>() { 0, 1, 2, 3, 4, 5 };
        public ObservableCollection<int> relayBList
        {
            get => _relayBList;
            set => base.OnPropertyChanged(ref _relayBList, value);
        }

        //B접점 콤보박스 선택값
        private int _relayBSelect;
        public int relayBSelect
        {
            get => _relayBSelect;
            set
            {
                if (base.OnPropertyChanged(ref _relayBSelect, value)) //A접점 콤보박스값이 변경?
                {
                    if (value > 0)
                    {
                        for (int i = 0; i < rcuLists.Count; i++) //라이트스위치 개수만큼 (ADD한만큼)
                        {
                            foreach (var item in rcuLists[i].relayLists) //라이트스위치별 릴레이(32개)만큼)
                            {
                                item.circuitNo.Clear();

                                for (int j = 1; j < rcuLists[i].selectNum + 1; j++)
                                {
                                    item.circuitNo.Add(new MatchItem() { Value = j, Division = "L", Display = $"{j}번 회로" });
                                }

                                for (int k = 1; k <= value; k++)
                                {
                                    item.circuitNo.Add(new MatchItem() { Value = 8, Division = "B", Display = $"B, {k}번" });
                                }

                                for (int h = 1; h <= relayASelect; h++)
                                {
                                    item.circuitNo.Add(new MatchItem() { Value = 7, Division = "A", Display = $"A, {h}번" });
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < rcuLists.Count; i++) //라이트스위치 개수만큼 (ADD한만큼)
                        {
                            foreach (var item in rcuLists[i].relayLists) //라이트스위치별 릴레이(32개)만큼)
                            {
                                item.circuitNo.Clear();

                                for (int j = 1; j < rcuLists[i].selectNum + 1; j++)
                                {
                                    item.circuitNo.Add(new MatchItem() { Value = j, Division = "L", Display = $"{j}번 회로" });
                                }

                                for (int k = 1; k <= value; k++)
                                {
                                    item.circuitNo.Add(new MatchItem() { Value = 8, Division = "B", Display = $"B, {k}번" });
                                }

                                for (int h = 1; h <= relayASelect; h++)
                                {
                                    item.circuitNo.Add(new MatchItem() { Value = 7, Division = "A", Display = $"A, {h}번" });
                                }
                            }
                        }
                    }
                }
            }
        }

        //Select comport
        private string _selectPort;
        public string selectPort
        {
            get => _selectPort;
            set => base.OnPropertyChanged(ref _selectPort, value);
        }

        //Button PAGE
        private string _frameSource = "/Views/Main_View.xaml";
        public string frameSource
        {
            get => _frameSource;
            set => base.OnPropertyChanged(ref _frameSource, value);
        }

        //RCU All count
        private int _rcuAllCount = 50;
        public int rcuAllCount
        {
            get => _rcuAllCount;
            set => base.OnPropertyChanged(ref _rcuAllCount, value);
        }

        //DTC All count
        private int[] _dtcCount = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public int[] dtcCount
        {
            get => _dtcCount;
            set => base.OnPropertyChanged(ref _dtcCount, value);
        }

        //Communication Speed
        private int _commSpeed = 30;
        public int commSpeed
        {
            get => _commSpeed;
            set => base.OnPropertyChanged(ref _commSpeed, value);
        }

        //DTC select number
        private int _selectAllDTC;
        public int selectAllDTC
        {
            get => _selectAllDTC;
            set => base.OnPropertyChanged(ref _selectAllDTC, value);
        }

        //RCU CB MODE LIST
        private int[] _cbMode = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public int[] cbMode
        {
            get => _cbMode;
            set => base.OnPropertyChanged(ref _cbMode, value);
        }

        //SELECT CB MODE
        private int _selectCbMode;
        public int selectCbMode
        {
            get => _selectCbMode;
            set => base.OnPropertyChanged(ref _selectCbMode, value);
        }

        //Scroll View
        private string _txLogPacket;
        public string txLogPacket
        {
            get => _txLogPacket;
            set => base.OnPropertyChanged(ref _txLogPacket, value);
        }

        //Year, Month, Day, Time
        private string _realTime;
        public string realTime
        {
            get => _realTime;
            set => base.OnPropertyChanged(ref _realTime, value);
        }

        //FW Set Mode
        private bool _fwMode = false;
        public bool fwMode
        {
            get => _fwMode;
            set => base.OnPropertyChanged(ref _fwMode, value);
        }

        //Protocol
        private string _protocol = "STX | DATA TYPE | CMD | DTC COUNT | RCU COUNT | DTC N COUNT | ETX";
        public string protocol
        {
            get => _protocol;
            set => base.OnPropertyChanged(ref _protocol, value);
        }

        private int pageNum = 1;

        public Main_ViewModel()
        {
            serialCom = new SerialCom();

            Init();
        }

        //initiallizing
        public void Init()
        {
            onTimeMethod();

            foreach (string port in SerialPort.GetPortNames())
            {
                portLists.Add(port);
            }
        }

        //Real Time
        public void onTimeMethod()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += (sender, e) =>
            {
                this.realTime = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
            };

            timer.Start();
        }

        //FW Setting Mode
        public bool FW_Setting()
        {
            if (MessageBox.Show("펌웨어 세팅모드로 설정하시겠습니까?", "Yes-No", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                return true;
            }
            else
            {

                return false;
            }
        }

        //Comport Refresh
        public void Click_Refresh(object sender, RoutedEventArgs e)
        {
            portLists.Clear();

            foreach (string port in SerialPort.GetPortNames())
            {
                portLists.Add(port);
            }
        }

        //Button page change
        public void ChangePage(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;

            frameSource = $"/Views/{btn.Name}.xaml";

            switch (btn.Name)
            {
                case "Main_View":
                    pageNum = 1;
                    protocol = "STX | DATA TYPE | CMD | DTC COUNT | RCU COUNT | DTC N COUNT | ETX";
                    break;

                case "RCU_View":
                    pageNum = 2;
                    LS_ADD();
                    protocol = "STX | DATA TYPE | CMD | ROOM TYPE | L/S COUNT | BUTTON COUNT | MASTER USE | BATH USE | RELAY COUNT | RELAY NAME | RELAY CIRCUIT | ETX";
                    break;
                case "Relay_View":
                    pageNum = 3;
                    break;
            }
        }

        //SERIALPORT OPEN & CLOSE
        public void Click_Connection(object sender, RoutedEventArgs e)
        {
            if (!serialCom.IsOpen)
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
                dtcList.Add(new DTC_List("> DTC " + i, i));
            }

        }

        //Main & RCU Transmit Logic
        public void Click_Trasmit(object sender, RoutedEventArgs e)
        {
            if (FW_Setting() == false)
            {
                return;
            }
            else
            {
                byte[] Setbyte = new byte[4];

                Setbyte[0] = 0x28;
                Setbyte[1] = 0x0A;
                Setbyte[2] = 0x01;
                Setbyte[3] = 0x29;

                serialCom.Send(Setbyte);


                List<string> strPacket = new List<string>();

                strPacket.Add(Constants.STX);

                for (int i = 0; i < 4; i++)
                {
                    strPacket.Add("?");
                }

                switch (pageNum)
                {
                    case 1: //MDU, DTC TX Packet
                        strPacket.Add(Constants.CMD_MAIN);
                        strPacket.Add(Convert.ToString(selectAllDTC));
                        strPacket.Add(rcuAllCount.ToString("D2"));

                        switch (dtcList.Count)
                        {
                            case 1: strPacket.Add(dtcList[0].rcuCount.ToString("D2")); break;

                            default:
                                foreach (var obj in dtcList)
                                {
                                    strPacket.Add(dtcList[obj.address - 1].rcuCount.ToString("D2"));
                                }
                                break;
                        }
                        break;

                    case 2: //RCU TX Packet

                        strPacket.Add(Constants.CMD_RCU);
                        strPacket.Add(Convert.ToString(selectCbMode));
                        strPacket.Add(rcuLists.Count.ToString());



                        for (int i = 1; i < rcuLists.Count + 1; i++) //LS 개수만큼
                        {
                            int relayCount = 0;
                            Rcu_List LS = rcuLists[i - 1];

                            strPacket.Add(LS.selectNum.ToString()); //회로수
                            strPacket.Add(Convert.ToInt32(LS.masterUse).ToString()); //마스터
                            strPacket.Add(Convert.ToInt32(LS.bathUse).ToString());   //화장실

                            for (int w = 0; w < 32; w++)
                            {
                                if (LS.relayLists[w].IsChecked == true)
                                {
                                    relayCount += 1;
                                }
                            }
                            strPacket.Add(relayCount.ToString());

                            for (int j = 0; j < 32; j++)
                            {
                                if (LS.relayLists[j].IsChecked == true)
                                {
                                    if (LS.relayLists[j].selectCircuitNo.Value != 0)
                                    {
                                        strPacket.Add(LS.relayLists[j].relayNo.ToString("D2"));
                                        strPacket.Add(i.ToString());
                                        strPacket.Add(LS.relayLists[j].selectCircuitNo.Value.ToString());
                                    }
                                    else return;
                                }
                            }
                        }

                        break;
                }
                strPacket.Add(Constants.ETX);
                Console.Write(strPacket);

                byte[] bytes = strPacket.SelectMany(x => Encoding.ASCII.GetBytes(x)).ToArray();
                string hexstring = strPacket.Aggregate((x, y) => x + y);
                txLogPacket = " 송신 : " + ConvertHelper.ConvertStringToHexString(hexstring);

                serialCom.Send(bytes);
            }
        }

        //Light Switch Plus
        public void LS_ADD()
        {
            rcuLists.Add(new Rcu_List(rcuLists.Count + 1));
        }

        //Light Switch Minus
        public void LS_Delete()
        {
            rcuLists.RemoveAt(rcuLists.Count - 1);
        }
    }
}
