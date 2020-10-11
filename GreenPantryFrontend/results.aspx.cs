using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class results : System.Web.UI.Page
    {
        public int currentPage;
        GP_ServiceClient SC = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            String display = "";

            String search = Request.QueryString["Search"];
            //String search = "bread";
            var inputSearch = this.Master.FindControl("searchText") as HtmlInputText;
            dynamic results;
            if(search.Equals("1"))
            {
                inputSearch.Value = "Shop";
                display += "<h2>Shop</h2>";
                results = SC.getAllProducts();
            }
            else
            {
                inputSearch.Value = search;
                display += "<h2>" + search + "</h2>";
                results = SC.searchProducts(search);
            }

            //breadcrumb
            display += "<div class='breadcrumb__option'>";
            display += "<a href='./home.aspx'>Home</a>";
            display += "<span>Search Results</span></div>";
            breadcrumb.InnerHtml = display;

            display = "";
            currentPage = int.Parse(Request.QueryString["Page"]);
            dynamic list = GetPage(results, currentPage, 6);
            int numProduct = results.Length;
            double roundUpPages = Math.Ceiling(numProduct / 6.00);
            int totalPages = (int)roundUpPages;


            //display the products from search result ------
            foreach (Product p in list)
            {
                if (p.Status.Equals("active"))
                {
                    display += "<div class='col-lg-4 col-md-6 col-sm-6'>";
                    display += "<div class='product__item' onclick='location.href=&#39;singleproduct.aspx?ProductID=" + p.ID + "&#39;'>";
                    display += "<div class='product__item__pic set-bg' data-setbg='" + p.Image_Location + "'>";
                    display += "<ul class='product__item__pic__hover'>";
                    if (Session["LoggedInUserID"] != null)
                    {
                        display += "<li><a href='#'><i class='fa fa-list'></i></a></li>";
                    }
                    display += "<li><a href='#'><i class='fa fa-shopping-cart'></i></a></li></ul></div>";
                    display += "<div class='product__item__text'>";
                    display += "<h6>" + p.Name + "</h6>";
                    display += "<h5>R" + Math.Round(p.Price, 2) + "</h5></div></div></div>";
                }

                //get subcategories of search result --------
                String display2 = "";
                List<SubCategory> subcats = new List<SubCategory>();
                dynamic subcat = SC.getSubCat(p.SubCategoryID);
                if (!subcats.Contains(subcat))
                    subcats.Add(subcat);

                foreach (SubCategory sc in subcats)
                {
                    if (sc.Status.Equals("active"))
                    {
                        display2 += "<li><a href='/results.aspx?Search=" + sc.SubID + "&Page=1'>" + sc.Name + "</a></li>";
                    }
                }
                subcatList.InnerHtml = display2;
            }
            categoryProducts.InnerHtml = display;

            display = "";
            if (currentPage.Equals(1))
            {
                display += "<a><i class='fa fa-long-arrow-left'></i></a>";
            }
            else
            {
                display = "<a href='results.aspx?Search=" + search + "&Page=" + (currentPage - 1) + "'><i class='fa fa-long-arrow-left'></i></a>";
            }

            //if current page is 1
            if (currentPage.Equals(1))
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (i <= totalPages)
                    {
                        display += "<a href='results.aspx?Search=" + search + "&Page=" + i + "'>" + i + "</a>";
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
                        display += "<a href='results.aspx?Search=" + search + "&Page=" + i + "'>" + i + "</a>";
                    }
                }
            }
            else
            {
                for (int i = currentPage - 1; i <= currentPage + 1; i++)
                {
                    if (i > 0 && i <= totalPages)
                    {
                        display += "<a href='results.aspx?Search=" + search + "&Page=" + i + "'>" + i + "</a>";
                    }
                }
            }
            //next button
            if (currentPage.Equals(totalPages))
            {
                display += "<a><i class='fa fa-long-arrow-right'></i></a>";
            }
            else
            {
                display += "<a href='results.aspx?SubcategoryID=" + search + "&Page=" + (currentPage + 1) + "'><i class='fa fa-long-arrow-right'></i></a>";
            }
            pageNumbers.InnerHtml = display;
        }

        static IList<Product> GetPage(IList<Product> list, int pageNumber, int pageSize = 6)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}