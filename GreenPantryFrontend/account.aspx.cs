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
            if (Session["LoggedInUserID"] != null)
            { 
                int userID = int.Parse(Session["LoggedInUserID"].ToString());
                User user = SC.getUser(userID);
                if (!IsPostBack)
                { 
                    Name.Value = user.Name;
                    Surname.Value = user.Surname;
                    Email1.Value = user.Email;
                    PhoneNumber1.Value = user.PhoneNumber;
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            int updateInfo = SC.updateUserDetails(int.Parse(Session["LoggedInUserID"].ToString()), Name.Value, Surname.Value, Email1.Value, PhoneNumber1.Value, oldPassword.Value, newPassword.Value);
            
            if (updateInfo == 1)
            {
                Response.Redirect("account.aspx");
                error.Visible = true;
                error.Text = "Account updated";
            }
            else if (updateInfo == 0)
            {
                error.Text = "An error has ocurred";
                error.Visible = true;
            }
            else if (updateInfo == -1)
            {
                error.Text = "Email already in use";
                error.Visible = true;
            }
            else if(updateInfo.Equals(-2))
            {
                error.Text = "Incorrect current password";
                error.Visible = true;
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["LoggedInUserID"] = null;
            Response.Redirect("/home.aspx");
        }
    }
}