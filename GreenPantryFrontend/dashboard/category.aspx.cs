using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminDashboard
{
    public partial class categories : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            int currentPage = int.Parse(Request.QueryString["Page"]);
            String display = "";

            dynamic allCats = SR.getAllCategories();
            int numCats = allCats.Length;
        }
    }
}