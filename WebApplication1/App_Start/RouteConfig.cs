using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace WebApplication1
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Categorie
            routes.MapPageRoute(null, "list/{category}/{page}", "~/Pages/Listing.aspx");

            //Lista
            routes.MapPageRoute(null, "list/{page}", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "list", "~/Pages/Listing.aspx");
            
            //Carrello
            routes.MapPageRoute("cart", "cart", "~/Pages/CartView.aspx");

            //Checkout
            routes.MapPageRoute("checkout", "checkout", "~/Pages/Checkout.aspx");
        }
    }
}
