using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void temp()
        {
            String display = "";
            int categoryID = 0;

            //category menu --------------------------------------------------------------------

            //dynamic allCategories = SC.getAllCat();
            //foreach (Categories c in allCategories)
            {
                //display += "<li><a href='#'" + c.Name + ".aspx'>" + c.Name + "</a></li>";

            }

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
            display += categoryHelper(sliderCaption, categoryID);

            categorySlider1.InnerHtml = display;

            //product category slider 222222222222222222-----------------------------------------------

            sliderCaption = "Fresh From The Bakery";

            display = "<div class='col-lg-12'>";
            display += categoryHelper(sliderCaption, categoryID);

            categorySlider2.InnerHtml = display;

            //product category slider 333333333333333333-----------------------------------------------

            sliderCaption = "Baby products for Zeerak";  

            display = "<div class='col-lg-12'>";
            display += categoryHelper(sliderCaption, categoryID);

            categorySlider3.InnerHtml = display;
        }

        String categoryHelper(String caption, int CategoryID)
        {
            //dynamic productsByCat = SC.getProductsByCat(CategoryID);
            String display = "<div class='section-title'>";
            display += "<h2>" + caption + "</h2>";
            display += "</div></div>";
            display += "<div class='categories__slider owl-carousel'>";

            //foreach (Products p in productsByCat)
            {
                display += "<div class='col-lg-3'>";
                display += "<div class='featured__item'>";
                //display += "<div class='featured__item__pic set-bg' data-setbg='img/" + p.imgLocation + "'>";
                display += "<ul class='featured__item__pic__hover'>";
                display += "<li><a href = '#'><i class='fa fa-heart'></i></a></li>";
                display += "<li><a href = '#'><i class='fa fa-shopping-cart'></i></a></li>";
                display += "</ul></div>";
                display += "<div class='featured__item__text'>";
                //display += "<h6><a href = '#'>" + p.name + "</a></h6>"; //product link
                //display += "<h5> R" + p.cost + "</h5>";
                display += "</div></div></div>";
            }
            display += "</div>";
            return display;
        }
    }
}