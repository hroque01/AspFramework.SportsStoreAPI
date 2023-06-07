using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebApplication1.Models.Repository;

namespace WebApplication1.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Category { get; set; }
        public decimal Price { get; set; }

        //Costruttore vuoto
        public Product() : this(0, string.Empty, string.Empty, string.Empty, 0) { }

        public Product(int productId, string name, string description, string category, decimal price)
        {
            ProductID = productId;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
        }
    }
}