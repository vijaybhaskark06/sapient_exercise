using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GM_MVC_API.Models
{
    public class ProductStore : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }

}