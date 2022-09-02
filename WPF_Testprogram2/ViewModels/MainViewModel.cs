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
using WPF_Testprogram2.Models.CardKey;
using WPF_Testprogram2.Models.Encoder;

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

        private ExcelHelper _Excel = new ExcelHelper();

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
            if (string.IsNullOrEmpty(SelectPort))
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
            if (serialCom != null && serialCom.IsOpen)
            {
                serialCom.Send(ConverterHelper.ConvertHexStringToByte(SendData));
            }
            else
            {
                MessageBox.Show("Port is not Open !");
            }
        }

        public void BtnClick_OnlineCheck()
        {
            byte[] packet = new D9_OnlineCheck().ToByte(this.EncoderNo, null);

            EncoderSend(packet);
        }

        public void BtnClick_ReadCard()
        {
            byte[] packet = new C9_ReadCard().ToByte(this.EncoderNo, null);

            EncoderSend(packet);
        }

        public void BtnClick_DeleteCard()
        {
            byte[] packet = new C8_DeleteCard().ToByte(this.EncoderNo, null);

            EncoderSend(packet);
        }

        private bool EncoderSend(byte[] packet)
        {
            bool result = false;

            try
            {
                SendData = BitConverter.ToString(packet, 0, packet.Length).Replace("-", "");
                SendPacket = BitConverter.ToString(packet, 0, packet.Length).Replace("-", " ");

                Console.WriteLine($"송신 > {BitConverter.ToString(packet, 0, packet.Length).Replace("-", " ")}");
                serialCom.Send(packet);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return true;
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

                    case "excel":
                        MainFrame = new Uri("V_Bulk.xaml", UriKind.Relative);
                        break;

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
            if (IsConnect == false)
            {
                MessageBox.Show("★엔코더 연결 필요★");
                return;
            }

            string page = MainFrame.OriginalString;
            ICardKey cardkey = null;

            //페이지(버튼) 선택에 따른 구분 
            switch (page)
            {
                case "V_GuestCard.xaml":
                    {
                        switch (GuestCardSelectedIndex)
                        {
                            case 0: //체크인
                                cardkey = new CheckIn()
                                {
                                    HotelCode = this.TxtHotelCode,
                                    ReaderNo = this.TxtReaderNo,
                                    SecurityNo = this.TxtSecurityNo,
                                    IndexNo = this.TxtIndexNo,
                                    CheckoutDate = new DateTime(this.TxtCheckoutDateYear, this.TxtCheckoutDateMonth, this.TxtCheckoutDateDay),
                                    CheckoutTime = this.TxtCheckoutTime,
                                    SuitArea = this.TxtSetSuitArea,
                                    SpecialArea = this.TxtSpecialArea
                                };

                                break;

                            case 1: //프리체크인
                                cardkey = new FreeCheckIn()
                                {
                                    HotelCode = this.TxtHotelCode,
                                    ReaderNo = this.TxtReaderNo,
                                    SecurityNo = this.TxtSecurityNo,
                                    IndexNo = this.TxtIndexNo,
                                    CheckoutDate = new DateTime(this.TxtCheckoutDateYear, this.TxtCheckoutDateMonth, this.TxtCheckoutDateDay),
                                    CheckinData = new DateTime(this.TxtCheckinDateYear, this.TxtCheckinDateMonth, this.TxtCheckinDateDay),
                                    CheckoutTime = this.TxtCheckoutTime,
                                    SuitArea = this.TxtSetSuitArea,
                                    SpecialArea = this.TxtSpecialArea
                                };
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

            if (cardkey == null)
            {
                MessageBox.Show("카드 데이터 정보 오류", "카드 발급", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            byte[] packet = new C8_WriteCard().ToByte(this.EncoderNo, cardkey);

            EncoderSend(packet);
        }

        public void BtnClick_LoadSourceFile(object sender, RoutedEventArgs e)
        {
            //파일찾기
            try
            {
                System.Windows.Forms.OpenFileDialog of = new System.Windows.Forms.OpenFileDialog();
                of.Filter = "Excel files (*.xlsx) | *.xlsx";
                of.Multiselect = false;

                if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TxtSourceExcelFile = of.FileName;
                }
            }
            catch (Exception e2)
            {

                MessageBox.Show(e2.Message);
            }
        }

        public void BtnClick_DefaultFile(object sender, RoutedEventArgs e)
        {
            //기본파일
            try
            {
                TxtSourceExcelFile = "WPF_Testprogram2.Resources.Racos_CardKey FW_Test (v1.9).xlsx";
            }
            catch (Exception EX)
            {

                throw;
            }
        }

        public void BtnClick_ExcelTest(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSourceExcelFile))
            {
                MessageBox.Show("테스트 파일을 선택하지 않았습니다");
                return;
            }

            if (string.IsNullOrEmpty(TxtDestinationExcelFile))
            {
                MessageBox.Show("저장경로를 선택하지 않았습니다");
                return;
            }

            if (string.IsNullOrEmpty(SelectExcelCommand))
            {
                MessageBox.Show("커맨드를 선택하지 않았습니다");
                return;
            }


            Task.Run(() =>
            {
                //엑셀파일 열기
                if (!_Excel.OpenExcelFile(TxtSourceExcelFile, TxtDestinationExcelFile, SelectExcelCommand))
                {
                    return;
                }

                //실행순서
                var orderList = _Excel.GetExcelSheet();

                if (orderList.Count < 1)
                {
                    MessageBox.Show("실행순서가 기입되지 않았습니다.");
                    return;
                }

                try
                {
                    for (int i = 0; i < orderList.Count; i++)
                    {
                        this.RcvPacket = string.Empty;

                        if (!EncoderSend(ConverterHelper.StringToByteArray(orderList[i].Input_Value)))
                        {
                            continue;
                        }

                        Task.Delay(ExcelTestTime).Wait();

                        string receivedData = this.RcvPacket;

                        if (string.IsNullOrEmpty(this.RcvPacket))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            receivedData = "응답 없음";
                            Console.WriteLine(string.Format("수신 > {0}", receivedData));
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        _Excel.SetExcelSheet(orderList[i], receivedData);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _Excel.SaveExcelFile();
                    _Excel.ExitExcelFile();

                    MessageBox.Show("엑셀파일 저장 완료!");
                }
            });

            Task.Delay(1000).Wait();
        }
    }
}
