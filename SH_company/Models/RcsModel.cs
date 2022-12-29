using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH_company.Models
{
    public class RcsModel
    {
        public string No { get; set; }

        public string Place { get; set; }

        public string Date { get; set; }

        public string Sale { get; set; }

        public string PM { get; set; }

        public string AS { get; set; }

        public string roomCnt { get; set; }

        public RcsModel(string No, string Place, string Date, string Sale, string PM, string AS, string roomCnt) 
        {
            this.No = No;
            this.Place = Place;
            this.Date = Date;
            this.Sale = Sale;
            this.PM = PM;
            this.AS = AS;
            this.roomCnt = roomCnt;
        }
    }
}
