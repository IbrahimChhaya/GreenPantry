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
            //string email = Request.Params["ID"].ToString();
            if (user != null)
            {
                string bodymessage = "";
                
                bodymessage += "Dear " + user.Name + "\n";
                bodymessage += "Thank you for subscribing to GreenPantry!! \n";
                bodymessage += "Regards \n";
               
               
                SC.newsletter("chandranero149@gmail.com", user.Email, "GreenPantry NewsLetter", bodymessage, "greenpantry", "smtp.gmail.com");
            }
            //else
            //{
            //    string bodymessage = "";
            //    bodymessage += "Dear Customer"  + "\n";
            //    bodymessage += "Thank you for subscribing to GreenPantry!! \n";
            //    bodymessage += "Regards \n";


            //    SC.newsletter("chandranero149@gmail.com", user.Email, "GreenPantry NewsLetter", bodymessage, "greenpantry", "smtp.gmail.com");
            //}
                          
        }
    }
}