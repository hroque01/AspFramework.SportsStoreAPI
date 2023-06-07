using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
using WebApplication1.Models.Repository;
using WebApplication1.Pages.Helpers;

namespace WebApplication1.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Imposta la visibilità dei controlli checkoutForm e checkoutMessage
            // in base alla condizione successiva.
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            // Controlla se la pagina è stata inviata al server (postback).
            if (IsPostBack)
            {
                // Crea una nuova istanza di Order.
                Order myOrder = new Order();

                // Prova a popolare l'oggetto myOrder con i valori dei campi del modulo
                // utilizzando il modello di binding dei dati (model binding).
                // Il metodo TryUpdateModel restituisce true se il modello è stato correttamente aggiornato.
                if (TryUpdateModel(myOrder, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    // Inizializza la lista OrderLines dell'oggetto myOrder.
                    myOrder.OrderLines = new List<OrderLine>();

                    // Ottiene il carrello dalla sessione utilizzando l'helper SessionHelper.
                    Cart myCart = SessionHelper.GetCart(Session);

                    // Per ogni linea nel carrello, crea una nuova istanza di OrderLine
                    // e aggiungila alla lista OrderLines dell'oggetto myOrder.
                    foreach (CartLine line in myCart.Lines)
                    {
                        myOrder.OrderLines.Add(new OrderLine
                        {
                            Order = myOrder,
                            Product = line.Product,
                            Quantity = line.Quantity
                        });
                    }

                    // Salva l'ordine utilizzando il Repository.
                    new Repository().SaveOrder(myOrder);

                    // Svuota il carrello.
                    myCart.Clear();

                    // Imposta la visibilità dei controlli checkoutForm e checkoutMessage
                    // in base alla condizione successiva.
                    checkoutForm.Visible = false;
                    checkoutMessage.Visible = true;
                }
            }
        }

    }
}