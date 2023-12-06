using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend.dashboard
{
    public partial class edithome : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["action"].ToString().Equals("1"))
            {
                int id = int.Parse(Request.QueryString["ID"].ToString());
                dynamic settings = SC.getSetting(id);
                if (!IsPostBack)
                {
                    mainText.Value = settings.Field1;
                    caption.Value = settings.Field2;
                    string image = settings.Field4;
                    imgPath.InnerHtml = "<img src='../" + image + "' alt='Image placeholder' class='card-img-top'>";
                }
            }
            else if (Request.QueryString["action"].ToString().Equals("0"))
            {
                int id = int.Parse(Request.QueryString["ID"].ToString());
                dynamic settings = SC.getSetting(id);
                hideCat.Visible = true;
                if (!IsPostBack)
                {
                    int catID = int.Parse(settings.Field3);
                    dynamic getCat = SC.getCat(catID);
                    dropdownCat.Items.Clear();
                    dropdownCat.Items.Add(getCat.Name);
                    dynamic cats = SC.getAllCategories();
                    foreach (ProductCategory c in cats)
                    {
                        if (c.ID != getCat.ID)

                            dropdownCat.Items.Add(c.Name);
                    }
                    mainText.Value = settings.Field1;
                    caption.Value = settings.Field2;
                    string image = settings.Field4;
                    imgPath.InnerHtml = "<img src='../" + image + "' alt='Image placeholder' class='card-img-top'>";
                }
            }
        }

        protected void upload_ServerClick(object sender, EventArgs e)
        {
            if (FileUpLoad1.HasFile)
            {
                error.Visible = false;
                Global.imagePath = Server.MapPath("/img/banner/") + FileUpLoad1.FileName;
                string extension = Path.GetExtension(FileUpLoad1.FileName);
                if (extension.Equals(".jpg") || extension.Equals(".png"))
                {

                    FileUpLoad1.SaveAs(Global.imagePath);
                    imgPath.InnerHtml = "<img src='../img/banner/" + FileUpLoad1.FileName + "' alt='Image placeholder' class='card-img-top'>";
                }
                else
                {
                    error.Visible = true;
                    error.InnerText = "Please enter a valid image type (.jpg or .png)";
                }
            }
            else
            {
                error.Visible = true;
                error.InnerText = "Error: No image uploaded";
            }
        }

        protected void updateHome_ServerClick(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["ID"].ToString());

            dynamic cats = SC.getAllCategories();
            string cat = dropdownCat.SelectedValue;
            int catID = 0;
            foreach (ProductCategory c in cats)
            {
                if (c.Name.Equals(cat))
                {
                    catID = c.ID;
                }
            }


            if (Global.imagePath == "" || Global.imagePath == null)
            {
                dynamic setting = SC.getSetting(id);
                string img = setting.Field4;

                int updateSettings = SC.updateSettings(id, mainText.Value, caption.Value, catID.ToString(), img);
                if (updateSettings.Equals(1))
                {

                    error.Visible = true;
                    error.InnerText = "Updated";
                }
                else
                {
                    error.Visible = true;
                    error.InnerText = "An error occurred";
                }
            }
            else
            {
                int index = Global.imagePath.IndexOf("img");
                string image = Global.imagePath.Substring(index);
                image = image.Replace('\\', '/');

                int updateSettings = SC.updateSettings(id, mainText.Value, caption.Value, catID.ToString(), image);
                if (updateSettings.Equals(1))
                {

                    error.Visible = true;
                    error.InnerText = "Updated";
                }
                else
                {
                    error.Visible = true;
                    error.InnerText = "An error occurred";
                }
            }
        }
    }
}