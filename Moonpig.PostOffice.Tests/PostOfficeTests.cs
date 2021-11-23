namespace Moonpig.PostOffice.Tests
{
    using System;
    using Api.Controllers;
    using Shouldly;
    using Xunit;

    public class PostOfficeTests
    {


        [Fact]
        public void IfDispatchDateFallsOnSaturdayEnsurePushedToMonday()
        {
            var postOffice = new PostOffice();

            var date = postOffice.GetNextWorkingDay(new DateTime(2021, 11, 13));

            date.DayOfWeek.ShouldBe(DayOfWeek.Monday);
        }

       // supplierCompletionDate.DayOfWeek == DayOfWeek.Sunday

        [Fact]
        public void IfDispatchDateFallsOnSundayEnsurePushedToMonday()
        {
            var postOffice = new PostOffice();

            var date = postOffice.GetNextWorkingDay(new DateTime(2021, 11, 14));

            date.DayOfWeek.ShouldBe(DayOfWeek.Monday);
        }













    }

}
