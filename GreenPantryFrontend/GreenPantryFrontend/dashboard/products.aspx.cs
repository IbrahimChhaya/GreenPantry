﻿using GreenPantryFrontend.ServiceReference1;
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
            if (Session["LoggedInUserID"] != null)
            {
                int userID = int.Parse(Session["LoggedInUserID"].ToString());
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
            //int currentPage = 2;
            String display = "";

            dynamic products = SR.getAllProducts();
            int numProduct = products.Length;
            numProducts.InnerText = (10 * currentPage) + "/" + numProduct;
            double roundUpPages = Math.Ceiling(numProduct / 10.00);
            int totalPages = (int)roundUpPages;

            //get 10 products per page
            dynamic list = GetPage(products, currentPage, 10);
            foreach (Product p in list)
            {
                double perc = SR.percProductSales(DateTime.Now, p.ID);
                int NumProducts = SR.numProductSales(DateTime.Now, p.ID);

                display += "<tr><th scope='row'>";
                display += "<div class='media align-items-center'>";
                display += "<a href='#' class='avatar rounded-circle mr-3'>";
                display += "<img alt='Image placeholder' src='" + "../" + p.Image_Location + "'>";
                display += "</a><div class='media-body'>";
                display += "<a href='editproduct.aspx?ProductID=" + p.ID + "'><span class='name mb-0 text-sm'>" + p.Name + "</span></a>";
                display += "</div></div></th>";
                display += "<td class='budget'>";
                display += "R" + Math.Round(p.Price, 2) + "</td><td>";
                display += "<span class='badge badge-dot mr-4'>";
                if(p.StockOnHand < 100)
                {
                    display += "<i class='bg-warning'></i><span class='status'>" + p.StockOnHand + "</span>";
                }
                else
                {
                    display += "<i class='bg-success'></i><span class='status'>" + p.StockOnHand + "</span>";
                }
                display += "</span></td><td>";
                display += "<span class='text-success mr-2' id='trafficChange' runat='server'><i class='fa fa-arrow-up'></i>"+ perc+ "%</span></td>";
                display += "<td class='text-right'>";
                display += "<div class='dropdown'>";
                display += "<a class='btn btn-sm btn-icon-only text-light' href='#' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>";
                display += "<i class='fas fa-ellipsis-v'></i></a>";
                display += "<div class='dropdown-menu dropdown-menu-right dropdown-menu-arrow'>";
                display += "<a class='dropdown-item' href='editproduct.aspx?ProductID=" + p.ID + "'>Edit Product</a>";;
                display += "</div></div></td></tr>";
            }
            productList.InnerHtml = display;

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
                display += "<a class='page-link' href='/dashboard/products.aspx?Page=" + (currentPage - 1) + "' tabindex='-1'>";
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
                        display += "<a class='page-link' href='/dashboard/products.aspx?Page=" + i + "'>" + i + "</a></li>";
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
                        display += "<a class='page-link' href='/dashboard/products.aspx?Page=" + i + "'>" + i + "</a></li>";
                    }
                }
            }
            else
            {
                for (int i = currentPage - 1; i <= currentPage + 1; i++)
                {
                    if (i > 0 && i <= totalPages)
                    {
                        if(i.Equals(currentPage))
                        { 
                            display += "<li class='page-item active'>";
                        }
                        else
                        {
                            display += "<li class='page-item'>";
                        }
                        display += "<a class='page-link' href='/dashboard/products.aspx?Page=" + i + "'>" + i + "</a></li>";
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
                display += "<a class='page-link' href='/dashboard/products.aspx?Page=" + (currentPage + 1) + "'>";
                display += "<i class='fas fa-angle-right'></i></a></li>";
            }
            pageNumbers.InnerHtml = display;
        }

        static IList<Product> GetPage(IList<Product> list, int pageNumber, int pageSize = 10)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}