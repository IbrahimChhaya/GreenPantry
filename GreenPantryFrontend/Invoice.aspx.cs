using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class Invoice : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            //replace nummber with int.Parse(Request.QueryString["OrderID"])
            var invoice = SR.getOrder(1);

            if(invoice == null)
            {
                Response.Redirect("orders.aspx");
            }
            else
            {
                string display = " ";

                display += "<h1 class ='h1Inv'>Invoice #" + invoice.ID + "</h1>";
                display += "<p class ='pInvoice'>Issued: " + invoice.Date.Date + "</p>";
                title.InnerHtml = display;

                var user = SR.getUser(invoice.CustomerID);

                display = "";
                display += "</br></br></br><div class='clientlogo'></div></br><div class='info'><h2 class='h2Inv'>" + user.Name + "</h2>";
                display += "<p class='pInvoice'>"+user.Email+ "</br>"+ user.PhoneNumber+ "</br></div>";
                clientInfo.InnerHtml = display;

                display = " ";

                dynamic invoiceItems = SR.getOrderedItems(invoice.ID);

                decimal subtotal = 0;

                foreach(InvoiceLine item in invoiceItems)
                {
                    var product = SR.getProduct(item.ProductID);

                    display += "<tr class='service'><td class='tableitem'><p class='pInvoice itemtext'>" + product.Name + "</p></td>";
                    display += "<td class='tableitem'><p class='pInvoice itemtext'>R" + Math.Round(product.Price, 2) + "</p></td>";
                    display += "<td class='tableitem'><p class='pInvoice itemtext'>" + item.Qty + "</p></td>";
                    display += "<td class='tableitem'><p class='pInvoice itemtext'>R" + Math.Round(product.Price * item.Qty) + "</p></td></tr>";
                    tableRow.InnerHtml = display;

                    subtotal += product.Price * item.Qty;
                }

                decimal vat = subtotal * (decimal)(0.15);

                Vat.InnerHtml = "<h2 class ='h2Inv'>R" + Math.Round(vat, 2) + "</h2>";

                Total.InnerHtml = "<h2 class ='h2Inv'>R"+ Math.Round(subtotal + vat, 2) +"</h2>";

                if(subtotal + vat > 500)
                {
                    delivery.Visible = true;
                    deliverFree.InnerHtml = "<h2 class ='h2Inv'>R0.00</h3>";
                }
            }
        }
    }
}