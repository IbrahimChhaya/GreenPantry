using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class results : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();

        public string jsonProducts;
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

            //display the products from search result ------
            display = "";
            foreach (Product p in results)
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
                        display2 += "<li><a href='/subcategory.aspx?SubcategoryID=" + sc.SubID + "'>" + sc.Name + "</a></li>";
                    }
                }
                subcatList.InnerHtml = display2;
            }
            categoryProducts.InnerHtml = display;
        }

        //function to get all products
        public string getProducts()
        {
            Product[] products = SC.searchProducts(Request.QueryString["Search"]);
            //create js serialized object to pass to js
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            jsonProducts = serializer.Serialize(products);
            //jsonProducts = products;
            return jsonProducts;

        }
    }
}