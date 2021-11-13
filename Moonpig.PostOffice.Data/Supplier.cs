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
            //throw new NotImplementedException();
            DateTime DespatchDate;
            DespatchDate = orderdate.AddDays(LeadTime);
            return DespatchDate;

        }

        public DateTime GetSupplierDispatchDateIfLeadTimeCrossesAWeekend(DateTime orderdate)
        {
            for (int i = 0; i <= LeadTime; i++)
            {
                if (orderdate.AddDays(i).DayOfWeek == DayOfWeek.Saturday || orderdate.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
                {
                    LeadTime++;
                }
            }
            return GetSupplierDispatchDate(orderdate);

        }

    }
}
