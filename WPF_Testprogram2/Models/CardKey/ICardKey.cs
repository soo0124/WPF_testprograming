using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Testprogram2.Models
{
    public interface ICardKey
    {
        byte[] ToPacket();
    }

}
