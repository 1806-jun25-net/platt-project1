using System;
using System.Collections.Generic;

namespace DBContext.Models
{
    public partial class OrderDb
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int LocId { get; set; }
        public string Opizza1 { get; set; }
        public string Opizza2 { get; set; }
        public string Opizza3 { get; set; }
        public string Opizza4 { get; set; }
        public string Opizza5 { get; set; }
        public string Opizza6 { get; set; }
        public string Opizza7 { get; set; }
        public string Opizza8 { get; set; }
        public string Opizza9 { get; set; }
        public string Opizza10 { get; set; }
        public string Opizza11 { get; set; }
        public string Opizza12 { get; set; }
        public DateTime TimeofOrder { get; set; }
        public decimal OrderTotalPrice { get; set; }

        public LocationDb Loc { get; set; }
        public UserDb User { get; set; }
    }
}
