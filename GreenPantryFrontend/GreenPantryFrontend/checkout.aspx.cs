﻿using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO.Compression;
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
            string display = "";

            if (Session["LoggedInUserID"] != null)
            {
                int userID = Convert.ToInt32(Session["LoggedInUserID"]);
                dynamic address = SR.getUserAddresses(userID);
                dynamic primaryAdd = SR.getPrimaryAddress(userID);

                if (address == null || primaryAdd == null)
                {
                    newAddress.Visible = true;
                    addressSaved.Visible = true;
                    oldAddress.Visible = false;
                    sidebarNew.Visible = true;
                    sidebar.Visible = false;
                }
                else
                {
                    sidebarNew.Visible = false;
                    sidebar.Visible = true;
                    oldAddress.Visible = true;
                    display += "<div><label><b>" + primaryAdd.Type + "</b> <span class='badge badge-success'>PRIMARY</span></label></div>";
                    display += "<div><label>" + primaryAdd.Line1 + "</label></div>";
                    if (primaryAdd.Line2 != "" || primaryAdd.Line2 != null)
                    {
                        display += "<div><label>" + primaryAdd.Line2 + "</label></div>";
                    }
                    display += "<div><label>" + primaryAdd.Suburb + ", " + primaryAdd.City + ", " + primaryAdd.Zip + "</label></div>";
                    display += "<div><label>" + primaryAdd.Number + "</label></div>";
                    display += "<div><label class='gpLabel2' style='float:right;'><a href='addressbook.aspx?action=0&ID=" + primaryAdd.ID + "'>Delete</a></label>";
                    display += "<label class='gpLabel2' style='float:right;'><a href='addressbook.aspx?action=1&ID=" + primaryAdd.ID + "'>Edit</a></label>";
                    display += "<label class='gpLabel2' style='float:right;'><a href='addressbook.aspx'>Change Primary Address</a></label>";
                    display += "</div><br />";

                    oldAddress.InnerHtml = display;
                }
                
                
                dynamic CookieContent = Request.Cookies["cart"].Value;

                dynamic products = CookieContent.Split(',');

                List<decimal> totals = new List<decimal>();
           
                points = SR.getUserPoints(userID);
                if(points == 0)
                {
                    noPoint.Visible = true;
                    noPointNew.Visible = true;
                    Redeem.Visible = false;
                    RedeemNew.Visible = false;
                }
                else
                {
                    noPoint.Visible = false;
                    noPointNew.Visible = false;
                    Redeem.Visible = true;
                    RedeemNew.Visible = true;
                }
                decimal VAT = 0;
                display = "";
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
                checkoutItemsNew.InnerHtml = display;

                display = "Subtotal<span>R" + Math.Round(subtotal, 2) + "</span>";
                orderSubtotal.InnerHtml = display;
                orderSubtotalNew.InnerHtml = display;

                orderVAT.InnerHtml = "VAT <span>R" + Math.Round(VAT, 2) + "</span>";
                orderVATNew.InnerHtml = "VAT <span>R" + Math.Round(VAT, 2) + "</span>";

                dynamic setting = SR.getSetting(1);
                int shippingCost = int.Parse(setting.Field2);
                if (total > shippingCost)
                {
                    orderShipping.InnerHtml = "Delivery<span>R0.00</span>";
                    orderShippingNew.InnerHtml = "Delivery<span>R0.00</span>";
                }
                else
                {
                    orderShipping.InnerHtml = "Delivery<span>R60.00</span>";
                    orderShippingNew.InnerHtml = "Delivery<span>R60.00</span>";
                }

                display = "Total<span>R" + Math.Round(total, 2) + "</span>";
                orderTotal.InnerHtml = display;
                orderTotalNew.InnerHtml = display;

                pointsAvailable.InnerHtml = "R" + points;
                pointsAvailableNew.InnerHtml = "R" + points;
                if (pointsUsed.Value == "0")
                {
                    try
                    {
                        pointsRedeemed = int.Parse(pointsUsedNew.Value);
                    }
                    catch
                    {
                        pointsErrorNew.Visible = true;
                        pointsErrorNew.InnerText = "Points must be an integer value";
                    }
                }
                else
                {
                    try
                    {
                        pointsRedeemed = int.Parse(pointsUsed.Value);
                    }
                    catch
                    {
                        pointsError.Visible = true;
                        pointsError.InnerText = "Points must be an integer value";
                    }
                }
            }
            else
            {
                Response.Redirect("/login.aspx");
            }
        }

        protected void btnRedeem_Click(object sender, EventArgs e)
        {
            if (pointsUsed.Value == "0")
            {
                try
                {
                    pointsRedeemed = int.Parse(pointsUsedNew.Value);
                }
                catch
                {
                    pointsErrorNew.Visible = true;
                    pointsErrorNew.InnerText = "Points must be an integer value";
                }
            }
            else
            {
                try
                {
                    pointsRedeemed = int.Parse(pointsUsed.Value);
                }
                catch
                {
                    pointsError.Visible = true;
                    pointsError.InnerText = "Points must be an integer value";
                }
            }

            if (pointsRedeemed > points)
            {
                pointsError.Visible = true;
                pointsError.InnerText = "Cannot redeemed more than R" + points;
                pointsDisplay.InnerHtml = "";

                pointsErrorNew.Visible = true;
                pointsErrorNew.InnerText = "Cannot redeemed more than R" + points;
                pointsDisplayNew.InnerHtml = "";
            }
            else 
            {
                pointsError.Visible = false;
                total = total - pointsRedeemed;
                pointsDisplay.InnerHtml = "<div class='checkout__order__subtotal' id='orderPoints' runat='server'>Points <span>R" + pointsRedeemed + ".00</span></div>";
                orderTotal.InnerHtml = "Total<span>R" + Math.Round(total, 2) + "</span>";

                pointsErrorNew.Visible = false;
                total = total - pointsRedeemed;
                pointsDisplayNew.InnerHtml = "<div class='checkout__order__subtotal' id='orderPoints' runat='server'>Points <span>R" + pointsRedeemed + ".00</span></div>";
                orderTotalNew.InnerHtml = "Total<span>R" + Math.Round(total, 2) + "</span>";
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            dynamic CookieContent = Request.Cookies["cart"].Value;
            int userID = Convert.ToInt32(Session["LoggedInUserID"]);

            dynamic primaryAddress = SR.getPrimaryAddress(userID);
            if (primaryAddress == null)
            {
                //save new address
                int newAdd = SR.addAddress(line1.Value, line2.Value, suburb.Value, town.Value, int.Parse(postcode.Value), type.Value, userID, provincesList.Value, 1, phone.Value);
            }

            //int addCard = SR.addCard(userID, "card", name.Value, cardnumber.Value, Convert.ToDateTime(expirationdate.Value));

            dynamic products = CookieContent.Split(',');

            int addInvoice = SR.addInvoice(userID, "Pending", DateTime.Now, Convert.ToDateTime(dateTimeID1.Value), notes.Value, subtotal, pointsRedeemed*10);
            points = points - pointsRedeemed;
            if(addInvoice > 0)
            {
                dynamic update = SR.updatePoints(userID, points*10);
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
                                    int updatepoints = SR.updatePoints(userID, points*10 + 30);
                                }
                                else
                                {
                                    int updatepoints = SR.updatePoints(userID, points*10 + 10);
                                }
                            }
                        }
                        int addinvLine = SR.addInvoiceLine(cartProduct.ID, addInvoice, Convert.ToInt32(qty), cartProduct.Price);
                        int decreaseProStock = SR.updateStock(cartProduct.ID, int.Parse(qty));
                    }
                }
                Response.Cookies["cart"].Expires = DateTime.Now.AddDays(-1);  //delete cookie
                Response.Redirect("invoice.aspx?InvoiceID=" + addInvoice);
            }
            else
            {
                error.Visible = true;
                error.Text = "Something went wrong";

                errorNew.Visible = true;
                errorNew.Text = "Something went wrong";
            }
        }
    }
}