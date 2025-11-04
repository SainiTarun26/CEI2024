using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Superintendent
{
    public partial class Pending_Final_Recommendations_List : System.Web.UI.Page
    {
        //Page Created by aslam 18-June-2025
        CEI CEI = new CEI();
        string LoginID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["SuperidentId"]) != null || Convert.ToString(Session["SuperidentId"]) != string.Empty)
                    {
                        BindDistrict();
                        BindApplicationStatus();
                        GridBind();
                       
                    }
                    else
                    {
                        Response.Redirect("/OfficerLogout.aspx");
                        return;

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/OfficerLogout.aspx");
            }
        }
        public void GridBind()
        {
            try
            {

                string District = ddlDistrict.SelectedItem.ToString();
                string Category = ddlcategory.SelectedItem.ToString();
                string Status = ddlApplicationStatus.SelectedValue;
                if (Status == "0" || string.IsNullOrEmpty(Status))
                {
                    Status = null;
                }
                
                DataSet ds = new DataSet();
               
                ds = CEI.Licence_Sup_Pending_FinalRecommendationList(Category, District, Status, txtName.Text.Trim());

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();

                }

                ds.Dispose();
            }
            catch (Exception ex)
            {
                string errorScript = "alert(\"An error occurred: " + ex.Message.Replace("'", "\\'") + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", errorScript, true);
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblApplicationId = (Label)row.FindControl("lblApplicationId");
                Session["Application_Id"] = lblApplicationId.Text.ToString();
                Response.Redirect("Pending_Final_Recommendations.aspx", false);
                return;
            }
            else
            {

            }
        }


        protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSearchBy.SelectedValue == "1")
            {
                district.Visible = true;
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
                AppStatus.Visible = true;
            }
            else if (ddlSearchBy.SelectedValue == "3")
            {
                ddlDistrict.SelectedValue = "0";
                ddlApplicationStatus.SelectedValue = "0";
                district.Visible = false;
                AppStatus.Visible = false;
                Name.Visible = true;
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
            GridBind();
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

        private void BindApplicationStatus()
        {
            DataTable dt = CEI.GetApplicationStatus();

            ddlApplicationStatus.DataSource = dt;
            ddlApplicationStatus.DataTextField = "ApplicationStatus";
            ddlApplicationStatus.DataValueField = "ApplicationStatus";
            ddlApplicationStatus.DataBind();

            // Add a default option at the top
            ddlApplicationStatus.Items.Insert(0, new ListItem("Select", "0"));

            ddlApplicationStatus.SelectedValue = "0";
        }

    }
}