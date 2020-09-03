﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="GreenPantryFrontend.Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="/Invoice.css" type="text/css">
    <div class ="bodyinvoice">
    <div id="invoiceholder">

  <div id="headerimage"></div>
  <div id="invoice" class="effect2">
    
    <div id="invoice-top">
      <div class="logo">
        </div>
      <div class="info">
        <h2 class="h2Inv">Green Pantry</h2>
        <p class ="pInvoice">
            289-335-6503
        </p>
      </div><!--End Info-->
      <div class="title" runat="server" id="title">
        <h3 class ="h1Inv">Invoice #1069</h3>
        <p class ="pInvoice">Issued: May 27, 2015</p>
        </div><!--End Title-->
    </div><!--End InvoiceTop-->


    
    <div id="invoice-mid">
      
      <div class="clientlogo"></div>
      <div class="info" runat="server" id="clientInfo">
        <h2 class="h2Inv">Client Name</h2>
        <p class="pInvoice">JohnDoe@gmail.com</br>
           555-555-5555</p>
      </div>

     <%-- <div id="project">
        <h2 class ="h2Inv">Project Description</h2>
        <p class ="pInvoice">Proin cursus, dui non tincidunt elementum, tortor ex feugiat enim, at elementum enim quam vel purus. Curabitur semper malesuada urna ut suscipit.</p>
      </div>--%>   

    </div><!--End Invoice Mid-->
    
    <div id="invoice-bot">
      
      <div class="tableInvoice">
        <table>
          <tr class="tabletitle">
            <td class="item"><h2 class="h2Inv">Product</h2></td>
            <td class="Hours"><h2 class="h2Inv">Price</h2></td>
            <td class="Rate"><h2 class="h2Inv">Quantity</h2></td>
            <td class="subtotal"><h2 class="h2Inv">Subtotal</h2></td>
          </tr>

            <tbody runat="server" id="tableRow">
            </tbody>
            
          <tr class="tabletitle">
            <td></td>
            <td></td>
             <td class="Rate"><h2 class="h2Inv">VAT</h2></td>
             <td class="payment" runat="server" id="Vat"><h2 class ="h2Inv">$3,644.25</h2></td>
            
          </tr>

         <tr class="tabletitle" runat="server" id="delivery">
            <td></td>
            <td></td>
            <td class="Rate"><h2 class="h2Inv">Delivery Fee</h2></td>
            <td class="payment" runat="server" id="deliverFree"><h2 class ="h2Inv">$3,644.25</h2></td>
        </tr>

         <tr class="tabletitle">
            <td></td>
            <td></td>
            <td class="Rate"><h2 class="h2Inv">Total</h2></td>
            <td class="payment" runat="server" id="Total"><h2 class ="h2Inv">$3,644.25</h2></td>

            </tr>

      
        </table>
      </div><!--End Table-->
      </div><!--End InvoiceBot-->
  </div><!--End Invoice-->
</div><!-- End Invoice Holder-->
</div>
</asp:Content>
