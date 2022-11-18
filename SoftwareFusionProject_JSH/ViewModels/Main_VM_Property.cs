using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using SoftwareFusionProject_JSH.Models;

namespace SoftwareFusionProject_JSH.ViewModels
{
    public partial class Main_ViewModel : Notify
    {
        private Uri _frameSource = new Uri("SetupView.xaml", UriKind.Relative);
        public Uri frameSource
        {
            get => _frameSource;
            set => base.OnPropertyChanged(ref _frameSource, value);
        }

        private ObservableCollection<String> _portLists = new ObservableCollection<string>();
        public ObservableCollection<String> portLists
        {
            get => _portLists;
            set => base.OnPropertyChanged(ref _portLists, value);
        }

        private string _selectPortD;
        public string selectPortD
        {
            get => _selectPortD;
            set => base.OnPropertyChanged(ref _selectPortD, value);
        }

        private string _selectPortR;
        public string selectPortR
        {
            get => _selectPortR;
            set => base.OnPropertyChanged(ref _selectPortR, value);
        }

        private bool _detectConnect;
        public bool detectConnect
        {
            get => _detectConnect;
            set => base.OnPropertyChanged(ref _detectConnect, value);
        }

        private bool _readerConnect;
        public bool readerConnect
        {
            get => _readerConnect;
            set => base.OnPropertyChanged(ref _readerConnect, value);
        }

        private bool _allConnect;
        public bool allConnect
        {
            get => _allConnect;
            set => base.OnPropertyChanged(ref _allConnect, value);
        }

        private bool _roomCheck;
        public bool roomCheck
        {
            get => _roomCheck;
            set => base.OnPropertyChanged(ref _roomCheck, value);
        }

        private string _rcvPacket;
        public string rcvPacket
        {
            get => _rcvPacket;
            set => base.OnPropertyChanged(ref _rcvPacket, value);
        }

        private string _lectureStatus = "Empty";
        public string lectureStatus
        {
            get => _lectureStatus;
            set => base.OnPropertyChanged(ref _lectureStatus, value);
        }

        private string _accessStatus;
        public string accessStatus
        {
            get => _accessStatus;
            set => base.OnPropertyChanged(ref _accessStatus, value);
        }

        private string _rxpacket;
        public string rxpacket
        {
            get => _rxpacket;
            set => base.OnPropertyChanged(ref _rxpacket, value);
        }
    }
}
