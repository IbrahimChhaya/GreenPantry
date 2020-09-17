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
        GP_ServiceClient SR = new GP_ServiceClient();

        decimal total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the session does not exist then redirect to home
            if (Session["LoggedInUserID"] != null)
            {
                bool freeShipping = false;
               // Response.Cookies["cart"].Value = "1-1, 2-3";
                dynamic CookieContent = Request.Cookies["cart"].Value;

                dynamic products = CookieContent.Split(',');

                string display = "";
                List<decimal> totals = new List<decimal>();
                decimal subtotal = 0;
                


                foreach (dynamic p in products)
                {
                    if (!p.Equals(""))
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
            }else
            {
                Response.Redirect("Home.aspx");
            }

    }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Response.Cookies["cart"].Value = "1-1, 2-3";
            dynamic CookieContent = Request.Cookies["cart"].Value;           

            int userID=0;
            userID = Convert.ToInt32(Session["LoggedInUserID"]);
            int addressUpdate = SR.AddAdress(Line1.Value, Line2.Value, suburb.Value , town.Value, 'F' ,postcode.Value,userID, Province.Value);


            dynamic products = CookieContent.Split(',');
         
            if (addressUpdate == 1)
            {
               
                int addInvoice = SR.addInvoices(userID,"Approved",DateTime.Now,DateTime.Now, order.Value);
                if(addInvoice>0)
                 {
                    
                    foreach (dynamic p in products)
                    {
                        if (!p.Equals(""))
                        {
                            string[] productDetails = p.Split('-');
                            var pID = productDetails[0];
                            pIds.Add(pID);

                            var cartProduct = SR.getProductByID(int.Parse(pID));
                            var qty = productDetails[1];
                            qtys.Add(qty);

                            int addinvLine = SR.addInvoiceLine(cartProduct.ID, addInvoice, Convert.ToInt32(qty));
                        }
                    }
                    Response.Redirect("orders.aspx?Total=" + total);

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