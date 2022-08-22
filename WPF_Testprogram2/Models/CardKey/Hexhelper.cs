using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Testprogram2.Models.CardKey
{
    public class Hexhelper
    {
        public byte[] intToReverseByteArray(string specialArea)
        {
            string str = specialArea.PadRight(40, '0');

            byte[] hex = new byte[str.Length/8];

            for (int i = 0; i < hex.Length; i++)
            {
                string s = str.Substring(i * 8, 8);
                int si = Convert.ToInt32(s, 2);

                hex[i] = Convert.ToByte(si);
            }

            return hex;
        }
    }
}
