using SH_company.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH_company.ViewModels
{
    public partial class MainViewModel : Notify
    {
        public ObservableCollection<RcsModel> rcsPlace { get; set; }


        public string weatherURL = "https://www.kma.go.kr/XML/weather/sfc_web_map.xml";
        private string _YMD;
        public string YMD
        {
            get { return _YMD; }
            set { base.OnPropertyChanged(ref _YMD, value); }
        }

        private string _HMS;
        public string HMS
        {
            get { return _HMS; }
            set { base.OnPropertyChanged(ref _HMS, value); }
        }

        private string _weather = "../Resources/Snow.png";
        public string weather
        {
            get { return _weather; }
            set { base.OnPropertyChanged(ref _weather, value); }
        }

        private Uri _frameSource = new Uri("RCSplaceView.xaml", UriKind.Relative);
        public Uri frameSource
        {
            get => _frameSource;
            set => base.OnPropertyChanged(ref _frameSource, value);
        }

        public string txt_place { get; set; }
        public string txt_sale { get; set; }
        public string txt_pm { get; set; }
        public string txt_as { get; set; }
        public int txt_roomCnt { get; set; }
        public string testbtn { get; set; }


    }
}
