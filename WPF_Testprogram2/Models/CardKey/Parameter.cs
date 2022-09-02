using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Testprogram2.Models.CardKey
{
    public class Parameter : ICardKey
    {
        public int CardType { get; private set; } = (int)CardKeyType.Parameter;

        public int HotelCode { get; set; }

        public int SecurityNo { get; set; }

        public int GLEDtime { get; set; }

        public int RLEDtime { get; set; }

        public int TypeOfLock { get; set; }

        public bool SetStaffDND { get; set; }

        public bool SetOfficeMode { get; set; }

        public byte[] ToPacket()
        {
            byte[] packet = new byte[11];

            //카드키 종류
            packet[0] = (byte)this.CardType;

            //호텔코드
            string strHotelcode = HotelCode.ToString("X4");
            packet[1] = Convert.ToByte(strHotelcode.Substring(0, 2), 16);
            packet[2] = Convert.ToByte(strHotelcode.Substring(2, 2), 16);

            //NULL 2Byte
            packet[3] = 0x00;
            packet[4] = 0x00;

            //시큐리티넘버
            string strSecurityNo = this.SecurityNo.ToString("X4");
            packet[5] = Convert.ToByte(strSecurityNo.Substring(0, 2), 16);
            packet[6] = Convert.ToByte(strSecurityNo.Substring(2, 2), 16);

            packet[7] = (byte)GLEDtime;

            packet[8] = (byte)RLEDtime;

            string strFunction = $"{Convert.ToByte(SetStaffDND)}{Convert.ToByte(SetOfficeMode)}";
            packet[9] = Convert.ToByte(Convert.ToInt32(strFunction, 2));

            packet[10] = (byte)TypeOfLock;

            return packet;
        }
    }
}
