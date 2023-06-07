<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartSummary.ascx.cs" Inherits="WebApplication1.Controls.CartSummary" %>

<div id="cartSummary">
    <span class="caption">
        <b>Your Cart:</b>
        <span id="csQuantity" runat="server"></span> items(s),
        <span id="csTotal" runat="server"></span>
    </span>
    <a id="csLink" runat="server">Checkout</a>
</div>
