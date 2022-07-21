using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TestProgram01.Models
{
    public class DbModel
    {
        public string tbx_DB_IP { get; set; } = "localhost";

        public string tbx_DB_PORT { get; set; } = "5000";

        public string tbx_DB_NAME { get; set; } = "racos";

        public string tbx_DB_USER { get; set; } = "root";

        public string tbx_DB_PW { get; set; } = String.Empty;

        private string mbtn_dbstart_color = "White";
        public string btn_dbstart_color
        {
            get => mbtn_dbstart_color;
            set
            {
                mbtn_dbstart_color = value;
                OnPropertyChanged("btn_dbstart_color");
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
