using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OrderWeb
    {

        public LocationWeb Location { get; set; }
        public UserWeb User;

        public int OrderID;
        public decimal OrderPrice;

        public DateTime TimeOfOrder { get; set; } = new DateTime();



        public string Pizza1 { get; set; }
        public string Pizza2 { get; set; }
        public string Pizza3 { get; set; }
        public string Pizza4 { get; set; }
        public string Pizza5 { get; set; }
        public string Pizza6 { get; set; }
        public string Pizza7 { get; set; }
        public string Pizza8 { get; set; }
        public string Pizza9 { get; set; }
        public string Pizza10 { get; set; }
        public string Pizza11 { get; set; }
        public string Pizza12 { get; set; }
    }
}
