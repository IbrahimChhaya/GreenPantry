using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend.dashboard
{
    class Global
    {
        public static string imagePath;
    }

    public partial class editproduct : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ProductID"] == null)
            {
                Response.Redirect("dashboard.aspx");
            }
            else
            {
                int productID = int.Parse(Request.QueryString["ProductID"].ToString());

                if (productID.Equals(0))
                {
                    updateProduct.Visible = false;
                    addProduct.Visible = true;
                    editName.InnerText = "Add New Product ";

                    dynamic subcats = SC.getAllSubCategories();
                    foreach (SubCategory s in subcats)
                    {
                        dropdownSub.Items.Add(s.Name);
                    }

                    dropdownStatus.Items.Add("Active");
                    dropdownStatus.Items.Add("Inactive");
                }
                else
                {
                    dynamic product = SC.getProduct(productID);
                    if (!IsPostBack)
                    {
                        editName.InnerText = "Edit " + product.Name;
                        imgPath.InnerHtml = "<img src='../" + product.Image_Location + "' alt='Image placeholder' class='card-img-top'>";
                        name.Value = product.Name;
                        stock.Value = product.StockOnHand.ToString();
                        description.Value = product.Description;

                        cost.Value = Math.Round(product.Cost, 2).ToString().Replace(",", ".");
                        price.Value = Math.Round(product.Price, 2).ToString().Replace(",", ".");

                        dynamic subcats = SC.getAllSubCategories();
                        dynamic subcat = SC.getSubCat(product.SubCategoryID);

                        dropdownSub.Items.Add(subcat.Name);
                        foreach (SubCategory s in subcats)
                        {
                            if (s.SubID != subcat.SubID)
                                dropdownSub.Items.Add(s.Name);
                        }

                        if (product.Status.Equals("active"))
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
        }

        protected void upload_ServerClick(object sender, EventArgs e)
        {
            if (FileUpLoad1.HasFile)
            {
                error.Visible = false;
                Global.imagePath = Server.MapPath("/img/Products/") + FileUpLoad1.FileName;
                FileUpLoad1.SaveAs(Global.imagePath);
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
            int productID = int.Parse(Request.QueryString["ProductID"].ToString());
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

            if (Global.imagePath.Equals(""))
            {
                int stockNum = int.Parse(stock.Value);
                String strName = name.Value;
                double dblPrice = Convert.ToDouble(price.Value.Replace('.', ','));
                double dblCost = Convert.ToDouble(cost.Value.Replace('.', ','));
                string img = product.Image_Location;
                string stat = dropdownStatus.Text.ToLower();
                int update = SC.updateProduct(productID, strName, subID, dblPrice, dblCost, img, stat, stockNum, description.Value);
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
                int stockNum = int.Parse(stock.Value);
                String strName = name.Value;
                double dblPrice = Convert.ToDouble(price.Value.Replace('.', ','));
                double dblCost = Convert.ToDouble(cost.Value.Replace('.', ','));
                string stat = dropdownStatus.Text.ToLower();

                int index = Global.imagePath.IndexOf("img");
                string image = Global.imagePath.Substring(index);

                int update = SC.updateProduct(productID, strName, subID, dblPrice, dblCost, image, stat, stockNum, description.Value);
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

        protected void addProduct_ServerClick(object sender, EventArgs e)
        {
            //C:\Users\ibrah\Desktop\GreenPantryFrontend\GreenPantryFrontend\GreenPantryFrontend\img\Products\cabbage.jpg


            if (Global.imagePath == "")
            {
                error.Visible = true;
                error.InnerText = "Please upload an image";
            }
            else
            {
                int subID = 0;

                String sub = dropdownSub.SelectedValue;

                dynamic subcats = SC.getAllSubCategories();
                foreach (SubCategory s in subcats)
                {
                    if (s.Name.Equals(sub))
                    {
                        subID = s.SubID;
                    }
                }

                int stockNum = int.Parse(stock.Value);
                double dblPrice = Convert.ToDouble(price.Value.Replace('.', ','));
                double dblCost = Convert.ToDouble(cost.Value.Replace('.', ','));
                string stat = dropdownStatus.Text.ToLower();

                int index = Global.imagePath.IndexOf("img");
                string image = Global.imagePath.Substring(index);

                int addProduct = SC.addNewProduct(name.Value, subID, dblPrice, dblCost, stockNum, image, stat, description.Value);
                if (addProduct.Equals(-1))
                {
                    error.Visible = true;
                    error.InnerText = "An error occurred";
                }
                else
                {
                    Response.Redirect("editproduct.aspx?ProductID=" + addProduct);
                }
            }
        }
    }
}