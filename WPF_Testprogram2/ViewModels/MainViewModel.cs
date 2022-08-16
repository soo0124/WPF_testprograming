using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_TestProgram01.Models;
using WPF_Testprogram2.Models;

namespace WPF_Testprogram2.ViewModels
{
    public class MainViewModel : Notify
    {
        private SerialCom serialCom;

        private bool mIsConnect; //통신 연결상태 (Elipse)
        public bool IsConnect
        {
            get => mIsConnect;
            set => base.OnPropertyChanged(ref mIsConnect, value);
        }

        private ObservableCollection<String> mPortLists = new ObservableCollection<string>(); //통신포트 리스트
        public ObservableCollection<String> PortLists
        {
            get => mPortLists;
            set => base.OnPropertyChanged(ref mPortLists, value);
        }

        private string mSelectPort; //선택한 포트
        public string SelectPort
        {
            get => mSelectPort;
            set => base.OnPropertyChanged(ref mSelectPort, value);
        }

        private string mSendData;  //송신 데이터 (수동입력)
        public string SendData
        {
            get => mSendData;
            set => base.OnPropertyChanged(ref mSendData, value);
        }

        private string mSendPacket; //송신한 데이터
        public string SendPacket
        {
            get => mSendPacket;
            set => base.OnPropertyChanged(ref mSendPacket, value);
        }

        private string mRcvPacket; //수신받은 데이터
        public string RcvPacket
        {
            get => mRcvPacket;
            set => base.OnPropertyChanged(ref mRcvPacket, value);
        }

        private int mEncoderNo = 1; //엔코더 Num
        public int EncoderNo
        {
            get => mEncoderNo;
            set => base.OnPropertyChanged(ref mEncoderNo, value);
        }

        public MainViewModel()
        {
            serialCom = new SerialCom();
            
            foreach (string port in SerialPort.GetPortNames())
            {
                PortLists.Add(port);
            }
        }

        public void BtnClick_PortRefresh(object sender, RoutedEventArgs e) //새로 고침
        {
            PortLists.Clear();

            foreach (string port in SerialPort.GetPortNames())
            {
                PortLists.Add(port);
            }
            //base.OnPropertyChanged("PortLists");
        }

        public void BtnClick_PortOpen(object sender, RoutedEventArgs e)    //포트 개방
        {
            if(string.IsNullOrEmpty(SelectPort))
            {
                return;
            }

            if (!serialCom.IsOpen)
            {
                IsConnect = true;
                serialCom.OpenCom(this.SelectPort, 19200, 8, StopBits.One, Parity.None);
            }
            else
            {
                IsConnect = false;
                serialCom.CloseCom();
            }
        }

        public void BtnClick_SendData(object sender, RoutedEventArgs e)    //데이터 전송
        {
            if(serialCom != null && serialCom.IsOpen)
            {
                serialCom.Send(ConverterHelper.ConvertHexStringToByte(SendData));
            }
            else
            {
                MessageBox.Show("Port is not Open !");
            }
        }

        public void BtnClick_OnlineCheck(object sender, RoutedEventArgs e)
        {
            if(IsConnect == false)
            {
                return;
            }

            byte[] packet = new byte[8];

            packet[0] = 0x7B;
            packet[1] = 0x00;
            packet[2] = Convert.ToByte(this.EncoderNo);
            packet[3] = Convert.ToByte(packet.Length);
            packet[4] = 0xD9;
            packet[5] = 0x01;
            packet[6] = CheckSum.Create(packet);
            packet[7] = 0x7D;

            serialCom.Send(packet);
        }

        public void BtnClick_ReadCard(object sender, RoutedEventArgs e)
        {
            //숙제1
        }

        public void BtnClick_DeleteCard(object sender, RoutedEventArgs e)
        {
            //숙제2
        }

    }
}
