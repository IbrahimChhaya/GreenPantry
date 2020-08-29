using GreenPantryFrontend.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class login2 : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            int userID = SR.login(Email.Value, Password.Value);
            Response.Redirect("home.aspx");

            if (userID == 0)
            {
                error.Visible = true;
            }
            else
            {
                Session["LoggedInUserID"] = userID;
                //Response.Redirect("home.aspx");
            }
        }
    }
}
