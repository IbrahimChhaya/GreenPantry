using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend.dashboard
{
    public partial class edituser : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = 0;
            if (Session["LoggedInUserID"] != null)
            {
                userID = int.Parse(Session["LoggedInUserID"].ToString());
                dynamic user = SC.getUser(userID);
                if (user.UserType == "admin")
                {
                    howdy.InnerText = "Howdy, " + user.Name;
                }
                else
                {
                    Response.Redirect("/home.aspx");
                }
            }
            else
            {
                Response.Redirect("/home.aspx");
            }

            userID = int.Parse(Request.QueryString["UserID"].ToString());
            //if(userID.Equals(0))
            //{
            //    editName.InnerText = "Add New User";

            //    dropdownStatus.Items.Add("Active");
            //    dropdownStatus.Items.Add("Inactive");

            //    dropdownType.Items.Add("Admin");
            //    dropdownType.Items.Add("Customer");
            //}
            //else
            //{
            userOrder.InnerHtml = "<a href='userorders.aspx?UserID=" + userID + "&Page=1' class='btn btn-sm btn-outline-primary'>View Orders</a>";
                if (!IsPostBack)
                {
                    dynamic user = SC.getUser(userID);
                    Details.InnerText = "User Details";
                    editName.InnerText = "Edit #" + user.ID;

                    email.Value = user.Email;
                    points.Value = user.Points.ToString();

                    dropdownStatus.Items.Clear();
                    if (user.Status.Equals("active"))
                    {
                        dropdownStatus.Items.Add("Active");
                        dropdownStatus.Items.Add("Inactive");
                    }
                    else
                    {
                        dropdownStatus.Items.Add("Inactive");
                        dropdownStatus.Items.Add("Active");
                    }

                    dropdownType.Items.Clear();
                    if (user.UserType.Equals("customer"))
                    {
                        dropdownType.Items.Add("Customer");
                        dropdownType.Items.Add("Admin");
                    }
                    else
                    {
                        dropdownType.Items.Add("Admin");
                        dropdownType.Items.Add("Customer");
                    }
                }
            //}
        }

        protected void updateUser_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int userID = int.Parse(Request.QueryString["UserID"].ToString());
                dynamic user = SC.getUser(userID);
                String type = dropdownType.SelectedValue;
                string stat = dropdownStatus.Text.ToLower();
                int pointsNum = int.Parse(points.Value);

                if (pointsNum >= 0)
                {
                    int updateUser = SC.updateUserAdmin(userID, pointsNum, type, stat);
                    if(updateUser.Equals(1))
                    {
                        error.Visible = true;
                        error.InnerText = "User Updated";
                    }
                    else
                    {
                        error.Visible = true;
                        error.InnerText = "An error occurred";
                    }
                }
                else
                {
                    error.Visible = true;
                    error.InnerText = "Points value must be non negative";
                }
            }
            catch
            {
                error.Visible = true;
                error.InnerText = "Please enter valid data";
            }
        }

        protected void addUser_ServerClick(object sender, EventArgs e)
        {

        }
    }
}