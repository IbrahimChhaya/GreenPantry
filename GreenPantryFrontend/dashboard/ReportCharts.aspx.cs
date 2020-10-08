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
        //Devices Details
        public string catChart;
        public string catName;

        //Top Products Details
        public string prodChart;
        public string prodName;
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

            //Product Chart-----------------------------------------
            dynamic topProduct = SR.TopProducts();
            List<int> pQuantity = new List<int>();
            List<String> pName = new List<String>();

            foreach(int p in topProduct)
            {
                int Qty = SR.getProQtySold(p);
                dynamic product = SR.getProduct(p);
                pQuantity.Add(Qty);
                pName.Add(product.Name);
            }
            prodChart = jSerializer.Serialize(pQuantity);
            prodName = jSerializer.Serialize(pName);

        }
    }
}