using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; } 
    }

    public class Cart
    {

        // Creo una lista
        private List<CartLine> lineCollection = new List<CartLine>();

        //Aggiunge un item 
        public void AddItem(Product product, int quantity)
        {
            // Tramite LinQ fa una query dove riprende l'ID
            CartLine line = lineCollection
            .Where(p => p.Product.ProductID == product.ProductID)
            .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        // Toglie un prodotto tramite una query basata sull'ID
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        // Fa la somma in base al prezzo del prodotto e la la quantità
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        // CLEAR
        public void Clear()
        {
            lineCollection.Clear();
        }


        public IEnumerable<CartLine> Lines
        {
            // Questa proprietà fornisce accesso alla collezione di oggetti CartLine.
            // Consente di leggere le righe nel carrello della spesa.
            get { return lineCollection; }
        }

    }
}