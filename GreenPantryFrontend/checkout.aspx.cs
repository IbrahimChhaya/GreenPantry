
using GreenPantryFrontend.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class checkout : System.Web.UI.Page
    {
        GP_ServiceClient SR = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {

           int addressUpdate = SR.AddAdress(Line1.Value, Line2.Value, suburb.Value , town.Value, 'F' ,postcode.Value,1, Province.Value);
           //int addInvoice = SR.addInvoice("Approved", DateTime.Today, DateTime.Today,order.Value, 1);
           

            if(addressUpdate == 1)
            {
                Response.Redirect("home.aspx");
            }
            else if(addressUpdate == -1)
            {
                error.Text = "Something went wrong";
            }
            else if(addressUpdate ==0)
            {
                error.Text ="I dunnoo";
            }
        }

    }
}