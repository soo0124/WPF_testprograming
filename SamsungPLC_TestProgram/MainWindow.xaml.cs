using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SamsungPLC_TestProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort serialPort;

        public MainWindow()
        {
            InitializeComponent();

            cb_COM.ItemsSource = SerialPort.GetPortNames();
            cb_COM.SelectedIndex = 2;

        }

        private void btn_Connect_Click(object sender, RoutedEventArgs e)
        {
            serialPort = new SerialPort(cb_COM.SelectedValue.ToString(),9600,Parity.Even,8,StopBits.One);

            serialPort.DataReceived += SerialPort_DataReceived;

            try
            {
                if(!serialPort.IsOpen)
                {
                    serialPort.Open();
                    MessageBox.Show($"{cb_COM.SelectedValue} 연결완료", "통신포트");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) //RX
        {
            if (serialPort.BytesToRead > 0)
            {
                byte[] packet = new byte[serialPort.BytesToRead];
                serialPort.Read(packet, 0, packet.Length);
                
                tbk_Console.Text = BitConverter.ToString(packet);
            }
        }

        public void SerialPort_DataTransmit(byte[] packet) //TX
        {
            if (serialPort == null || serialPort.IsOpen == false)
            {
                MessageBox.Show("* 통신 포트 연결상태를 확인하세요 *", "ERROR");
            }
            else
            {
                serialPort.Write(packet, 0, packet.Length);
                
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

        private void btn_com_5status(object sender, RoutedEventArgs e)
        {
            string comStatus_5 = "320011200100B0FFFFC01472014052051F9434";

            byte[] comStatus_5_byte = ConvertHexStringToByte(comStatus_5);

            for (int i = 0; i < 5; i++)
            {
                SerialPort_DataTransmit(comStatus_5_byte);
                Thread.Sleep(1000);
            }
        }

        private void btn_PLCtoRCU1(object sender, RoutedEventArgs e)
        {
            string PLCtoRCU_1 = "320008FFFFFF01971E34";

            byte[] PLCtoRCU_1_byte = ConvertHexStringToByte(PLCtoRCU_1);
            SerialPort_DataTransmit(PLCtoRCU_1_byte);
        }

        private void btn_PLCtoRCU2(object sender, RoutedEventArgs e)
        {
            string PLCtoRCU_2 = "320108FFFFFF01971E34";

            byte[] PLCtoRCU_2_byte = ConvertHexStringToByte(PLCtoRCU_2);
            SerialPort_DataTransmit(PLCtoRCU_2_byte);
        }

        private void btn_PLCtoRCU3(object sender, RoutedEventArgs e)
        {
            string PLCtoRCU_3 = "320208FFFFFF01971E34";

            byte[] PLCtoRCU_3_byte = ConvertHexStringToByte(PLCtoRCU_3);
            SerialPort_DataTransmit(PLCtoRCU_3_byte);
        }

        private void btn_PLCtoRCU4(object sender, RoutedEventArgs e)
        {
            string PLCtoRCU_4 = "320308FFFFFF01971E34";

            byte[] PLCtoRCU_4_byte = ConvertHexStringToByte(PLCtoRCU_4);
            SerialPort_DataTransmit(PLCtoRCU_4_byte);
        }

        private void btn_ResponseRCU1(object sender, RoutedEventArgs e)
        {
            string ResponseRCU_1 = "32000E200000510000C0160000299C34";

            byte[] ResponseRCU_1_byte = ConvertHexStringToByte(ResponseRCU_1);
            SerialPort_DataTransmit(ResponseRCU_1_byte);
        }

        private void btn_ResponseRCU2(object sender, RoutedEventArgs e)
        {
            string ResponseRCU_2 = "32010E200000510000C0160000299C34";

            byte[] ResponseRCU_2_byte = ConvertHexStringToByte(ResponseRCU_2);
            SerialPort_DataTransmit(ResponseRCU_2_byte);
        }

        private void btn_ResponseRCU3(object sender, RoutedEventArgs e)
        {
            string ResponseRCU_3 = "32020E200000510000C0160000299C34";

            byte[] ResponseRCU_3_byte = ConvertHexStringToByte(ResponseRCU_3);
            SerialPort_DataTransmit(ResponseRCU_3_byte);
        }

        private void btn_ResponseRCU4(object sender, RoutedEventArgs e)
        {
            string ResponseRCU_4 = "32030E200000510000C0160000299C34";

            byte[] ResponseRCU_4_byte = ConvertHexStringToByte(ResponseRCU_4);
            SerialPort_DataTransmit(ResponseRCU_4_byte);
        }

    }
}
