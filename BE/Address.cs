using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [path("", "Address","")]
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Num { get; set; }
    }
}