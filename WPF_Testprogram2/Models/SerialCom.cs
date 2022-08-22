using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows;

namespace WPF_TestProgram01.Models
{
    public delegate void ByteReceiveHandler(byte[] packet);

    public class SerialCom
    {
        public SerialPort serialPort;
        private List<byte> serialBuffer = new List<byte>();

        public ByteReceiveHandler ByteReceive { get; set; }


        public delegate void DataReceiveHandler(byte[] receiveData);
        public DataReceiveHandler EncoderDataReceiveHandler { get; set; }

        public delegate void DisconnectHandler();
        public DisconnectHandler EncoderDisconnectHandler;


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
            serialPort = new SerialPort();
            try
            {
                serialPort.PortName = portName;
                serialPort.BaudRate = baudrate;
                serialPort.DataBits = databits;
                serialPort.StopBits = stopbits;
                serialPort.Parity = parity;
                serialPort.Encoding = new System.Text.ASCIIEncoding();

                serialPort.ErrorReceived += serialPort_ErrorReceived;
                //serialPort.DataReceived += serialPort_DataReceived;

                serialPort.DataReceived += DataReceived;

                serialPort.Open();

                StartCheckSerialOpenThread();

                return true;
            }
            catch (InvalidOperationException e1)
            {
                MessageBox.Show($"Model/SerialCom 62번\n{portName} is already opened.", e1.Message);
                return true;
            }
            catch (UnauthorizedAccessException e2)
            {
                MessageBox.Show($"Model/SerialCom 67번\nOther application is using {portName}.", e2.Message);
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
                    serialPort.DataReceived -= serialPort_DataReceived;
                    serialPort = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Model/SerialCom 88번\n" + ex.ToString(), ex.Message);
            }
        }

        public bool Send(byte[] sendData)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Write(sendData, 0, sendData.Length);
                    Console.WriteLine(BitConverter.ToString(sendData));
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Model/SerialCom 105번\n" + ex.ToString(), ex.Message);
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
                    Console.WriteLine(BitConverter.ToString(sendData));
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Model/SerialCom 123번\n" + ex.ToString(), ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 리시브 이벤트.
        /// </summary>
        /// <returns></returns>
        private byte[] ReadSerialByteData()
        {
            serialPort.ReadTimeout = 100;

            byte[] bytesBuffer = new byte[serialPort.BytesToRead];
            int bufferOffset = 0;
            int bytesToRead = serialPort.BytesToRead;

            while (bytesToRead >= 1)
            {
                try
                {
                    // 이게 문제네..
                    int readBytes = serialPort.Read(bytesBuffer, bufferOffset, bytesToRead - bufferOffset);

                    bytesToRead -= readBytes;
                    bufferOffset += readBytes;
                }
                catch (TimeoutException ex)
                {
                    MessageBox.Show("Model/SerialCom 146번\n" + ex.ToString(), ex.Message);
                }
            }

            //byte[] ReadBuffer = new byte[serialPort.BytesToRead];
            //serialPort.Read(ReadBuffer, 0, ReadBuffer.Length);

            return bytesBuffer;
            //return ReadBuffer;
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort receivedPort = sender as SerialPort;

            if(receivedPort.BytesToRead > 0)
            {
                List<byte> bufferQue = serialBuffer;

                while (receivedPort.BytesToRead > 0)
                {
                    byte b = (byte)receivedPort.ReadByte();
                    bufferQue.Add(b);   
                }

                //STX, Length, ETX 검사
                if (bufferQue.Count < 8) return;
                
                if (bufferQue.First() != 0x28)
                {
                    bufferQue.Clear();
                    return;
                }

                switch (bufferQue[4])
                {
                    case 0xC8:
                        if (bufferQue.Count < 68) return;
                        break;

                    case 0xC9 when bufferQue[5] == 0x01:
                        if (bufferQue.Count < 65) return;
                        break;

                    case 0xC9 when bufferQue[5] == 0x02:
                        if (bufferQue.Count < 28) return;
                        break;

                    case 0xCB:
                        if (bufferQue.Count < 65) return;
                        break;

                    case 0xD9:
                        if (bufferQue.Count < 9) return;
                        break;

                    default:
                        bufferQue.Clear();
                        return;
                }

                if(bufferQue.Last() != 0x29)
                {
                    bufferQue.Clear();
                    return;
                }



                byte[] packet = bufferQue.ToArray();
                bufferQue.Clear();

                ByteReceive?.Invoke(packet);
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] bytesBuffer = ReadSerialByteData();

                if (EncoderDataReceiveHandler != null) // 널인 경우가 있어서 그런가?
                {
                    EncoderDataReceiveHandler(bytesBuffer); // 이게문제네?
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Model/SerialCom 167번\n" + ex.ToString(), ex.Message);
            }
        }

        private void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show("Model/SerialCom 173번\n" + e.ToString());
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
                    MessageBox.Show("Model/SerialCom 211번\n" + ex.ToString(), ex.Message);
                }
            }
        }
    }
}
