﻿namespace Moonpig.PostOffice.Api.Controllers
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

        public DateTime GetSupplierCompletionDate(DateTime orderDate, List<int> productIds)
        {
            var suppliers = GetSuppliersForOrder(productIds);
            var supplier = GetSupplierWithLongestLeadTime(suppliers);
            var supplierCompletionDate = orderDate.AddBusinessDays(supplier.LeadTime);
            return supplierCompletionDate;
        }



    }
}
