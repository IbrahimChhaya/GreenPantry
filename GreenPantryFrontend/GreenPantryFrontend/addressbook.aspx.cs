using GreenPantryFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenPantryFrontend
{
    public partial class addressbook : System.Web.UI.Page
    {
        GP_ServiceClient SC = new GP_ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["LoggedInUserID"] != null)
            {
                if (Request.QueryString["action"] == null)
                {
                    if (Request.QueryString["ID"] == null)
                    {
                        int userID = int.Parse(Session["LoggedInUserID"].ToString());
                        dynamic address = SC.getUserAddresses(userID);
                        if (address == null)
                        {
                            newAddress.Visible = true;
                            oldAddress.Visible = false;
                            Submit.Visible = true;
                        }
                        else
                        {
                            string display = "";
                            newAddress.Visible = false;
                            oldAddress.Visible = true;
                            if(address.Length == 2)
                            {
                                addNew.Visible = false;
                            }

                            foreach (Address a in address)
                            {
                                display += "<div class='checkout__order'>";
                                if (a.Primary.Equals(1))
                                {
                                    display += "<div><label><b>" + a.Type + "</b> <span class='badge badge-success'>PRIMARY</span></label></div>";
                                }
                                else
                                {
                                    display += "<div><label><b>" + a.Type + "</b></label></div>";
                                }
                                display += "<div><label>" + a.Line1 + "</label></div>";
                                if (a.Line2 != "" || a.Line2 != null)
                                {
                                    display += "<div><label>" + a.Line2 + "</label></div>";
                                }
                                display += "<div><label>" + a.Suburb + ", " + a.City + ", " + a.Zip + "</label></div>";
                                display += "<div><label>" + a.Number + "</label></div>";
                                display += "<div><label class='gpLabel2' style='float:right;'><a href='addressbook.aspx?action=0&ID=" + a.ID + "'>Delete</a></label>";
                                display += "<label class='gpLabel2' style='float:right;'><a href='addressbook.aspx?action=1&ID=" + a.ID + "'>Edit</a></label>";
                                if (a.Primary.Equals(0))
                                {
                                    display += "<label class='gpLabel2' style='float:right;'><a href='addressbook.aspx?action=2&ID=" + a.ID + "'>Set as Primary</a></label>";
                                }
                                display += "</div></div><br />";
                            }
                            oldAddress.InnerHtml = display;
                        }
                    }
                    else if (Request.QueryString["ID"].ToString() == "0")
                    {
                        newAddress.Visible = true;
                        oldAddress.Visible = false;
                        Submit.Visible = true;
                        addNew.Visible = false;
                    }
                }
                else
                {
                    string action = Request.QueryString["action"].ToString();
                    int addID = int.Parse(Request.QueryString["ID"].ToString());
                    //delete
                    if(action.Equals("0"))
                    {
                        deleteAddress(addID);
                    }
                    //edit
                    else if(action.Equals("1"))
                    {
                        editAddress(addID, 0);
                    }
                    //set as primary
                    else
                    {
                        setAsPrimary(addID);
                    }
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string firstLine = line1.Value;
            string secondLine = line2.Value;
            string sub = suburb.Value;
            string city = town.Value;
            string pro = provincesList.Value;
            int zip = int.Parse(postcode.Value);
            int userID = int.Parse(Session["LoggedInUserID"].ToString());
            string phone = number.Value;
            dynamic existAdd = SC.getUserAddresses(userID);
            int addAddress;
            if (provincesList.Value != "Province")
            {
                if (existAdd == null)
                {
                    addAddress = SC.addAddress(firstLine, secondLine, sub, city, zip, type.Value, userID, pro, 1, phone);
                }
                else
                {
                    addAddress = SC.addAddress(firstLine, secondLine, sub, city, zip, type.Value, userID, pro, 0, phone);
                }
                if (addAddress.Equals(1))
                {
                    Response.Redirect("addressbook.aspx");
                }
                else
                {
                    error.Visible = true;
                    error.Text = "An error occurred";
                }
            }
            else
            {
                error.Visible = true;
                error.Text = "Please select a province";
            }    
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["LoggedInUserID"] = null;
            Response.Redirect("/home.aspx");
        }

        private void deleteAddress(int addID)
        {
            int deleteAdd = SC.deleteAddress(addID);
            if(deleteAdd.Equals(1))
            {
                Response.Redirect("addressbook.aspx");
            }
            else
            {
                //error
                error.Visible = true;
                error.Text = "An error occurred";
            }
        }

        private void editAddress(int addID, int primary)
        {
            addNew.Visible = false;
            oldAddress.Visible = false;
            newAddress.Visible = true;
            updateBtn.Visible = true;

            dynamic address = SC.getAddress(addID);
            if (!IsPostBack)
            {
                aID.Value = addID.ToString();
                if (primary.Equals(1))
                {
                    pr.Value = primary.ToString();
                }
                else
                {
                    pr.Value = address.Primary.ToString();
                }
                type.Value = address.Type;
                line1.Value = address.Line1;
                line2.Value = address.Line2;
                suburb.Value = address.Suburb;
                town.Value = address.City;
                provincesList.Value = address.Province;
                postcode.Value = address.Zip.ToString();
                number.Value = address.Number;
            }
        }

        private void setAsPrimary(int addID)
        {
            dynamic a = SC.getAddress(addID);
            //a is address
            int userID = int.Parse(Session["LoggedInUserID"].ToString());
            dynamic cp = SC.getPrimaryAddress(userID);
            //cp is current primary
            int updatePrimary = SC.updateAddress(cp.Line1, cp.Line2, cp.Suburb, cp.City, cp.Province, cp.Zip, cp.Type, cp.ID, 0, cp.Number);
            int updateAdd = SC.updateAddress(a.Line1, a.Line2, a.Suburb, a.City, a.Province, a.Zip, a.Type, addID, 1, a.Number);
            Response.Redirect("addressbook.aspx");
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            //if(line1.Value == "" && line2.Value, suburb.Value, town.Value, provincesList.Value)


            int update = SC.updateAddress(line1.Value, line2.Value, suburb.Value, town.Value, provincesList.Value, int.Parse(postcode.Value), type.Value, int.Parse(aID.Value), int.Parse(pr.Value), number.Value);
            if(update.Equals(1))
            {
                Response.Redirect("addressbook.aspx");
            }
        }
    }
}