namespace Moonpig.PostOffice.Api.Controllers
{
    using System;

    public class PostOffice
    {
       
        public DateTime GetNextWorkingDay(DateTime supplierCompletionDate)
        {
            if (supplierCompletionDate.DayOfWeek == DayOfWeek.Saturday || supplierCompletionDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return supplierCompletionDate.AddBusinessDays(1);
            }

            return supplierCompletionDate;
        }
    }
}
