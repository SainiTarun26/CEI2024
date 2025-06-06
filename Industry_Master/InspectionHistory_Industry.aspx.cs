﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;


namespace CEIHaryana.Industry_Master
{
    public partial class InspectionHistory_Industry : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId_Industry"] != null && Convert.ToString(Session["SiteOwnerId_Industry"]) != "")
                    {
                        BindGrid();
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata_InvalidSession();", true);
                    }
                }
            }
            catch(Exception ex)
            {
                string script = "alert('" + ex.Message.Replace("'", "\\'") + "'); window.location = 'https://staging.investharyana.in/#/';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
            }
        }

        public void BindGrid()
        {
            string LoginID = string.Empty;
            string Districtlocalpr = null;
            //added on 24 feb 2025 to filter district records against a panno
            LoginID = Session["SiteOwnerId_Industry"].ToString();
            if (Session["district_Temp"] != null)
            {
                Districtlocalpr = Session["district_Temp"].ToString();
            }
            DataTable ds = new DataTable();
            //ds = CEI.SiteOwnerInspectionData_Industries(LoginID);
            //added on 24 feb 2025 to filter district records against a panno
            ds = CEI.SiteOwnerInspectionData_Industries(LoginID, Districtlocalpr);
            if (ds.Rows.Count > 0)
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select" || e.CommandName == "Print" || e.CommandName == "Print1")
            {
              string  LoginID = Session["SiteOwnerId_Industry"].ToString();
                Session["LineID_Industry"] = "";
                Session["SubStationID_Industry"] = "";
                Session["GeneratingSetId_Industry"] = "";
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Session["InspectionId_Industry"] = lblID.Text;
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval_Industry"] = lblApproval.Text.Trim();
                Label lblTestRportId = (Label)row.FindControl("lblTestRportId");
                Label lblType = (Label)row.FindControl("lblType");
                Label LblInspectionType = (Label)row.FindControl("LblInspectionType");
                Label LblAssignTo = (Label)row.FindControl("LblAssignTo");
                if (lblType.Text.Trim() == "Line")
                {
                    Session["LineID_Industry"] = lblTestRportId.Text.Trim();
                }
                else if (lblType.Text.Trim() == "Substation Transformer")
                {
                    Session["SubStationID_Industry"] = lblTestRportId.Text.Trim();
                }
                else if (lblType.Text.Trim() == "Generating Set")
                {
                    Session["GeneratingSetId_Industry"] = lblTestRportId.Text.Trim();
                }
                if (e.CommandName == "Select")
                {
                    Response.Redirect("/Industry_Master/Inspection_Industry.aspx");
                }
                else if (e.CommandName == "Print")
                {
                    Response.Redirect("/Industry_Master/InspectionRequestPrint_Industry.aspx");
                }
                else if (e.CommandName == "Print1")
                {
                    if (LblInspectionType.Text == "New")
                    {

                        if (lblType.Text == "Multiple")
                        {
                            Response.Redirect("/Print_Forms/NewInspectionApprovalCertificate_Industry.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("/Print_Forms/PrintCertificate1_Industry.aspx", false);

                        }
                    }
                    else
                    {

                        Response.Redirect("/Print_Forms/PeriodicApprovalCertificate_Industry.aspx", false);
                    }
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton linkButton = (LinkButton)e.Row.FindControl("lnkPrint");
                string applicationStatus = DataBinder.Eval(e.Row.DataItem, "ApplicationStatus").ToString();
                string AssignTo = DataBinder.Eval(e.Row.DataItem, "AssignTo").ToString();
                if (applicationStatus == "Approved")
                {
                    if (string.IsNullOrEmpty(AssignTo))
                    {
                        linkButton.Visible = false;
                    }
                    else
                    {
                        linkButton.Visible = true;
                    }

                }
                int reportTypeColumnIndex = 9;
                TableCell reportTypeCell = e.Row.Cells[reportTypeColumnIndex];

                if (reportTypeCell.Text == "Returned")
                {
                    e.Row.CssClass = "ReturnedRowColor";
                }
                //else
                //{

                //    linkButton.Visible = false;
                //}
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch { }
        }
    }
}