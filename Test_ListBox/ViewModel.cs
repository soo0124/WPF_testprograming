using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Media;

namespace Test_ListBox
{
    public class User
    {
        public string Name { get; set; }

        public string Checkin { get; set; } = "✔️";
    }

    public class Dong
    {
        public string DongName { get; set; }
    }

    public class Floor : Dong
    {
        public string FloorName { get; set; }
    }

    public class Model : Floor
    {
        public string AcuType { get; set; }

        public string AcuName { get; set; }

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
    }

    public class ViewModel
    {
        public ObservableCollection<Model> AcuList { get; set; }

        public ICollectionView Monitoring { get; set; }

        public ViewModel()
        {
            AcuList = new ObservableCollection<Model>();
            AcuList.Add(new Model() { DongName = "101동", FloorName = "1층", AcuName = "101호", AcuType = "Room", Users = new ObservableCollection<User>()
            {
                new User() { Name = "사용자 A" },
                new User() { Name = "사용자 B" },
            }});
            AcuList.Add(new Model() { DongName = "101동", FloorName = "1층", AcuName = "102호", AcuType = "Room",
                Users = new ObservableCollection<User>()
            {
                new User() { Name = "사용자 A" },
                new User() { Name = "사용자 B" },
            }
            });
            AcuList.Add(new Model() { DongName = "101동", FloorName = "1층", AcuName = "103호", AcuType = "Room",
                Users = new ObservableCollection<User>()
            {
                new User() { Name = "사용자 A" },
                new User() { Name = "사용자 B" },
            }
            });
            AcuList.Add(new Model() { DongName = "101동", FloorName = "1층", AcuName = "104호", AcuType = "Room",
                Users = new ObservableCollection<User>()
            {
                new User() { Name = "사용자 A" },
                new User() { Name = "사용자 B" },
            }
            });
            AcuList.Add(new Model() { DongName = "101동", FloorName = "1층", AcuName = "105호", AcuType = "Room",
                Users = new ObservableCollection<User>()
            {
                new User() { Name = "사용자 A" },
                new User() { Name = "사용자 B" },
            }
            });

            AcuList.Add(new Model() { DongName = "101동", FloorName = "2층", AcuName = "201호", AcuType = "Room",
                Users = new ObservableCollection<User>()
            {
                new User() { Name = "사용자 A" },
                new User() { Name = "사용자 B" },
            }
            });
            AcuList.Add(new Model() { DongName = "101동", FloorName = "2층", AcuName = "202호", AcuType = "Room",
                Users = new ObservableCollection<User>()
            {
                new User() { Name = "사용자 A" },
                new User() { Name = "사용자 B" },
            }
            });
            AcuList.Add(new Model() { DongName = "101동", FloorName = "2층", AcuName = "203호", AcuType = "Room" });
            AcuList.Add(new Model() { DongName = "101동", FloorName = "2층", AcuName = "204호", AcuType = "Room" });

            AcuList.Add(new Model() { DongName = "101동", FloorName = "3층", AcuName = "201호", AcuType = "Room" });
            AcuList.Add(new Model() { DongName = "101동", FloorName = "3층", AcuName = "202호", AcuType = "Room" });
            AcuList.Add(new Model() { DongName = "101동", FloorName = "3층", AcuName = "203호", AcuType = "Room" });

            AcuList.Add(new Model() { DongName = "102동", FloorName = "1층", AcuName = "101호", AcuType = "Room" });
            AcuList.Add(new Model() { DongName = "102동", FloorName = "1층", AcuName = "102호", AcuType = "Room" });
            AcuList.Add(new Model() { DongName = "102동", FloorName = "1층", AcuName = "103호", AcuType = "Room" });

            Monitoring = CollectionViewSource.GetDefaultView(AcuList);

            Monitoring.GroupDescriptions.Add(new PropertyGroupDescription("DongName"));
            Monitoring.GroupDescriptions.Add(new PropertyGroupDescription("FloorName"));
        }
    }
}
