<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" MasterPageFile="/Pages/Store.Master" Inherits="SportsStore.Pages.Listing" %>

<%-- Import web routing --%>
<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <asp:Repeater ItemType="WebApplication1.Models.Product" SelectMethod="GetProducts" runat="server">
            <ItemTemplate>
                <div class="item">

                    <!-- Visualizza il nome del prodotto -->
                    <h3><%# Item.Name %></h3>

                    <!-- Visualizza la descrizione del prodotto -->
                    <%# Item.Description %>

                    <!-- Visualizza il prezzo del prodotto formattato come una rappresentazione di valuta -->
                    <h4><%# Item.Price.ToString("c") %></h4>

                    <!-- Pulsante "Add to Cart" per aggiungere il prodotto al carrello -->
                    <button name="add" type="submit" value="<%# Item.ProductID %>">Add to Cart</button>

                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="pager">
        <% 
            // Genera i link per la navigazione tra le pagine utilizzando le variabili di routing
            for (int i = 1; i <= MaxPage; i++)
            {
                // Ottiene il percorso virtuale per la pagina corrente
                string path = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary() { { "page", i } }).VirtualPath;
    
                // Scrive il link HTML per la pagina corrente, evidenziando il link della pagina attuale
                Response.Write(
                    string.Format("<a href='{0}' {1}>{2}</a>",
                    path, i == CurrentPage ? "class='selected'" : "", i));
            }

        %>
       
    </div>
</asp:Content>

<asp:Content ID="FooterContent" ContentPlaceHolderID="FooterPlaceHolder" runat="server">
    Page Footer
</asp:Content>
