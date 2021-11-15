namespace Moonpig.PostOffice.Api.Controllers
{

    using System;

    public class PostOffice
    {
       
        public DateTime GetNextWorkingDay(DateTime ordercompletiondate)
        {
            DateTime despatchdate;
            despatchdate = ordercompletiondate;
            if (ordercompletiondate.DayOfWeek == DayOfWeek.Saturday)
            {
                despatchdate = ordercompletiondate.AddDays(2);
            }
            else if (ordercompletiondate.DayOfWeek == DayOfWeek.Sunday)
            {
                despatchdate = ordercompletiondate.AddDays(1);
            }
            return despatchdate;
        }


    }
}
