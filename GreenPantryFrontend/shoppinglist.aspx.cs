using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                        dynamic product = SR.getProduct(s.ProductID);
                        if (product.Status.Equals("active"))
                        {
                            display += "<tr><td class='shoping__cart__item'>";
                            display += "<img src =" + product.Image_Location + " alt=''>";
                            display += "<h5>" + product.Name + "</h5></td><td class='shoping__cart__price'>" + Math.Round(product.Price, 2) + "</td>";
                            display += "<td class='shoping__cart__quantity'>";
                            display += "<div class='quantity'><div class='pro-qty'><input type='text' value=" + s.Quantity + " runat='server' id='item_qty'>";
                            display += "</div></div></td>";
                            display += "<td class='shoping__cart__total' id='pTotal'>" + Math.Round((product.Price * s.Quantity), 2) + "</td>";
                            display += "<td class='shoping__cart__item__close'><span class='icon_close'></span></td></tr>";
                            tablerow.InnerHtml = display;
                            totals.Add(Math.Round((product.Price * s.Quantity), 2));
                        }     
                    }

                    display = "";
                    decimal subTotal = calcSubtotal(totals);

                    //check if delivery charge applies
                    decimal carttotal = subTotal;

                    display += "<h5>List Total</h5>";
                    display += "<ul><li>Total<span id='checkout__cart-total'>R" + Math.Round(carttotal, 2) + "</span></li>";
                    display += "</ul><a href='checkout2.aspx' class='primary-btn'>PROCEED TO CHECKOUT</a>";
                    cartTotal.InnerHtml = display;
                }
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
    }
}