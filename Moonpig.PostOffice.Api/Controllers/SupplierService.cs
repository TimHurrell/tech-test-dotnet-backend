namespace Moonpig.PostOffice.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using System;

    public class SupplierService
    {
        private readonly IDbContext _dbContext;

        public SupplierService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Supplier> GetSuppliersForOrder(IEnumerable<int> productIds)
        {
            List<Supplier> listofsuppliers = new List<Supplier>();
            foreach (var productId in productIds)
            {
                int supplierId = _dbContext.Products.Single(x => x.ProductId == productId).SupplierId;
                Supplier supplier = _dbContext.Suppliers.Single(o => o.SupplierId == supplierId);
                listofsuppliers.Add(supplier);
            }
            return listofsuppliers;
        }

        public Supplier GetSupplierWithLongestLeadTime(IEnumerable<Supplier> listofsuppliers)
        {
            int LongestLeadTime = 0;
            Supplier selectedSupplier = new Supplier();
            foreach (var supplier in listofsuppliers)
            {
                if (supplier.LeadTime > LongestLeadTime)
                {
                    LongestLeadTime = supplier.LeadTime;
                    selectedSupplier = supplier;
                }
            }
            return selectedSupplier;
        }

        public DateTime GetOrderCompletionDate(DateTime orderdate, List<int> productIds)
        {
            var suppliers = GetSuppliersForOrder(productIds);
            var supplier = GetSupplierWithLongestLeadTime(suppliers);
            return supplier.GetSupplierDispatchDate(orderdate);
        }


        public DateTime ExtendLeadTimeIfDispatchDateFallsOnAWeekend(DateTime initialdespatchdate)
        {
            DateTime despatchdate;
            despatchdate = initialdespatchdate;
            if (initialdespatchdate.DayOfWeek == DayOfWeek.Saturday)
            {
                despatchdate = initialdespatchdate.AddDays(2);
            }
            else if (initialdespatchdate.DayOfWeek == DayOfWeek.Sunday)
            {
                despatchdate = initialdespatchdate.AddDays(1);
            }
            return despatchdate;
        }

        //public class ExtendLeadTimeIfDispatchDateFallsOnAWeekend
        //{
        //    public int Get(DateTime orderdate, int leadtime)
        //    {

        //        if (orderdate.AddDays(leadtime).DayOfWeek == DayOfWeek.Saturday)
        //        {
        //            leadtime += 2;
        //        }
        //        else if (orderdate.AddDays(leadtime).DayOfWeek == DayOfWeek.Sunday)
        //        {
        //            leadtime += 1; ;
        //        }
        //        return leadtime;
        //    }

        //}


    }
}
