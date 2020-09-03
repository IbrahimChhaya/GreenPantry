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
                //dynamic invoice = SR.getAllCustomerOrders(userID);

                //foreach(Invoice i in invoice)
                {
                    display += "<td><a href='/invoice.aspx?InvoiceID=" + 1 + "'></a></td><td>";
                    display += "<span class='short'>2020/09/02</span></td>";
                    display += "<td>R428.00</td>";
                    display += "<td>Dispatched</td><td></td>";
                    display += "<td><a class='site-btn' href='/invoice.aspx?InvoiceID=" + 1 + "'>View order</a></td>";
                }
                //invoice.InnerHtml = display;
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["LoggedInUserID"] = null;
            Response.Redirect("/home.aspx");
        }
    }
}