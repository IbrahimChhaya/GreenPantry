using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminDashboard
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

            int currentPage = int.Parse(Request.QueryString["Page"]);
            //get the user ID from url parameters
            userID = Convert.ToInt32(Request.QueryString["userID"]);
            //userID = 1;
            dynamic invoice = SR.getAllCustomerInvoices(userID);
            int numInvoices = invoice.Length;
            double roundUpPages = Math.Ceiling(numInvoices / 10.00);
            int totalPages = (int)roundUpPages;
            dynamic listo = GetPage(invoice, currentPage, 10);

            userIDOrders.InnerHtml = "User #" + userID + "'s Orders";

            string display = "";
            foreach(var inv in listo)
            {
                int delivery = 0;
                if (inv.Total < 500)
                {
                    delivery = 60;
                }
                display += "<tr><th scope='row'><div class='media align-items-center'>";
                display += "<div class='media-body'>";
                display += "<a href='editOrder.aspx?InvoiceID=" + inv.ID + "'><span class='name mb-0 text-sm'>#" + inv.ID + "</span></a></div></div></th>";
                display += "<td class='budget'>R" + Math.Round((inv.Total + delivery - inv.Points), 2) +"</td>";
                display += "<td><span class='badge badge-dot mr-4'>";
                if (inv.Status.Equals("Pending"))
                {
                    display += "<i class='bg-warning'></i><span class='status'>" + inv.Status + "</span>";
                }
                else if (inv.Status.Equals("Approved"))
                {
                    display += "<i class='bg-success'></i><span class='status'>" + inv.Status + "</span>";
                }
                else
                {
                    display += "<i class='bg-danger'></i><span class='status'>" + inv.Status + "</span>";
                }
                //"<i class='bg-warning'></i><span class='status'>" +inv.Status+"</span></span></td>";
                display += "</td><td><div class='avatar-group'><span class='Date'>" + inv.Date.ToShortDateString()+ "</span></div></td>";
                display += "<td class='text-right'><div class='dropdown'>";
                display += "<a class='btn btn-sm btn-icon-only text-light' href='#' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>";
                display += "<i class='fas fa-ellipsis-v'></i></a>";
                display += "<div class='dropdown-menu dropdown-menu-right dropdown-menu-arrow'>";
                display += "<a class='dropdown-item' href='editOrder.aspx?InvoiceID=" + inv.ID + "'>Edit Order</a>";
                display += "</div></div></td></tr>";
            }
            InvoiceNumber.InnerHtml = display;

            //page numbers
            //previous button
            display = "";
            if (currentPage.Equals(1))
            {
                display += "<li class='page-item disabled'>";
                display += "<a class='page-link' href='#' tabindex='-1'>";
                display += "<i class='fas fa-angle-left'></i></a></li>";
            }
            else
            {
                display += "<li class='page-item'>";
                display += "<a class='page-link' href='userorders.aspx?UserID=" + userID + "&Page=" + (currentPage - 1) + "' tabindex='-1'>";
                display += "<i class='fas fa-angle-left'></i></a></li>";
            }

            //if current page is 1
            if (currentPage.Equals(1))
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (i <= totalPages)
                    {
                        if (i.Equals(1))
                        {
                            display += "<li class='page-item active'>";
                        }
                        else
                        {
                            display += "<li class='page-item'>";
                        }
                        display += "<a class='page-link' href='userorders.aspx?UserID=" + userID + "&Page=" + i + "'>" + i + "</a></li>";
                    }
                }
            }
            //else
            else if (currentPage.Equals(totalPages))
            {
                for (int i = totalPages - 2; i <= totalPages; i++)
                {
                    if (i > 0)
                    {
                        if (i.Equals(totalPages))
                        {
                            display += "<li class='page-item active'>";
                        }
                        else
                        {
                            display += "<li class='page-item'>";
                        }
                        display += "<a class='page-link' href='/dashboard/userorders.aspx?UserID=" + userID + "&Page=" + i + "'>" + i + "</a></li>";
                    }
                }
            }
            else
            {
                for (int i = currentPage - 1; i <= currentPage + 1; i++)
                {
                    if (i > 0 && i <= totalPages)
                    {
                        if (i.Equals(currentPage))
                        {
                            display += "<li class='page-item active'>";
                        }
                        else
                        {
                            display += "<li class='page-item'>";
                        }
                        display += "<a class='page-link' href='/dashboard/userorders.aspx?UserID=" + userID + "&Page=" + i + "'>" + i + "</a></li>";
                    }
                }
            }
            //next button
            if (currentPage.Equals(totalPages))
            {
                display += "<li class='page-item disabled'>";
                display += "<a class='page-link' href='#'>";
                display += "<i class='fas fa-angle-right'></i></a></li>";
            }
            else
            {
                display += "<li class='page-item'>";
                display += "<a class='page-link' href='/dashboard/userorders.aspx?UserID=" + userID + "&Page=" + (currentPage + 1) + "'>";
                display += "<i class='fas fa-angle-right'></i></a></li>";
            }
            pageNumbers.InnerHtml = display;
        }

        static IList<Invoice> GetPage(IList<Invoice> list, int pageNumber, int pageSize)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}