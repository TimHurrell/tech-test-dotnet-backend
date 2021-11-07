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

       

        //[Fact]
        //public void TestSupplierLeadTimeFromProductSelected()
        //{
        //    Supplier supplierinstance = new Supplier();
        //    supplierinstance.GetSupplierIdFromProduct(3);


        //    Assert.Equal(3, supplierinstance.LeadTime);
        //}

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

            List<int> expectedIds = new List<int> { 4};


            Assert.Equal(expectedIds, listofsupplierids);
        }

        [Fact]
        public void TestReturnedMultipleProductIdFromSupplierService()
        {
            DbContext dbContext = new DbContext();
            SupplierService supplierServiceinstance = new SupplierService(dbContext);

            List<Supplier> listofsuppliers = supplierServiceinstance.GetSuppliersForOrder(new List<int>() { 3,2,1 });

            List<int> listofsupplierids = new List<int>();
            foreach (var ID in listofsuppliers)
            {
                listofsupplierids.Add(ID.SupplierId);
            }

            List<int> expectedIds = new List<int> { 4,2,1 };


            Assert.Equal(expectedIds, listofsupplierids);
        }

        [Fact]
        public void TestReturnedOneLeadtimeFromSupplierService()
        {
            DbContext dbContext = new DbContext();
            SupplierService supplierService = new SupplierService(dbContext);

            List<Supplier> suppliers = supplierService.GetSuppliersForOrder(new List<int>() { 3 });


            //this isn't a list of supplier ids its a list of leadtimes so should be renamed.
            List<int> listofsupplierids = new List<int>();

            //you can probably improve on this because we know we'll only get back one supplier because
            //there is only one item on the order
            foreach (var supplier in suppliers)
            {
                listofsupplierids.Add(supplier.LeadTime);
            }


            List<int> expectedIds = new List<int> { 3 };


            Assert.Equal(expectedIds, listofsupplierids);
        }


        [Fact]
        public void GetLeadTimeWithJustOneProduct()
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

        //    [Fact]
        //    public void GetLeadTimeWithJustOtherProduct()
        //    {
        //        ProductInformationDataBase databaseinstance = new ProductInformationDataBase();

        //        Assert.Equal(13, databaseinstance.Get(new List<int>() { 10 }));
        //    }

        //    [Fact]
        //    public void GetLeadTimeWithThreeProducts()
        //    {
        //        ProductInformationDataBase databaseinstance = new ProductInformationDataBase();

        //        Assert.Equal(13, databaseinstance.Get(new List<int>() { 10, 2, 1 }));
        //    }

        //    [Fact]
        //    public void GetLeadTimeWithThreeProductsSwitched()
        //    {
        //        ProductInformationDataBase databaseinstance = new ProductInformationDataBase();

        //        Assert.Equal(13, databaseinstance.Get(new List<int>() { 2, 10, 1 }));
        //    }

        //    [Fact]
        //    public void GetDispatchDateFromOrderDateAndLeadTime()
        //    {
        //        DateCalculatorUsingLeadTime initialdispatchdatecalculatorinstance = new DateCalculatorUsingLeadTime();

        //        var date = initialdispatchdatecalculatorinstance.Get(new DateTime(2018, 1, 21), 6);


        //        date.Date.ShouldBe(new DateTime(2018, 1, 27));
        //    }

        //    [Fact]
        //    public void GetLeadTimeIfDispatchDateFallsOnSaturday()
        //    {
        //        ExtendLeadTimeIfDispatchDateFallsOnAWeekend extendleadtimeifdispatchdatefallsonaweekendinstance = new ExtendLeadTimeIfDispatchDateFallsOnAWeekend();
        //        int extendedleadtime = extendleadtimeifdispatchdatefallsonaweekendinstance.Get(new DateTime(2021, 10, 29), 1);

        //        Assert.Equal(3, extendedleadtime);
        //    }


        //    [Fact]
        //    public void GetLeadTimeIfDispatchDateFallsOnSunday()
        //    {
        //        ExtendLeadTimeIfDispatchDateFallsOnAWeekend extendleadtimeifdispatchdatefallsonaweekendinstance = new ExtendLeadTimeIfDispatchDateFallsOnAWeekend();
        //        int extendedleadtime = extendleadtimeifdispatchdatefallsonaweekendinstance.Get(new DateTime(2021, 10, 29), 2);

        //        Assert.Equal(3, extendedleadtime);
        //    }


        //    [Fact]
        //    public void GetLeadTimeIfDispatchDateFallsOnMonday()
        //    {
        //        ExtendLeadTimeIfDispatchDateFallsOnAWeekend extendleadtimeifdispatchdatefallsonaweekendinstance = new ExtendLeadTimeIfDispatchDateFallsOnAWeekend();
        //        int extendedleadtime = extendleadtimeifdispatchdatefallsonaweekendinstance.Get(new DateTime(2021, 10, 29), 3);

        //        Assert.Equal(3, extendedleadtime);
        //    }


        //    [Fact]
        //    public void GetLeadTimeIfLeadTimeCrossesOneWeekend()
        //    {
        //        ExtendLeadTimeIfLeadTimeCrossesAWeekend extendLeadTimeIfLeadTimeCrossesAWeekendinstance = new ExtendLeadTimeIfLeadTimeCrossesAWeekend();
        //        int extendedleadtime = extendLeadTimeIfLeadTimeCrossesAWeekendinstance.Get(new DateTime(2021, 10, 29), 5);

        //        Assert.Equal(7, extendedleadtime);
        //    }

        //    [Fact]
        //    public void GetLeadTimeIfLeadTimeCrossesTwoWeekends()
        //    {
        //        ExtendLeadTimeIfLeadTimeCrossesAWeekend extendLeadTimeIfLeadTimeCrossesAWeekendinstance = new ExtendLeadTimeIfLeadTimeCrossesAWeekend();
        //        int extendedleadtime = extendLeadTimeIfLeadTimeCrossesAWeekendinstance.Get(new DateTime(2021, 10, 26), 13);

        //        Assert.Equal(17, extendedleadtime);
        //    }

        //    [Fact]
        //    public void GetLeadTimeIfLeadTimeCrossesThreeWeekends()
        //    {
        //        ExtendLeadTimeIfLeadTimeCrossesAWeekend extendLeadTimeIfLeadTimeCrossesAWeekendinstance = new ExtendLeadTimeIfLeadTimeCrossesAWeekend();
        //        int extendedleadtime = extendLeadTimeIfLeadTimeCrossesAWeekendinstance.Get(new DateTime(2021, 10, 27), 13);

        //        Assert.Equal(19, extendedleadtime);
        //    }
    }

}
