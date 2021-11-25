namespace Moonpig.PostOffice.Tests
{
    using System;
    using Shouldly;
    using Xunit;
    using Data;
    using Moonpig.PostOffice.Api;

    public class SupplierTests
    {


        [Fact]
        public void Add7BusinessDaysToFridayShouldBeFridayTest()
        {
            Supplier Supplier1 = new Supplier();
            Supplier1.LeadTime = 7;


            var date = Supplier1.GetSupplierDispatchDate(new DateTime(2021, 11, 26));
            date.DayOfWeek.ShouldBe((DayOfWeek.Friday));
        }


        [Fact]
        public void Add10BusinessDaysToFridayShouldBeMondayTest()
        {
            Supplier Supplier1 = new Supplier();
            Supplier1.LeadTime = 10;


            var date = Supplier1.GetSupplierDispatchDate(new DateTime(2021, 11, 26));
            date.DayOfWeek.ShouldBe((DayOfWeek.Monday));
        }






        //        The Moonpig post office is still getting complaints...It turns out suppliers
        //don't work during the weekend as well, i.e. if an order is received on the
        //Friday with a lead time of 2 days, Moonpig would receive and despatch on the
        //Tuesday.


        [Fact]
        public void Add2BusinessDaysToFridayShouldBeTuesdayTest()
        {
            var date = new DateTime(2021, 11, 26);

            var businessDate = date.AddBusinessDays(2);

            businessDate.DayOfWeek.ShouldBe(DayOfWeek.Tuesday);
        }

        [Fact]
        public void Add5BusinessDaysToFridayShouldBeFridayTest()
        {
            var date = new DateTime(2021, 11, 26);

            var businessDate = date.AddBusinessDays(5);

            businessDate.DayOfWeek.ShouldBe(DayOfWeek.Friday);
        }


        [Fact]
        public void Add6BusinessDaysToFridayShouldBeMondayTest()
        {
            var date = new DateTime(2021, 11, 26);

            var businessDate = date.AddBusinessDays(6);

            businessDate.DayOfWeek.ShouldBe(DayOfWeek.Monday);
        }

        [Fact]
        public void Add11BusinessDaysToFridayShouldBeMondayTest()
        {
            var date = new DateTime(2021, 11, 26);

            var businessDate = date.AddBusinessDays(11);

            businessDate.DayOfWeek.ShouldBe(DayOfWeek.Monday);
        }

        [Fact]
        public void Add18BusinessDaysToFridayShouldBeWednesdayTest()
        {
            var date = new DateTime(2021, 11, 26);

            var businessDate = date.AddBusinessDays(18);

            businessDate.DayOfWeek.ShouldBe(DayOfWeek.Wednesday);
        }
    }
}


