using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MainLibrary.Models
{

    public class Order
    {
        [XmlElement]

        public Location Location { get; set; }
        public User User;

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