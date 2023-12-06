﻿using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class shoppinglist : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUserID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (!IsPostBack) { 
                    int userID = int.Parse(Session["LoggedInUserID"].ToString());

                    dynamic list = SR.getList(userID);
                    if (list == null)
                    {
                        emptyCart.Visible = true;
                        crumbSection.Visible = false;
                        cartSection.Visible = false;
                    }
                    else
                    {
                        emptyCart.Visible = false;
                        crumbSection.Visible = true;
                        cartSection.Visible = true;

                        string display = "";
                        List<decimal> totals = new List<decimal>();

                        foreach (ShoppingList s in list)
                        {
                            //add to cookie
                            if (Request.Cookies["list"] != null)
                            {
                                string str = s.ProductID + "-" + s.Quantity;
                                saveToCookie("list", str);
                            }
                            else
                            {
                                createCookie("list", s.ProductID + "-" + s.Quantity + ",");
                            }

                            dynamic product = SR.getProduct(s.ProductID);

                            display += "<tr class='shopping-list__row'><td class='shoping__cart__item'>";
                            display += "<img src =" + product.Image_Location + " alt=''>";
                            display += "<h5><input class='cart__item-id' ID='pID' runat='server' value='" + product.ID + "' hidden/>"  + product.Name + " </h5></td><td class='shoping__cart__price'>" + Math.Round(product.Price, 2) + "</td>";
                            display += "<td class='shoping__cart__quantity' data-stock='" + product.StockOnHand + "'>";
                            display += "<div class='quantity'><div class='pro-qty'><input data-product-id='" + product.ID + "' type='text' value=" + s.Quantity + " runat='server' id='item_qty' readonly>";
                            display += "</div></div></td>";
                            display += "<td class='shoping__cart__total' id='pTotal'>" + Math.Round((product.Price * s.Quantity), 2) + "</td>";
                            display += "<td class='shoping__cart__item__close'><span class='icon_close'></span></td></tr>";
                            tablerow.InnerHtml = display;

                            totals.Add(Math.Round((product.Price * s.Quantity), 2));
                        }

                        display = "";
                        decimal subTotal = calcSubtotal(totals);

                        //check if delivery charge applies
                        decimal carttotal = subTotal;

                        //display += "<h5>List Total</h5>";
                        //display += "<ul><li>Total<span id='checkout__cart-total'>R" + Math.Round(carttotal, 2) + "</span></li>";
                        //display += "</ul><a href='checkout2.aspx' class='primary-btn'>PROCEED TO CHECKOUT</a>";
                        //cartTotal.InnerHtml = display;

                        listTotal.InnerHtml = "Total<span id='checkout__cart-total'>R" + Math.Round(carttotal, 2) + "</span>";
                    }
                }
            }
        }

        private void saveToCookie(String CookieName, String content)
        {
            //content: productID-quantity,productID-quantity
            Response.Cookies[CookieName].Value += content + ",";
        }
        private void createCookie(String CookieName, String content)
        {
            Response.Cookies[CookieName].Value = content;
            Response.Cookies["cart"].Expires = DateTime.Now.AddDays(30);
        }

        protected void update_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["LoggedInUserID"]);
            //clear the user's list
            int removed = SR.removeList(userId);

            if(removed == 1)
            {
                //get cookie value
                dynamic cookieContent = Request.Cookies["list"].Value;

                dynamic items = cookieContent.Split(',');
                int added = 0;
                foreach (dynamic i in items)
                {
                    if (!i.Equals(""))
                    {
                        dynamic itemDetails = i.Split('-');

                        var itemID = Convert.ToInt32(itemDetails[0]);
                        var itemQty = Convert.ToInt32(itemDetails[1]);

                        added = SR.addToList(userId, itemID, itemQty);

                    }
                }

                Response.Cookies["list"].Expires = DateTime.Now.AddDays(-1);  //delete cookie
                Response.Redirect("/shoppinglist.aspx");
            }

        }

        protected void move_Click(object sender, EventArgs e)
        {
            dynamic listItems = SR.getList(Convert.ToInt32(Session["LoggedInUserID"]));
            string str = "";
            if (Request.Cookies["cart"] != null)
            {
                str = Request.Cookies["cart"].Value;
            }


            foreach(ShoppingList s in listItems)
            {
                if(Request.Cookies["cart"] != null)
                {
                    //check if product is already in the cookie
                    string foundInCookie = findProductInCookie(s.ProductID.ToString());
                    

                    if (foundInCookie.Equals(""))
                    {
                        int qtyAllowed = getFinalQty(s.ProductID.ToString(), s.Quantity);

                        
                        str += s.ProductID.ToString() + "-" + qtyAllowed.ToString() + ",";
                        Response.Cookies["cart"].Expires = DateTime.Now.AddDays(-1);
                        createCookie("cart", str);
                    }
                    else
                    {
                        //change quantity in existing product-quantity pair
                        string newPQPair = addToCookieProQty(foundInCookie, s.Quantity);

                        //check that  amount trying to add is less than amount on hand
                        dynamic pairValues = newPQPair.Split('-');
                        int qtyRequested = int.Parse(pairValues[1]);
                        string pId = pairValues[0];

                        int qtyAllowed = getFinalQty(pId, qtyRequested);
                        string finalPQPair = pId + "-" + qtyAllowed;

                        str = str.Replace(foundInCookie, finalPQPair);
                        Response.Cookies["cart"].Expires = DateTime.Now.AddDays(-1);
                        createCookie("cart", str);

                    }
                }
                else
                {
                    int qtyAllowed = getFinalQty(s.ProductID.ToString(), s.Quantity);
                    str = s.ProductID + "-" + qtyAllowed + ",";
                    createCookie("cart", str);
                }
            }

            Response.Redirect("cart.aspx");
        }

        //function to check a particular products is in the cookie
        private string findProductInCookie(string pId)
        {
            string found = "";
            dynamic cookieContent = Request.Cookies["cart"].Value;
            cookieContent = cookieContent.Split(',');

            foreach (var p in cookieContent)
            {
                if (!p.Equals(""))
                {

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

        private int getFinalQty(string pId, int qty)
        {
            int finalQty = 0;
            var product = SR.getProduct(int.Parse(pId));

            if(qty > product.StockOnHand)
            {
                finalQty = product.StockOnHand;
            }
            else
            {
                finalQty = qty;
            }

            return finalQty;
        }

        private decimal calcSubtotal(List<decimal> totals)
        {
            decimal subTotal = 0;
            foreach (decimal t in totals)
            {
                subTotal += t;
            }

            return subTotal;
        }
    }
}