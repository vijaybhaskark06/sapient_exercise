using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GM_MVC_API.Models
{
    public class ProductInitializer : DropCreateDatabaseIfModelChanges<ProductStore>
    {
        protected override void Seed(ProductStore storeContext)
        {
            storeContext.Products.Add(new Product() {  Name = "MVC4 RC Early Release", Type="Electronics", Price = 220 });
            storeContext.Products.Add(new Product() { Name = "Entity FrameWork", Type="HomeAppliance",Price = 350M });
            storeContext.Products.Add(new Product() { Name = "Azure Getting Started", Type="Mobiles",Price = 540M });

        }
    }
}