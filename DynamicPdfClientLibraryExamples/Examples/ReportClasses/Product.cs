using System;

namespace DlexLayoutObjectExample.Examples.ReportClasses
{
    class Product
    {
        public int ProductID { get; set; }
        public String ProductName { get; set; }
        public String QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public bool Discontinued { get; set; }
    }
}
