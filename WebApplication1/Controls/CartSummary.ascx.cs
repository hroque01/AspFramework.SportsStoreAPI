using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
using WebApplication1.Pages.Helpers;

namespace WebApplication1.Controls
{
    public partial class CartSummary : System.Web.UI.UserControl
    {
        // Questo controllo utente mostra un riepilogo del carrello
        // Viene utilizzato per visualizzare il numero di articoli nel carrello
        // e il totale dei prezzi dei prodotti nel carrello.

        protected void Page_Load(object sender, EventArgs e)
        {
            // Otteniamo l'istanza del carrello dalla sessione utilizzando un helper di sessione personalizzato.
            Cart myCart = SessionHelper.GetCart(Session);

            // Aggiorniamo l'elemento HTML con l'id "csQuantity" con la quantità totale di articoli nel carrello.
            csQuantity.InnerText = myCart.Lines.Sum(x => x.Quantity).ToString();

            // Aggiorniamo l'elemento HTML con l'id "csTotal" con il valore totale dei prodotti nel carrello.
            csTotal.InnerText = myCart.ComputeTotalValue().ToString();

            // Impostiamo il link dell'elemento HTML con l'id "csLink" in modo che punti alla pagina "cart" utilizzando il routing.
            csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath;
        }
    }
}