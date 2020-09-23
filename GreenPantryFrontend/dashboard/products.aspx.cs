using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminDashboard
{
    public partial class products : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            int currentPage = int.Parse(Request.QueryString["Page"]);

            String display = "";

            dynamic products = SR.getAllProducts();
            int numProduct = products.Length;
            decimal pages = Math.Ceiling(Convert.ToDecimal(numProduct / 10));

            //for the page numbers, onclick next/previous page change numbers (from 1,2,3 to 4,5,6) on numbers a href
            
            dynamic list = GetPage(products, currentPage, 10);
            foreach (Product p in list)
            {
                display += "<tr><th scope='row'>";
                display += "<div class='media align-items-center'>";
                display += "<a href='#' class='avatar rounded-circle mr-3'>";
                display += "<img alt='Image placeholder' src='" + "../" + p.Image_Location + "'>";
                display += "</a><div class='media-body'>";
                display += "<span class='name mb-0 text-sm'>" + p.Name + "</span>";
                display += "</div></div></th>";
                display += "<td class='budget'>";
                display += "R" + Math.Round(p.Price, 2) + "</td><td>";
                display += "<span class='badge badge-dot mr-4'>";
                display += "<i class='bg-warning'></i>";
                display += "<span class='status'>" + p.StockOnHand + "</span>";
                display += "</span></td><td>";
                display += "<span class='text-success mr-2' id='trafficChange' runat='server'><i class='fa fa-arrow-up'></i> 3.48%</span></td>";
                display += "<td class='text-right'>";
                display += "<div class='dropdown'>";
                display += "<a class='btn btn-sm btn-icon-only text-light' href='#' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>";
                display += "<i class='fas fa-ellipsis-v'></i></a>";
                display += "<div class='dropdown-menu dropdown-menu-right dropdown-menu-arrow'>";
                display += "<a class='dropdown-item' href='#'>Action</a>";
                display += "<a class='dropdown-item' href='#'>Another action</a>";
                display += "<a class='dropdown-item' href='#'>Something else here</a>";
                display += "</div></div></td></tr>";
            }    
            productList.InnerHtml = display;
        }

        static IList<Product> GetPage(IList<Product> list, int pageNumber, int pageSize = 10)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}