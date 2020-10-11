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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        GP_ServiceClient SC = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["cart"] != null)
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
                numCartItems.Visible = false;
            }

            if (Session["LoggedInUserID"] == null)
            {
                listIcon.Visible = false;
            }
            else
            {
                listIcon.Visible = true;
                var user = SC.getUser(Convert.ToInt32(Session["LoggedInUserID"]));
                if (!user.UserType.Equals("admin"))
                {
                    int userID = int.Parse(Session["LoggedInUserID"].ToString());
                    User customer = SC.getUser(userID);
                    newsletterID.Value = customer.Email;

                }
                
            }

            //TRAFFIC------------------------------------------------------
            string currentPage = Path.GetFileName(Request.Path);
            if (Session["TrafficUser"] == null)
            {
                int addTraffic = SC.addTraffic(currentPage, DateTime.Now, 1);
                Session["TrafficUser"] = addTraffic;
            }
            else
            {
                int addTraffic = SC.addTraffic(currentPage, DateTime.Now, 0);
            }


        }
           // NewsLetterbtnID12.InnerHtml += "<a class='site-btn' ID='NewsLetterbtnID12' runat='server' href='ThankYou.aspx?ID='" + newsletterID +"' >Subscribe</a>";


    }

}