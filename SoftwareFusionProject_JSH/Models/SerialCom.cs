using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows;

namespace SoftwareFusionProject_JSH.Models
{
    public delegate void ByteReceiveHandler(byte[] packet);

    public class SerialCom
    {
        public SerialPort serialPort = new SerialPort();

        private List<byte> serialBuffer = new List<byte>();

        public delegate void DataReceiveHandler(byte[] receiveData);
        public DataReceiveHandler EncoderDataReceiveHandler { get; set; }

        public delegate void DisconnectHandler();
        public DisconnectHandler EncoderDisconnectHandler;

        public event ByteReceiveHandler ByteReceive;

        public bool IsOpen
        {
            get
            {
                if (serialPort != null) return serialPort.IsOpen;
                return false;
            }
        }

        private Thread threadCheckSerialOpen;
        private bool isThreadCheckSerialOpen = false;

        public bool OpenCom(string portName, int baudrate, int databits, StopBits stopbits, Parity parity)
        {
            try
            {
                serialPort.PortName = portName;
                serialPort.BaudRate = baudrate;
                serialPort.DataBits = databits;
                serialPort.StopBits = stopbits;
                serialPort.Parity = parity;
                serialPort.Encoding = new System.Text.ASCIIEncoding();

                serialPort.ErrorReceived += serialPort_ErrorReceived;
                serialPort.DataReceived += DataReceived_D;
                serialPort.DataReceived += DataReceived_R;

                serialPort.Open();

                StartCheckSerialOpenThread();

                return true;
            }
            catch (InvalidOperationException e1)
            {
                MessageBox.Show($"Model/SerialCom 53번\n{portName} is already opened.", e1.Message);
                return false;
            }
            catch (UnauthorizedAccessException e2)
            {
                MessageBox.Show($"Model/SerialCom 58번\nOther application is using {portName}.", e2.Message);
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("You need Port set-up");
                return false;
            }
        }

        public void CloseCom()
        {
            try
            {
                if (serialPort != null)
                {
                    StopCheckSerialOpenThread();
                    serialPort.Close();
                    serialPort.Dispose();
                    serialPort.ErrorReceived -= serialPort_ErrorReceived;
                    serialPort.DataReceived -= DataReceived_D;
                    serialPort.DataReceived -= DataReceived_R;
                    //serialPort = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Model/SerialCom 79번\n" + ex.ToString(), ex.Message);
            }
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
                MessageBox.Show("Model/SerialCom 95번\n" + ex.ToString(), ex.Message);
            }
            return false;
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
                MessageBox.Show("Model/SerialCom 112번\n" + ex.ToString(), ex.Message);
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
                MessageBox.Show("Model/SerialCom 129번\n" + ex.ToString(), ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 리시브 이벤트.
        /// </summary>
        /// <returns></returns>
        private void DataReceived_R(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort receivedPort = sender as SerialPort;

            if (receivedPort.BytesToRead > 0)
            {
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
                if (bufferQue.Count < 8) return;

                byte[] packet = bufferQue.ToArray();
                bufferQue.Clear();

                ByteReceive?.Invoke(packet);
            }
        }

        private void DataReceived_D(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort receivedPort = sender as SerialPort;

            if (receivedPort.BytesToRead > 0)
            {
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
                    bufferQue.Clear();
                    return;
                }

                switch (bufferQue[1])
                {
                    case 0x01:
                        if (bufferQue.Count < 8) return;
                        break;


                    default:
                        bufferQue.Clear();
                        return;
                }

                if (bufferQue.Last() != 0xFF)
                {
                    bufferQue.Clear();
                    return;
                }

                byte[] packet = bufferQue.ToArray();
                bufferQue.Clear();

                ByteReceive?.Invoke(packet);
            }
        }

        

        private void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show("Model/SerialCom 188번\n" + e.ToString());
        }

        private void StartCheckSerialOpenThread()
        {
            isThreadCheckSerialOpen = true;
            threadCheckSerialOpen = new Thread(new ThreadStart(ThreadCheckSerialOpen));
            threadCheckSerialOpen.Start();
        }

        private void StopCheckSerialOpenThread()
        {
            if (isThreadCheckSerialOpen)
            {
                isThreadCheckSerialOpen = false;
                if (Thread.CurrentThread != threadCheckSerialOpen)
                    threadCheckSerialOpen.Join();
            }
        }

        private void ThreadCheckSerialOpen()
        {
            while (isThreadCheckSerialOpen)
            {
                Thread.Sleep(100);

                try
                {
                    if (serialPort == null || !serialPort.IsOpen)
                    {
                        if (EncoderDisconnectHandler != null)
                            EncoderDisconnectHandler();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Model/SerialCom 225번\n" + ex.ToString(), ex.Message);
                }
            }
        }
    }
}
