using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [path(@"orders.xml", "Order", "Reservation_number")]
    public class Order
    {
#region propreties
        Random r = new Random();
        public kosher_level Kusher_level { get; set; }
        public DateTime Date { get; set; }
        public string Bruanch_number { get; set; }
        public string Reservation_number { get; set; }
        public string Cl { get; set; }
        public bool status { get; set; }
#endregion
        
        public Order()
        {
            Date = new DateTime();
            Date = DateTime.Now;
            for (int i = 0; i < 8; i++)
            {
                Reservation_number += r.Next() % 10;
            }
            status = false;
        }

    }

}

