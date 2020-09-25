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
                // Response.Cookies["cart"].Value = "1-1,2-3";
                dynamic CookieContent = Request.Cookies["cart"].Value;
                int userID = Convert.ToInt32(Session["LoggedInUserID"]);

                dynamic products = CookieContent.Split(',');

                string display = "";
                List<decimal> totals = new List<decimal>();
                //decimal subtotal = 0;
                //decimal total = 0;

                //getting the userpoints
                //int points = SR.getpointbyUserID(userID);
                foreach (dynamic p in products)
                {
                    if (!p.Equals(""))
                    {

                        string[] productDetails = p.Split('-');
                        var pID = productDetails[0];
                        pIds.Add(pID);

                        var cartProduct = SR.getProduct(int.Parse(pID));
                        var qty = productDetails[1];
                        qtys.Add(qty);


                        subtotal += cartProduct.Price;

                        display += "<li>" + cartProduct.Name + "<span>R" + Math.Round(cartProduct.Price, 2) + "</span></li>";

                        total += SR.calcProductVAT(cartProduct.ID) + subtotal;
                    }

                }
                int points = 0;
                total = total - Convert.ToDecimal(points * 0.05);

                Checkout.InnerHtml = display;
                /* display = "<div class='checkout__order__subtotal' id='ProductSubtotal' runat='server'>Subtotal<span>R" + Math.Round(subtotal, 2) + "</span></div>";
                 ProductSubtotal.InnerHtml = display;
                 if(total >500)
                 {
                 display = "<div class='checkout__order__shipping' id='deliveryCharge' runat='server'>Deliver charge<span>R " + 0.00 + "</span></div>";
                 deliveryCharge.InnerHtml = display;
                 }
                 else
                 {
                 display = "<div class='checkout__order__shipping' id='deliveryCharge' runat='server'>Delivery charge<span>R " + 60.00 + "</span></div>";
                 deliveryCharge.InnerHtml = display;
                 }

                 display = "<div class='checkout__order__userpoints' id='usrPoints' runat='server'>Points<span>"+ points +"</span></div>";
                 usrPoints.InnerHtml = display;
                 display = "<div class='checkout__order__total' id='P_Total' runat='server'>Total<span>R" + Math.Round(total, 2) + "</span>";
                 P_Total.InnerHtml = display;*/

                if (total > 500)
                {
                    freeShipping = true;
                }
            }
            // else
             {
           // Response.Redirect("login.aspx");
             }

    }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Response.Cookies["cart"].Value = "1-1, 2-3";
            dynamic CookieContent = Request.Cookies["cart"].Value;

            int userID=0;
            userID = Convert.ToInt32(Session["LoggedInUserID"]);
            int addressUpdate = SR.addAddress(Line1.Value, Line2.Value, suburb.Value , town.Value, 'F' ,postcode.Value,userID, Province.Value);

            //int points = SR.getpointbyUserID(userID);
            int points = 0;
            dynamic products = CookieContent.Split(',');
         
            if (addressUpdate == 1)
            {
                int addInvoice = SR.addInvoice(userID, "Approved", DateTime.Now, DateTime.Now, order.Value, subtotal, points);
                points = 0;
                //@50 need to pass the points received from the textbox
                if(addInvoice>0)
                 {
                    //dynamic point = SR.getpointIDbyUserID(userID);

                    foreach (dynamic p in products)
                    {
                        string[] productDetails = p.Split('-');
                        var pID = productDetails[0];
                        pIds.Add(pID);

                        var cartProduct = SR.getProduct(int.Parse(pID));
                        var qty = productDetails[1];
                        qtys.Add(qty);

                        dynamic pcategory = SR.getCategorybyProductID(cartProduct.ID);
                        if (pcategory.ID == 2 || pcategory.ID == 9)
                        {
                            if ((cartProduct.Price*Convert.ToDecimal(qty)) > 300)
                            {
                                ///int updatepoints = SR.updatePoints(point.PointID, userID, point.Points+30);
                            }
                            else
                            {
                                //int updatepoints = SR.updatePoints(point.PointID, userID, point.Points+10);
                            }
                        }

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