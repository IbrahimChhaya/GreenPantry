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
                    
                    cost.Value = Math.Round(product.Cost, 2).ToString().Replace(",", ".");
                    price.Value = Math.Round(product.Price, 2).ToString().Replace(",", ".");

                    dynamic subcats = SC.getAllSubCategories();
                    dynamic subcat = SC.getSubCat(product.SubCategoryID);
                    //display = "";
                    //display += "<label for='subcatSelect' class='form-control-label'>SubCategory</label>";
                    //display += "<select class='form-control' id='subcatSelect' runat='server' name='subcatSelect'>";
                    //display += "<option value='-1' disabled selected hidden>" + subcat.Name + "</option>";
                    //foreach (SubCategory s in subcats)
                    //{
                    //    display += "<option value='" + s.SubID + "'>" + s.Name + "</option>";
                    //}
                    //subcatList.InnerHtml = display + "</select>";

                    dropdownSub.Items.Add(subcat.Name);
                    foreach(SubCategory s in subcats)
                    {
                        if(s.SubID != subcat.SubID)
                            dropdownSub.Items.Add(s.Name);
                    }


                    if(product.Status.Equals("active"))
                    {
                        dropdownStatus.Items.Add("Active");
                        dropdownStatus.Items.Add("Inactive");
                    }
                    else
                    {
                        dropdownStatus.Items.Add("Inactive");
                        dropdownStatus.Items.Add("Active");
                    }
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
            int subID = 0;

            String sub = dropdownSub.SelectedValue;
            
            dynamic subcats = SC.getAllSubCategories();
            foreach(SubCategory s in subcats)
            {
                if(s.Name.Equals(sub))
                {
                    subID = s.SubID;
                }
            }

            if (imagePath.Equals(""))
            {
                int stockNum = int.Parse(stock.Value);
                String strName = name.Value;
                double dblPrice = Convert.ToDouble(price.Value.Replace('.', ','));
                double dblCost = Convert.ToDouble(cost.Value.Replace('.', ','));
                string img = product.Image_Location;
                string stat = dropdownStatus.Text.ToLower();
                int update = SC.updateProduct(productID, strName, subID, dblPrice, dblCost, img, stat, stockNum);
                if(update.Equals(1))
                {
                    error.Visible = true;
                    error.InnerText = "Product Updated";
                }
                else
                {
                    error.Visible = true;
                    error.InnerText = "An error occurred";
                }
            }
            else
            {
                int update = SC.updateProduct(productID, name.Value, subID, Convert.ToDouble(price.Value), Convert.ToDouble(cost.Value), imagePath, dropdownStatus.Text.ToLower(), int.Parse(stock.Value));
                if (update.Equals(1))
                {
                    error.Visible = true;
                    error.InnerText = "Product Updated";
                }
                else
                {
                    error.Visible = true;
                    error.InnerText = "An error occurred";
                }
            }
        }

        protected void removeProduct_ServerClick(object sender, EventArgs e)
        {

        }
    }
}