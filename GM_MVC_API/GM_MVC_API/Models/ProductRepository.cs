using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GM_MVC_API.Models
{

    public class ProductRepository : IProductRepository
    {
        private ProductStore db = new ProductStore();

        GMDBEntities globalMartDBEntities; 


        public ProductRepository()
        {
            globalMartDBEntities = new GMDBEntities();
        }

        public IEnumerable<Product> GetAll()
        {
            //return db.Products;
            return globalMartDBEntities.Products.ToList(); 

        }

        public Product Get(int id)
        {
            //return db.Products.Find(id);
            var products = globalMartDBEntities.Products.Where(x => x.Id == id);
            if (products.Count() > 0)
            {
                return products.Single();
            }
            else
            {
                return null;
            } 

        }

        public Product Add(Product item)
        {
            //db.Products.Add(item);
            //db.SaveChanges();
            //return item;

            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            globalMartDBEntities.Products.Add(item);
            globalMartDBEntities.SaveChanges();
            return item; 

        }

        public void Remove(int id)
        {
            //Product Product = db.Products.Find(id);
            //db.Products.Remove(Product);
            //db.SaveChanges();

           // Table student = Get(id);
            Product Product = globalMartDBEntities.Products.Find(id);
            if (Product != null)
            {
                globalMartDBEntities.Products.Remove(Product);
                globalMartDBEntities.SaveChanges();
            } 

        }

        public bool Update(Product item)
        {
            //db.Entry(item).State = EntityState.Modified;
            //db.SaveChanges();
            //return true;

            if (item == null)
            {
                throw new ArgumentNullException("product");
            }

            //Table studentInDB = Get(student.Id);

            //if (studentInDB == null)
            //{
            //    return false;
            //}

            globalMartDBEntities.Products.Remove(item);
            globalMartDBEntities.SaveChanges();

            globalMartDBEntities.Products.Add(item);
            globalMartDBEntities.SaveChanges();

            return true; 

        }
    }
}
