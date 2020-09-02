<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="GreenPantryFrontend.Invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="/Invoice.css" type="text/css">
    <div class ="bodyinvoice">
    <div id="invoiceholder">

  <div id="headerimage"></div>
  <div id="invoice" class="effect2">
    
    <div id="invoice-top">
      <div class="logo"></div>
      <div class="info">
        <h2>Green Pantry</h2>
        <p class ="pInvoice"> hello@michaeltruong.ca</p>
      </div>
        <!--End Info-->
     <div class="title">
        <h2>Invoice #1069</h2>
        <p class ="pInvoice">Issued: May 27, 2015</p>
      </div>
        <!--End Title-->
    </div>
      <!--End InvoiceTop-->
          
      <div id="invoice-mid">
            <div class="clientlogo"></div>
            <div class="info">
                <h2 class="h2Inv">Client Name</h2>
                <p class="pInvoice">JohnDoe@gmail.com</br>
                       555-555-5555</br>
            </div>
            <div id="project">
            </div>   
        </div><!--End Invoice Mid-->
    
                <div id="invoice-bot">
                  <div class="tableInvoice">
                    <table>
                      <tr class="tabletitle">
                        <td class="item"><h2 class="h2Inv">Items</h2></td>
                        <td class="Hours"><h2 class="h2Inv">Quantity</h2></td>
                        <td class="Rate"><h2 class="h2Inv">Price</h2></td>
                        <td class="subtotal"><h2 class="h2Inv">Sub-Total</h2></td>
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
                        <td class="tableitem"><p class="pInvoice itemtext">VAT</p></td>
                        <td class="tableitem"><p class="pInvoice itemtext">15%</p></td>
                        <td class="tableitem"><p class="pInvoice itemtext">$419.25</p></td>
                      </tr>
            
                      <tr class="tabletitle">
                        <td></td>
                        <td></td>
                        <td class="Rate"><h2 class="h2Inv">Total</h2></td>
                        <td class="payment"><h2 class ="h2Inv">$3,644.25</h2></td>
                      </tr>
                    </table>
                  </div>
                    <!--End Table-->
                </div>
        <!--End InvoiceBot-->
            </div>
        <!--End Invoice-->
        </div>
        <!-- End Invoice Holder-->
    </div>
</asp:Content>
