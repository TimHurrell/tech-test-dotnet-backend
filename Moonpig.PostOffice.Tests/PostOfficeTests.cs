namespace Moonpig.PostOffice.Tests
{
    using System;
    using System.Collections.Generic;
    using Api.Controllers;
    using Shouldly;
    using Xunit;
    using Data;

    public class PostOfficeTests
    {


        [Fact]
        public void OneProductWithLeadTimeOfOneDayFromMonday()
        {
            DespatchDateController controller = new DespatchDateController();
            var date = controller.Get(new List<int>() { 1 }, new DateTime(2018, 1, 22));
        date.Date.ShouldBe(new DateTime(2018, 1, 22).Date.AddDays(1));
        }

    [Fact]
    public void OneProductWithLeadTimeOfTwoDay()
    {
        DespatchDateController controller = new DespatchDateController();
        var date = controller.Get(new List<int>() { 2 }, new DateTime(2018, 1, 22));
        date.Date.ShouldBe(new DateTime(2018, 1, 22).Date.AddDays(2));
    }

    [Fact]
    public void OneProductWithLeadTimeOfThreeDay()
    {
        DespatchDateController controller = new DespatchDateController();
        var date = controller.Get(new List<int>() { 3 }, new DateTime(2018, 1, 22));
        date.Date.ShouldBe(new DateTime(2018, 1, 22).Date.AddDays(3));
    }

        [Fact]
        public void SaturdayHasExtraTwoDaysLeadTimeOfOneDay()
        {
            DespatchDateController controller = new DespatchDateController();
            var date = controller.Get(new List<int>() { 1 }, new DateTime(2018, 1, 26));
            date.Date.ShouldBe(new DateTime(2018, 1, 26).Date.AddDays(3));
        }

        [Fact]
        public void SundayHasExtraDayTimeOfThreeDay()
        {
            DespatchDateController controller = new DespatchDateController();
            var date = controller.Get(new List<int>() { 3 }, new DateTime(2018, 1, 25));
            date.Date.ShouldBe(new DateTime(2018, 1, 25).Date.AddDays(4));
        }


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

            List<Supplier> listofsuppliers = supplierServiceinstance.GetSuppliersForOrder(new [] { 3, 2, 1 });

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
        public void TestDespatchDateFromLeadTime()
        {
            Supplier Supplier1 = new Supplier();
            Supplier1.LeadTime = 7;


            var date = Supplier1.GetSupplierDispatchDate(new DateTime(2018, 1, 25));
            date.Date.ShouldBe(new DateTime(2018, 1, 25).Date.AddDays(7));
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


        [Fact]
        public void GetDispatchDateFromOrderDateForSupplierWithLongestLeadtime()
        {
            var dbContext = new DbContext();
            var supplierService = new SupplierService(dbContext);

            supplierService.GetOrderCompletionDate(new DateTime(2021, 11, 5), new List<int> { 1, 9 }).ShouldBe(new DateTime(2021, 11, 11));
        }


        [Fact]
        public void GetLeadTimeIfDispatchDateFallsOnSaturday()
        {
            var dbContext = new DbContext();
            var supplierService = new SupplierService(dbContext);
            var date = supplierService.PushtoMondayIfDispatchDateFallsOnAWeekend(new DateTime(2021, 11, 13)); 

            date.Date.ShouldBe(new DateTime(2021, 11, 13).Date.AddDays(2));
        }

        [Fact]
        public void GetLeadTimeIfDispatchDateFallsOnSunday()
        {
            var dbContext = new DbContext();
            var supplierService = new SupplierService(dbContext);
            var date = supplierService.PushtoMondayIfDispatchDateFallsOnAWeekend(new DateTime(2021, 11, 14));

            date.Date.ShouldBe(new DateTime(2021, 11, 13).Date.AddDays(2));
        }




        [Fact]
        public void GetDespatchDateIfLeadTimeCrossesOneWeekend()
        {
            Supplier Supplier1 = new Supplier();
            Supplier1.LeadTime = 7;


            var date = Supplier1.GetSupplierDispatchDateIfLeadTimeCrossesAWeekend(new DateTime(2021, 11, 10));
            date.Date.ShouldBe(new DateTime(2021, 11, 10).Date.AddDays(9));
        }

        [Fact]
        public void GetDespatchDateIfLeadTimeCrossesTwoWeekends()
        {
            Supplier Supplier1 = new Supplier();
            Supplier1.LeadTime = 7;


            var date = Supplier1.GetSupplierDispatchDateIfLeadTimeCrossesAWeekend(new DateTime(2021, 11, 11));
            date.Date.ShouldBe(new DateTime(2021, 11, 11).Date.AddDays(11));
        }

        [Fact]
        public void GetDespatchDateIfLeadTimeCrossesThreeWeekends()
        {
            Supplier Supplier1 = new Supplier();
            Supplier1.LeadTime = 14;


            var date = Supplier1.GetSupplierDispatchDateIfLeadTimeCrossesAWeekend(new DateTime(2021, 11, 11));
            date.Date.ShouldBe(new DateTime(2021, 11, 11).Date.AddDays(20));
        }
    }

}
