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
                    display += "<li><a href='/categories.aspx?CategoryID=" + c.ID + "&Page=1'>" + c.Name + "</a></li>";
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
            dynamic banner1S = SC.getSetting(2);
            String caption = banner1S.Field1;//"These discounts dough!";
            String tag = banner1S.Field2;//"25% off at the bakery this month";
            String categoryLink = banner1S.Field3;//"7";
            display = "<a href='/categories.aspx?CategoryID=" + categoryLink + "&Page=1'>";
            display += "<div class='hero__4item set-bg' data-setbg='" + banner1S.Field4 + "'>";//img/banner/banner-1.png"'>";
            display += "<div class='hero__textButBlack'>";
            display += "<span></span>";
            display += "<h2>" + caption + "</h2>";
            display += "<p>" + tag + "</p>";
            display += "</div></div></a>";

            banner1.InnerHtml = display;

            dynamic banner2S = SC.getSetting(3);

            caption = banner2S.Field1;//"Stock up on groceries";
            tag = banner2S.Field2;//"Get all your ingredients here";
            categoryLink = banner2S.Field3;//"1";
            display = "<a href='/categories.aspx?CategoryID=" + categoryLink + "&Page=1'>";
            display += "<div class='hero__4item set-bg' data-setbg='" + banner2S.Field4 + "'>";
            display += "<div class='hero__textButBlack secondary'>";
            display += "<span></span>";
            display += "<h2>" + caption + "</h2>";
            display += "<p>" + tag + "</p>";
            display += "</div></div></a>";

            banner2.InnerHtml = display;

            dynamic banner3S = SC.getSetting(4);

            caption = banner3S.Field1; //"Celebrate Spring time with natural juices";
            tag = banner3S.Field2; //"100% fruit juices in every flavour";
            categoryLink = banner3S.Field3;//"8";
            display = "<a href='/categories.aspx?CategoryID=" + categoryLink + "&Page=1'>";
            display += "<div class='hero__4item set-bg' data-setbg='" + banner3S.Field4 + "'>";
            display += "<div class='hero__textButBlack secondary'>";
            display += "<span></span>";
            display += "<h2>" + caption + "</h2>";
            display += "<p>" + tag + "</p>";
            display += "</div></div></a>";

            banner3.InnerHtml = display;

            dynamic banner4S = SC.getSetting(5);

            caption = banner4S.Field1;//"Fresh foods at fresh prices";
            tag = banner4S.Field2; //"Fill up your fridge with next-day delivery";
            categoryLink = banner4S.Field3;//"2";
            display = "<a href='/categories.aspx?CategoryID=" + categoryLink + "&Page=1'>";
            display += "<div class='hero__4item set-bg' data-setbg='" + banner4S.Field4 + "'>";
            display += "<div class='hero__textButBlack'>";
            display += "<span></span>";
            display += "<h2>" + caption + "</h2>";
            display += "<p>" + tag + "</p>";
            display += "</div></div></a>";

            banner4.InnerHtml = display;

            String sliderCaption;
            //product category slider 0000000000000000000--------------------------------------------

            int userID = 0;
            bool noAddress = false;
            if(Session["LoggedInUserID"] != null)
            {
                userID = int.Parse(Session["LoggedInUserID"].ToString());
                dynamic address = SC.getPrimaryAddress(userID);
                if (address == null)
                {
                    noAddress = true;
                }
            }
            
            if (Session["LoggedInUserID"] != null && noAddress == false)
            {
                dynamic bigBanner1 = SC.getSetting(6);

                userID = int.Parse(Session["LoggedInUserID"].ToString());
                
                sliderCaption = "Recommendations For You";

                display = "<div class='col-lg-12'>";
                display += "<div class='hero__item set-bg' data-setbg='" + bigBanner1.Field4 + "'>";
                display += "<div class='hero__text'>";
                display += "<span></span>";
                display += "<h2>" + bigBanner1.Field1 + "</h2>";
                display += "<p>" + bigBanner1.Field2 + "</p>";
                display += "<a href='results.aspx?Search=1&Page=1' class='primary-btn'>SHOP NOW</a>";
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
                sliderCaption = "Meals Made To Go";

                display = "<div class='col-lg-12'>";
                display += "<div class='hero__item set-bg' data-setbg='img/freeshipping.png'>";
                display += "<div class='hero__text'>";
                display += "<span></span>";
                display += "<h2>Free <br/>Shipping</h2>";
                display += "<p>On Orders Over R500</p>";
                display += "<a href='results.aspx?Search=1&Page=1' class='primary-btn'>SHOP NOW</a>";
                display += "</div></div></br>";
                display += categoryHelper(sliderCaption, 6);

                categorySlider.InnerHtml = display;
            }

            //product category slider 222222222222222222-----------------------------------------------

            sliderCaption = "Fresh From The Bakery";

            display = "<div class='col-lg-12'>";

            display += categoryHelper(sliderCaption, 7);

            categorySlider2.InnerHtml = display;

            //product category slider 333333333333333333-----------------------------------------------

            dynamic bigBanner2 = SC.getSetting(7);

            sliderCaption = "Quench Your Thirst";

            display = "<div class='col-lg-12'>";
            display += "<div class='hero__item set-bg' data-setbg='" + bigBanner2.Field4 + "'>";
            display += "<div class='hero__text'>";
            display += "<span></span>";
            display += "<h2>" + bigBanner2.Field1 + "</h2>";
            display += "<p>" + bigBanner2.Field2 + "</p>";
            display += "<a href='results.aspx?Search=1&Page=1' class='primary-btn'>SHOP NOW</a>";
            display += "</div></div></br>";
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
            Response.Redirect("/results.aspx?Search=" + searchText.Value + "&Page=1");
        }
    }
}