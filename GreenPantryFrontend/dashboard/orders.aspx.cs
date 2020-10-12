using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class orderdash : System.Web.UI.Page
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

            int currentPage = int.Parse(Request.QueryString["Page"]);
            string display = "";
            dynamic orders = SC.getAllInvoices();
            int numOrder = orders.Length;
            double roundUpPages = Math.Ceiling(numOrder / 10.00);
            int totalPages = (int)roundUpPages;
            dynamic list = GetPage(orders, currentPage, 10);

            foreach (var i in list)
            {
                User getuser = SC.getUser(i.CustomerID);
                display += "<tr><th scope='row'>";
                display += "<div class='media align-items-center'>";
                display += "<div class='media-body'>";
                display += "<a href='editOrder.aspx?InvoiceID=" + i.ID + "'><span class='name mb-0 text-sm'>#" + i.ID + "</span></a>";
                display += "</div></div></th>";
                display += "<td class='budget'>";
                display += "R" + Math.Round(i.Total,2);
                display += "</td><td>";
                display += "<span class='badge badge-dot mr-4'>";
                if(i.Status.Equals("Pending"))
                {
                    display += "<i class='bg-warning'></i><span class='status'>" + i.Status + "</span>";
                }
                else if(i.Status.Equals("Approved"))
                {
                    display += "<i class='bg-success'></i><span class='status'>" + i.Status + "</span>";
                }
                else
                {
                    display += "<i class='bg-danger'></i><span class='status'>" + i.Status + "</span>";
                }
                display += "</span></td>";
                display += "<td><span class='budget'>" + i.Date.ToString("d") + "</span></td>";
                display += "<td><div class='avatar-group'>";
                display += "<a href='#' class='avatar avatar-sm rounded-circle' data-toggle='tooltip' data-original-title=" + getuser.Name +">";
                display += "<i class='ni ni-circle-08'></i>";
                display += "</a></div></td>";
                display += "<td class='text-right'>";
                display += "<div class='dropdown'>";
                display += "<a class='btn btn-sm btn-icon-only text-light' href='#' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>";
                display += "<i class='fas fa-ellipsis-v'></i>";
                display += "</a>";
                display += "<div class='dropdown-menu dropdown-menu-right dropdown-menu-arrow'>";
                display += "<a class='dropdown-item' href='editOrder.aspx?InvoiceID=" + i.ID + "'>Edit Order</a>";
                display += "</div></div></td></tr></a>";
            }
            orderID.InnerHtml = display;

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
                display += "<a class='page-link' href='orders.aspx?Page=" + (currentPage - 1) + "' tabindex='-1'>";
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
                        display += "<a class='page-link' href='orders.aspx?Page=" + i + "'>" + i + "</a></li>";
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
                        display += "<a class='page-link' href='/dashboard/orders.aspx?Page=" + i + "'>" + i + "</a></li>";
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
                        display += "<a class='page-link' href='/dashboard/orders.aspx?Page=" + i + "'>" + i + "</a></li>";
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
                display += "<a class='page-link' href='/dashboard/orders.aspx?Page=" + (currentPage + 1) + "'>";
                display += "<i class='fas fa-angle-right'></i></a></li>";
            }
            pageNumbers.InnerHtml = display;
        }

        static IList<Invoice> GetPage(List<Invoice> list, int pageNumber, int pageSize)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}