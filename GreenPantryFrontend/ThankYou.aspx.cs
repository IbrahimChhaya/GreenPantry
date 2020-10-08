using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    
    public partial class ThankYou : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = SC.getUser(Convert.ToInt32(Session["LoggedInUserID"]));
            if (user != null)
            {
               // if (user.UserType.Equals("admin"))
               // {
                    SC.newsletter("chandranero149@gmail.com", user.Email, "GreenPantry NewsLetter", "Thank you for subscribing", "greenpantry", "smtp.gmail.com");

              //  }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
                          
        }
    }
}