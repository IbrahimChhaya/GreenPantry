using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend.dashboard
{
    public partial class editorder : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUserID"] != null)
            {
                int userID = int.Parse(Session["LoggedInUserID"].ToString());
                dynamic user = SC.getUser(userID);
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

            if (Request.QueryString["InvoiceID"] == null)
            {
                Response.Redirect("dashboard.aspx");
            }
            else
            {
                int invoiceID = int.Parse(Request.QueryString["InvoiceID"].ToString());
                editName.InnerText = "Edit Order #" + invoiceID;
                dynamic invoice = SC.getInvoice(invoiceID);
                dynamic items = SC.getAllInvoiceLines(invoiceID);
                string display = "";

                foreach (InvoiceLine i in items)
                {
                    dynamic product = SC.getProduct(i.ProductID);
                    display += "<tr><th scope='row'>";
                    display += "<div class='media align-items-center'>";
                    display += "<div class='media-body'>";
                    display += "<span class='name mb-0 text-sm'>" + product.Name + "</span>";
                    display += "</div></div></th>";
                    display += "<td class='budget'>";
                    display += "R" + Math.Round((decimal)i.Price, 2) + "</td>";
                    display += "<td class='budget'>" + i.Qty + "</td></tr>";
                }
                productList.InnerHtml = display;

                if (!IsPostBack)
                {
                    userID.InnerText = "User #" + invoice.CustomerID;
                    dynamic user = SC.getUser(invoice.CustomerID);
                    email.Value = user.Email;
                    datePlaced.Value = invoice.Date.ToString("d");
                    notes.Value = invoice.Notes;

                    dropdownStatus.Items.Clear();
                    if (invoice.Status.Equals("Pending"))
                    {
                        dropdownStatus.Items.Add("Pending");
                        dropdownStatus.Items.Add("Approved");
                        dropdownStatus.Items.Add("Cancelled");
                    }
                    else if (invoice.Status.Equals("Approved"))
                    {
                        dropdownStatus.Items.Add("Approved");
                        dropdownStatus.Items.Add("Pending");
                        dropdownStatus.Items.Add("Cancelled");
                    }
                    else
                    {
                        dropdownStatus.Items.Add("Cancelled");
                        dropdownStatus.Items.Add("Approved");
                        dropdownStatus.Items.Add("Pending");
                    }
                }
            }
        }

        protected void updateOrder_ServerClick(object sender, EventArgs e)
        {
            int invoiceID = int.Parse(Request.QueryString["InvoiceID"].ToString());
            dynamic invoice = SC.getInvoice(invoiceID);
            int updateInvoice = SC.updateInvoice(invoice.CustomerID, dropdownStatus.Text, invoice.Date, invoice.DeliveryDatetime, notes.Value, invoice.Total, invoice.Points);
            if(updateInvoice.Equals(1))
            {
                error.Visible = true;
                error.InnerText = "Order updated";
            }
            else
            {
                error.Visible = true;
                error.InnerText = "An error occurred";
            }
        }
    }
}