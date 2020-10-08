using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["cart"] != null)
            {
                dynamic products = Request.Cookies["cart"].Value.Split(',');
                int numProducts = 0;

                foreach (var p in products)
                {
                    if (!p.Equals(""))
                    {
                        numProducts++;
                    }
                }

                numCartItems.InnerHtml = numProducts.ToString();
                numCartItems.Visible = true;
            }
            else
            {
                numCartItems.Visible = false;
            }

            if (Session["LoggedInUserID"] == null)
            {
                listIcon.Visible = false;
            }
            else
            {
                listIcon.Visible = true;
            }

            
        }
    }
}