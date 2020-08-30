using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class singleproduct : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            dynamic getProducts = SC.getProductByID(int.Parse(Request.QueryString["ProductID"]));
            string Display = "";

            dynamic getSub = SC.getSubCat(getProducts.SubCategoryID);
            //breadcrumb
            title.InnerHtml = getProducts.Name;
            Display += "<a href='./home.aspx'>Home</a>";
            Display += "<a href='./subcategory.aspx?SubcategoryID=" + getProducts.SubCategoryID + "'>" + getSub.Name + "</a>";
            Display += "<span>" + getProducts.Name + "</span>";
            productName.InnerHtml = Display;

            //PImage
            Display = "";
            Display += "<img class='product__details__pic__item--large'";
            Display += "src ='" + getProducts.Image_Location + "' alt=''>";
            PImage.InnerHtml = Display;

            Display = "";
            //Pdetails
            Display += "<h3>" + getProducts.Name + "</h3>";
            Display += "<div class='product__details__price'>R" + getProducts.Price + "</div>";
            Display += "<div class='product__details__quantity'>";
            Display += "<div class='quantity'>";
            Display += "<div class='pro-qty'>";
            Display += "<input type = 'text' value='1'>";
            Display += "</div></div></div>";
            Display += "<a href = '#' class='primary-btn'>ADD TO CART</a>";
            Display += "<a href = '#' class='heart-icon'><span class='icon_heart_alt'></span></a>";
            Display += "<ul>";
            if(getProducts.StockOnHand > 0)
                Display += "<li><b>Availability:</b> <span>" + "In Stock" +"</span></li>";
            else
                Display += "<li><b>Availability:</b> <span>" + "Out of Stock" + "</span></li>";
            Display += "<li><b>Share on</b>";
            Display += "<div class='share'>";
            Display += "<a href = '#' ><i class='fa fa-facebook'></i></a>";
            Display += "<a href = '#' ><i class='fa fa-twitter'></i></a>";
            Display += "<a href = '#' ><i class='fa fa-instagram'></i></a>";
            Display += "<a href = '#' ><i class='fa fa-pinterest'></i></a>";
            Display += "</div></li></ul>";
            PDetails.InnerHtml = Display;

            Display = "";
            //description
            Display += "<h6> Products Infomation </h6>";
            Display += "<p>" + getProducts.Name + "</p>";
            Description.InnerHtml = Display;

            ////relatedproducts
            dynamic relatedProducts = SC.getProductBySubCat(getSub.SubID);
            Display = "";
            foreach (Product p in relatedProducts)
            {
                Display += "<div class='col-lg-3 col-md-4 col-sm-6'>";
                Display += "<div class='product__item'>";
                Display += "<div class='product__item__pic set-bg' data-setbg='" + p.Image_Location + "'>";
                Display += "<ul class='product__item__pic__hover'>";
                Display += "<li><a href='#'><i class='fa fa-heart'></i></a></li>";
                Display += "<li><a href='#'><i class='fa fa-shopping-cart'></i></a></li>";
                Display += "</ul></div>";
                Display += "<div class='product__item__text'>";
                Display += "<h6><a href='#'>" + p.Name + "</a></h6>";
                Display += "<h5>R" + p.Price + "</h5>";
                Display += "</div></div></div>";
            }
            RelatedProducts.InnerHtml = Display;
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