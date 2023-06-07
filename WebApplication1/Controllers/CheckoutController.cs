using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static System.Collections.Specialized.BitVector32;
using WebApplication1.Models.Repository;
using WebApplication1.Models;
using WebApplication1.Pages.Helpers;
using System.Web;

namespace WebApplication1.Controllers
{
    public class CheckoutController : ApiController
    {
        [HttpPost]
        public IHttpActionResult ProcessOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                // Crea una nuova istanza di Order e popola i suoi dati con i valori ricevuti dalla richiesta
                Order myOrder = new Order
                {
                    Name = order.Name,
                    Line1 = order.Line1,
                    Line2 = order.Line2,
                    Line3 = order.Line3,
                    City = order.City,
                    State = order.State,
                    GiftWrap = order.GiftWrap,
                    Dispatched = order.Dispatched
                };

                // Inizializza la lista OrderLines dell'oggetto myOrder
                myOrder.OrderLines = new List<OrderLine>();

                // Ottieni il carrello dalla sessione utilizzando l'helper SessionHelper
                Cart myCart = SessionHelper.GetCart(HttpContext.Current.Session);

                // Per ogni linea nel carrello, crea una nuova istanza di OrderLine
                // e aggiungila alla lista OrderLines dell'oggetto myOrder
                foreach (CartLine line in myCart.Lines)
                {
                    myOrder.OrderLines.Add(new OrderLine
                    {
                        Order = myOrder,
                        Product = line.Product,
                        Quantity = line.Quantity
                    });
                }

                // Salva l'ordine utilizzando il Repository
                new Repository().SaveOrder(myOrder);

                // Svuota il carrello
                myCart.Clear();

                return Ok("Order placed successfully.");
            }

            return BadRequest("Invalid order data.");
        }

    }
}
