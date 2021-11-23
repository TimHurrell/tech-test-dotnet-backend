namespace Moonpig.PostOffice.Tests
{
    using System;
    using System.Collections.Generic;
    using Api.Controllers;
    using Shouldly;
    using Xunit;
    using Data;

    public class ControllerTests
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
            //OrderDate Thursday
            //DespatchDate Tuesday

            DespatchDateController controller = new DespatchDateController();
            var date = controller.Get(new List<int>() { 3 }, new DateTime(2018, 1, 25));
            date.Date.ShouldBe(new DateTime(2018, 1, 25).Date.AddDays(5));

        }


    }
}
