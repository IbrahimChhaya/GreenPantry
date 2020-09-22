using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class results : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            String display = "";

            //String search = Request.QueryString["Search"];
            String search = "bread";
            var inputSearch = this.Master.FindControl("searchText") as HtmlInputText;
            inputSearch.Value = search;

            //breadcrumb
            display += "<h2>" + search + "</h2>";
            display += "<div class='breadcrumb__option'>";
            display += "<a href='./home.aspx'>Home</a>";
            display += "<span>Search Results</span></div>";
            breadcrumb.InnerHtml = display;

            //display the products from search result ------
            display = "";
            dynamic results = SC.searchProducts(search);
            foreach (Product p in results)
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


                //get subcategories of search result --------
                String display2 = "";
                List<SubCategory> subcats = new List<SubCategory>();
                dynamic subcat = SC.getSubCat(p.SubCategoryID);
                if (!subcats.Contains(subcat))
                    subcats.Add(subcat);

                foreach (SubCategory sc in subcats)
                {
                    display2 += "<li><a href='/subcategory.aspx?SubcategoryID=" + sc.SubID + "'>" + sc.Name + "</a></li>";
                }
                subcatList.InnerHtml = display2;
            }
            categoryProducts.InnerHtml = display;
        }
    }
}