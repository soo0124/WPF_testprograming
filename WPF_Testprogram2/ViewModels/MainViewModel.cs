using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_TestProgram01.Models;

namespace WPF_Testprogram2.ViewModels
{
    public class MainViewModel : Notify
    {
        SerialCom serialCom = new SerialCom();

        private bool mIsConnect; //통신 연결상태 (Elipse)
        public bool IsConnect
        {
            get => mIsConnect;
            set => base.OnPropertyChanged(ref mIsConnect, value);
        }

        private List<String> mPortLists = new List<string>(); //통신포트 리스트
        public List<String> PortLists
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
            string[] portList = SerialPort.GetPortNames();

            foreach(string port in portList)
            {
                PortLists.Add(port);
            }
        }

        public void BtnClick_PortRefresh(object sender, RoutedEventArgs e) //새로 고침
        {
            
        }

        public void BtnClick_PortOpen(object sender, RoutedEventArgs e)    //포트 개방
        {
            if(!serialCom.IsOpen)
            {
                IsConnect = true;
                serialCom.OpenCom(SelectPort, 19200, 8, StopBits.One, Parity.None);
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
                serialCom.Send(ConvertHexStringToByte(SendData));
            }
            else
            {
                MessageBox.Show("Port is not Open !");
            }
        }

        public static byte[] ConvertHexStringToByte(string convertString)  // HEX String -> Byte[] 
        {
            byte[] convertArr = new byte[convertString.Length / 2];
            for (int i = 0; i < convertArr.Length; i++)
            {
                convertArr[i] = Convert.ToByte(convertString.Substring(i * 2, 2), 16);
            }
            return convertArr;
        }

    }
}
