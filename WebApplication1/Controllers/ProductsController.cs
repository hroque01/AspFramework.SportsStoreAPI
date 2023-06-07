using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        [Route("api/products")]
        public IEnumerable<Product> GetProducts()
        {
            // Richiama il metodo esistente GetProducts() del code-behind
            return GetProductsFromCodeBehind();
        }

    }
}
