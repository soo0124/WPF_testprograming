using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Testprogram2.Models.Encoder
{
    public interface IEncoder
    {
        /// <summary>
        /// 엔코더에 바이트배열로 송신한다. 
        /// </summary>
        /// <param name="encoderNo"></param>
        /// <param name="cardKey"></param>
        /// <returns></returns>
        byte[] ToByte(int encoderNo, ICardKey cardKey);
        
        
    }
}
