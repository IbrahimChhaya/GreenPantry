<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="GreenPantryFrontend.Invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="bodyinvoice">
    <div id="invoiceholder">

  <div id="headerimage"></div>
  <div id="invoice" class="effect2">
    
    <div id="invoice-top">
      <div class="logo"></div>
      <div class="info">
        <h2 class="h2Inv">Michael Truong</h2>
        <p class ="pInvoice"> hello@michaeltruong.ca </br>
            289-335-6503
        </p>
      </div><!--End Info-->
      <div class="title">
        <h1 class ="h1Inv">Invoice #1069</h1>
        <p class ="pInvoice">Issued: May 27, 2015</br>
           Payment Due: June 27, 2015
        </p>
      </div><!--End Title-->
    </div><!--End InvoiceTop-->


    
    <div id="invoice-mid">
      
      <div class="clientlogo"></div>
      <div class="info">
        <h2 class="h2Inv">Client Name</h2>
        <p class="pInvoice">JohnDoe@gmail.com</br>
           555-555-5555</br>
      </div>

      <div id="project">
        <h2 class ="h2Inv">Project Description</h2>
        <p class ="pInvoice">Proin cursus, dui non tincidunt elementum, tortor ex feugiat enim, at elementum enim quam vel purus. Curabitur semper malesuada urna ut suscipit.</p>
      </div>   

    </div><!--End Invoice Mid-->
    
    <div id="invoice-bot">
      
      <div class="tableInvoice">
        <table>
          <tr class="tabletitle">
            <td class="item"><h2 class="h2Inv">Item Description</h2></td>
            <td class="Hours"><h2 class="h2Inv">Hours</h2></td>
            <td class="Rate"><h2 class="h2Inv">Rate</h2></td>
            <td class="subtotal"><h2 class="h2Inv">Sub-total</h2></td>
          </tr>
          
          <tr class="service">
            <td class="tableitem"><p class="pInvoice itemtext">Communication</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">5</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">$75</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">$375.00</p></td>
          </tr>
          
          <tr class="service">
            <td class="tableitem"><p class="pInvoice itemtext">Asset Gathering</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">3</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">$75</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">$225.00</p></td>
          </tr>
          
          <tr class="service">
            <td class="tableitem"><p class="pInvoice itemtext">Design Development</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">5</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">$75</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">$375.00</p></td>
          </tr>
          
          <tr class="service">
            <td class="tableitem"><p class="pInvoice itemtext">Animation</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">20</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">$75</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">$1,500.00</p></td>
          </tr>
          
          <tr class="service">
            <td class="tableitem"><p class="pInvoice itemtext">Animation Revisions</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">10</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">$75</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">$750.00</p></td>
          </tr>
          
          <tr class="service">
            <td class="tableitem"><p class="pInvoice itemtext"></p></td>
            <td class="tableitem"><p class="pInvoice itemtext">HST</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">13%</p></td>
            <td class="tableitem"><p class="pInvoice itemtext">$419.25</p></td>
          </tr>
          
            
          <tr class="tabletitle">
            <td></td>
            <td></td>
            <td class="Rate"><h2 class="h2Inv">Total</h2></td>
            <td class="payment"><h2 class ="h2Inv">$3,644.25</h2></td>
          </tr>
          
        </table>
      </div><!--End Table-->
      
   
      
    </div><!--End InvoiceBot-->
  </div><!--End Invoice-->
</div><!-- End Invoice Holder-->
</div>
</asp:Content>
