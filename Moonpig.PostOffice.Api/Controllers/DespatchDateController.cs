namespace Moonpig.PostOffice.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Model;

    [Route("api/[controller]")]
    public class DespatchDateController : Controller
    {
        [HttpGet]
        public DespatchDate Get(List<int> productIds, DateTime orderDate)
        {
            SupplierService supplierService = new SupplierService(new DbContext());
            PostOffice postOffice = new PostOffice();

            var supplierCompletionDate = supplierService.GetSupplierCompletionDate(orderDate, productIds);
            var orderCompletionDate = postOffice.GetNextWorkingDay(supplierCompletionDate);

            return new DespatchDate { Date = orderCompletionDate };
        }
    }
}
