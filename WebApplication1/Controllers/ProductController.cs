using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Models.Repository;

namespace WebApplication1.ControllersApi
{

    public class ProductController : ApiController
    {
        public IEnumerable<Product> GetProducts()
        {
            using (EFDbContext db = new EFDbContext())
            {
                var products = db.Products.ToList();
                return products;
            }
        }



    }
}
