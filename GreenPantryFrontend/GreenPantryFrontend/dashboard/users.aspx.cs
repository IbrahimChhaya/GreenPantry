using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminDashboard
{
    public partial class users : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            int currentPage = int.Parse(Request.QueryString["Page"]);

            string display = "";
            dynamic users = SC.getAllUsers();

            int numUsers = users.Length;
            double roundUpPages = Math.Ceiling(numUsers / 10.00);
            int totalPages = (int)roundUpPages;
            dynamic list = GetPage(users, currentPage, 10);

            foreach (User u in list)
            {
                display += "<tr><th scope='row'>";
                display += "<div class='media align-items-center'>";
                display += "<div class='media-body'>";
                display += "<a href='edituser.aspx?UserID=" + u.ID + "'><span class='name mb-0 text-sm'>User #" + u.ID + "</span></a>";
                display += "</div></div></th>";
                display += "<td class='budget'>" + u.DateRegistered.ToString("d") + "</td><td>";
                display += "<span class='badge badge-dot mr-4'>";
                if(u.Status.Equals("active"))
                {
                    display += "<i class='bg-success'></i><span class='status'>" + u.Status + "</span></span>";
                }
                else
                {
                    display += "<i class='bg-danger'></i><span class='status'>" + u.Status + "</span></span>";
                }
                display += "</td><td class='text-right'>";
                display += "<div class='dropdown'>";
                display += "<a class='btn btn-sm btn-icon-only text-light' href='#' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>";
                display += "<i class='fas fa-ellipsis-v'></i></a>";
                display += "<div class='dropdown-menu dropdown-menu-right dropdown-menu-arrow'>";
                display += "<a class='dropdown-item' href='edituser.aspx?UserID=" + u.ID + "'>Edit User</a></div>";
                display += "</div></td></tr>";
            }
            userList.InnerHtml = display;

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
                display += "<a class='page-link' href='/dashboard/users.aspx?Page=" + (currentPage - 1) + "' tabindex='-1'>";
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
                        display += "<a class='page-link' href='/dashboard/users.aspx?Page=" + i + "'>" + i + "</a></li>";
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
                        display += "<a class='page-link' href='/dashboard/users.aspx?Page=" + i + "'>" + i + "</a></li>";
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
                        display += "<a class='page-link' href='/dashboard/users.aspx?Page=" + i + "'>" + i + "</a></li>";
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
                display += "<a class='page-link' href='/dashboard/users.aspx?Page=" + (currentPage + 1) + "'>";
                display += "<i class='fas fa-angle-right'></i></a></li>";
            }
            pageNumbers.InnerHtml = display;
        }

        static IList<User> GetPage(IList<User> list, int pageNumber, int pageSize = 10)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}