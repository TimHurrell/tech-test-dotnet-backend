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
            return listofsuppliers.OrderByDescending(o => o.LeadTime).First();
        }


        public DateTime GetSupplierCompletionDate(DateTime orderDate, List<int> productIds)
        {
            var suppliers = GetSuppliersForOrder(productIds);
            var supplier = GetSupplierWithLongestLeadTime(suppliers);
            var supplierCompletionDate = supplier.GetSupplierDispatchDate(orderDate);
            return supplierCompletionDate;
        }



    }
}
