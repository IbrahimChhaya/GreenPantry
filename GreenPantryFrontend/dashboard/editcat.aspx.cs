using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend.dashboard
{
    public partial class editcat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //load category or subcat using URL parameter
            //url will look like editcat.aspx?type=subcat&catID=1
            //if(request.querystring["type"].tostring == subcat then
            //  if(!IsPostBack) then getsubcat and display
            //else if(request.querystring["type"].tostring == cat then
            //  if(!IsPostBack) then getcat and display

        }

        protected void updateCat_ServerClick(object sender, EventArgs e)
        {

        }
    }
}