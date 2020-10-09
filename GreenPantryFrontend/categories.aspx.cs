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

        public string jsonProducts;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["CategoryID"] == null)
            {
                Response.Redirect("home.aspx");
            }
            else { 
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
                    display += "<li><a href='/subcategory.aspx?SubcategoryID=" + sc.SubID + "'>" + sc.Name + "</a></li>";
                }
            }
            subcatList.InnerHtml = display;

            display = "";
            decimal high = 0;
            dynamic products = SC.getProductByCat(int.Parse(catID));
            foreach(Product p in products)
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
                    if (p.Price > high)
                    {
                        high = p.Price;
                    }
                }
                   
            }
            categoryProducts.InnerHtml = display;

                display = "";
                display += "<div class='price-range ui-slider ui-corner-all ui-slider-horizontal ui-widget ui-widget-content'";
                display += "data-min='0' data-max='"+ high + "'>";
                display += "<div class='ui-slider-range ui-corner-all ui-widget-header'></div>";
                display += "<span tabindex='0' class='ui-slider-handle ui-corner-all ui-state-default'></span>";
                display += "<span tabindex='0' class='ui-slider-handle ui-corner-all ui-state-default'></span></div>";

            }
        }

        //function to get all products
        public string getProducts()
        {
            Product[] products = SC.getProductByCat(Convert.ToInt32(Request.QueryString["CategoryID"]));
            //create js serialized object to pass to js
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            jsonProducts = serializer.Serialize(products);
            //jsonProducts = products;
            return jsonProducts;

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
    }
}