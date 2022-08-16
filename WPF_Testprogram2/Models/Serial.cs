using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Testprogram2.Models
{
    public delegate void ConnectionChangedHandler(bool isConnect);

    public class Serial
    {
        private SerialPort mSerialPort;
        public ConnectionChangedHandler connectionChanged;

        public void Open(string portName)
        {
            if(string.IsNullOrEmpty(portName))
            {
                return;
            }

            mSerialPort = new SerialPort()
            {
                PortName = portName,
                BaudRate = 19200,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Encoding = Encoding.ASCII,
            };
            //mSerialPort.DataReceived += DataReceived;

            try
            {
                mSerialPort.Open();
                connectionChanged?.Invoke(true);
            }
            catch (Exception EX)
            {
                connectionChanged?.Invoke(false);
            }
            Task.Run(() => ConnectionRoof());
        }

        private async void ConnectionRoof()
        {
            while (mSerialPort != null)
            {
                if(!mSerialPort.IsOpen)
                {
                    connectionChanged?.Invoke(false);
                }

                await Task.Delay(1000);
            }
        }

        public bool Close()
        {
            try
            {
                if(mSerialPort != null && mSerialPort.IsOpen == true)
                {
                    connectionChanged?.Invoke(false);

                    mSerialPort.Close();
                    mSerialPort.Dispose();

                    mSerialPort = null;
                }

                return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return false;
        }

        //private void DataReceived()
    }
}
