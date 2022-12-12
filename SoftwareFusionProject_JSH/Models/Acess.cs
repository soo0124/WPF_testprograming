using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareFusionProject_JSH.Models
{
    public class Acess
    {
        public string no { get; set; }

        public string code { get; set; }

        public string division { get; set; }

        public string eventTime { get; set; }

        public Acess(string no, string code, string division, string eventTime)
        {
            this.no = no;
            this.code = code;  
            this.division = division;
            this.eventTime = eventTime;
        }
    }
}
