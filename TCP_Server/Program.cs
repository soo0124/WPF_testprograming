﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            // (1) 로컬 포트 7000 을 Listen
            TcpListener listener = new TcpListener(IPAddress.Any, 7000);
            listener.Start();

            byte[] buff = new byte[1024];

            while (true)
            {
                // (2) TcpClient Connection 요청을 받아들여
                //     서버에서 새 TcpClient 객체를 생성하여 리턴
                TcpClient tc = listener.AcceptTcpClient();

                // (3) TcpClient 객체에서 NetworkStream을 얻어옴 
                NetworkStream stream = tc.GetStream();

                // (4) 클라이언트가 연결을 끊을 때까지 데이타 수신
                int nbytes;
                while ((nbytes = stream.Read(buff, 0, buff.Length)) > 0)
                {
                    byte[] packet = new byte[nbytes];
                    Array.Copy(buff, 0, packet, 0, packet.Length);

                    string log = string.Format("{0:yyyy-MM-dd HH:mm:ss}\t클라이언트의 데이터를 수신했다. {1}\n", DateTime.Now, Encoding.UTF8.GetString(packet));

                    Console.Write(log);
                    File.WriteAllText(@"C:\Users\swjang\source\repos\TCP_Server\bin\Debug\log.txt", log);


                    // (5) 데이타 그대로 송신
                    stream.Write(buff, 0, nbytes);
                }

                // (6) 스트림과 TcpClient 객체 
                stream.Close();
                tc.Close();

                // (7) 계속 반복
            }
        }
    }
}
