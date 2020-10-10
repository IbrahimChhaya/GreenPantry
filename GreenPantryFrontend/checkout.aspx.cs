using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class checkout2 : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();

        List<string> pIds = new List<string>();
        List<string> qtys = new List<string>();
        decimal subtotal = 0;
        decimal total = 0;
        int points = 0;
        int pointsRedeemed = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUserID"] != null)
            {
                int userID = Convert.ToInt32(Session["LoggedInUserID"]);
                //Response.Cookies["cart"].Value = "1-1, 2-3";
                dynamic CookieContent = Request.Cookies["cart"].Value;

                dynamic products = CookieContent.Split(',');

                string display = "";
                List<decimal> totals = new List<decimal>();
           
                points = SR.getUserPoints(userID);
                if(points == 0)
                {
                    noPoints.Visible = true;
                    Redeem.Visible = false;
                }
                else
                {
                    noPoints.Visible = false;
                    Redeem.Visible = true;
                }
                decimal VAT = 0;
                foreach (dynamic p in products)
                {
                    if(!p.Equals(""))
                    {
                        string[] productDetails = p.Split('-');
                        var pID = productDetails[0];
                        pIds.Add(pID);

                        var cartProduct = SR.getProduct(int.Parse(pID));
                        var qty = productDetails[1];
                        qtys.Add(qty);

                        subtotal += cartProduct.Price * Convert.ToInt32(qty);

                        display += "<li>" + qty + "x " + cartProduct.Name + "<span>R" + Math.Round(cartProduct.Price * Convert.ToInt32(qty), 2) + "</span></li>";

                        if(subtotal < 500)
                        { 
                            total = subtotal + 60;
                        }
                        else
                        {
                            total = subtotal;
                        }

                        VAT += SR.calcProductVAT(cartProduct.ID) * Convert.ToInt32(qty);
                    }
                }
                checkoutItems.InnerHtml = display;
            
                display = "Subtotal<span>R" + Math.Round(subtotal, 2) + "</span>";
                orderSubtotal.InnerHtml = display;

                orderVAT.InnerHtml = "VAT <span>R" + Math.Round(VAT, 2) + "</span>";

                if (total > 500)
                {
                    orderShipping.InnerHtml = "Delivery<span>R0.00</span>";
                }
                else
                {
                    orderShipping.InnerHtml = "Delivery<span>R60.00</span>";
                }

                display = "Total<span>R" + Math.Round(total, 2) + "</span>";
                orderTotal.InnerHtml = display;

                pointsAvailable.InnerHtml = "R" + points;
                pointsRedeemed = int.Parse(pointsUsed.Value);
            }
            else
            {
                Response.Redirect("/login.aspx");
            }
        }

        protected void btnRedeem_Click(object sender, EventArgs e)
        {
            pointsRedeemed = int.Parse(pointsUsed.Value);
            if(pointsRedeemed > points)
            {
                pointsError.Visible = true;
                pointsError.InnerText = "Cannot redeemed more than R" + points;
                pointsDisplay.InnerHtml = "";
            }
            else 
            {
                pointsError.Visible = false;
                total = total - pointsRedeemed;
                pointsDisplay.InnerHtml = "<div class='checkout__order__subtotal' id='orderPoints' runat='server'>Points <span>R" + pointsRedeemed + ".00</span></div>";
                orderTotal.InnerHtml = "Total<span>R" + Math.Round(total, 2) + "</span>";
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            dynamic CookieContent = Request.Cookies["cart"].Value;
            int userID = Convert.ToInt32(Session["LoggedInUserID"]);
            
            dynamic products = CookieContent.Split(',');

            int addInvoice = SR.addInvoice(userID, "Pending", DateTime.Now, Convert.ToDateTime(dateTimeID.Value), notes.Value, subtotal, pointsRedeemed);
            points = points - pointsRedeemed;
            if(addInvoice > 0)
            {
                dynamic update = SR.updatePoints(userID, points);
                foreach(dynamic p in products)
                {
                    if (!p.Equals(""))
                    {
                        string[] productDetails = p.Split('-');
                        var pID = productDetails[0];
                        pIds.Add(pID);

                        var cartProduct = SR.getProduct(int.Parse(pID));
                        var qty = productDetails[1];
                        qtys.Add(qty);

                        if(pointsRedeemed.Equals(0))
                        { 
                            dynamic pcategory = SR.getCategorybyProductID(cartProduct.ID);
                            if (pcategory.ID == 2 || pcategory.ID == 9)
                            {
                                if ((cartProduct.Price * Convert.ToDecimal(qty)) > 300)
                                {
                                    int updatepoints = SR.updatePoints(userID, points + 30);
                                }
                                else
                                {
                                    int updatepoints = SR.updatePoints(userID, points + 10);
                                }
                            }
                        }
                        int addinvLine = SR.addInvoiceLine(cartProduct.ID, addInvoice, Convert.ToInt32(qty), cartProduct.Price);
                        int decreaseProStock = SR.updateStock(cartProduct.ID, int.Parse(qty));
                    }
                }
                Response.Cookies["cart"].Expires = DateTime.Now.AddDays(-1);  //delete cookie
                Response.Redirect("Invoice.aspx?InvoiceID=" + addInvoice);
            }
            else
            {
                error.Visible = true;
                error.Text = "Something went wrong";
            }
        }
    }
}