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
            //load category or subcat using URL parameter
            if(Request.QueryString["type"].ToString().Equals("SubCat"))
            {
                int subID = int.Parse(Request.QueryString["CatID"].ToString());
                if(subID.Equals(0))
                {
                    updateCat.Visible = false;
                    addCat.Visible = true;
                    editName.InnerText = "Add New SubCategory ";

                    catDropdown.Visible = true;
                    dynamic cats = SC.getAllCategories();
                    foreach (ProductCategory c in cats)
                    {
                        dropdownCat.Items.Add(c.Name);
                    }

                    dropdownStatus.Items.Add("Active");
                    dropdownStatus.Items.Add("Inactive");
                }
                else
                {
                    if (!IsPostBack)
                    {
                        //Get the subcategory by the ID
                        dynamic subcat = SC.getSubCat(subID);
                        Details.InnerText = "SubCategory Details";
                        editName.InnerText = "Edit " + subcat.Name;
                        name.Value = subcat.Name;

                        dropdownStatus.Items.Clear();
                        if (subcat.Status.Equals("active"))
                        {
                            dropdownStatus.Items.Add("Active");
                            dropdownStatus.Items.Add("Inactive");
                        }
                        else
                        {
                            dropdownStatus.Items.Add("Inactive");
                            dropdownStatus.Items.Add("Active");
                        }

                        catDropdown.Visible = true;
                        dynamic catList = SC.getAllCategories();
                        dynamic cat = SC.getCat(subcat.CategoryID);

                        dropdownCat.Items.Clear();
                        dropdownCat.Items.Add(cat.Name);
                        foreach (ProductCategory c in catList)
                        {
                            if (c.ID != subcat.CategoryID)
                                dropdownCat.Items.Add(c.Name);
                        }
                    }
                }
            }
            else if(Request.QueryString["type"].ToString().Equals("Cat"))
            {
                int catID = int.Parse(Request.QueryString["CatID"].ToString());
                if(catID.Equals(0))
                {
                    updateCat.Visible = false;
                    addCat.Visible = true;
                    editName.InnerText = "Add New Category ";

                    dropdownStatus.Items.Add("Active");
                    dropdownStatus.Items.Add("Inactive");
                }
                else
                {
                    if (!IsPostBack)
                    {
                        //get the category by the category ID
                        dynamic category = SC.getCat(catID);
                        Details.InnerText = "Category Details";
                        editName.InnerText = "Edit " + category.Name;
                        name.Value = category.Name;

                        dropdownStatus.Items.Clear();
                        if (category.Status.Equals("active"))
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
            else
            {
                Response.Redirect("dashboard.aspx");
            }
        }

        protected void updateCat_ServerClick(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["CatID"].ToString());
            if (Request.QueryString["type"].ToString().Equals("SubCat"))
            {
                dynamic cats = SC.getAllCategories();
                string cat = dropdownCat.SelectedValue;
                int catID = 0;
                foreach(ProductCategory c in cats)
                {
                    if(c.Name.Equals(cat))
                    {
                        catID = c.ID;
                    }
                }
                string stat = dropdownStatus.Text.ToLower();

                int updateSubcat = SC.updateSubCategories(ID, catID, name.Value, stat);
                if(updateSubcat == 1)
                {
                    //Successfully updated
                    error.Visible = true;
                    error.InnerText = "SubCategory updated";
                }
                else
                {
                    //error message
                    error.Visible = true;
                    error.InnerText = "An error occurred";
                } 
            }
            else if (Request.QueryString["type"].ToString().Equals("Cat"))
            {
                string stat = dropdownStatus.Text.ToLower();
                int updateCategory = SC.updateCategories(ID, name.Value, stat);
                if(updateCategory == 1)
                {
                    //updated Successfully
                    error.Visible = true;
                    error.InnerText = "Category updated";
                }
                else
                {
                    //show error
                    error.Visible = true;
                    error.InnerText = "An error occurred";
                }
            }
        }

        protected void addCat_ServerClick(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["CatID"].ToString());
            if (Request.QueryString["type"].ToString().Equals("SubCat"))
            {
                int catID = 0;

                String cat = dropdownCat.SelectedValue;

                dynamic cats = SC.getAllCategories();
                foreach (ProductCategory c in cats)
                {
                    if (c.Name.Equals(cat))
                    {
                        catID = c.ID;
                    }
                }
                string stat = dropdownStatus.Text.ToLower();

                int addSub = SC.addSubCategory(catID, name.Value, stat);
                if (addSub.Equals(-1))
                {
                    error.Visible = true;
                    error.InnerText = "An error occurred";
                }
                else
                {
                    Response.Redirect("editcat.aspx?type=SubCat&CatID=" + addSub);
                }
            }
            else if (Request.QueryString["type"].ToString().Equals("Cat"))
            {
                string stat = dropdownStatus.Text.ToLower();

                int addCat = SC.addCategory(name.Value, stat);
                if (addCat.Equals(-1))
                {
                    error.Visible = true;
                    error.InnerText = "An error occurred";
                }
                else
                {
                    Response.Redirect("editcat.aspx?type=Cat&CatID=" + addCat);
                }
            }
        }
    }
}