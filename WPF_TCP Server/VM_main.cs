using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_TCP_Server
{
    public class VM_main : Notify
    {
        private string mTxtServerIP = "192.168.0.40";
        public string TxtServerIP
        {
            get => mTxtServerIP;
            set => base.OnPropertyChanged(ref mTxtServerIP, value);
        }

        private int mTxtServerPort = 7532;
        public int TxtServerPort
        {
            get => mTxtServerPort;
            set => base.OnPropertyChanged(ref mTxtServerPort, value);
        }

        private string mTxtReceived = string.Empty;
        public string TxtReceived
        {
            get => mTxtReceived;
            set => base.OnPropertyChanged(ref mTxtReceived, value);
        }

        private string mTxtSend = string.Empty;
        public string TxtSend
        {
            get => mTxtSend;
            set => base.OnPropertyChanged(ref mTxtSend, value);
        }


        public TcpListener mTcpListener;       //Server
        public TcpClient mTcpClient;           //Client
        public NetworkStream mNetworkStream;   //송수신 매체

        public void isConnect()
        {
            Task.Run(() =>
            {
                mTcpListener = new TcpListener(IPAddress.Parse(TxtServerIP), TxtServerPort);

                if (mTcpListener == null)
                {
                    MessageBox.Show("IP값을 다시 설정해주세요.");
                    return;
                }
                try
                {
                    // 서버 개방을 시작합니다.
                    mTcpListener.Start();

                    // 연결요청이 들어오면 수락합니다. (보류중이던 연결도 진행합니다.)
                    mTcpClient = mTcpListener.AcceptTcpClient();
                    mNetworkStream = mTcpClient.GetStream();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                while (mTcpClient != null)
                {
                    if (mTcpClient.Available < 0)
                    {
                        return;
                    }
                    try
                    {
                        byte[] ReceiveMsg = new byte[mTcpClient.Available];
                        mNetworkStream.Read(ReceiveMsg, 0, ReceiveMsg.Length);
                        if (ReceiveMsg.Length > 0)
                        {
                            TxtReceived += $"[Client]: {Encoding.ASCII.GetString(ReceiveMsg)}\n";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        mNetworkStream.Close();
                        break;
                    }
                }
            });
        }

        public void Send()
        {
            if(mTcpClient != null && mTcpClient.Connected == true)
            {
                try
                {
                    byte[] sendMsg = Encoding.ASCII.GetBytes(TxtSend);

                    mNetworkStream.Write(sendMsg, 0, sendMsg.Length);
                }
                catch (Exception)
                {

                }
            }
        }

       
    }
}
