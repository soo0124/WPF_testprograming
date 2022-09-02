using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_Setting_Program.Models
{
    public class Relay : Notify
    {
        private int _relayNo;
        public int relayNo
        {
            get => _relayNo;
            set => base.OnPropertyChanged(ref _relayNo, value);
        }

        private ObservableCollection<MatchItem> _circuitNo = new ObservableCollection<MatchItem>();
        public ObservableCollection<MatchItem> circuitNo
        {
            get => _circuitNo;
            set => base.OnPropertyChanged(ref _circuitNo, value);
        }

        private MatchItem _selectCircuitNo;
        public MatchItem selectCircuitNo
        {
            get => _selectCircuitNo;
            set => base.OnPropertyChanged(ref _selectCircuitNo, value);
        }

        private bool _IsChecked;
        public bool IsChecked
        {
            get => _IsChecked;
            set => base.OnPropertyChanged(ref _IsChecked, value);
        }
    }
}
