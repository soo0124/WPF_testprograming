using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App
{
    public class Item
    {
        public string Name { get; set; } = "이름";
    }

    public class ViewModel
    {
        public string Name { get; set; } = "안녕하세요";

        public List<Item> MyList { get; set; } = new List<Item>()
        {
            new Item(),
            new Item(),
            new Item()
        };
    }
}
