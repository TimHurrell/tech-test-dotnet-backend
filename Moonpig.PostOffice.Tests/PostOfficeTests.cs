namespace Moonpig.PostOffice.Tests
{
    using System;
    using Api.Controllers;
    using Shouldly;
    using Xunit;

    public class PostOfficeTests
    {


        [Fact]
        public void GetLeadTimeIfDispatchDateFallsOnSaturday()
        {
            var postOffice = new PostOffice();

            var date = postOffice.GetNextWorkingDay(new DateTime(2021, 11, 13));

            date.Date.ShouldBe(new DateTime(2021, 11, 13).Date.AddDays(2));
        }

        [Fact]
        public void GetLeadTimeIfDispatchDateFallsOnSunday()
        {
            var postOffice = new PostOffice();

            var date = postOffice.GetNextWorkingDay(new DateTime(2021, 11, 14));

            date.Date.ShouldBe(new DateTime(2021, 11, 13).Date.AddDays(2));
        }













    }

}
