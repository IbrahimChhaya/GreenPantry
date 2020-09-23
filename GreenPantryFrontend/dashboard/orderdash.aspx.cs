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
            string Display = ""; 
            dynamic orders = SC.getAllOrders();

            foreach(var i in orders)
            {
                User getuser = SC.getUser(i.CustomerID);
                Display += "<tr>";
                Display += "<th scope = 'row'>";
                Display += "<div class='media align-items-center'>";
                Display += "<div class='media-body'>";
                Display += "<span class='name mb-0 text-sm'>Invoice #" + i.ID + "</span>";
                Display += "</div></div></th>";
                Display += "<td class='budget'>";
                Display += "R" + Math.Round(i.Total,2);
                Display += "</td><td>";
                Display += "<span class='badge badge-dot mr-4'>";
                Display += "<i class='bg-warning'></i>";
                Display += "<span class='status'>" + i.Status + "</span>";
                Display += "</span></td><td>";
                Display += "<div class='avatar-group'>";
                Display += "<a href = '#' class='avatar avatar-sm rounded-circle' data-toggle='tooltip' data-original-title=" + getuser.Name +">";
                Display += "<i class='ni ni-circle-08'></i>";
                Display += "</a></div></td>"; 
                Display += "<td class='text-right'>";
                Display += "<div class='dropdown'>"; 
                Display += "<a class='btn btn-sm btn-icon-only text-light' href='#' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>";
                Display += "<i class='fas fa-ellipsis-v'></i>";
                Display += "</a>"; 
                Display += "<div class='dropdown-menu dropdown-menu-right dropdown-menu-arrow'>"; 
                Display += "<a class='dropdown-item' href='#'>Action</a>";
                Display += "<a class='dropdown-item' href='#'>Another action</a>";
                Display += "<a class='dropdown-item' href='#'>Something else here</a>";
                Display += "</div></div></td></tr>";
                
            }
            orderID.InnerHtml = Display;
        }
    }
}