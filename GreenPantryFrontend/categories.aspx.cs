using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class categories : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            String display = "";

            String catID = Request.QueryString["CategoryID"];

            dynamic category = SC.getCat(int.Parse(catID));

            display += "<h2>" + category.Name + "</h2>";
            display += "<div class='breadcrumb__option'>";
            display +=  "<a href='./home.aspx'>Home</a>";
            display += "<span>" + category.Name + "</span></div>";

            breadcrumb.InnerHtml = display;

            display = "";
            dynamic subcats = SC.getSubCatPerCat(int.Parse(catID));
            int numProducts = SC.getNumProductsInSub(subcats.SubID);
            foreach(SubCategory sc in subcats)
            { 
                display += "<li><a href='/subcategory.aspx?SubcategoryID=" + sc.SubID + "'>" + sc.Name + "(" + numProducts + ")</a></li>";
            }
            subcatList.InnerHtml = display;

            display = "";
            dynamic products = SC.getProductByCat(int.Parse(catID));
            foreach(Product p in products)
            {
                display += "<div class='col-lg-4 col-md-6 col-sm-6'>";
                display += "<div class='product__item' onclick='location.href=&#39;singleproduct.aspx?ProductID=" + p.ID + "&#39;'>";
                display += "<div class='product__item__pic set-bg' data-setbg='" + p.Image_Location + "'>";
                display += "<ul class='product__item__pic__hover'>";
                display += "<li><a href='#'><i class='fa fa-heart'></i></a></li>";
                display += "<li><a href='#'><i class='fa fa-shopping-cart'></i></a></li></ul></div>";
                display += "<div class='product__item__text'>";
                display += "<h6>" + p.Name + "</h6>";
                display += "<h5>R" + p.Price + "</h5></div></div></div>";
            }
            categoryProducts.InnerHtml = display;
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
    }
}