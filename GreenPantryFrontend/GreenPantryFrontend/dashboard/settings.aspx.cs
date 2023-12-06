using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend.dashboard
{
    public partial class settings : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = 0;
            //if (Session["LoggedInUserID"] != null)
            //{
            //    userID = int.Parse(Session["LoggedInUserID"].ToString());
            //    dynamic user = SC.getUser(userID);
            //    if (user.UserType == "admin")
            //    {
            //        howdy.InnerText = "Howdy, " + user.Name;
            //    }
            //    else
            //    {
            //        Response.Redirect("/home.aspx");
            //    }
            //}
            //else
            //{
            //    Response.Redirect("/home.aspx");
            //}

            dynamic settings = SC.getSetting(1);

            if(!IsPostBack)
            {
                name.Value = settings.Field1;
                minimum.Value = settings.Field2;
                vat.Value = settings.Field3;
            }
        }

        protected void updateSite_ServerClick(object sender, EventArgs e)
        {
            int update = SC.updateSettings(1, name.Value, minimum.Value, vat.Value, "");
            if(update.Equals(1))
            {
                error.Visible = true;
                error.InnerText = "Updated";
            }
            else
            {
                error.Visible = true;
                error.InnerText = "error";
            }
        }
    }
}