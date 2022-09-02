using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Testprogram2.Models.Encoder
{
    public enum EncoderCommand
    {
        WriteCard = 0xC8,
        DeleteCard = 0xC8,
        ReadCard = 0xC9,
        OnlineCheck = 0xD9
    }
}
