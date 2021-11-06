namespace Moonpig.PostOffice.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Model;

    [Route("api/[controller]")]
    public class DespatchDateController : Controller
    {
        public DateTime _mlt;

        [HttpGet]
        public DespatchDate Get(List<int> productIds, DateTime orderDate)
        {
            _mlt = orderDate; // max lead time
            foreach (var ID in productIds)
            {
                DbContext dbContext = new DbContext();
                var s = dbContext.Products.Single(x => x.ProductId == ID).SupplierId;
                var lt = dbContext.Suppliers.Single(x => x.SupplierId == s).LeadTime;
                if (orderDate.AddDays(lt) > _mlt)
                    _mlt = orderDate.AddDays(lt);
            }
            if (_mlt.DayOfWeek == DayOfWeek.Saturday)
            {
                return new DespatchDate { Date = _mlt.AddDays(2) };
            }
            else if (_mlt.DayOfWeek == DayOfWeek.Sunday) return new DespatchDate { Date = _mlt.AddDays(1) };
            else return new DespatchDate { Date = _mlt };
        }
    }

    public class ProductInformationDataBase
    {
        public int Get(List<int> productIds)
        {

            int highleadtime = 0;
            foreach (var ID in productIds)
            {
                DbContext dbContext = new DbContext();
                var s = dbContext.Products.Single(x => x.ProductId == ID).SupplierId;
                var lt = dbContext.Suppliers.Single(x => x.SupplierId == s).LeadTime;
                if (lt > highleadtime)
                { highleadtime = lt; }

            }
            return highleadtime;
        }

    }


    public class DateCalculatorUsingLeadTime : Controller
    {
        public DespatchDate Get(DateTime orderdate, int leadtime)
        {

            return new DespatchDate { Date = orderdate.AddDays(leadtime) };
        }
    }


    public class ExtendLeadTimeIfDispatchDateFallsOnAWeekend
    {
        public int Get(DateTime orderdate, int leadtime)
        {

            if (orderdate.AddDays(leadtime).DayOfWeek == DayOfWeek.Saturday)
            {
                leadtime += 2;
            }
            else if (orderdate.AddDays(leadtime).DayOfWeek == DayOfWeek.Sunday)
            {
                leadtime += 1; ;
            }
            return leadtime;
        }

    }

    // supplier class and post office class
    // supplier service class
    // get supplier(s)[] for a particualr order
    //get supplier with the longest leadtime

    //    public IEnumerable<Supplier> GetSuppliersForOrder()
    public class SupplierService
    {
        private readonly IDbContext _dbContext;

        public SupplierService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Supplier> GetSuppliersForOrder(List<int> productIds)
        {
            List<Supplier> listofsuppliers = new List<Supplier>();
            foreach (var ID in productIds)
            {
                // this line doesnt work.int supplierId = _dbContext.Products.Single(x => productIds.Contains(ID)).SupplierId;
                var s = _dbContext.Products.Single(x => x.ProductId == ID).SupplierId;
                var lt = _dbContext.Suppliers.Single(x => x.SupplierId == s).LeadTime;
                Supplier supplier = _dbContext.Suppliers.Single(o => o.SupplierId == s);
                supplier = _dbContext.Suppliers.Single(o => o.LeadTime == lt);
                listofsuppliers.Add(supplier);

            }
            return listofsuppliers;
        }

        //complete this method
        //public Supplier GetSupplierWithLongestLeadTime(IEnumerable<Supplier> suppliers)

        //complete this method
        //public DateTime GetOrderCompletionDate(Order order)
    }


    public class ExtendLeadTimeIfLeadTimeCrossesAWeekend
    {
        public int Get(DateTime orderdate, int leadtime)
        {
            for (int i = 0; i <= leadtime; i++)
            {
                if (orderdate.AddDays(i).DayOfWeek == DayOfWeek.Saturday || orderdate.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
                {
                    leadtime++;
                }
            }

            return leadtime;
        }

    }


    public class IdentifyIfWeekend
    {
        public Boolean isWeekend;
        public IdentifyIfWeekend(DateTime date)
        {

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                isWeekend = true;
            }
        }

    }


}
