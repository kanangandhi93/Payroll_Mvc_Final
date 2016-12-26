using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class City
    {
        public long Id { get; set; }
        public string city { get; set; }
        public long StateId { get; set; }
        public long CountryId { get; set; }
        public string StateName { get; set; }
        public string ContryName { get; set; }

    }
}
