namespace Moonpig.PostOffice.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;

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
                int supplierId = _dbContext.Products.Single(x => productIds.Contains(x.ProductId)).SupplierId;
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


        //complete this method
        //public DateTime GetOrderCompletionDate(Order order)
    }


}
