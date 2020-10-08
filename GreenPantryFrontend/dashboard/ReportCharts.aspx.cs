using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend.dashboard
{
    public partial class ReportCharts : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();
        public string catChart;
        public string catName;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<int> cat = new List<int>();
            List<String> categories = new List<String>();
            dynamic category = SR.getAllCategories();
            foreach (ProductCategory pc in category)
            {
                cat.Add(pc.ID);
                categories.Add(pc.Name);

            }

            //creating a javascript serializer
            JavaScriptSerializer jSerializer = new JavaScriptSerializer();
            catChart = jSerializer.Serialize(cat);
            catName = jSerializer.Serialize(categories);

        }
    }
}