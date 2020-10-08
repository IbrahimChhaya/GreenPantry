using GreenPantryFrontend.ServiceReference1;
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
        GP_ServiceClient SC = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string display = "";
            //load category or subcat using URL parameter
            int ID = 1;         //int.Parse(Request.QueryString["CatID"].ToString());
            if(Request.QueryString["type"].ToString().Equals("SubCat"))
            {
                if(!IsPostBack)
                {
                    //Get the subcategory by the ID
                    dynamic subcat = SC.getSubCat(ID);
                    Details.InnerText = "SubCategory Details";
                    editName.InnerText = "Edit " + subcat.Name;
                    name.Value = subcat.Name;
                    display = "<label for='statusSelect' class='form-control-label'>Status</label>";
                    display += "<select class='form-control' id='statusSelect'>";
                    display += "<option value='-1' disabled selected hidden>" + subcat.Status + "</option>";
                    display += "<option value='1'>Active</option>";
                    display += "<option value='0'>Inactive</option></select>";
                    CategoryStatus.InnerHtml = display;
                }
            }
            else if(Request.QueryString["type"].ToString().Equals("Cat"))
            {
                 if(!IsPostBack)
                 {
                    //get the category by the category ID
                     dynamic category = SC.getCat(ID);
                     Details.InnerText = "SubCategory Details";
                     editName.InnerText = "Edit " + category.Name;
                     name.Value = category.Value;
                     display = "<label for='statusSelect' class='form-control-label'>Status</label>";
                     display += "<select class='form-control' id='statusSelect'>";
                     display += "<option value='-1' disabled selected hidden>" + category.Status + "</option>";
                     display += "<option value='1'>Active</option>";
                     display += "<option value='0'>Inactive</option></select>";
                     CategoryStatus.InnerHtml = display;
                 }
            }
        }

        protected void updateCat_ServerClick(object sender, EventArgs e)
        {
            int ID = 1;   //int.Parse(Request.QueryString["CatID"].ToString());
            dynamic sub = SC.getSubCat(ID);
            if (Request.QueryString["type"].ToString().Equals("SubCat"))
            {
                int updateSubcat = SC.updateSubCategories(ID, sub.CategoryID, name.Value, statusSelect.Value);//2 - refers to the category ID
                if(updateSubcat == 1)
                {
                    //Successfully updated
                    //error.Visible = true;
                    //error.InnerText = "Category updated";
                }else
                {
                    //error message
                   // error.Visible = true;
                   // error.InnerText = "An error occurred";
                } 
            }
            else if (Request.QueryString["type"].ToString().Equals("Cat"))
            {
                int updateCategory = SC.updateCategories(ID, name.Value, statusSelect.Value);
                if(updateCategory == 1)
                {
                    //updated Successfully
                    //error.Visible = true;
                    //error.InnerText = "Category updated";
                }
                else
                {
                    //show error
                    //error.Visible = true;
                   // error.InnerText = "An error occurred";
                }
            }
        }
    }
}