using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Testprogram2.Models.CardKey
{
        public enum CardKeyType
        {
            Checkin = 0x00,
            PreCheckin = 0x01,
            Standby = 0x02,
            Onetime = 0x03,

            Emergency = 0x04,
            Grandmaster = 0x05,
            Master = 0x06,
            Maid = 0x07,
            Minibar = 0x08,

            Group = 0x09,

            Reset = 0x0F,
            Time = 0x10,
            Init = 0x11,
            Parameter = 0x12,
            Address = 0x14,
            HHT = 0x1C
        }
    
}
