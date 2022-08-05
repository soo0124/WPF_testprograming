using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testprogram
{
    public class DTC_setting
    {
        public byte RcuCount { get; set; }
        public String Name { get; set;  }
        public int Address { get; set; }
        public DTC_setting(String Name, int Address)
        {
            this.Name = Name;
            this.Address = Address;
        }
    }
}
