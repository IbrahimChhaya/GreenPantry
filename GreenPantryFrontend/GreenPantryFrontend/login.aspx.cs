using GreenPantryFrontend.ServiceReference1;
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
            string reset = Request.QueryString["Reset"];
            if (reset == null)
            {
                loginDiv.Visible = true;
                resetDiv.Visible = false;
            }
            else if(reset.Equals("true"))
            {
                loginDiv.Visible = false;
                resetDiv.Visible = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String email = Email.Value;
            int userID = SR.login(email.ToLower(), Password.Value);
           
            if (userID != 0)
            {
                Session["LoggedInUserID"] = userID;
                int addDevice = SR.addDevices(userID, Request.Browser.Platform);
                Response.Redirect("home.aspx");
               
            }
            else
            {
                error.Visible = true;
            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //if (RegPassword.Value != cPassword.Value)
            //{
            //    error.Text = "Passwords do not match";
            //    error.Visible = true;
            //}
            //else
            //{
            String email = RegEmail.Value;
            int registered = SR.register(name.Value, surname.Value, email.ToLower(), RegPassword.Value, "active", DateTime.Today, "customer");

            if (registered == 1)
            {
                Response.Redirect("home.aspx");

            }
            else if (registered == -1)
            {
                error.Text = "Something went wrong, please try again later";
                error.Visible = true;
            }
            else if (registered == 0)
            {
                error.Text = "The username already exists";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            resetText.InnerText = "Password reset link was sent. \r\n Please check your email for instructions.";
        }
    }
}
