﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Testprogram2.Models.CardKey
{
    public class FreeCheckIn : Hexhelper, ICardKey
    {
        public int CardType { get; private set; } = (int)CardKeyType.Checkin;

        public int HotelCode { get; set; }

        public int ReaderNo { get; set; }

        public int SecurityNo { get; set; }

        public DateTime CheckoutDate { get; set; }

        public DateTime CheckinData { get; set; }

        public int IndexNo { get; set; }

        public int SuitArea { get; set; }

        public string SpecialArea { get; set; }

        public int CheckoutTime { get; set; }


        public byte[] ToPacket()
        {
            byte[] packet = new byte[32];

            //카드키 종류
            packet[0] = (byte)this.CardType;

            //호텔코드
            string strHotelcode = HotelCode.ToString("X4");
            packet[1] = Convert.ToByte(strHotelcode.Substring(0, 2), 16);
            packet[2] = Convert.ToByte(strHotelcode.Substring(2, 2), 16);

            //리더넘버
            string strReaderNo = this.ReaderNo.ToString("X4");
            packet[3] = Convert.ToByte(strReaderNo.Substring(0, 2), 16);
            packet[4] = Convert.ToByte(strReaderNo.Substring(2, 2), 16);

            //시큐리티넘버
            string strSecurityNo = this.SecurityNo.ToString("X4");
            packet[5] = Convert.ToByte(strSecurityNo.Substring(0, 2), 16);
            packet[6] = Convert.ToByte(strSecurityNo.Substring(2, 2), 16);

            //체크아웃날짜
            string strCheckoutDate = this.CheckoutDate.ToString("yymmdd");
            packet[7] = Convert.ToByte(strCheckoutDate.Substring(0, 2), 16);
            packet[8] = Convert.ToByte(strCheckoutDate.Substring(2, 2), 16);
            packet[9] = Convert.ToByte(strCheckoutDate.Substring(4, 2), 16);

            //인덱스 넘버
            packet[10] = Convert.ToByte(this.IndexNo);

            //체크인날짜
            string strCheckinDate = this.CheckinData.ToString("yymmdd");
            packet[11] = Convert.ToByte(strCheckinDate.Substring(0, 2), 16);
            packet[12] = Convert.ToByte(strCheckinDate.Substring(2, 2), 16);
            packet[13] = Convert.ToByte(strCheckinDate.Substring(4, 2), 16);

            packet[14] = Convert.ToByte(this.SuitArea);

            byte[] bspecialArea = base.intToReverseByteArray(this.SpecialArea);
            Array.Copy(bspecialArea, 0, packet, 15, bspecialArea.Length);

            packet[20] = Convert.ToByte(this.CheckoutTime);

            return packet;
        }
    }
}