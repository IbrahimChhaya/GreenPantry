using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class charts : System.Web.UI.Page
    {
        //GP_ServiceClient SC = new GP_ServiceClient();
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //dynamic getCategory = SC.getAllCategories();
            //dynamic getprofit = SC.CalculateProfit();
            //string display = "";
            //var profit = "<%= returnProfit%>";

            //foreach(ProductCategory p in getCategory)
            //{
            //    display += "data:";
            //    display += "{";
            //    display += "labels:[" + p.Name + "],";
            //    display += "datasets:";
            //    display += "[{";
            //    display += "label: 'Profit',";
            //    display += "data:[" + profit + "],";
            //} 

          
        }
        //public double MyProperty()
        //{
        //    dynamic getcatProfit = SC.profitPerCat('1');
        //    return getcatProfit;
        //}


    }
}