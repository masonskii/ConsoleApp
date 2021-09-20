using System;

namespace ConsoleApp2
{
    struct CostOrders
    {
        public string itemname;
        public int unitCount;
        public double unitCost;
        public double TotalCost()
        {
            var r = new Random();
            return r.Next(50, 400);
        }
    }
}
