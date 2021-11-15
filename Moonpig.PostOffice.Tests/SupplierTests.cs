namespace Moonpig.PostOffice.Tests
{
    using System;
    using Shouldly;
    using Xunit;
    using Data;

    public class SupplierTests
    {


        [Fact]
        public void TestDespatchDateFromLeadTime()
        {
            Supplier Supplier1 = new Supplier();
            Supplier1.LeadTime = 7;


            var date = Supplier1.GetSupplierDispatchDate(new DateTime(2018, 1, 25));
            date.Date.ShouldBe(new DateTime(2018, 1, 25).Date.AddDays(7));
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
