using System;





namespace Moonpig.PostOffice.Data
{

    public class Supplier
    {
        public int SupplierId { get; set; }


        public string Name { get; set; }


        public int LeadTime { get; set; }


        public DateTime GetSupplierDispatchDate(DateTime orderdate)
        {
           return orderdate.AddBusinessDays(LeadTime);
        }
    }
}
