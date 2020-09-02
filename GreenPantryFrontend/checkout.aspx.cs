
using GreenPantryFrontend.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class checkout : System.Web.UI.Page
    {
        List<string> pIds = new List<string>();
        List<string> qtys = new List<string>();
        GP_ServiceClient SR = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            bool freeShipping = false;
            Response.Cookies["cart"].Value = "1-1, 2-3";
            dynamic CookieContent = Request.Cookies["cart"].Value;

            dynamic products = CookieContent.Split(',');

            string display = "";
            List<decimal> totals = new List<decimal>();
            decimal subtotal = 0;
            decimal total = 0;
            

            foreach (dynamic p in products)
            {
                
                string[] productDetails = p.Split('-');
                var pID = productDetails[0];
                pIds.Add(pID);

                var cartProduct = SR.getProductByID(int.Parse(pID));
                var qty = productDetails[1];
                qtys.Add(qty);
               

                subtotal += cartProduct.Price;

                display += "<li>"+cartProduct.Name +"<span>R"+Math.Round(cartProduct.Price,2)+"</span></li>";

                total += SR.calcProductVAT(cartProduct.ID) +subtotal;


            }
            Checkout.InnerHtml = display;
            display = "<div class='checkout__order__subtotal' id='ProductSubtotal' runat='server'>Subtotal<span>R" +Math.Round(subtotal,2) + "</span></div>";
            ProductSubtotal.InnerHtml = display;
            display = "<div class='checkout__order__total' id='P_Total' runat='server'>Total<span>R"+Math.Round(total,2)+"</span>";
            P_Total.InnerHtml = display;

            if(total > 500)
            {
                freeShipping = true;
            }

    }

        protected void Submit_Click(object sender, EventArgs e)
        {

           int addressUpdate = SR.AddAdress(Line1.Value, Line2.Value, suburb.Value , town.Value, 'F' ,postcode.Value,1, Province.Value);
           //int addInvoice = SR.addInvoice("Approved", DateTime.Today, DateTime.Today,order.Value, 1);
           

            if(addressUpdate == 1)
            {
                Response.Redirect("home.aspx");
            }
            else if(addressUpdate == -1)
            {
                error.Text = "Something went wrong";
            }
            else if(addressUpdate ==0)
            {
                //Allow user to update his address
                error.Text ="Address already exists";
            }
        }

    }
}