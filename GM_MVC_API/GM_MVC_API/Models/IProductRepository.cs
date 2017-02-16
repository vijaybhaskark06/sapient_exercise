using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GM_MVC_API.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Add(Product item);
        void Remove(int id);
        bool Update(Product item);
    }
}