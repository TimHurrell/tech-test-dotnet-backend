namespace Moonpig.PostOffice.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Model;

    [Route("api/[controller]")]
    public class DespatchDateController : Controller
    {
        //public DateTime _mlt;

        [HttpGet]
        public DespatchDate Get(List<int> productIds, DateTime orderDate)
        {
            SupplierService supplierService = new SupplierService(new DbContext());
// part 1 and part 2
            var supplierCompletionDate = supplierService.GetOrderCompletionDate(orderDate, productIds);
            // part 2

// part 3
         //   despatchDate = supplierService.GetOrderCompletionDateIfLeadTimeCrossesWeekend(orderDate, productIds);

            return new DespatchDate { Date = supplierCompletionDate };

            //the goal is to try and remove as much logic from the controller into the service class,
            //because there are less moving parts and it is more testable.
            //therefore call the logic from PushtoMondayIfDispatchDateFallsOnAWeekend inside GetOrderCompletionDate

        }
    }

    //public class ProductInformationDataBase
    //{
    //    public int Get(List<int> productIds)
    //    {

    //        int highleadtime = 0;
    //        foreach (var ID in productIds)
    //        {
    //            DbContext dbContext = new DbContext();
    //            var s = dbContext.Products.Single(x => x.ProductId == ID).SupplierId;
    //            var lt = dbContext.Suppliers.Single(x => x.SupplierId == s).LeadTime;
    //            if (lt > highleadtime)
    //            { highleadtime = lt; }

    //        }
    //        return highleadtime;
    //    }

    //}


    //public class DateCalculatorUsingLeadTime : Controller
    //{
    //    public DespatchDate Get(DateTime orderdate, int leadtime)
    //    {

    //        return new DespatchDate { Date = orderdate.AddDays(leadtime) };
    //    }
    //}




    //public class IdentifyIfWeekend
    //{
    //    public Boolean isWeekend;
    //    public IdentifyIfWeekend(DateTime date)
    //    {

    //        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
    //        {
    //            isWeekend = true;
    //        }
    //    }

    //}


}
