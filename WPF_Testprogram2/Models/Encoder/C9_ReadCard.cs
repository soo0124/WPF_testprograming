using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Testprogram2.Models.Encoder
{
    public class C9_ReadCard
    {
        public byte[] ToByte(int encoderNo, ICardKey cardKey)
        {
            byte[] packet = new byte[28];

            packet[0] = 0x7B;
            packet[1] = 0x00;

            byte[] cardDate = cardKey.ToPacket();
            Array.Copy(cardDate, 0, packet, 2, cardDate.Length);

            packet[3] = Convert.ToByte(packet.Length);
            packet[4] = 0xC9;
            packet[5] = 0x01;

            packet[26] = CheckSum.Create(packet);
            packet[27] = 0x7D;

            return packet;
        }
    }
}
