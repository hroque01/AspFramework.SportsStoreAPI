using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplication1.Models.Repository;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    // Classe controller per gestire il checkout degli ordini
    public class CheckoutController : ApiController
    {
        // Istanzia un oggetto Repository e una sessione HTTP
        private Repository repository = new Repository();

        [HttpPost]
        // Processa l'ordine inviato come parametro
        public IHttpActionResult ProcessOrder(OrderDTO orderDTO)
        {
            // Verifica se il modello dei dati è valido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verifica se il carrello è vuoto
            if (orderDTO.CartItems == null || orderDTO.CartItems.Count == 0)
            {
                return BadRequest("The cart is empty");
            }

            try
            {
                // Crea un nuovo ordine dai dati inviati
                var order = new Order
                {
                    Name = orderDTO.Name,
                    Line1 = orderDTO.Line1,
                    Line2 = orderDTO.Line2,
                    Line3 = orderDTO.Line3,
                    City = orderDTO.City,
                    State = orderDTO.State,
                    GiftWrap = orderDTO.GiftWrap,
                    Dispatched = orderDTO.Dispatched,
                    OrderLines = new List<OrderLine>()
                };

                // Aggiungi ogni prodotto del carrello all'ordine
                foreach (var item in orderDTO.CartItems)
                {
                    Product product = repository.Products.FirstOrDefault(p => p.ProductID == item.ProductID);

                    if (product != null)
                    {
                        order.OrderLines.Add(new OrderLine
                        {
                            Order = order,
                            Product = product,
                            Quantity = item.Quantity // Usa la quantità dal carrello
                        });
                    }
                }

                // Salva l'ordine nel repository
                bool isOrderSaved = repository.SaveOrder(order);
                if (isOrderSaved)
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError(new Exception("Order saving failed"));
                }
            }
            catch (Exception ex)
            {
                // Stampa l'eccezione nel log del debug
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                // Restituisci l'errore al client
                return InternalServerError(ex);
            }
        }
    }

    // Definizione delle classi DTO

    // Classe per rappresentare un articolo del carrello
    public class CartItemDTO
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }

    // Classe per rappresentare un ordine
    public class OrderDTO
    {
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool GiftWrap { get; set; }
        public bool Dispatched { get; set; }
        public List<CartItemDTO> CartItems { get; set; }

        public OrderDTO()
        {
            CartItems = new List<CartItemDTO>();
        }
    }
}
