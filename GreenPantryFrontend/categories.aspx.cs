using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class categories : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();

        public int currentPage;
        public string jsonProducts;
        public int loggedIn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["CategoryID"] == null)
            {
                Response.Redirect("home.aspx");
            }
            else 
            { 
                String display = "";

                String catID = Request.QueryString["CategoryID"];

                dynamic category = SC.getCat(int.Parse(catID));
                if (category.Status.Equals("active"))
                {
                    display += "<h2>" + category.Name + "</h2>";
                    display += "<div class='breadcrumb__option'>";
                    display += "<a href='./home.aspx'>Home</a>";
                    display += "<span>" + category.Name + "</span></div>";

                    breadcrumb.InnerHtml = display;
                }
                display = "";
                dynamic subcats = SC.getSubCatPerCat(int.Parse(catID));
                //int numProducts = SC.getNumProductsInSub(subcats.SubID);
                foreach(SubCategory sc in subcats)
                {
                    if (sc.Status.Equals("active"))
                    {
                        display += "<li><a href='/subcategory.aspx?SubcategoryID=" + sc.SubID + "&Page=1'>" + sc.Name + "</a></li>";
                    }
                }
                subcatList.InnerHtml = display;

                display = "";
                dynamic products = SC.getProductByCat(int.Parse(catID));
                currentPage = int.Parse(Request.QueryString["Page"]);
                //int currentPage = 1;
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
                        if(Session["LoggedInUserID"] != null)
                        { 
                            display += "<li><a href='#'><i class='fa fa-list'></i></a></li>";
                        }
                        display += "<li><a href='#'><i class='fa fa-shopping-cart'></i></a></li></ul></div>";
                        display += "<div class='product__item__text'>";
                        display += "<h6>" + p.Name + "</h6>";
                        display += "<h5>R" + Math.Round(p.Price, 2) + "</h5></div></div></div>";
                    }
                }
                categoryProducts.InnerHtml = display;

                display = "";
                if (currentPage.Equals(1))
                {
                    display += "<a><i class='fa fa-long-arrow-left'></i></a>";
                }
                else
                {
                    display = "<a href='categories.aspx?CategoryID=" + catID + "&Page=" + (currentPage - 1) + "'><i class='fa fa-long-arrow-left'></i></a>";
                }

                //if current page is 1
                if (currentPage.Equals(1))
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        if (i <= totalPages)
                        {
                            display += "<a href='categories.aspx?CategoryID=" + catID + "&Page=" + i + "'>" + i + "</a>";
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
                            display += "<a href='categories.aspx?CategoryID=" + catID + "&Page=" + i + "'>" + i + "</a>";
                        }
                    }
                }
                else
                {
                    for (int i = currentPage - 1; i <= currentPage + 1; i++)
                    {
                        if (i > 0 && i <= totalPages)
                        {
                            display += "<a href='categories.aspx?CategoryID=" + catID + "&Page=" + i + "'>" + i + "</a>";
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
                    display += "<a href='categories.aspx?CategoryID=" + catID + "&Page=" + (currentPage + 1) + "'><i class='fa fa-long-arrow-right'></i></a>";
                }
                pageNumbers.InnerHtml = display;
            }

        }

        //function to get all products
        public string getProducts()
        {
            Product[] products = SC.getProductByCat(Convert.ToInt32(Request.QueryString["CategoryID"]));
            dynamic list = GetPage(products, currentPage, 6);
            //create js serialized object to pass to js
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            jsonProducts = serializer.Serialize(list);
            //jsonProducts = products;
            return jsonProducts;
        }

        //sort by price (ascending)
        public string sortAscending()
        {
            dynamic products = SC.getProductByCat(Convert.ToInt32(Request.QueryString["CategoryID"]));
            dynamic list = GetPage(products, currentPage, 6);

            List<Product> productPricePair = new List<Product>();

            foreach(Product p in list)
            {
                productPricePair.Add(p);
            }

            var sortedResult =  productPricePair.OrderBy(p => p.Price).ToList();

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var jsonSortedProducts = serializer.Serialize(sortedResult);
            return jsonSortedProducts;
            
        }

        //sort by price (descending)
        public string sortDescending()
        {
            dynamic products = SC.getProductByCat(Convert.ToInt32(Request.QueryString["CategoryID"]));
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
            dynamic products = SC.getProductByCat(Convert.ToInt32(Request.QueryString["CategoryID"]));
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
            dynamic products = SC.getProductByCat(Convert.ToInt32(Request.QueryString["CategoryID"]));
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

        private void saveToCookie(String CookieName, String content)
        {
            //content: productID-quantity,productID-quantity
            Response.Cookies[CookieName].Value += content + ",";
        }
        private void createCookie(String CookieName, String content)
        {
            Response.Cookies[CookieName].Value = content + ",";
        }

        private String readCookie(String CookieName)
        {
            return Request.Cookies[CookieName].ToString();
        }

        protected void btnFilterPrice_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        static IList<Product> GetPage(IList<Product> list, int pageNumber, int pageSize = 6)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}