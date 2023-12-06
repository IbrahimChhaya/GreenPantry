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
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            int updateInfo = SC.updateUserDetails(int.Parse(Session["LoggedInUserID"].ToString()), Name.Value, Surname.Value, Email1.Value);
            
            if (updateInfo == 1)
            {
                //Response.Redirect("account.aspx");
                error.Visible = true;
                error.Text = "Account updated :)";
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
        }

        protected void updatePass_Click(object sender, EventArgs e)
        {
            if (newPass.Value.Equals(confirmPass.Value))
            {
                int updatePass = SC.updatePassword(int.Parse(Session["LoggedInUserID"].ToString()), oldPass.Value, newPass.Value);
                if(updatePass.Equals(1))
                {
                    error.Text = "Password updated :)";
                    error.Visible = true;
                }
                else if(updatePass.Equals(-2))
                {
                    error.Text = "Current password incorrect";
                    error.Visible = true;
                }
                else
                {
                    error.Text = "An error has ocurred";
                    error.Visible = true;
                }
            }
            else
            {
                error.Visible = true;
                error.Text = "New and confirm password do not match";
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["LoggedInUserID"] = null;
            Response.Redirect("/home.aspx");
        }
    }
}