
using GreenPantryFrontend.ServiceReference1;
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
        decimal subtotal = 0;
        decimal total = 0;
        GP_ServiceClient SR = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the session does not exist then redirect to home
            //if (Session["LoggedInUserID"] != null)
            {
                bool freeShipping = false;
                Response.Cookies["cart"].Value = "1-1,2-3";
                dynamic CookieContent = Request.Cookies["cart"].Value;

                dynamic products = CookieContent.Split(',');

                string display = "";
                List<decimal> totals = new List<decimal>();
                //decimal subtotal = 0;
                //decimal total = 0;


                foreach (dynamic p in products)
                {

                    string[] productDetails = p.Split('-');
                    var pID = productDetails[0];
                    pIds.Add(pID);

                    var cartProduct = SR.getProductByID(int.Parse(pID));
                    var qty = productDetails[1];
                    qtys.Add(qty);


                    subtotal += cartProduct.Price;

                    display += "<li>" + cartProduct.Name + "<span>R" + Math.Round(cartProduct.Price, 2) + "</span></li>";

                    total += SR.calcProductVAT(cartProduct.ID) + subtotal;


                }
                Checkout.InnerHtml = display;
                display = "<div class='checkout__order__subtotal' id='ProductSubtotal' runat='server'>Subtotal<span>R" + Math.Round(subtotal, 2) + "</span></div>";
                ProductSubtotal.InnerHtml = display;
                display = "<div class='checkout__order__total' id='P_Total' runat='server'>Total<span>R" + Math.Round(total, 2) + "</span>";
                P_Total.InnerHtml = display;

                if (total > 500)
                {
                    freeShipping = true;
                }
             }//else
            //{
            //    Response.Redirect("Home.aspx");
            //}

    }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Response.Cookies["cart"].Value = "1-1, 2-3";
            dynamic CookieContent = Request.Cookies["cart"].Value;           

            int userID=0;
            userID = Convert.ToInt32(Session["LoggedInUserID"]);
            int addressUpdate = SR.AddAdress(Line1.Value, Line2.Value, suburb.Value , town.Value, 'F' ,postcode.Value,1, Province.Value);


            dynamic products = CookieContent.Split(',');
         
            if (addressUpdate == 1)
            {
               
                int addInvoice = SR.addInvoices(1,"Approved",DateTime.Now,DateTime.Now, order.Value,subtotal,50); //@50 need to pass the points received from the textbox
                if(addInvoice>0)
                 {
                    
                    foreach (dynamic p in products)
                    {
                        string[] productDetails = p.Split('-');
                        var pID = productDetails[0];
                        pIds.Add(pID);

                        var cartProduct = SR.getProductByID(int.Parse(pID));
                        var qty = productDetails[1];
                        qtys.Add(qty);

                        int addinvLine = SR.addInvoiceLine(cartProduct.ID, addInvoice, Convert.ToInt32(qty),cartProduct.Price);
                    }
                    Response.Redirect("orders.aspx");

                 }
                 else
                {
                 error.Text = "Invoice failed";
                }

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