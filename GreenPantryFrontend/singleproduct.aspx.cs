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

            //int.Parse(Request.QueryString["ProductID"])
            if (Request.QueryString["ProductID"] != null)
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

                ///singleproduct.aspx?ProductID=" + getProducts.ID + "
                Display = "";

                //Product name
                pName.InnerHtml = getProducts.Name;
                //Product Price
                pPrice.InnerHtml = "R" + Math.Round(getProducts.Price, 2);


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
                    Display += "<h5>R" + Math.Round(p.Price, 2) + "</h5>";
                    Display += "</div></div></div>";
                }
                RelatedProducts.InnerHtml = Display;
            }
            else
            {
                Response.Redirect("home.aspx");
            }
        }

        private void saveToCookie(String CookieName, String content)
        {
            //content: productID-quantity,productID-quantity
            Response.Cookies[CookieName].Value += content + ",";
        }
        private void createCookie(String CookieName, String content)
        {
            Response.Cookies[CookieName].Value = content + ",";
            Response.Cookies[CookieName].Expires = DateTime.Now.AddDays(30);
        }

        private String readCookie(String CookieName)
        {
            return Request.Cookies[CookieName].ToString();
        }



        protected void add_Click(object sender, EventArgs e)
        {
            if(Request.Cookies["cart"] != null)
            {
                string str = Request.Cookies["cart"].Value;

                str += Request.QueryString["ProductID"] + "-" + quantity.Value;
                saveToCookie("cart", str);
               
            }
            else
            {
                createCookie("cart", Request.QueryString["ProductID"] + "-" + quantity.Value);
               // Add.Text = "it worked";
                Response.Redirect("/singleproduct.aspx?ProductID=39");
               // System.Diagnostics.Debug.WriteLine(Request.QueryString["ProductID"] + "-" + quantity.Value);

            }
            
        }

    }
}