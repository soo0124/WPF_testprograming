using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_Setting_Program.Models
{
    public class DTC_List : Notify
    {
        private string _name;
        public string name
        {
            get => _name;
            set => _name = value;
        }

        private int _address;
        public int address
        {
            get => _address;
            set => _address = value;
        }

        private int _rcuCount;
        public int rcuCount
        {
            get => _rcuCount;
            set => base.OnPropertyChanged(ref _rcuCount, value);
        }

        public DTC_List(string dtc_name, int dtc_address)
        {
            this.name = dtc_name;
            this.address = dtc_address;
        }
    }
}
