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
            string email = RegEmail.Value;
            int registered = SR.register(name.Value, surname.Value, email.ToLower(), Password1.Value, "active", DateTime.Today, "customer");
            string bodymessage = "";
            bodymessage += "Dear " + name.Value + "\n\n";
            bodymessage += "Thank you for registering to GreenPantry!! \n";
            bodymessage += "You have received free 50 points \n";
            bodymessage += "Thank you \n"; 

            if (registered == -1)
            {
                error.Text = "Something went wrong, please try again later";
                error.Visible = true;
            }
            else if (registered == 0)
            {
                error.Text = "The username already exists";
            }
            else
            {
                Session["LoggedInUserID"] = registered;

                int addpoint = SR.updatePoints(registered, 50);
                int addDevice = SR.addDevices(registered, Request.Browser.Platform);
                //"Congratulations you registered succesfully! you get 50 points"
                if (addpoint == 1)
                {
                    SR.newsletter("chandranero149@gmail.com", email, "GreenPantry Family",bodymessage, "greenpantry", "smtp.gmail.com");
                    Response.Redirect("home.aspx");   
                }
            }
        }
    }
}