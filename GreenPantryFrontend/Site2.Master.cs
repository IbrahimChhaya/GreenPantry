using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        GP_ServiceClient SC = new GP_ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            String display = "";

            if (Session["LoggedInUserID"] != null)
            {
                listIcon.Visible = true;
                var user = SC.getUser(Convert.ToInt32(Session["LoggedInUserID"]));
                if (user.UserType.Equals("admin"))
                {
                    account.InnerHtml = "<a href='/dashboard/dashboard.aspx'>Dashboard</a>";
                }
                else
                {
                    display = "<a href='account.aspx'>My Account</a>";
                    account.InnerHtml = display;
                    int userID = int.Parse(Session["LoggedInUserID"].ToString());
                    User customer = SC.getUser(userID);
                    newsletterID.Value = customer.Email;
   
                }
            }
            else
            {
                listIcon.Visible = false;
            }
            //TRAFFIC --------------------------------------------------------------------------
            string currentPage = Path.GetFileName(Request.Path);
            if(Session["TrafficUser"]==null)
            {
                int addTraffic = SC.addTraffic(currentPage, DateTime.Now,1);
                Session["TrafficUser"] = addTraffic;
            }else
            {
                int addTraffic = SC.addTraffic(currentPage, DateTime.Now,0);
            }
            
            //category menu --------------------------------------------------------------------
            display = "";
            dynamic allCategories = SC.getAllCategories();
            foreach (ProductCategory c in allCategories)
            {

                display += "<li><a href='/categories.aspx?CategoryID=" + c.ID + "'>" + c.Name + "</a></li>";
            }
            categoryList.InnerHtml = display;

            if (Request.Cookies["cart"] != null)
            {
                if(Request.Cookies["cart"].Value != null)
                {
                    dynamic products = Request.Cookies["cart"].Value.Split(',');
                    int numProducts = 0;

                    foreach (var p in products)
                    {
                        if (!p.Equals(""))
                        {
                            numProducts++;
                        }
                    }
                    if (numProducts > 0)
                    {
                        numCartItems.InnerText = numProducts.ToString();
                        numCartItems.Visible = true;
                    }
                }
                else
                {
                    Response.Cookies["cart"].Expires = DateTime.Now.AddDays(-1);
                    numCartItems.Visible = false;
                }
               
            }
            else
            {
                numCartItems.Visible = false;
            }
        }

        protected void Search_Click(object sender,EventArgs e)
        {
            string userInput = searchText.Value;
            Response.Redirect("/results.aspx?Search=" + userInput);
        }               
    }
}