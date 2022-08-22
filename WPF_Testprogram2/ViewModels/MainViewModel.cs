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
    public partial class MainViewModel : Notify
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

        private Uri mMainFrame = new Uri("V_GuestCard.xaml", UriKind.Relative);
        public Uri MainFrame
        {
            get => mMainFrame;
            set => base.OnPropertyChanged(ref mMainFrame, value);
        }

        public MainViewModel()
        {
            serialCom = new SerialCom();
            
            foreach (string port in SerialPort.GetPortNames())
            {
                PortLists.Add(port);
            }

            serialCom.ByteReceive += PortByteReceived;
        }

        private void PortByteReceived(byte[] packet)
        {
            Console.WriteLine($"수신 > {BitConverter.ToString(packet)}");
            RcvPacket = BitConverter.ToString(packet);
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
            SendPacket = BitConverter.ToString(packet);
        }

        public void BtnClick_ReadCard(object sender, RoutedEventArgs e)
        {
            if (IsConnect == false)
            {
                return;
            }

            byte[] packet = new byte[28];

            packet[0] = 0x7B;
            packet[1] = 0x00;
            packet[2] = Convert.ToByte(this.EncoderNo);
            packet[3] = Convert.ToByte(packet.Length);
            packet[4] = 0xC9;
            packet[5] = 0x01;
  
            packet[26] = CheckSum.Create(packet);
            packet[27] = 0x7D;

            serialCom.Send(packet);
            SendPacket = BitConverter.ToString(packet);
        }

        public void BtnClick_DeleteCard(object sender, RoutedEventArgs e)
        {
            if (IsConnect == false)
            {
                return;
            }

            byte[] packet = new byte[60];

            packet[0] = 0x7B;
            packet[1] = 0x00;
            packet[2] = Convert.ToByte(this.EncoderNo);
            packet[3] = Convert.ToByte(packet.Length);
            packet[4] = 0xC8;
            packet[5] = 0x02;
            
            packet[58] = CheckSum.Create(packet);
            packet[59] = 0x7D;

            serialCom.Send(packet);
            SendPacket = BitConverter.ToString(packet);
        }

        public void BtnClick_ChangePage(object sender, RoutedEventArgs e) //페이지 전환버튼 클릭
        {
            try
            {
                //object 타입을 button 타입으로 강제 형변환
                System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;

                switch (button.Name)
                {
                    case "guest":
                        MainFrame = new Uri("V_GuestCard.xaml", UriKind.Relative);
                        break;

                    case "staff":
                        MainFrame = new Uri("V_StaffCard.xaml", UriKind.Relative);
                        break;

                    case "system":
                        MainFrame = new Uri("V_SystemCard.xaml", UriKind.Relative);
                        break;

                    //case "excel":
                    //    mMainFrame = new Uri("V_Bulk.xaml", UriKind.Relative);
                    //    break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void BtnClick_WriteCard(object sender, RoutedEventArgs e)
        {
            if(IsConnect == false)
            {
                MessageBox.Show("★엔코더 연결 필요★");
                return;
            }

            //페이지(버튼) 선택에 따른 구분 
            switch (MainFrame.OriginalString)
            {
                case "V_GuestCard.xaml":
                    {
                        switch (GuestCardSelectedIndex)
                        {
                            case 0: //체크인
                                break;

                            case 1: //프리체크인
                                break;

                            case 2: //스탠바이
                                break;

                            case 3: //원타임
                                break;
                        }
                    }
                    break;

                case "V_StaffCard.xaml":
                    {
                        switch (GuestCardSelectedIndex)
                        {
                            case 0: //이머전시
                                break;

                            case 1: //그랜드마스터
                                break;

                            case 2: //마스터
                                break;

                            case 3: //메이드
                                break;

                            case 4: //미니바
                                break;
                        }
                    }
                    break;

                case "V_SystemCard.xaml":
                    {
                        switch (GuestCardSelectedIndex)
                        {
                            case 0: //리셋
                                break;

                            case 1: //타임
                                break;

                            case 2: //이닛
                                break;

                            case 3: //파라미터
                                break;

                            case 4: //어드레스
                                break;

                            case 5: //HHT
                                break;
                        }
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
