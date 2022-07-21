using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class MainViewModel
    {
        public Model MyModel { get; set; } = new Model() { Id = 1, Name = "모델", Rate = 38400 };

        public ObservableCollection<Model> ModelList { get; set; }
            = new ObservableCollection<Model>()
            {
                new Model() { Name = "1" },
                new Model() { Name = "2" },
                new Model() { Name = "3" }
            };

        public ObservableCollection<string> ModelList2{ get; set; }
            = new ObservableCollection<string>()
            {
                        "1",
                        "2",
                        "3"
            };


        public MainViewModel()
        {
        }
    }
}
