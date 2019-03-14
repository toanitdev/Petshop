using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Class

{
    public class OrderDetails
    {
        public string name { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }
        public double sum { get; set; }
    }
}