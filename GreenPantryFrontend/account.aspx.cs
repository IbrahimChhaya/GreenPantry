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
        int userID;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            userID = int.Parse(Session["LoggedInUserID"].ToString());
            User user = SC.getUser(userID);
            Name.Value = user.Name;
            Surname.Value = user.Surname;
            Email1.Value = user.Email;
            PhoneNumber1.Value = user.PhoneNumber; 
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //userID = int.Parse(Session["LoggedInUserID"].ToString());
            int getUpdateduserdetails = SC.UpdateUserDetails(userID, Name.Value, Surname.Value, Email1.Value, PhoneNumber1.Value);
           // int getupdatedpassword = SC.UpdatePassword(userID, Password1.Value, Password2.Value);
            

            if (getUpdateduserdetails == 1)
            {
                Response.Redirect("home.aspx");
            }
            else if (getUpdateduserdetails == -1)
            {
                //error.Text = "Something went wrong";
            }
            else if (getUpdateduserdetails == 0)
            {
                //error.Text = "I dunnoo";
            }


        }
    }
}