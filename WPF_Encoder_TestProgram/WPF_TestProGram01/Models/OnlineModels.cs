using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//OnLineCheck's models
namespace WPF_TestProgram01.Models
{
    public class OnlineModels : INotifyPropertyChanged
    {
        public string tbx_send { get; set; } //TX textbox

        private string _tbx_receive;         //RX textbox
        public string tbx_receive
        {
            get => _tbx_receive;
            set
            {
                _tbx_receive = value;
                OnPropertyChanged("tbx_receive"); //Event
            }
        }

        //-------------- Rectangle Text Block -------------//
        private string _stx_value;  
        public string stx_value
        {
            get => _stx_value;
            set
            {
                _stx_value = value;
                OnPropertyChanged("stx_value");
            }
        }

        private string _dtc_value;
        public string dtc_value
        {
            get => _dtc_value;
            set
            {
                _dtc_value = value;
                OnPropertyChanged("dtc_value");
            }
        }

        private string _ecd_value;
        public string ecd_value
        {
            get => _ecd_value;
            set
            {
                _ecd_value = value;
                OnPropertyChanged("ecd_value");
            }
        }

        private string _len_value;
        public string len_value 
        {
            get => _len_value; 
            set
            {
                _len_value = value;
                OnPropertyChanged("len_value");
            }
        }

        private string _cmd_value;
        public string cmd_value 
        {
            get => _cmd_value;
            set
            {
                _cmd_value = value;
                OnPropertyChanged("cmd_value");
            }
        }

        private string _sub_value;
        public string sub_value
        {
            get => _sub_value;
            set
            {
                _sub_value = value;
                OnPropertyChanged("sub_value");
            }
        }

        private string _ack_value;
        public string ack_value 
        {
            get => _ack_value;
            set 
            {
                _ack_value = value;
                OnPropertyChanged("ack_value");
            }
        }

        private string _crc_value;
        public string crc_value 
        {
            get => _crc_value;
            set
            {
                _crc_value = value;
                OnPropertyChanged("crc_value");
            }
        }

        private string _etx_value;
        public string etx_value 
        {
            get => _etx_value; 
            set
            {
                _etx_value = value;
                OnPropertyChanged("etx_value");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) //실시간 업데이트
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
