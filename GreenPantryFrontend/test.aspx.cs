using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class test : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            string display = "";
            int userID = int.Parse(Session["LoggedInUserID"].ToString());
            //dynamic products = SC.recommendedProducts(userID);
            dynamic list = SC.recommendTest(userID);

            foreach (recommended r in list)
            {
                display += "<div class='col-lg-4 col-md-6 col-sm-6'>";
                display += "<div class='product__item'>";
                display += "<div class='product__item__pic set-bg' data-setbg='" + r.product.Image_Location + "'>";
                display += "<ul class='product__item__pic__hover'>";
                display += "<li><a href='#'><i class='fa fa-list'></i></a></li>";
                display += "<li><a href='#'><i class='fa fa-shopping-cart'></i></a></li>";
                display += "</ul></div><div class='product__item__text'>";
                display += "<h6><a href='#'>" + r.product.Name +"</a></h6>";
                display += "<h5>R" + Math.Round(r.product.Price, 2) + "</h5></div></div></div>";
            }
            recommendedProducts.InnerHtml = display;
        }
    }
}