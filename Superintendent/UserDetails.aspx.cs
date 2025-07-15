using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Superintendent
{
    public partial class UserDetails : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["SuperidentId"]) != null && Convert.ToString(Session["SuperidentId"]) != string.Empty)
                    {
                        string Id = Session["SuperidentId"].ToString();
                        DataTable ds = new DataTable();
                        ds = CEI.GETActiveSuperident(Id);
                        if (ds.Rows.Count > 0)
                        {
                            BindDistrict();
                            GridBind();
                        }
                        else
                        {
                           
                            string script = "alert(\"No any request submit for Licence yet.\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        }
                      
                    }
                  
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/OfficerLogout.aspx");
            }
        }
        private void BindDistrict()
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDistrict();
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "AreaCovered";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('An Error Occured');", true);
            }
        }
        public void GridBind()
        {
            try
            {
                string District = ddlDistrict.SelectedItem.ToString();
                string Category = ddlcategory.SelectedItem.ToString();
                string Status = ddlApplicationStatus.SelectedItem.ToString();
                DataTable ds = new DataTable();
                ds = CEI.BindDataForSuperident(Category, District, Status, txtName.Text.Trim());
                if (ds.Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No any User exist.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            Label lblID = (Label)row.FindControl("lblID");
            Label lblStatus = (Label)row.FindControl("lblStatus");
            Label lblRegistrationId = (Label)row.FindControl("lblRegistrationId");
            Label lblCategory = (Label)row.FindControl("lblCategory");
            if (e.CommandName == "Select")
            {
                Session["Application_Id"] = lblID.Text;
                //Session["Superidentent"] = "SUP_CDG";

                Response.Redirect("/Superintendent/CommentForRequest.aspx", false);


            }
            else if (e.CommandName == "Print")
            {
                if(lblCategory.Text == "Contractor")
                {
                    Session["NewApplication_Contractor_RegNo"] = lblRegistrationId.Text;
                    Response.Redirect("/UserPages/New_Registration_Information_Contractor.aspx", false);
                }
                else
                {
                    Session["NewApplicationRegistrationNo"] = lblRegistrationId.Text;
                    Response.Redirect("/UserPages/New_Registration_Information.aspx", false);
                }
              
            }
        }
                 
        protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlSearchBy.SelectedValue == "1")
            {
                district.Visible= true;
                ddlApplicationStatus.SelectedValue = "0";
                txtName.Text = "";
                Name.Visible = false;
                AppStatus.Visible = false;
            }
           else if (ddlSearchBy.SelectedValue == "2")
            {
                ddlApplicationStatus.SelectedValue = "0";
                txtName.Text = "";
                Name.Visible = false;
                district.Visible = false;
                AppStatus.Visible= true;
            }
            else if(ddlSearchBy.SelectedValue == "3")
            {
                ddlDistrict.SelectedValue = "0";
                ddlApplicationStatus.SelectedValue = "0";
                district.Visible = false;
                AppStatus.Visible = false;
                Name.Visible= true;
            }
            else
            {
                ddlDistrict.SelectedValue = "0";
                ddlApplicationStatus.SelectedValue = "0";
                ddlSearchBy.SelectedValue = "0";
                txtName.Text = "";
                district.Visible = false;
                AppStatus.Visible = false;
                Name.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlcategory.SelectedValue != "0")
            {
                if (ddlSearchBy.SelectedValue != "0")
                {
                    if (ddlSearchBy.SelectedValue == "1")
                    {


                        if (ddlDistrict.SelectedItem.ToString() == "Select")
                        {
                            ddlDistrict.Focus();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please Select District by to proceed.');", true);
                            return;
                        }
                    }
                    else if (ddlSearchBy.SelectedValue == "2")
                    {
                        ddlDistrict.SelectedValue = "0";
                        if (ddlApplicationStatus.SelectedItem.ToString() == "Select")
                        {
                            ddlApplicationStatus.Focus();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please Select Status by to proceed.');", true);
                            return;
                        }

                    }
                    else if (ddlSearchBy.SelectedValue == "3")
                    {

                        if (string.IsNullOrWhiteSpace(txtName.Text))
                        {
                            txtName.Focus();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please Enter the name  to proceed.');", true);
                            return;

                        }
                    }

                    GridBind();
                }
                else
                {
                    ddlSearchBy.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please Select Search by to proceed.');", true);
                    return;
                }
            }
            else
            {
                ddlcategory.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please Select Category to proceed.');", true);
                return;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlcategory.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";
            ddlApplicationStatus.SelectedValue = "0";
            ddlSearchBy.SelectedValue = "0";
            txtName.Text = "";
            district.Visible = false;
            AppStatus.Visible = false;
            Name.Visible = false;
            GridBind();
        }
    }
}