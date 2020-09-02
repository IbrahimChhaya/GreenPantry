using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class register2 : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnLogin_Click(object sender, EventArgs e)
        //{

        //}

        protected void Register_Click(object sender, EventArgs e)
        {
            //if (RegPassword.Value != cPassword.Value)
            //{
            //    error.Text = "Passwords do not match";
            //    error.Visible = true;
            //}
            //else
            //{
                int registered = SR.Register(name.Value, surname.Value, RegEmail.Value, RegPassword.Value, "active", DateTime.Today, "customer");

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
            //}
        }
    }
}