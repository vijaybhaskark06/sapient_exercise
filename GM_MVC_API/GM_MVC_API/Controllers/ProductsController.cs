using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GM_MVC_API.Models;


namespace GM_MVC_API.Controllers
{
    public class ProductsController : ApiController
    {
       static  IProductRepository _repository;
       
        public ProductsController(IProductRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            _repository = repository;
        }

        //Relative URI= /api/products
        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }
        //Relative URI /api/products/id
        public Product GetProduct(int id)
        {
            Product product = _repository.Get(id);
            if (product == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return product;
        }
        public HttpResponseMessage PostProduct(Product product)
        {
            product = _repository.Add(product);
            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, product);
            string uri = Url.Route(null, new { id = product.Id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        public void PutProduct(int id, Product product)
        {
            product.Id = id;
            if (!_repository.Update(product))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        }

        public HttpResponseMessage DeleteProduct(int id)
        {
            _repository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
