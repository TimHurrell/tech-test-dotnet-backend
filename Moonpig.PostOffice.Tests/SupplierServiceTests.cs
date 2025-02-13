﻿namespace Moonpig.PostOffice.Tests
{
    using System.Collections.Generic;
    using Api.Controllers;
    using Xunit;
    using Data;

    public class SupplierServiceTests
    {




        [Fact]
        public void TestReturnedOneProductIdFromSupplierService()
        {
            DbContext dbContext = new DbContext();
            SupplierService supplierServiceinstance = new SupplierService(dbContext);

            List<Supplier> listofsuppliers = supplierServiceinstance.GetSuppliersForOrder(new List<int>() { 3 });

            List<int> listofsupplierids = new List<int>();
            foreach (var ID in listofsuppliers)
            {
                listofsupplierids.Add(ID.SupplierId);
            }

            List<int> expectedIds = new List<int> { 4 };


            Assert.Equal(expectedIds, listofsupplierids);
        }

        [Fact]
        public void TestReturnedMultipleProductIdFromSupplierService()
        {
            DbContext dbContext = new DbContext();
            SupplierService supplierServiceinstance = new SupplierService(dbContext);

            List<Supplier> listofsuppliers = supplierServiceinstance.GetSuppliersForOrder(new[] { 3, 2, 1 });

            List<int> listofsupplierids = new List<int>();
            foreach (var ID in listofsuppliers)
            {
                listofsupplierids.Add(ID.SupplierId);
            }

            List<int> expectedIds = new List<int> { 4, 2, 1 };


            Assert.Equal(expectedIds, listofsupplierids);
        }

        [Fact]
        public void TestReturnedOneLeadtimeFromSupplierService()
        {
            DbContext dbContext = new DbContext();
            SupplierService supplierService = new SupplierService(dbContext);

            List<Supplier> suppliers = supplierService.GetSuppliersForOrder(new List<int>() { 3 });
            List<int> listofsupplierleadtimes = new List<int>();
            listofsupplierleadtimes.Add(suppliers[0].LeadTime);



            List<int> expectedIds = new List<int> { 3 };


            Assert.Equal(expectedIds, listofsupplierleadtimes);
        }




        [Fact]
        public void TestGetLongestLeadTimeWithFromThreeSuppliers()
        {
            Supplier Supplier1 = new Supplier();
            Supplier Supplier2 = new Supplier();
            Supplier Supplier3 = new Supplier();
            Supplier1.LeadTime = 3;
            Supplier2.LeadTime = 5;
            Supplier3.LeadTime = 2;

            List<Supplier> listofsuppliers = new List<Supplier>() { Supplier1, Supplier2, Supplier3 };

            DbContext dbContext = new DbContext();
            SupplierService supplierServiceinstance = new SupplierService(dbContext);

            Assert.Equal(5, supplierServiceinstance.GetSupplierWithLongestLeadTime(listofsuppliers).LeadTime);
        }




    }

}
