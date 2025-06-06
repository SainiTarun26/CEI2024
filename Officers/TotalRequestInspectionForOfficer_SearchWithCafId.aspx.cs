﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CEIHaryana.Officers
{
    public partial class TotalRequestInspectionForOfficer_SearchWithCafId : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string LoginId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //var master = (MasterPage)Master;
                    //var loginTypeLabel = (Label)master.FindControl("LoginType");
                    //if (loginTypeLabel != null)
                    //{
                    //    loginTypeLabel.Text = "Admin / Dashboard / Total Inspection Request";
                    //}

                    if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        GridBind();
                        BindDropDownForDivision();
                    }
                    else
                    {
                        Session["StaffID"] = "";
                        Response.Redirect("/OfficerLogout.aspx", false);
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
                string searchText = txtSearch.Text.Trim();
                LoginId = Convert.ToString(Session["StaffID"]);
                string id = ddldivision.SelectedValue.ToString();
                string InstallationType = RadioButtonList1.SelectedValue.ToString();
                string UserType = RadioButtonList2.SelectedValue.ToString();
                DataSet ds = new DataSet();
                ds = CEI.TotalRequestInspectionForStaff_SearchCafWithGlobalFilter(LoginId, id, InstallationType, searchText, UserType);
                if (ds.Tables.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                //throw;
            }

        }

        private void BindDropDownForDivision()
        {
            try
            {
                DataSet dsDivision = new DataSet();
                dsDivision = CEI.DdlForDivision();
                ddldivision.DataSource = dsDivision;
                ddldivision.DataTextField = "HeadOffice";
                ddldivision.DataValueField = "HeadOffice";
                ddldivision.DataBind();
                ddldivision.Items.Insert(0, new ListItem("Select", "0"));
                dsDivision.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval"] = lblApproval.Text.Trim();
                Label lblInstallationFor = (Label)row.FindControl("lblInstallationFor");
                string id = lblID.Text;
                Session["InspectionId"] = id;
                if (e.CommandName == "Select")
                {
                    if (lblInstallationFor.Text == "Lift" || lblInstallationFor.Text == "Escalator" || lblInstallationFor.Text == "Lift/Escalator" || lblInstallationFor.Text == "MultiLift" || lblInstallationFor.Text == "MultiEscalator")
                    {
                        Response.Redirect("/Officers/LiftInspectionDetails.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("/Officers/InspectionDetails.aspx", false);
                    }
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch { }
        }

        protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ddldivision.SelectedValue.ToString();
            GridBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string InstallationType = RadioButtonList1.SelectedValue.ToString();
            GridBind();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string enteredText = txtSearch.Text;
            if (enteredText.Length >= 4)
            {
                GridBind();
            }
            if (enteredText.Length == 0)
            {
                GridBind();
            }
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string InstallationType = RadioButtonList2.SelectedValue.ToString();
            GridBind();
        }
        //public void divisionWise()
        //{
        //    try
        //    {
        //        string id = ddldivision.SelectedValue.ToString();
        //        LoginId = Convert.ToString(Session["StaffID"]);
        //        DataSet ds = new DataSet();
        //        ds = CEI.TotalRequestAcc_Division(LoginId, id);

        //    }
        //    catch (Exception ex)
        //    { }
        //}
    }
}