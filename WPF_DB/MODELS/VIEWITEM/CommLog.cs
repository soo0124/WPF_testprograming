using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_DB.MODELS.VIEWITEM
{
    public class CommLog : Notify
    {
        public int No { get; set; }

        public DateTime EventDateTime { get; set; }

        private bool _Division;
        public bool Division
        {
            get => _Division;
            set => base.OnPropertyChanged(ref _Division, value);
        }
        

        public string packet { get; set; }
    }
}
