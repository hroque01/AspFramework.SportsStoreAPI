using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

        // Proprietà che restituisce una collezione di oggetti Product
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}