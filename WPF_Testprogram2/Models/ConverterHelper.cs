using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Testprogram2.Models
{
    public class ConverterHelper
    {
        public static byte[] StringToByteArray(string data)
        {
            try
            {
                string str = data.Trim().Replace("-", ""); //Trim: 공백제거, Replace: 좌측을 우측으로 변경

                byte[] sendPacket = new byte[str.Length / 2];
                for (int i = 0; i <sendPacket.Length; i++)
                {
                    string strSub = str.Substring(i * 2, 2);
                    byte sendByte = Convert.ToByte(strSub, 16);
                    sendPacket[i] = sendByte;
                }

                return sendPacket;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        public static byte[] ConvertHexStringToByte(string convertString)  // HEX String -> Byte[] 
        {
            byte[] convertArr = new byte[convertString.Length / 2];
            for (int i = 0; i < convertArr.Length; i++)
            {
                convertArr[i] = Convert.ToByte(convertString.Substring(i * 2, 2), 16);
            }
            return convertArr;
        }
    }
}
