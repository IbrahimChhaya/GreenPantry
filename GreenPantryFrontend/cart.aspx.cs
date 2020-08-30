using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            Response.Cookies["cart"].Value = "1-2, 2-3";
            dynamic cookiecontent = Request.Cookies["cart"].Value;

            dynamic products = cookiecontent.Split(',');

            string display = "";
            List<decimal> totals = new List<decimal>(); 

            foreach (dynamic product in products)
            {
                //display = " ";
                string[] productDetails = product.Split('-');
                var pID = productDetails[0];
                pIds.Add(pID);

                var cartProduct = SR.getProductByID(int.Parse(pID));
                var qty = productDetails[1];
                qtys.Add(qty);

                display += "<tr><td class='shoping__cart__item'>";
                display += "<img src ="+ cartProduct.Image_Location +" alt=''>";
                display += "<h5>" + cartProduct.Name + "</h5></td><td class='shoping__cart__price'>" + Math.Round(cartProduct.Price, 2) + "</td>";
                display += "<td class='shoping__cart__quantity'>";
                display += "<div class='quantity'><div class='pro-qty'><input type = 'text' value=" + qty + ">";
                display += "</div></div></td>";
                display += "<td class='shoping__cart__total'>"+ Math.Round(cartProduct.Price * decimal.Parse(qty), 2) + "</td>";
                display += "<td class='shoping__cart__item__close'><span class='icon_close'></span></td></td>";
                tablerow.InnerHtml = display;

                totals.Add(Math.Round(cartProduct.Price * decimal.Parse(qty), 2));

            }

            display = " ";

            decimal subTotal = calcSubtotal(totals);
            decimal VAT = subTotal * (decimal)0.15;
            decimal carttotal = subTotal + VAT;

            display += "<h5>Cart Total</h5><ul><li>Subtotal<span>R"+ Math.Round(subTotal, 2) +"</span></li>";
            display += "<li>VAT at 15% <span>R"+ Math.Round(VAT, 2) + "</span></li><li>Total<span>R"+ Math.Round(carttotal, 2) +"</span></li>";
            display += "</ul><a href = 'checkout.aspx' class='primary-btn'>PROCEED TO CHECKOUT</a>";
            cartTotal.InnerHtml = display;
        }

        protected void decQty_Click(object sender, EventArgs e)
        {
           
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
