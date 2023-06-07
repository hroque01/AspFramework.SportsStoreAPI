using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Pages;

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

        public IEnumerable<Order> Orders
        {
            get
            {
                // Questa proprietà restituisce una raccolta di oggetti Order dal contesto del database.
                // Utilizza il metodo Include per caricare in modo esplicito le proprietà correlate OrderLines e Product insieme all'ordine.
                // Ciò consente di ottenere i dati correlati senza ulteriori query al database.

                return context.Orders
                    .Include(o => o.OrderLines.Select(ol => ol.Product));
            }
        }

        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                // Se l'ID dell'ordine è 0, significa che è un nuovo ordine e lo aggiungiamo al contesto del database.
                // Inoltre, per ogni linea dell'ordine, impostiamo lo stato dell'oggetto Product associato come Modified.
                // Ciò indica al contesto del database che l'oggetto Product è stato modificato.

                order = context.Orders.Add(order);
                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Product).State = EntityState.Modified;
                }
            }
            else
            {
                // Se l'ID dell'ordine non è 0, significa che stiamo aggiornando un ordine esistente nel database.
                // Cerchiamo l'ordine corrispondente nel contesto del database e aggiorniamo i suoi attributi con i valori forniti nell'oggetto order.

                Order dbOrder = context.Orders.Find(order.OrderId);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Line1 = order.Line1;
                    dbOrder.Line2 = order.Line2;
                    dbOrder.Line3 = order.Line3;
                    dbOrder.City = order.City;
                    dbOrder.State = order.State;
                    dbOrder.GiftWrap = order.GiftWrap;
                    dbOrder.Dispatched = order.Dispatched;
                }
            }
            // Salviamo le modifiche nel database chiamando il metodo SaveChanges del contesto del database.
            context.SaveChanges();
        }

    }
}