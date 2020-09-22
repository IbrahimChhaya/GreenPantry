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
        List<string> pIds = new List<string>();
        List<string> qtys = new List<string>();
        decimal subtotal = 0;
        decimal total = 0;
        GP_ServiceClient SR = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            bool freeShipping = false;
            int userID = Convert.ToInt32(Session["LoggedInUserID"]);
            Response.Cookies["cart"].Value = "1-1, 2-3";
            dynamic CookieContent = Request.Cookies["cart"].Value;

            dynamic products = CookieContent.Split(',');

            string display = "";
            List<decimal> totals = new List<decimal>();
           // decimal subtotal = 0;
           // decimal total = 0;
            int points = SR.getpointbyUserID(userID);
            foreach (dynamic p in products)
            {
                if(!p.Equals(""))
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
            total = total - Convert.ToDecimal(points * 0.05);
            checkoutItems.InnerHtml = display;
            
            display = "Subtotal<span>R" + Math.Round(subtotal, 2) + "</span>";
            orderSubtotal.InnerHtml = display;
            
            display = "Total<span>R" + Math.Round(total, 2) + "</span>";
            orderTotal.InnerHtml = display;

            if (total > 500)
            {
                freeShipping = true;
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            dynamic CookieContent = Request.Cookies["cart"].Value;
            int userID = 0;
            userID = Convert.ToInt32(Session["LoggedInUserID"]);
            int addressUpdate = SR.AddAdress(line1.Value, line2.Value, suburb.Value, town.Value, 'F', postcode.Value, userID, "gauteng");
            //int addInvoice = SR.addInvoice("Approved", DateTime.Today, DateTime.Today,order.Value, 1);

            int points = SR.getpointbyUserID(userID);
            dynamic products = CookieContent.Split(',');

            if (addressUpdate == 1)
            {
                int addInvoice = SR.addInvoices(userID, "Approved", DateTime.Now, DateTime.Now,"My Notes", subtotal, points);
                points = 0;
                if(addInvoice > 0)
                {
                    dynamic point = SR.getpointIDbyUserID(userID);
                    foreach(dynamic p in products)
                    {
                        if (!p.Equals(""))
                        {
                            string[] productDetails = p.Split('-');
                            var pID = productDetails[0];
                            pIds.Add(pID);

                            var cartProduct = SR.getProductByID(int.Parse(pID));
                            var qty = productDetails[1];
                            qtys.Add(qty);

                            dynamic pcategory = SR.getCategorybyProductID(cartProduct.ID);
                            if (pcategory.ID == 2 || pcategory.ID == 9)
                            {
                                if ((cartProduct.Price * Convert.ToDecimal(qty)) > 300)
                                {
                                    int updatepoints = SR.updatePoints(point.PointID, userID, point.Points + 30);
                                }
                                else
                                {
                                    int updatepoints = SR.updatePoints(point.PointID, userID, point.Points + 10);
                                }
                            }
                            int addinvLine = SR.addInvoiceLine(cartProduct.ID, addInvoice, Convert.ToInt32(qty), cartProduct.Price);
                        }

                    }
                    Response.Redirect("home.aspx");

                }
                else
                {
                    error.Text ="Invoice failed";
                }
                
            }
            else if (addressUpdate == -1)
            {
                error.Text = "Something went wrong";
            }
            else if (addressUpdate == 0)
            {
                //Allow user to update his address
                error.Text = "Address already exists";
            }
        }
    }
}