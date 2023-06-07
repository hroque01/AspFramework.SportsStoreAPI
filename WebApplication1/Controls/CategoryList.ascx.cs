using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using WebApplication1.Models.Repository;

namespace WebApplication1.Controls
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Metodo che restituisce una sequenza di categorie uniche ordinate
        protected IEnumerable<string> GetCategories()
        {
            // Utilizza il repository per ottenere la lista dei prodotti,
            // seleziona la proprietà Category di ciascun prodotto,
            // rimuove i duplicati e ordina alfabeticamente
            return new Repository().Products.Select(p => p.Category).Distinct().OrderBy(x => x);
        }

        // Metodo per creare il link di navigazione alla pagina Home
        protected string CreateHomeLinkHtml()
        {
            // Ottiene il percorso virtuale per la Home utilizzando RouteTable.Routes.GetVirtualPath()
            string path = RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;

            // Restituisce il link HTML per la Home con il percorso generato
            return string.Format("<a href='{0}'>Home</a>", path);
        }

        // Metodo per creare il link di navigazione per una categoria specifica
        protected string CreateLinkHtml(string category)
        {
            string selectedCategory = (string)Page.RouteData.Values["category"] ?? Request.QueryString["category"];

            // Ottiene il percorso virtuale per la categoria specifica utilizzando RouteTable.Routes.GetVirtualPath()
            string path = RouteTable.Routes.GetVirtualPath(null, null,
                new RouteValueDictionary() { { "category", category }, { "page", "1" } }).VirtualPath;

            // Restituisce il link HTML per la categoria con il percorso generato e delle categorie
            return string.Format("<a href='{0}' {1}>{2}</a>", path, category == selectedCategory ? "class='selected'" : "", category);
        }

    }
}