using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class orders : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUserID"] != null)
            {
                int userID = int.Parse(Session["LoggedInUserID"].ToString());

                String display = "";
                dynamic invoice = SR.getAllCustomerInvoices(userID);

                foreach (var inv in invoice)
                {
                    int delivery = 0;
                    if(inv.Total < 500)
                    {
                        delivery = 60;
                    }
                    DateTime date = inv.Date;
                    display += "<tr><td>" + inv.ID + "</td>";
                    display += "<td>" + date.ToString("d") + "</td>";
                    display += "<td>R" + Math.Round((inv.Total + delivery - inv.Points), 2) + "</td>";
                    display += "<td>Dispatched</td><td></td>";
                    display += "<td><a class='site-btn' href='/invoice.aspx?InvoiceID=" + inv.ID + "'>View order</a></td></tr>";
                }
                order.InnerHtml = display;
            }
            else
            {
                Response.Redirect("/login.aspx");
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["LoggedInUserID"] = null;
            Response.Redirect("/home.aspx");
        }
    }
}