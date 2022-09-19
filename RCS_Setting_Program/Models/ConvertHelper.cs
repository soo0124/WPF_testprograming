using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_Setting_Program.Models
{
    public class ConvertHelper
    {
        // HEX String -> Byte[] 
        public static byte[] ConvertHexStringToByte(string convertString) 
        {
            byte[] convertArr = new byte[convertString.Length / 2];
            for (int i = 0; i < convertArr.Length; i++)
            {
                convertArr[i] = Convert.ToByte(convertString.Substring(i * 2, 2), 16);
            }
            return convertArr;
        }

        // Byte[] -> HEX String
        public static string ConvertByteToHexString(byte[] convertArr)     
        {
            string convertArrString = string.Empty;
            convertArrString = string.Concat(Array.ConvertAll(convertArr, byt => byt.ToString("X2")));
            return convertArrString;
        }

        public static byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            return StrByte;
        }

        public static string ConvertStringToHexString(string convertString)
        {
            byte[] bytes = Encoding.Default.GetBytes(convertString);
            string convertHexString = BitConverter.ToString(bytes).Replace("-", " ");

            return convertHexString;
        }

    }
}
