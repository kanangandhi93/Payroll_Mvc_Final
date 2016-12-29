using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Branch
    {
        public int BrId { get; set; }
        public string BeName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string potalcode { get; set; }
        public long ContactNo1 { get; set; }
        public long ContactNo2 { get; set; }
        public long FaxNo { get; set; }
        public string EmailId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Int64 CUser { get; set; }
        public Int64 UUser { get; set; }

    }
}
