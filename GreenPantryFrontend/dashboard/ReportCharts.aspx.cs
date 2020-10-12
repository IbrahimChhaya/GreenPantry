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

        //sales details
        protected string jsonMonthDates;
        protected string jsonMonthSales;
        protected string jsonWeekDays;
        protected string jsonWeekSales;

        //worstProduct details
        public string WorstProdChart;
        public string WorstProdName;

        //usersperday details
        public string userspDayMonthly;
        public string userspDayWeekly; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUserID"] != null)
            {
                int userID = int.Parse(Session["LoggedInUserID"].ToString());
                dynamic user = SR.getUser(userID);
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

            /*Sales Graph data --START*/
            //List<string> display = new List<string>();
            //List<decimal> catSales = new List<decimal>();

            //dynamic categories = SR.getAllCategories();

            //categories = SR.getAllCategories();
            //foreach (var c in categories)
            //{
            //    display.Add(c.Name);
            //    var catTotal = SR.calcCategoryTotalSales(c.ID);
            //    catSales.Add(catTotal);
            //}
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //jsonCategories = serializer.Serialize(display);
            //jsonCatSales = serializer.Serialize(catSales);


            dynamic monthDates = SR.getMonthDates(new DateTime(2020, 09, 24));

            List<string> dates = new List<string>();

            List<decimal> salesMonthDays = new List<decimal>();
            foreach (DateTime d in monthDates)
            {
                var daySales = SR.calcSalesPerDay(d.Date);
                salesMonthDays.Add(daySales);
                dates.Add(d.ToShortDateString());
            }

            jsonMonthDates = serializer.Serialize(dates);
            jsonMonthSales = serializer.Serialize(salesMonthDays);

            dynamic weekDates = SR.getWeekDates(new DateTime(2020, 09, 24));
            List<string> wDays = new List<string>();
            List<decimal> weekSales = new List<decimal>();

            foreach (DateTime d in weekDates)
            {
                var wDaySales = SR.calcSalesPerDay(d.Date);
                weekSales.Add(wDaySales);
                wDays.Add(d.Date.ToShortDateString());
            }

            jsonWeekDays = serializer.Serialize(wDays);
            jsonWeekSales = serializer.Serialize(weekSales);
            /*Sales Graph data --END*/

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

            //getusersperday--------------------------------------------------
            List<int> getusersmonthly = new List<int>();
            List<int> getusersweekly = new List<int>(); 

            dynamic monthDates1 = SR.getMonthDates(new DateTime(2020, 09, 24));
            foreach (DateTime d in monthDates1)
            {
                int usersperday = SR.getUsersPerDay(d.Date);
                getusersmonthly.Add(usersperday); 
            }
            userspDayMonthly = jSerializer.Serialize(getusersmonthly); 

            foreach(DateTime d in weekDates)
            {
                int usersperday = SR.getUsersPerDay(d.Date);
                getusersweekly.Add(usersperday); 
            }
            userspDayWeekly = jSerializer.Serialize(getusersweekly); 
        }
    }
}