using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend.dashboard
{
    public partial class userorders : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = 0;
            if (Session["LoggedInUserID"] != null)
            {
                userID = int.Parse(Session["LoggedInUserID"].ToString());
                dynamic user = SR.getUser(userID);
                if (user.UserType == "admin")
                {
                    howdy.InnerText = "Howdy, " + user.Name;
                }
                else
                {
                    Response.Redirect("/home.aspx");
                }
            }
            else
            {
                Response.Redirect("/home.aspx");
            }

            //get the user ID from url parameters
            // int userID = Convert.ToInt32(Request.QueryString["userID"]);
            userID = 1;
            dynamic invoice = SR.getAllCustomerInvoices(userID);
            userIDOrders.InnerHtml = "User #" + userID + "'s Orders";

            string display = "";
            foreach(var inv in invoice)
            {
                int delivery = 0;
                if (inv.Total < 500)
                {
                    delivery = 60;
                }
                display += "<tr><th scope='row'> <div class='media align-items-center'>";
                display += "<div class='media-body'>";
                display += "<span class='name mb-0 text-sm'>#" + inv.ID + "</span></div></div></th>";
                display += "<td class='budget'>R" + Math.Round((inv.Total + delivery - inv.Points), 2) +"</td>";
                display += "<td><span class='badge badge-dot mr-4'><i class='bg-warning'></i><span class='status'>"+inv.Status+"</span></span></td>";
                display += "<td><div class='avatar-group'><span class='Date'>"+inv.Date.ToShortDateString()+ "</span></div></td>";
                display += "<td class='text-right'><div class='dropdown'>";
                display += "<a class='btn btn-sm btn-icon-only text-light' href='#' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>";
                display += "<i class='fas fa-ellipsis-v'></i></a>";
                display += "<div class='dropdown-menu dropdown-menu-right dropdown-menu-arrow'>";
                display += "<a class='dropdown-item' href='#'>Approve</a>";
                display += "<a class='dropdown-item' href='#'>Cancel</a>";
                display += "<a class='dropdown-item' href='#'>Do something else</a>";
                display += "</div></div></td></tr>";
            }
            InvoiceNumber.InnerHtml = display;
        }
    }
}