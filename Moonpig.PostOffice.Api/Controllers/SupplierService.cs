namespace Moonpig.PostOffice.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using System;

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


        //complete this method
        public DateTime GetOrderCompletionDate(DateTime orderdate, Supplier supplier)

            { 
             DateTime DespatchDate;
            DespatchDate = orderdate.AddDays(supplier.LeadTime);
            return DespatchDate;
            }
    }


}
