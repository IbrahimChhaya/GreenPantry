﻿using GreenPantryFrontend.ServiceReference1;
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
            if(Session["LoggedInUserID"] == null)
            {
                listIcon.Visible = false;
            }
            else
            {
                listIcon.Visible = true;
            }

            if (Request.QueryString["ProductID"] != null)
            {
                dynamic getProducts = SC.getProduct(int.Parse(Request.QueryString["ProductID"]));
                string Display = "";

                dynamic getSub = SC.getSubCat(getProducts.SubCategoryID);
                //breadcrumb
                title.InnerHtml = getProducts.Name;
                Display += "<a href='./home.aspx'>Home</a>";
                Display += "<a href='./subcategory.aspx?SubcategoryID=" + getProducts.SubCategoryID + "&Page=1'>" + getSub.Name + "</a>";
                Display += "<span>" + getProducts.Name + "</span>";
                productName.InnerHtml = Display;

                //PImage
                Display = "";
                Display += "<img class='product__details__pic__item--large'";
                Display += "src ='" + getProducts.Image_Location + "' alt=''>";
                PImage.InnerHtml = Display;

                //singleproduct.aspx?ProductID=" + getProducts.ID + "
                Display = "";

                //Product name
                pName.InnerHtml = getProducts.Name;
                //Product Price
                pPrice.InnerHtml = "R" + Math.Round(getProducts.Price, 2);


                Display = "";
                //description
                Display += "<h6>Products Infomation</h6>";
                Display += "<p>" + getProducts.Name + "</p>";
                Description.InnerHtml = Display;

                ////relatedproducts
                var productCategory = SC.getCategorybyProductID(int.Parse(Request.QueryString["ProductID"]));
                dynamic relatedProducts = SC.getProductByCat(productCategory.ID);
                Display = "";
                for (int i = 0; i < 4; i++)
                {
                    Display += "<div class='col-lg-3 col-md-4 col-sm-6'>";
                    Display += "<div class='product__item'>";
                    Display += "<div class='product__item__pic set-bg' data-setbg='" + relatedProducts[i].Image_Location + "'>";
                    Display += "<ul class='product__item__pic__hover'>";
                    if(Session["LoggedInUserID"] != null)
                    {
                        Display += "<li><a href='#'><i class='fa fa-list'></i></a></li>";
                    }
                    Display += "<li><a href='singleproduct.aspx?ProductID=" + relatedProducts[i].ID + "'><i class='fa fa-shopping-cart'></i></a></li>";
                    Display += "</ul></div>";
                    Display += "<div class='product__item__text'>";
                    Display += "<h6><a href='singleproduct.aspx?ProductID=" + relatedProducts[i].ID + "'>" + relatedProducts[i].Name + "</a></h6>";
                    Display += "<h5>R" + Math.Round(relatedProducts[i].Price, 2) + "</h5>";
                    Display += "</div></div></div>";
                    
                   
                    if (relatedProducts[i].StockOnHand.Equals(0))
                    {
                        stock.InnerHtml = "Out of Stock";
                        //Add.Enabled = false;
                        addToCart.Visible = false;
                        listIcon.Visible = false;
                    }
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
           // int worked = 0;
            if(Request.Cookies["cart"] != null)
            {
                //check if product is already in the cookie
                string foundInCookie = findProductInCookie(Request.QueryString["ProductID"]);
                string str = Request.Cookies["cart"].Value;

                if (foundInCookie.Equals(""))
                {
                    str += Request.QueryString["ProductID"] + "-" + item_qty.Value;
                    saveToCookie("cart", str);
                   // worked = 2;
                }
                else
                {
                    //change quantity in existing product-quantity pair
                    string newPQPair = addToCookieProQty(foundInCookie, int.Parse(item_qty.Value));

                    str = str.Replace(foundInCookie, newPQPair);
                    Response.Cookies["cart"].Value = str;
                    Response.Cookies["cart"].Expires = DateTime.Now.AddDays(30);
                   // worked = 3;
                }
            }
            else
            {
                createCookie("cart", Request.QueryString["ProductID"] + "-" + item_qty.Value);
               // worked = 1;
            }
            //addToCart.InnerText = "Added to cart";
            Response.Redirect(Request.RawUrl);
        }
        //protected int add_Click()
        //{
        //     int worked = 0;
        //    if (Request.Cookies["cart"] != null)
        //    {
        //        //check if product is already in the cookie
        //        string foundInCookie = findProductInCookie(Request.QueryString["ProductID"]);
        //        string str = Request.Cookies["cart"].Value;

        //        if (foundInCookie.Equals(""))
        //        {
        //            str += Request.QueryString["ProductID"] + "-" + item_qty.Value;
        //            saveToCookie("cart", str);
        //             worked = 2;
        //        }
        //        else
        //        {
        //            //change quantity in existing product-quantity pair
        //            string newPQPair = addToCookieProQty(foundInCookie, int.Parse(item_qty.Value));

        //            str = str.Replace(foundInCookie, newPQPair);
        //            Response.Cookies["cart"].Value = str;
        //            Response.Cookies["cart"].Expires = DateTime.Now.AddDays(30);
        //             worked = 3;
        //        }
        //    }
        //    else
        //    {
        //        createCookie("cart", Request.QueryString["ProductID"] + "-" + item_qty.Value);
        //         worked = 1;
        //    }

        //     return worked;
        //}
        //function to check a particular products is in the cookie
        private string findProductInCookie(string pId)
        {
            string found = "";
            dynamic cookieContent = Request.Cookies["cart"].Value;
            cookieContent = cookieContent.Split(',');

            foreach(var p in cookieContent)
            {
                if (!p.Equals("")){

                    if (p.Contains(pId + "-"))
                    {
                        found = p;
                    }
                }
            }

            return found;
        }

        //function to add to cookie quantity
        private string addToCookieProQty(string currentCookiePro, int qtyToAdd)
        {
            dynamic str = currentCookiePro.Split('-');
            var proId = str[0];
            var oldQty = str[1];

            int newQty = int.Parse(oldQty) + qtyToAdd;

            var newCookiePro = proId + "-" + newQty.ToString();
            return newCookiePro;
        }

        protected void listIcon_ServerClick(object sender, EventArgs e)
        {
            int addToList = SC.addToList(int.Parse(Session["LoggedInUserID"].ToString()), int.Parse(Request.QueryString["ProductID"]), int.Parse(item_qty.Value));
            //if (addToList.Equals(1))
            //{
            //    listIcon.InnerHtml = "<span class='icon_ul iconSize'></span> Added to Shopping List";
            //}
            //else if (addToList.Equals(0))
            //{
            //    listIcon.InnerHtml = "<span class='icon_ul iconSize'></span> Added to Shopping List";
            //}
            //else
            //{
            //    listIcon.InnerHtml = "<span class='icon_ul iconSize'></span> An error occured";
            //}
        }

        //protected int listIcon_ServerClick()
        //{
        //    int addToList = -1;
        //    if(Session["LoggedInUserID"] != null)
        //    {
        //        addToList = SC.addToList(int.Parse(Session["LoggedInUserID"].ToString()), int.Parse(Request.QueryString["ProductID"]), int.Parse(item_qty.Value));
        //    }
        //    return addToList;
        //}
    }
}