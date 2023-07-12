using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BE
{
    [path(@"braunches.xml", "Braunch", "Braunch_number")]
    public class Braunch
    {
        public string Braunch_number { get; set; }
        public kosher_level Kusher_level { get; set; }
        public int Deliveries_Availabile { get; set; }
        public string Braunch_responsible { get; set; }
        public string Phone_number { get; set; }
        public int Opening_hour
        {
            get
            {
                return opening_hour;
            }

            set
            {
                opening_hour = value % 24;
            }
        }

        public int Closing_hour
        {
            get
            {
                return closing_hour;
            }

            set
            {
                closing_hour = value% 24;
            }
        }

        private int opening_hour;
        private int closing_hour;
        
        public Address Address { get; set; }
        public Braunch()
        {
            Address = new Address();
            Random r = new Random();
            for (int i = 0; i < 7; i++)
            {
                Braunch_number += r.Next(0, 10);
            }
            opening_hour = 0;
            closing_hour = 23;
            Deliveries_Availabile = 5;
        }
    }
}
