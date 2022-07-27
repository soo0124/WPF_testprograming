//using EncoderTester.Network.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using WPF_TestProgram01.Model;
using WPF_TestProgram01.Models;
using WPF_TestProgram01.Views;
using WPF_TestProGram01;

namespace WPF_TestProgram01.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MariaDB mariaDB { get; set; }

        public MainModel mainModel { get; set; }

        public OnlineModels onlineModel { get; set; }

        public WriteModel writeModel { get; set; }

        public ReadModel readModel { get; set; }

        public DbModel dbModel { get; set; }

        public Command btn_start { get; set; }

        public Command btn_transmit { get; set; }

        public Command btn_clear { get; set; }

        public Command btn_WriteCard { get; set; }

        public Command btn_OnlineCheck { get; set; }

        public Command btn_ReadCard { get; set; }

        public Command btn_DBconn { get; set; }

        public Command btn_DB_start { get; set; }

        public Command btn_DB_insert { get; set; }

        SerialPort serialPort = new SerialPort();

        DateTime dateTime = DateTime.Now;

        List<byte> list = new List<byte>();

        int pageNum = 0;
        public string TXsqlDate;
        public string RXsqlDate;


        public MainViewModel()
        {
            mainModel = new MainModel();

            onlineModel = new OnlineModels();

            writeModel = new WriteModel();

            readModel = new ReadModel();

            dbModel = new DbModel();

            mariaDB = new MariaDB("127.0.0.1",
                                  "3306",
                                  "test",
                                  "root",
                                  "racos5117");



            btn_start = new Command(Execute_Start, CanExecute_Start);

            btn_transmit = new Command(Execute_TX, CanExecute_TX);

            btn_clear = new Command(Execute_Clear, CanExecute_Clear);

            btn_OnlineCheck = new Command(Execute_Online, CanExecute_Online);

            btn_WriteCard = new Command(Execute_Write, CanExecute_Write);

            btn_ReadCard = new Command(Execute_Read, CanExecute_Read);

            btn_DBconn = new Command(Execute_DB, CanExecute_DB);

            //btn_DB_start = new Command(Execute_StartDB, CanExecute_StartDB);

            //btn_DB_insert = new Command(Execute_InsertDB, CanExecute_InsertDB);
        }

        private bool CanExecute_Online(object arg) { return true; }
        private void Execute_Online(object obj)
        {
            mainModel.frameSource = "/Views/OnLineCheck.xaml";
            pageNum = 0;
        }

        private bool CanExecute_Write(object arg) { return true; }
        private void Execute_Write(object obj)
        {
            mainModel.frameSource = "/Views/WriteCard.xaml";
            pageNum = 1;
        }

        private bool CanExecute_Read(object arg) { return true; }
        private void Execute_Read(object obj)
        {
            mainModel.frameSource = "/Views/ReadCard.xaml";
            pageNum = 2;
        }

        private bool CanExecute_DB(object arg) { return true; }
        private void Execute_DB(object obj)
        {
            mainModel.frameSource = "/Views/SetEncoder.xaml";
            pageNum = 8;
        }

        private bool CanExecute_Clear(object arg) { return true; }
        private void Execute_Clear(object obj)
        {
            switch (pageNum)
            {
                case 0:

                    onlineModel.stx_value = String.Empty;
                    onlineModel.dtc_value = String.Empty;
                    onlineModel.ecd_value = String.Empty;
                    onlineModel.len_value = String.Empty;
                    onlineModel.cmd_value = String.Empty;
                    onlineModel.sub_value = String.Empty;
                    onlineModel.ack_value = String.Empty;
                    onlineModel.crc_value = String.Empty;
                    onlineModel.etx_value = String.Empty;

                    onlineModel.tbx_receive = String.Empty;
                    break;

                case 1:

                    writeModel.stx_value = String.Empty;
                    writeModel.dtc_value = String.Empty;
                    writeModel.ecd_value = String.Empty;
                    writeModel.len_value = String.Empty;
                    writeModel.cmd_value = String.Empty;
                    writeModel.sub_value = String.Empty;
                    writeModel.ack_value = String.Empty;
                    writeModel.crc_value = String.Empty;
                    writeModel.etx_value = String.Empty;

                    writeModel.tbx_receive = String.Empty;
                    break;

                case 2:

                    readModel.stx_value = String.Empty;
                    readModel.dtc_value = String.Empty;
                    readModel.ecd_value = String.Empty;
                    readModel.len_value = String.Empty;
                    readModel.cmd_value = String.Empty;
                    readModel.sub_value = String.Empty;
                    readModel.uid_value = String.Empty;
                    readModel.cardData_value = String.Empty;
                    readModel.cardData_value2 = String.Empty;
                    readModel.wsID_value = String.Empty;
                    readModel.crc_value = String.Empty;
                    readModel.etx_value = String.Empty;

                    readModel.tbx_receive = String.Empty;
                    break;
            }
        }

        private bool CanExecute_TX(object arg) { return true; } //CanExecute = Execute 코드 실행 여부 결정 (True: 호출, False: 호출X)
        private void Execute_TX(object obj) //DATA Transmit
        {


            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    switch (pageNum)
                    {
                        case 0:

                            byte[] send_byte_O = ConvertHexStringToByte(onlineModel.tbx_send);

                            serialPort.Write(send_byte_O, 0, send_byte_O.Length);

                            break;

                        case 1:

                            byte[] send_byte_W = ConvertHexStringToByte(writeModel.tbx_send);

                            serialPort.Write(send_byte_W, 0, send_byte_W.Length);

                            break;

                        case 2:

                            byte[] send_byte_R = ConvertHexStringToByte(readModel.tbx_send);

                            serialPort.Write(send_byte_R, 0, send_byte_R.Length);

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Port is not open\n" + ex.ToString(), ex.Message);
            }

        }

        /*
        private bool CanExecute_StartDB(object arg) { return true; }
        private void Execute_StartDB(object obj)
        {
            mariaDB = new MariaDB(dbModel.tbx_DB_IP, 
                                  dbModel.tbx_DB_PORT, 
                                  dbModel.tbx_DB_NAME,
                                  dbModel.tbx_DB_USER,
                                  dbModel.tbx_DB_PW);
        }

        private bool CanExecute_InsertDB(object arg) { return true; }
        private void Execute_InsertDB(object obj)
        {
            try
            {
                mariaDB.AddDB(13, 16, 19); //try catch 추가
            }
            catch (Exception E1)
            {
                MessageBox.Show(E1.Message);
            }
        }*/

        private bool CanExecute_Start(object obj) { return true; }
        private void Execute_Start(object obj)
        {
            if (!serialPort.IsOpen) //PORT Not Open?
            {
                serialPort.PortName = mainModel.Pick_comPort;
                serialPort.BaudRate = mainModel.Pick_baudRate;
                serialPort.DataBits = mainModel.Pick_dataBit;
                serialPort.StopBits = (StopBits)mainModel.Pick_stopBit;

                if (mainModel.Pick_parityBit == "NONE") serialPort.Parity = Parity.None;
                else if (mainModel.Pick_parityBit == "SPACE") serialPort.Parity = Parity.Space;
                else if (mainModel.Pick_parityBit == "EVEN") serialPort.Parity = Parity.Even;

                serialPort.DataReceived += SerialPort_DataReceived;

                serialPort.Open();

                MessageBox.Show("Port Open");
                mainModel.btn_start_name = "연결 해제!";
                mainModel.btn_start_color = "Pink";
            }
            else
            {
                serialPort.Close();

                MessageBox.Show("Port Close");
                mainModel.btn_start_name = "연결 시작!";
                mainModel.btn_start_color = "White";
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) //Receive
        {
            string hexString = String.Empty;
            RXsqlDate = dateTime.ToString("yyyy-MM-dd HH:mm:ss");

            if (serialPort.BytesToRead > 0)
            {
                while (serialPort.BytesToRead > 0)
                {
                    list.Add((byte)serialPort.ReadByte());
                }

                //최소 Length 비교
                if (list.Count < 4)
                {
                    return;
                }

                //STX Check
                if (list.First() != 40)
                {
                    list.Clear();
                    return;
                }

                switch (list[4])
                {
                    case 217: //D9 - Online Check
                        if (list[5] > 9) list.Clear();
                        break;

                    case 200: //C8 - Write Card

                        break;

                    case 201: //C9 - Read Card

                        break;
                }

                //ETX Check
                if (list.Last() != 41)
                {
                    list.Clear();
                    return;
                }

                for (int i = 0; i < list.Count; i++) hexString += string.Format("{0:X2}", list[i]);

                switch (pageNum)
                {
                    case 0:
                        onlineModel.tbx_receive = hexString;
                        onlineModel.stx_value = hexString.Substring(0, 2);
                        onlineModel.dtc_value = hexString.Substring(2, 2);
                        onlineModel.ecd_value = hexString.Substring(4, 2);
                        onlineModel.len_value = hexString.Substring(6, 2);
                        onlineModel.cmd_value = hexString.Substring(8, 2);
                        onlineModel.sub_value = hexString.Substring(10, 2);
                        onlineModel.ack_value = hexString.Substring(12, 2);
                        onlineModel.crc_value = hexString.Substring(14, 2);
                        onlineModel.etx_value = hexString.Substring(16, 2);
                        break;

                    case 1:
                        writeModel.tbx_receive = hexString;
                        writeModel.stx_value = hexString.Substring(0, 2);
                        writeModel.dtc_value = hexString.Substring(2, 2);
                        writeModel.ecd_value = hexString.Substring(4, 2);
                        writeModel.len_value = hexString.Substring(6, 2);
                        writeModel.cmd_value = hexString.Substring(8, 2);
                        writeModel.sub_value = hexString.Substring(10, 2);
                        writeModel.ack_value = hexString.Substring(12, 2);
                        writeModel.crc_value = hexString.Substring(14, 2);
                        writeModel.etx_value = hexString.Substring(16, 2);
                        break;

                    case 2:
                        readModel.tbx_receive = hexString;
                        readModel.stx_value = hexString.Substring(0, 2);
                        readModel.dtc_value = hexString.Substring(2, 2);
                        readModel.ecd_value = hexString.Substring(4, 2);
                        readModel.len_value = hexString.Substring(6, 2);
                        readModel.cmd_value = hexString.Substring(8, 2);
                        readModel.sub_value = hexString.Substring(10, 2);

                        if (list[5] == 1) //Yes CARD
                        {
                            readModel.uid_value = hexString.Substring(12, 10);
                            readModel.cardData_value = hexString.Substring(22, 32);
                            readModel.cardData_value2 = hexString.Substring(54, 32);
                            readModel.wsID_value = hexString.Substring(86, 40);
                            readModel.crc_value = hexString.Substring(126, 2);
                            readModel.etx_value = hexString.Substring(128, 2);
                        }
                        else if (list[5] == 2)  //No CARD
                        {
                            readModel.wsID_value = hexString.Substring(12, 40);
                            readModel.crc_value = hexString.Substring(52, 2);
                            readModel.etx_value = hexString.Substring(54, 2);
                        }
                        break;

                        
                }

                TXsqlDate = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                mariaDB.AddDB(TXsqlDate, onlineModel.tbx_send, RXsqlDate, hexString);

                list.Clear();
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

        public static string ConvertByteToHexString(byte[] convertArr)     // Byte[] -> HEX String
        {
            string convertArrString = string.Empty;
            convertArrString = string.Concat(Array.ConvertAll(convertArr, byt => byt.ToString("X2")));
            return convertArrString;
        }

        private byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            return StrByte;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) //실시간 업데이트
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
