using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WebApplication1.Models;

namespace WebApplication1.Pages.Helpers
{
    // Definizione di un enum chiamato SessionKey per le chiavi della sessione
    public enum SessionKey
    {
        CART,           // Chiave per il carrello
        RETURN_URL      // Chiave per l'URL di ritorno
    }

    public class SessionHelper
    {
        // Metodo per impostare un valore nella sessione utilizzando una chiave specificata
        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[Enum.GetName(typeof(SessionKey), key)] = value;
        }

        // Metodo per ottenere un valore dalla sessione utilizzando una chiave specificata
        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            object dataValue = session[Enum.GetName(typeof(SessionKey), key)];
            if (dataValue != null && dataValue is T)
            {
                return (T)dataValue;
            }
            else
            {
                // Restituisce il valore predefinito del tipo specificato se il valore non è presente o non è del tipo corretto
                return default(T);
            }
        }

        // Metodo per ottenere il carrello dalla sessione
        public static Cart GetCart(HttpSessionState session)
        {
            // Ottiene il carrello dalla sessione utilizzando la chiave CART
            Cart myCart = Get<Cart>(session, SessionKey.CART);

            if (myCart == null)
            {
                // Se il carrello non è presente nella sessione, crea un nuovo carrello
                myCart = new Cart();

                // Imposta il carrello nella sessione utilizzando la chiave CART
                Set(session, SessionKey.CART, myCart);
            }

            // Restituisce il carrello
            return myCart;
        }
    }

}