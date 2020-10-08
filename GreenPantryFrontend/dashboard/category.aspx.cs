using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminDashboard
{
    public partial class categories : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
           int currentPage = int.Parse(Request.QueryString["Page"]);
           // int currentPage = 2;
            String display = "";
            dynamic categories = SR.getAllCategories();
            int numCategories = categories.Length;
            double roundUpPages = Math.Ceiling(numCategories/ 10.00);
            int totalPages = (int)roundUpPages;

            dynamic list = GetPage(categories, currentPage, 10);

             foreach(ProductCategory p in list)
             {
                    double saleperc = SR.percentageCategorySales(DateTime.Now, p.ID);
                    display += "<tr><th scope='row'>";
                    display += "<div class='media align-items-center'>";
                    //display += "<a href='#' class='avatar rounded-circle mr-3'>";
                    //display += "<img alt='Image placeholder' src='../assets/img/Products/3.jpg'></a>";
                    display += "<div class='media-body'>";
                    display += "<span class='name mb-0 text-sm'>" + p.Name + "</span></div></div></th>";
                    display += "<td class='budget'>"+saleperc+"%</td><td>";
                    display += "<span class='badge badge-dot mr-4'>";
                    //display += "<i class='bg-warning'></i>";
                    display += "<span class='status'>" + p.Status + "</span></span></td><td>";
                    //display += "<span class='text-success mr-2' id='trafficChange' runat='server'><i class='fa fa-arrow-up'></i> 3.48%</span></td>";
                    display += "<td class='text-right'>";
                    display += "<div class='dropdown'>";
                    display += "<a class='btn btn-sm btn-icon-only text-light' href='#' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>";
                    display += "<i class='fas fa-ellipsis-v'></i></a>";
                    //display += "<div class='dropdown-menu dropdown-menu-right dropdown-menu-arrow'>";
                   // display += "<a class='dropdown-item' href='#'>Action</a>";
                    //display += "<a class='dropdown-item' href='#'>Another action</a>";
                    //display += "<a class='dropdown-item' href='#'>Something else here</a>";
                    display+="</div></div></td></tr>";
                
             }
              catList.InnerHtml = display;

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
                  display += "<a class='page-link' href='/dashboard/category.aspx?Page=" + (currentPage - 1) + "' tabindex='-1'>";
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
                          display += "<a class='page-link' href='/dashboard/category.aspx?Page=" + i + "'>" + i + "</a></li>";
                      }
                  }
              }
              //else
              else if (currentPage.Equals(totalPages))
              {
                  for (int i = totalPages - 2; i <= totalPages; i++)
                  {
                      if (i.Equals(totalPages))
                      {
                          display += "<li class='page-item active'>";
                      }
                      else
                      {
                          display += "<li class='page-item'>";
                      }
                      display += "<a class='page-link' href='/dashboard/category.aspx?Page=" + i + "'>" + i + "</a></li>";
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
                          display += "<a class='page-link' href='/dashboard/category.aspx?Page=" + i + "'>" + i + "</a></li>";
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
                  display += "<a class='page-link' href='/dashboard/category.aspx?Page=" + (currentPage + 1) + "'>";
                  display += "<i class='fas fa-angle-right'></i></a></li>";
              }
              pageNumbers.InnerHtml = display;
        }

        static IList<ProductCategory> GetPage(IList<ProductCategory> list, int pageNumber, int pageSize = 10)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}