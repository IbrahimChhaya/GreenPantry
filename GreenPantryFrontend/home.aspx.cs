using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class home : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            String display = "";

            //category menu --------------------------------------------------------------------

            dynamic allCategories = SC.getAllCategories();
            foreach (ProductCategory c in allCategories)
            {

                display += "<li><a href='/categories.aspx?CategoryID=" + c.ID + "'>" + c.Name + "</a></li>";
            }

            categoryList.InnerHtml = display;

            //search box categories drop down --------------------------------------------------------------------

            //foreach (ProductCategory c in allCategories)
            //{

            //    display += "<a href='/categories.aspx?CategoryID='" + c.ID + ">" + c.Name + "</a></li>";
            //}

            //categoryList.InnerHtml = display;


            //product category slider 11111111111111111--------------------------------------------

            String sliderCaption = "Freshly Picked";

            display = "<div class='col-lg-12'>";
            display += "<div class='hero__item set-bg' data-setbg='img/freeshipping.png'>";
            display += "<div class='hero__text'>";
            display += "<span></span>";
            display += "<h2>Free <br/>Shipping</h2>";
            display += "<p>On Orders Over R500</p>";
            display += "<a href='#' class='primary-btn'>SHOP NOW</a>";
            display += "</div></div></br>";
            display += categoryHelper(sliderCaption, 2);

            categorySlider1.InnerHtml = display;

            //product category slider 222222222222222222-----------------------------------------------

            sliderCaption = "Fresh From The Bakery";

            display = "<div class='col-lg-12'>";
            display += categoryHelper(sliderCaption, 7);

            categorySlider2.InnerHtml = display;

            //product category slider 333333333333333333-----------------------------------------------

            sliderCaption = "Baby products for Zeerak";

            display = "<div class='col-lg-12'>";
            display += categoryHelper(sliderCaption, 9);

            categorySlider3.InnerHtml = display;
        }

        String categoryHelper(String caption, int CategoryID)
        {
            dynamic productsByCat = SC.getProductByCat(CategoryID);
            String display = "<div class='section-title'>";
            display += "<h2>" + caption + "</h2>";
            display += "</div></div>";
            display += "<div class='categories__slider owl-carousel'>";

            foreach (Product p in productsByCat)
            {
                display += "<div class='col-lg-3 catSliderHover'>";
                display += "<div class='featured__item'>";
                display += "<div class='featured__item__pic set-bg' data-setbg='/" + p.Image_Location + "'>"; //onclick='location.href=&#39;singleproduct.aspx?ProductID=" + p.ID + "&#39;'>";
                display += "<ul class='featured__item__pic__hover'>";
                display += "<li><i class='fa fa-heart'></i></li>";
                display += "<li><i class='fa fa-shopping-cart' id='cart' OnClick='AddToCart(" + p.ID + ")' runat='server'></i></li>";
                display += "</ul></div>";
                display += "<div class='featured__item__text'>";
                display += "<h6><a href='singleproduct.aspx?ProductID=" + p.ID+ "'>" + p.Name + "</a></h6>"; //product link
                display += "<h5>R" + p.Price + "</h5>";
                display += "</div></div></div>";
            }
            display += "</div>";
            return display;
        }

        //cookies
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

        //add to cart click
        protected void AddToCart(String ProductID)
        {
            createCookie("cart", ProductID);
            Debug.WriteLine(ProductID);
        }
    }
}