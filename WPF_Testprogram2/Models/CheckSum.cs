using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Testprogram2.Models
{
    public class CheckSum
    {
        public static byte Create(byte[] packet)
        {
            int checkSum = 0;

            for (int i = 0; i < packet.Length; i++)
            {
                checkSum += packet[i];
            }

            return Convert.ToByte(checkSum & 0x55);
        }
    }
}
