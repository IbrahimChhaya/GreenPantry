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

        //sales details
        protected string jsonMonthDates;
        protected string jsonMonthSales;
        protected string jsonWeekDays;
        protected string jsonWeekSales;
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

        }
    }
}