using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class subcategory : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();

        public int currentPage;
        public string jsonProducts;
        public int loggedIn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["SubcategoryID"] == null)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                String display = "";

                String subID = Request.QueryString["SubcategoryID"];

                dynamic subcat = SC.getSubCat(int.Parse(subID));

                //breadcrumb-------------------------------------------------------------
                if (subcat.Status.Equals("active"))
                {
                    display += "<h2>" + subcat.Name + "</h2>";
                    display += "<div class='breadcrumb__option'>";
                    display += "<a href='./home.aspx'>Home</a>";
                    display += "<span>" + subcat.Name + "</span></div>";

                    breadcrumb.InnerHtml = display;

                    //filterd by sidebar-------------------------------------------------------------

                    display = "";
                    display += "<li>" + subcat.Name + "</li>";

                    filtered.InnerHtml = display;
                }

                //products-------------------------------------------------------------

                display = "";
                currentPage = int.Parse(Request.QueryString["Page"]);
                dynamic products = SC.getProductBySubCat(int.Parse(subID));
                dynamic list = GetPage(products, currentPage, 6);
                int numProduct = products.Length;
                double roundUpPages = Math.Ceiling(numProduct / 6.00);
                int totalPages = (int)roundUpPages;

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
                }
                subProducts.InnerHtml = display;

                display = "";
                if (currentPage.Equals(1))
                {
                    display += "<a><i class='fa fa-long-arrow-left'></i></a>";
                }
                else
                {
                    display = "<a href='subcategories.aspx?SubcategoryID=" + subID + "&Page=" + (currentPage - 1) + "'><i class='fa fa-long-arrow-left'></i></a>";
                }

                //if current page is 1
                if (currentPage.Equals(1))
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        if (i <= totalPages)
                        {
                            display += "<a href='subcategories.aspx?SubcategoryID=" + subID + "&Page=" + i + "'>" + i + "</a>";
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
                            display += "<a href='subcategories.aspx?SubcategoryID=" + subID + "&Page=" + i + "'>" + i + "</a>";
                        }
                    }
                }
                else
                {
                    for (int i = currentPage - 1; i <= currentPage + 1; i++)
                    {
                        if (i > 0 && i <= totalPages)
                        {
                            display += "<a href='subcategories.aspx?SubcategoryID=" + subID + "&Page=" + i + "'>" + i + "</a>";
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
                    display += "<a href='subcategories.aspx?SubcategoryID=" + subID + "&Page=" + (currentPage + 1) + "'><i class='fa fa-long-arrow-right'></i></a>";
                }
                pageNumbers.InnerHtml = display;
            }

            if (Session["LoggedInUserID"] != null)
            {
                loggedIn = Convert.ToInt32(Session["LoggedInUserID"]);
            }
        }

        //function to get all products
        public string getProducts()
        {
            Product[] products = SC.getProductBySubCat(Convert.ToInt32(Request.QueryString["SubcategoryID"]));
            dynamic list = GetPage(products, currentPage, 6);
            //create js serialized object to pass to js
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            jsonProducts = serializer.Serialize(list);
            //jsonProducts = products;
            return jsonProducts;

        }

        static IList<Product> GetPage(IList<Product> list, int pageNumber, int pageSize = 6)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        //sort by price (ascending)
        public string sortAscending()
        {
            Product[] products = SC.getProductBySubCat(Convert.ToInt32(Request.QueryString["SubcategoryID"]));
            dynamic list = GetPage(products, currentPage, 6);

            List<Product> productPricePair = new List<Product>();

            foreach (Product p in list)
            {
                productPricePair.Add(p);
            }

            var sortedResult = productPricePair.OrderBy(p => p.Price).ToList();

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var jsonSortedProducts = serializer.Serialize(sortedResult);
            return jsonSortedProducts;

        }

        //sort by price (descending)
        public string sortDescending()
        {
            Product[] products = SC.getProductBySubCat(Convert.ToInt32(Request.QueryString["SubcategoryID"]));
            dynamic list = GetPage(products, currentPage, 6);

            List<Product> productPricePair = new List<Product>();

            foreach (Product p in list)
            {
                productPricePair.Add(p);
            }

            var sortedResult = productPricePair.OrderByDescending(p => p.Price).ToList();

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var jsonSortedProducts = serializer.Serialize(sortedResult);
            return jsonSortedProducts;

        }

        //sort alpahbetically (descending)
        public string sortAlphabeticalDescending()
        {
            Product[] products = SC.getProductBySubCat(Convert.ToInt32(Request.QueryString["SubcategoryID"]));
            dynamic list = GetPage(products, currentPage, 6);

            List<Product> productPricePair = new List<Product>();

            foreach (Product p in list)
            {
                productPricePair.Add(p);
            }

            var sortedResult = productPricePair.OrderByDescending(p => p.Name).ToList();

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var jsonSortedProducts = serializer.Serialize(sortedResult);
            return jsonSortedProducts;

        }

        //sort alpahbetically (ascending)
        public string sortAlphabeticalAscending()
        {
            Product[] products = SC.getProductBySubCat(Convert.ToInt32(Request.QueryString["SubcategoryID"]));
            dynamic list = GetPage(products, currentPage, 6);

            List<Product> productPricePair = new List<Product>();

            foreach (Product p in list)
            {
                productPricePair.Add(p);
            }

            var sortedResult = productPricePair.OrderBy(p => p.Name).ToList();

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var jsonSortedProducts = serializer.Serialize(sortedResult);
            return jsonSortedProducts;

        }
    }
}