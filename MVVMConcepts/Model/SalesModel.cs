using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMConcepts.Model
{
    public class Sales
    {
        public string Order_No { get; set; }
        public string Item_No { get; set; }
        public decimal Item_Price { get; set; }
        public int Quantity { get; set; }

    }
    public class Items
    {
        public string Item_No { get; set; }
        public string Item_Name { get; set; }
        public decimal Item_Cost { get; set; }
        public decimal Item_Price { get; set; }

    }
}
