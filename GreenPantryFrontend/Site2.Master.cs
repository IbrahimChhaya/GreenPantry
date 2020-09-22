using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        GP_ServiceClient SC = new GP_ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            String display = "";

            if (Session["LoggedInUserID"] != null)
            {
                var user = SC.getUser(Convert.ToInt32(Session["LoggedInUserID"]));
                if (user.UserType.Equals("admin"))
                {
                    account.InnerHtml = "<a href='/dashboard/dashboard.aspx'>Dashboard</a>";
                }
                else
                {
                    display = "<a href='account.aspx'>My Account</a>";
                    account.InnerHtml = display;
                }
                
            }
            
            //category menu --------------------------------------------------------------------

            dynamic allCategories = SC.getAllCategories();
            foreach (ProductCategory c in allCategories)
            {

                display += "<li><a href='/categories.aspx?CategoryID=" + c.ID + "'>" + c.Name + "</a></li>";
            }

            categoryList.InnerHtml = display;
        }

        protected void Search_Click(object sender,EventArgs e)
        {
          
            string userInput = SearchBar.Value;

            Response.Redirect("Results.aspx?Search=" + userInput);


        }
    }
}