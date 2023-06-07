using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
using WebApplication1.Models.Repository;
using WebApplication1.Pages.Helpers;

namespace WebApplication1.Pages
{
    public partial class CartView : System.Web.UI.Page
    {

        // Questo metodo viene eseguito ogni volta che la pagina viene caricata o ricaricata.
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                // Se la pagina è stata ricaricata a causa di un evento di postback (ad esempio, un pulsante premuto),
                // gestiamo la richiesta di rimuovere un prodotto dal carrello.

                Repository repo = new Repository();
                int productId;
                if (int.TryParse(Request.Form["remove"], out productId))
                {
                    // Otteniamo il prodotto da rimuovere dal repository in base all'ID specificato.

                    Product productToRemove = repo.Products.Where(p => p.ProductID == productId).FirstOrDefault();
                    if (productToRemove != null)
                    {
                        // Rimuoviamo la linea corrispondente al prodotto dal carrello dell'utente.
                        SessionHelper.GetCart(Session).RemoveLine(productToRemove);
                    }
                }
            }
        }

        // Questo metodo restituisce le linee del carrello dell'utente come una raccolta di oggetti CartLine.
        public IEnumerable<CartLine> GetCartLines()
        {
            return SessionHelper.GetCart(Session).Lines;
        }


        // Questa proprietà restituisce il totale del carrello dell'utente, calcolato come valore totale dei prodotti presenti nel carrello.
        public decimal CartTotal
        {
            get
            {
                return SessionHelper.GetCart(Session).ComputeTotalValue();
            }
        }

        // Questa proprietà restituisce l'URL di ritorno memorizzato nella sessione.
        public string ReturnUrl
        {
            get
            {
                return SessionHelper.Get<string>(Session, SessionKey.RETURN_URL);
            }
        }

        // Questa proprietà restituisce l'URL di checkout.
        public string CheckoutUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "checkout",
                null).VirtualPath;
            }
        }
    }
}