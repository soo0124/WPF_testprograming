using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;

namespace SoftwareFusionProject_JSH.Models
{
    public delegate void ByteReceiveHandler(byte[] packet);

    public class SerialTest
    {
        /// <summary>
        /// D or R
        /// </summary>
        private string commType = string.Empty;
        public SerialPort serialPort = new SerialPort();
        private List<byte> serialBuffer = new List<byte>();

        public event ByteReceiveHandler ByteReceive;

        public bool IsOpen
        {
            get
            {
                if (serialPort != null) return serialPort.IsOpen;
                return false;
            }
        }

        public SerialTest(string commType)
        {
            this.commType = commType;
        }

        public bool OpenPort(string portName, int baudrate, int databits, StopBits stopbits, Parity parity)
        {
            try
            {
                serialPort.PortName = portName;
                serialPort.BaudRate = baudrate;
                serialPort.DataBits = databits;
                serialPort.StopBits = stopbits;
                serialPort.Parity = parity;
                serialPort.Encoding = new System.Text.ASCIIEncoding();

                serialPort.DataReceived += DataReceived;

                serialPort.Open();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public void ClosePort()
        {
            try
            {
                if (serialPort != null)
                {
                    serialPort.Close();
                    serialPort.Dispose();
                    serialPort.DataReceived -= DataReceived;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public bool Send(string sendData)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Write(sendData);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool Send(byte[] sendData)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Write(sendData, 0, sendData.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool Send(byte[] sendData, int offset, int count)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Write(sendData, offset, count);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return false;
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (commType == "D")
            {
                ReceivedCheck_D(sender);
            }
            else
            {
                ReceivedCheck_R(sender);
            }
        }


        private void ReceivedCheck_D(object sender)
        {
            SerialPort receivedPort = sender as SerialPort;

            if (receivedPort.BytesToRead > 0)
            {
                Console.WriteLine("{0} DataReceived_D", DateTime.Now);
                List<byte> bufferQue = serialBuffer;

                while (receivedPort.BytesToRead > 0)
                {
                    try
                    {
                        byte b = (byte)receivedPort.ReadByte();
                        bufferQue.Add(b);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }

                //STX, Length, ETX 검사
                if (bufferQue.Count < 8) return;

                if (bufferQue.First() != 0xAA)
                {
                    Console.WriteLine("{0:HH:mm:ss.ffff}\t{1}\t{2}", DateTime.Now, "DataReceived_D", "Clear");
                    bufferQue.Clear();
                    return;
                }

                switch (bufferQue[1])
                {
                    case 0x01:
                        if (bufferQue.Count < 8) return;
                        break;


                    default:
                        Console.WriteLine("{0:HH:mm:ss.ffff}\t{1}\t{2}", DateTime.Now, "DataReceived_D", "Clear");
                        bufferQue.Clear();
                        return;
                }

                if (bufferQue.Last() != 0xFF)
                {
                    Console.WriteLine("{0:HH:mm:ss.ffff}\t{1}\t{2}", DateTime.Now, "DataReceived_D", "Clear");
                    bufferQue.Clear();
                    return;
                }

                byte[] packet = bufferQue.ToArray();
                bufferQue.Clear();

                ByteReceive?.Invoke(packet);
                Console.WriteLine("DataReceived_D => {0}", receivedPort.BytesToRead);
            }

        }

        private void ReceivedCheck_R(object sender)
        {
            SerialPort receivedPort = sender as SerialPort;

            if (receivedPort.BytesToRead > 0)
            {
                Console.WriteLine("{0} DataReceived_R", DateTime.Now);

                List<byte> bufferQue = serialBuffer;

                while (receivedPort.BytesToRead > 0)
                {
                    try
                    {
                        byte b = (byte)receivedPort.ReadByte();
                        bufferQue.Add(b);
                    }
                    catch (Exception)
                    {
                        return;
                    }

                }
                if (bufferQue.Count < 10) return;

                if (bufferQue.First() != 0x5B)
                {
                    Console.WriteLine("{0:HH:mm:ss.ffff}\t{0}\t{1}", DateTime.Now, "DataReceived_R", "Clear");
                    bufferQue.Clear();
                    return;
                }

                if (bufferQue.Last() != 0x5D)
                {
                    Console.WriteLine("{0:HH:mm:ss.ffff}\t{0}\t{1}", DateTime.Now, "DataReceived_R", "Clear");
                    bufferQue.Clear();
                    return;
                }

                if (bufferQue.First() == 0x5B)
                {
                    if (bufferQue.Last() == 0x5D)
                    {
                        byte[] packet = bufferQue.ToArray();
                        Console.WriteLine("{0:HH:mm:ss.ffff}\t{0}\t{1}", DateTime.Now, "DataReceived_R", "Clear");
                        bufferQue.Clear();

                        ByteReceive?.Invoke(packet);
                        Console.WriteLine("DataReceived_R => {0}", receivedPort.BytesToRead);
                    }
                }
            }
        }
    }
}
