using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace TcpSocekt_Module.Service
{
    public class TCP_Server_Module 
    {
        private TcpListener serverListener;


        public bool TcpOpen(int port)
        {
            bool result = false;

            serverListener = new TcpListener(port);
            serverListener.Start();

            Console.WriteLine("server open");

            serverListener.BeginAcceptSocket(asyncacceptSocket, serverListener);

            result = true;

            return result;
        }

        private void asyncacceptSocket(IAsyncResult ar)
        {
            byte[] test = new byte[1024];
            TcpListener server = ar.AsyncState as TcpListener;

            Socket client = server.EndAcceptSocket(ar);
            client.BeginReceive(test, 0, test.Length, SocketFlags.None, asyncReceived, client);

            server.BeginAcceptSocket(asyncacceptSocket, server);
        }

        private void asyncReceived(IAsyncResult ar)
        {
            byte[] test = new byte[1024];
            Socket client = ar.AsyncState as Socket;

            int length = client.EndReceive(ar);

            if (length > 0)
            {
                Console.WriteLine($"데이터 {length}바이트 수신.");
            }

            client.BeginReceive(test, 0, test.Length, SocketFlags.None, asyncReceived, client);
        }

        public void Send(byte[] packet)
        {
            serverListener.Server.Send(packet);

        }
    }
}
