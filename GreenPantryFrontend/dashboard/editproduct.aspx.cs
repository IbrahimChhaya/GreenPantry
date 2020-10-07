using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend.dashboard
{
    public partial class editproduct : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();
        String imagePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //load the product with URL parameter product ID
            //if(Request.QueryString["ProductID"] == null)
            //{
            //    Response.Redirect("dashboard.aspx");
            //}
            //else
            {
                String display = "";
                int productID = 1; // int.Parse(Request.QueryString["ProductID"].ToString());
                dynamic product = SC.getProduct(productID);
                if (!IsPostBack)
                {
                    editName.InnerText = "Edit " + product.Name;
                    imgPath.InnerHtml = "<img src='../" + product.Image_Location + "' alt='Image placeholder' class='card-img-top'>";
                    name.Value = product.Name;
                    stock.Value = product.StockOnHand.ToString();
                    description.Value = product.Name; //.Description;

                    display = "<label for='statusSelect' class='form-control-label'>Status</label>";
                    display += "<select class='form-control' id='statusSelect'>";
                    display += "<option value='-1' disabled selected hidden>" +  product.Status + "</option>";
                    display += "<option value='1'>Active</option>";
                    display += "<option value='0'>Inactive</option></select>";
                    statusDropdown.InnerHtml = display;
                }
            }
        }

        protected void upload_ServerClick(object sender, EventArgs e)
        {
            if (FileUpLoad1.HasFile)
            {
                error.Visible = false;
                imagePath = Server.MapPath("/img/Products/") + FileUpLoad1.FileName;
                FileUpLoad1.SaveAs(imagePath);
                imgPath.InnerHtml = "<img src='../img/Products/" + FileUpLoad1.FileName + "' alt='Image placeholder' class='card-img-top'>";
            }
            else
            {
                error.Visible = true;
                error.InnerText = "Error: No image uploaded";
            }
        }

        protected void updateProduct_ServerClick(object sender, EventArgs e)
        {
            //update the product using imagePath global var
            int productID = 1; // int.Parse(Request.QueryString["ProductID"].ToString());
            dynamic product = SC.getProduct(productID);
            if (imagePath.Equals(""))
            {
                //int update = SC.updateProduct(productID, name.Value, subcatSelect.Value, 
            }
        }
    }
}