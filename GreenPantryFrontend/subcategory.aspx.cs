using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class subcategory : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();

        public string jsonProducts;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["SubcategoryID"] == null)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                String display = "";

                String subID = Request.QueryString["SubcategoryID"];

            dynamic subcat = SC.getSubCat(int.Parse(subID));

            //breadcrumb-------------------------------------------------------------
            if (subcat.Status.Equals("active"))
            {
                display += "<h2>" + subcat.Name + "</h2>";
                display += "<div class='breadcrumb__option'>";
                display += "<a href='./home.aspx'>Home</a>";
                display += "<span>" + subcat.Name + "</span></div>";

                breadcrumb.InnerHtml = display;

                //filterd by sidebar-------------------------------------------------------------

                display = "";
                display += "<li>" + subcat.Name + "</li>";

                filtered.InnerHtml = display;
            }

                //products-------------------------------------------------------------

            display = "";
            dynamic products = SC.getProductBySubCat(int.Parse(subID));
            foreach (Product p in products)
            {
                if (p.Status.Equals("active"))
                {
                    display += "<div class='col-lg-4 col-md-6 col-sm-6'>";
                    display += "<div class='product__item' onclick='location.href=&#39;singleproduct.aspx?ProductID=" + p.ID + "&#39;'>";
                    display += "<div class='product__item__pic set-bg' data-setbg='" + p.Image_Location + "'>";
                    display += "<ul class='product__item__pic__hover'>";
                    display += "<li><a href='#'><i class='fa fa-heart'></i></a></li>";
                    display += "<li><a href='#'><i class='fa fa-shopping-cart'></i></a></li></ul></div>";
                    display += "<div class='product__item__text'>";
                    display += "<h6>" + p.Name + "</h6>";
                    display += "<h5>R" + Math.Round(p.Price, 2) + "</h5></div></div></div>";
                }
            }
            subProducts.InnerHtml = display;
        }
    }
}