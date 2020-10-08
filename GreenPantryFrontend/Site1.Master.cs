using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
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
        }

    }
}