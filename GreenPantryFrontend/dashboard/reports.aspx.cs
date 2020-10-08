using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminDashboard
{
    public partial class reports : System.Web.UI.Page
    {

        GP_ServiceClient SR = new GP_ServiceClient();
        public string catChart;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ProductCategory> cat = new List<ProductCategory>();
            dynamic category = SR.getAllCategories();
            foreach(ProductCategory pc in category)
            {
                cat.Add(pc);
            }

            //creating a javascript serializer
            JavaScriptSerializer jSerializer = new JavaScriptSerializer();
            catChart = jSerializer.Serialize(cat);

        }
    }
}