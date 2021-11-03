using System.Linq;

namespace Moonpig.PostOffice.Data
{
    public class Supplier
    {
        public int SupplierId { get; set; }


        public string Name { get; set; }


        public int LeadTime { get; set; }

        public int GetSupplierIdFromProduct(int ProductId)
        {

            DbContext dbContext = new DbContext();
            var s = dbContext.Products.Single(x => x.ProductId == ProductId).SupplierId;
            return s;


        }

        //using the leadtime from this object work out the despatch date.
        //}

        //public Datetime GetSupplierDespatchDate(DateTime orderdate) {

        //using the leadtime from this object work out the despatch date.
        //}
    }
}
