using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPF_TestProgram01.Model
{
    public class MainModel : INotifyPropertyChanged
    {
        private string _frameSource { get; set; } = "/Views/OnLineCheck.xaml";
        public string frameSource
        {
            get =>  _frameSource;
            set
            {
                _frameSource = value;
                OnPropertyChanged("FrameSource");
            }
        }

        public string[] _comPort { get; set; } = SerialPort.GetPortNames();
        public string Pick_comPort { get; set; } 

        public int[] _baudRate { get; set; } = { 4800, 7200, 9600, 19200, 38400 };
        public int Pick_baudRate { get; set; } = 0;

        public int[] _dataBits { get; set; } = { 7, 8, 9 };
        public int Pick_dataBit { get; set; } = 0;

        public int[] _stopBits { get; set; } = { 1, 2, 3 };
        public int Pick_stopBit { get; set; } = 0;

        public string[] _parityBits { get; set; } = { "SPACE", "NONE", "EVEN" };
        public string Pick_parityBit { get; set; }

        private string mbtn_start_name = "연결 시작!";
        public string btn_start_name 
        {
            get => mbtn_start_name; 
            set
            {
                mbtn_start_name = value;
                OnPropertyChanged("btn_start_name");
            }
        }

        private string mbtn_start_color = "White";
        public string btn_start_color 
        {
            get => mbtn_start_color;
            set
            {
                mbtn_start_color = value;
                OnPropertyChanged("btn_start_color");
            }
        }

        

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) //실시간 업데이트
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
