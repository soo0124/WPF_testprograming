using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Testprogram2.Models.Encoder
{
    public class C8_WriteCard : IEncoder
    {
        public byte[] ToByte(int encoderNo, ICardKey cardKey)
        {
            byte[] packet = new byte[60];

            //STX 
            packet[0] = 0x7B;

            //DTC
            packet[1] = 0x00;
            packet[2] = Convert.ToByte(encoderNo);

            packet[3] = Convert.ToByte(packet.Length);

            //CMD, Sub
            packet[4] = 0xC8;
            packet[5] = 0x01;

            byte[] cardDate = cardKey.ToPacket();
            Array.Copy(cardDate, 0, packet, 6, cardDate.Length);

            //WSID = 38 ~ 57 (20자리)

            //Check Sum
            packet[58] = CheckSum.Create(packet);
            
            //ETX
            packet[59] = 0x7D;

            return packet;
        }
    }
}
