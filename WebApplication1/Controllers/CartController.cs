using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CartController : ApiController
    {
        private Cart cart = new Cart();

        // API per aggiungere un prodotto al carrello
        [HttpPost]
        public IHttpActionResult AddToCart(Product product)
        {
            cart.AddItem(product, 1); // Aggiungi il prodotto al carrello con quantità 1
            return Ok(); // Restituisci una risposta di successo
        }

        // API per rimuovere un prodotto dal carrello
        [HttpPost]
        public IHttpActionResult RemoveFromCart(Product product)
        {
            cart.RemoveLine(product); // Rimuovi il prodotto dal carrello
            return Ok(); // Restituisci una risposta di successo
        }

        // API per svuotare il carrello
        [HttpPost]
        public IHttpActionResult ClearCart()
        {
            cart.Clear(); // Svuota il carrello
            return Ok(); // Restituisci una risposta di successo
        }

        // API per calcolare il totale del carrello
        [HttpGet]
        public IHttpActionResult ComputeTotalValue()
        {
            decimal totalValue = cart.ComputeTotalValue(); // Calcola il totale del carrello
            return Ok(totalValue); // Restituisci il totale come parte della risposta
        }
    }
}
