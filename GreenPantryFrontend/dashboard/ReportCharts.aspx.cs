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
        public string devChart;
        public string devName;

        //Top Products Details
        public string prodChart;
        public string prodName;

        //worstProduct details
        public string WorstProdChart;
        public string WorstProdName;

        protected void Page_Load(object sender, EventArgs e)
        {
            // List<int> cat = new List<int>();
            List<int> qty = new List<int>();
            List<String> devices = new List<String>();
            dynamic getalldevice = SR.getAllDevices();
            foreach (string d in getalldevice)
            {
                int quantity = SR.getTotOSUsers(d);
              
                qty.Add(quantity); 
               // cat.Add(d.DeviceID);
                devices.Add(d);

            }

            //creating a javascript serializer
            JavaScriptSerializer jSerializer = new JavaScriptSerializer();
            devChart = jSerializer.Serialize(qty);
            devName = jSerializer.Serialize(devices);

            //TopProduct Chart----------------------------------------- 
            dynamic topProduct = SR.TopProducts();
            List<int> pQuantity = new List<int>();

            List<String> pName = new List<String>();

            
            foreach(int p in topProduct)
            {

                //int Qty = SR.getProQtySold(p);
                int Qty = SR.getProQtySold(p);
                dynamic product = SR.getProduct(p);
                pQuantity.Add(Qty);
                pName.Add(product.Name);
            }
            
            prodChart = jSerializer.Serialize(pQuantity);
            prodName = jSerializer.Serialize(pName);

            //WorstProduct chart--------------------------------------------
            dynamic worstProduct = SR.WorstProducts();
            List<int> wpQuantity = new List<int>();
            List<String> wpName = new List<String>();

            foreach (int p in worstProduct)
            {
                int Qty = SR.getProQtySold(p);
                dynamic product = SR.getProduct(p);
                wpQuantity.Add(Qty);
                wpName.Add(product.Name);
            }

            WorstProdChart = jSerializer.Serialize(wpQuantity);
            WorstProdName = jSerializer.Serialize(wpName);

        }
    }
}