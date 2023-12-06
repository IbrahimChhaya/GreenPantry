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
    public partial class cart : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();

        List<string> pIds = new List<string>();
        List<string> qtys = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["cart"] == null || Request.Cookies["cart"].Value == "")
            {
                emptyCart.Visible = true;
                crumbSection.Visible = false;
                cartSection.Visible = false;

                //delete cookie
                Response.Cookies["cart"].Expires = DateTime.Now.AddDays(-1);
            }
            else
            {
                emptyCart.Visible = false;
                crumbSection.Visible = true;
                cartSection.Visible = true;

                dynamic cookiecontent = Request.Cookies["cart"].Value;

                dynamic products = cookiecontent.Split(',');
                              
                string display = "";
                List<decimal> totals = new List<decimal>();

                foreach (dynamic product in products)
                {
                    if(!product.Equals(""))
                    {
                        //display = " ";
                        string[] productDetails = product.Split('-');
                        var pID = productDetails[0];
                        pIds.Add(pID);

                        var cartProduct = SR.getProduct(int.Parse(pID));
                        var qty = productDetails[1];
                        qtys.Add(qty);

                        display += "<tr><td class='shoping__cart__item'>";
                        display += "<img src =" + cartProduct.Image_Location + " alt=''>";
                        display += "<h5><input class='cart__item-id' ID='pID' runat='server' value='" + cartProduct.ID + "' hidden/>" + cartProduct.Name + "</h5></td><td class='shoping__cart__price'>" + Math.Round(cartProduct.Price, 2) + "</td>";
                        display += "<td class='shoping__cart__quantity' data-pID='" + cartProduct.ID + "' data-stock='" + cartProduct.StockOnHand + "'>";
                        display += "<div class='quantity'><div class='pro-qty'><input type = 'text' value=" + qty + " runat='server' id='item_qty' readonly>";
                        display += "</div></div></td>";
                        display += "<td class='shoping__cart__total' id='pTotal'>" + Math.Round(cartProduct.Price * decimal.Parse(qty), 2) + "</td>";
                        display += "<td class='shoping__cart__item__close'><span class='icon_close'></span></td></td>";
                        tablerow.InnerHtml = display;

                        totals.Add(Math.Round(cartProduct.Price * decimal.Parse(qty), 2));
                    } 
                }

                display = " ";
                decimal Delivery = 0.00M;
                decimal subTotal = calcSubtotal(totals);

                dynamic setting = SR.getSetting(1);
                int shippingCost = int.Parse(setting.Field2);
                //check if delivery charge applies
                if (subTotal < shippingCost)
                    Delivery = 60.00M;
                decimal VAT = subTotal * (decimal)(0.15/1.15);
                decimal carttotal = subTotal + Delivery;

                display += "<h5>Cart Total</h5><ul><li>Subtotal<span id='checkout__cart-subtotal'>R" + Math.Round(subTotal, 2) + "</span></li>";
                display += "<li>VAT at 15% <span id='checkout__cart-VAT'>R" + Math.Round(VAT, 2) + "</span></li><li>Delivery Fee <span id='checkout__cart-delivery'>R" + Math.Round(Delivery, 2) + "</span></li>";
                display += "<li>Total<span id='checkout__cart-total'>R" + Math.Round(carttotal, 2) + "</span></li>";
                display += "</ul><a href = 'checkout.aspx' class='primary-btn' id='checkout-btn'>PROCEED TO CHECKOUT</a>";
                cartTotal.InnerHtml = display;
            }
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

        //function to add to cookie quantity
        private string editToCookieProQty(string currentCookiePro, int qtyToAdd)
        {
            dynamic str = currentCookiePro.Split('-');
            var proId = str[0];

            var newCookiePro = proId + "-" + qtyToAdd.ToString();
            return newCookiePro;
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
    }
}
