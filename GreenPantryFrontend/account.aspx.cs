using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class account : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(Session["LoggedInUserID"].ToString());
            int getupdatedpassword = SC.UpdatePassword(userID, Password1.Value, Password2.Value);
            int getUpdateduserdetails = SC.UpdateUserDetails(userID, Line1.Value, Line2.Value, Email1.Value, PhoneNumber1.Value);
        }
    }
}