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
                if (c.Status.Equals("active"))
                {
                    display += "<li><a href='/categories.aspx?CategoryID=" + c.ID + "'>" + c.Name + "</a></li>";
                }
            }

            categoryList.InnerHtml = display;

            //my account / login register --------------------------------------------------

            display = "";
            if (Session["LoggedInUserID"] != null)
            {
                var user = SC.getUser(Convert.ToInt32(Session["LoggedInUserID"]));
                if (user.UserType.Equals("admin"))
                {
                    account.InnerHtml = "<a href='/dashboard/dashboard.aspx'>Dashboard</a>";
                }
                else
                {
                    display += "<a href='account.aspx'>My Account</a>";
                    account.InnerHtml = display;
                }
            }

            //search box categories drop down --------------------------------------------------------------------

            //foreach (ProductCategory c in allCategories)
            //{

            //    display += "<a href='/categories.aspx?CategoryID='" + c.ID + ">" + c.Name + "</a></li>";
            //}

            //categoryList.InnerHtml = display;

            //the 4 banners ---------------------------------------------------------------------
            String caption = "These discounts dough!";
            String tag = "25% off at the bakery this month";
            String categoryLink = "7";
            display = "<a href='/categories.aspx?CategoryID=" + categoryLink + "'>";
            display += "<div class='hero__4item set-bg' data-setbg='img/banner/banner-1.png'>";
            display += "<div class='hero__textButBlack'>";
            display += "<span></span>";
            display += "<h2>" + caption + "</h2>";
            display += "<p>" + tag + "</p>";
            display += "</div></div></a>";

            banner1.InnerHtml = display;

            caption = "Stock up on groceries";
            tag = "Get all your ingredients here";
            categoryLink = "1";
            display = "<a href='/categories.aspx?CategoryID=" + categoryLink + "'>";
            display += "<div class='hero__4item set-bg' data-setbg='img/banner/banner-2.png'>";
            display += "<div class='hero__textButBlack secondary'>";
            display += "<span></span>";
            display += "<h2>" + caption + "</h2>";
            display += "<p>" + tag + "</p>";
            display += "</div></div></a>";

            banner2.InnerHtml = display;

            caption = "Celebrate Spring time with natural juices";
            tag = "100% fruit juices in every flavour";
            categoryLink = "8";
            display = "<a href='/categories.aspx?CategoryID=" + categoryLink + "'>";
            display += "<div class='hero__4item set-bg' data-setbg='img/banner/banner-3.png'>";
            display += "<div class='hero__textButBlack secondary'>";
            display += "<span></span>";
            display += "<h2>" + caption + "</h2>";
            display += "<p>" + tag + "</p>";
            display += "</div></div></a>";

            banner3.InnerHtml = display;

            caption = "Fresh foods at fresh prices";
            tag = "Fill up your fridge with next-day delivery";
            categoryLink = "2";
            display = "<a href='/categories.aspx?CategoryID=" + categoryLink + "'>";
            display += "<div class='hero__4item set-bg' data-setbg='img/banner/banner-4.png'>";
            display += "<div class='hero__textButBlack'>";
            display += "<span></span>";
            display += "<h2>" + caption + "</h2>";
            display += "<p>" + tag + "</p>";
            display += "</div></div></a>";

            banner4.InnerHtml = display;

            String sliderCaption;
            //product category slider 0000000000000000000--------------------------------------------

            if(Session["LoggedInUserID"] != null)
            {
                int userID = int.Parse(Session["LoggedInUserID"].ToString());
                sliderCaption = "Recommendations For You";

                display = "<div class='col-lg-12'>";
                display += "<div class='hero__item set-bg' data-setbg='img/freeshipping.png'>";
                display += "<div class='hero__text'>";
                display += "<span></span>";
                display += "<h2>Free <br/>Shipping</h2>";
                display += "<p>On Orders Over R500</p>";
                display += "<a href='results.aspx?Search=1' class='primary-btn'>SHOP NOW</a>";
                display += "</div></div></br>";

                dynamic list = SC.recommendTest(userID);
                display += "<div class='section-title'>";
                display += "<h2>" + sliderCaption + "</h2>";
                display += "</div></div>";
                display += "<div class='categories__slider owl-carousel'>";

                foreach (recommended r in list)
                {
                    display += "<div class='col-lg-3 catSliderHover'>";
                    display += "<div class='featured__item'>";
                    display += "<div class='featured__item__pic set-bg' data-setbg='&#39;/" + r.product.Image_Location + "&#39;' onclick='location.href=&#39;singleproduct.aspx?ProductID=" + r.product.ID + "&#39;'>";
                    display += "<ul class='featured__item__pic__hover'>";
                    display += "<li><a><i class='fa fa-list'></i></a></li>";
                    display += "<li><a><i class='fa fa-shopping-cart'></i></a></li>";
                    display += "</ul></div>";
                    display += "<div class='featured__item__text'>";
                    display += "<h6>" + r.product.Name + "</h6>"; //product link
                    display += "<h5>R" + Math.Round(r.product.Price, 2) + "</h5>";
                    display += "</div></div></div>";
                    
                }
                display += "</div>";

                categorySlider.InnerHtml = display;


                sectionToHide.Visible = true;
                sliderCaption = "Straight From The Fruit Tree";
                display = "<div class='col-lg-12'>";
                display += categoryHelper(sliderCaption, 2);
                categorySlider1.InnerHtml = display;
            }
            else
            {
                sliderCaption = "Straight From The Fruit Tree";

                display = "<div class='col-lg-12'>";
                display += "<div class='hero__item set-bg' data-setbg='img/freeshipping.png'>";
                display += "<div class='hero__text'>";
                display += "<span></span>";
                display += "<h2>Free <br/>Shipping</h2>";
                display += "<p>On Orders Over R500</p>";
                display += "<a href='results.aspx?Search=1' class='primary-btn'>SHOP NOW</a>";
                display += "</div></div></br>";
                display += categoryHelper(sliderCaption, 2);

                categorySlider.InnerHtml = display;
            }

            //product category slider 222222222222222222-----------------------------------------------

            sliderCaption = "Fresh From The Bakery";

            display = "<div class='col-lg-12'>";
            display += categoryHelper(sliderCaption, 7);

            categorySlider2.InnerHtml = display;

            //product category slider 333333333333333333-----------------------------------------------

            sliderCaption = "Quench Your Thirst";

            display = "<div class='col-lg-12'>";
            display += categoryHelper(sliderCaption, 8);

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
                if (p.Status.Equals("active"))
                {
                    display += "<div class='col-lg-3 catSliderHover'>";
                    display += "<div class='featured__item'>";
                    display += "<div class='featured__item__pic set-bg' data-setbg='/" + p.Image_Location + "' onclick='location.href=&#39;singleproduct.aspx?ProductID=" + p.ID + "&#39;'>";
                    display += "<ul class='featured__item__pic__hover'>";
                    if(Session["LoggedInUserID"] != null)
                    { 
                        display += "<li><a><i class='fa fa-list'></i></a></li>";
                    }
                    display += "<li><a><i class='fa fa-shopping-cart'></i></a></li>";
                    display += "</ul></div>";
                    display += "<div class='featured__item__text'>";
                    display += "<h6>" + p.Name + "</h6>"; //product link
                    display += "<h5>R" + Math.Round(p.Price, 2) + "</h5>";
                    display += "</div></div></div>";
                }
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/results.aspx?Search=" + searchText.Value);
        }
    }
}