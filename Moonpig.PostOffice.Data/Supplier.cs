using System;
using System.Linq;

namespace Moonpig.PostOffice.Data
{
    public class Supplier
    {
        public int SupplierId { get; set; }


        public string Name { get; set; }


        public int LeadTime { get; set; }


        public DateTime GetSupplierDispatchDate(DateTime orderdate)
        {
            //using the leadtime from this object work out the despatch date.
            //and write a test for it
            //at this point we don't care what was ordered. this class knows nothing of orders
            //and doesn't need to
            //throw new NotImplementedException();
            DateTime DespatchDate;
            DespatchDate = orderdate.AddDays(LeadTime);
            return DespatchDate;

        }
    }
}
