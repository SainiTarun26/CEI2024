﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using iText.Layout.Element;
using Pipelines.Sockets.Unofficial.Arenas;

namespace CEIHaryana.Industry_Master.SiteOwnerPages
{
    public partial class Inspection_Lift_New_IndustryLift : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string Id = string.Empty;
        DateTime inspectionCreatedDate;
        string voltage = string.Empty;
        string id = string.Empty;
        string CartId = string.Empty;
        string ReturnedBased = string.Empty;
        private static string IType = string.Empty;
        bool Edit = false;
        private bool hasLinkInAnyRow = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId_IndustryLift"]) != null && Convert.ToString(Session["SiteOwnerId_IndustryLift"]) != "")
                    {
                        if (Convert.ToString(Session["InspectionId_IndustryLift"]) != null && Convert.ToString(Session["InspectionId_IndustryLift"]) != "")
                        {
                            ID = Session["InspectionId_IndustryLift"].ToString();
                            GetDetailsWithId(ID);
                            GridBind(ID);
                            GetTestReportData(ID);
                            Session["PreviousPage_IndustryLift"] = "";
                        }
                    }
                    else
                    {
                        Response.Redirect("/login.aspx", false);
                    }
                }

            }
            catch (Exception ex)
            {
                //
            }

        }

        //testreport componenet gridview for periodic
        private void GetTestReportDataIfPeriodic()
        {
            try
            {
                if (Convert.ToString(Session["InspectionId_IndustryLift"]) != null && Convert.ToString(Session["InspectionId_IndustryLift"]) != "")
                {
                    ID = Session["InspectionId_IndustryLift"].ToString();
                    DataSet ds = new DataSet();
                    //ds = CEI.GetTestReportDataIfPeriodic(ID);
                    ds = CEI.GetDetailsToViewCart_Lift_Escalator_IndustryLift(ID);

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        periodicTestReport.Visible = true;
                        GridViewForPeriodicTestReport.DataSource = ds;
                        GridViewForPeriodicTestReport.DataBind();
                    }
                    else
                    {
                        GridViewForPeriodicTestReport.DataSource = null;
                        GridViewForPeriodicTestReport.DataBind();

                    }
                    ds.Dispose();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "alert('yur inspectionid is lost,please go back');", true);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void GetDetailsWithId(string InspectionId)
        {
            try
            {

                DataSet ds = new DataSet();
                ds = CEI.InspectionData_Lift_Escalator_IndustryLift(ID);

                IType = ds.Tables[0].Rows[0]["IType"].ToString();
                //Added By aslam 2-June-2025
                lblInspectionType.Text = ds.Tables[0].Rows[0]["IType"].ToString();
                //txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                string createdDate = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                DateTime.TryParse(createdDate, out inspectionCreatedDate);
                txtApplicationNo.Text = ds.Tables[0].Rows[0]["InspectionReportID"].ToString();
                txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                if (IType == "New")
                {
                    //string InspectionType = ds.Tables[0].Rows[0]["IType"].ToString();
                    // txtInspectionType.Text= ds.Tables[0].Rows[0]["IType"].ToString();
                    //voltagelevel.Visible = true;
                    // Type.Visible = true;

                    string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                    if (Status == "Rejected")
                    {
                        Rejection.Visible = true;
                        txtRejected.Text = ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                        ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));

                        ddlReview.Attributes.Add("disabled", "true");
                        txtRejected.Attributes.Add("disabled", "true");
                        btnBack.Visible = true;
                        btnSubmit.Visible = false;
                    }
                    if (Status == "Return")
                    {
                        Reason.Visible = true;
                        //ApprovalRequired.Visible = false;
                        btnSubmit.Visible = false;
                        txtReason.Text = ds.Tables[0].Rows[0]["ReturnReason"].ToString();
                        //buttonSubmit.Visible = true;
                        //Remarks.Visible = true;

                        //Rejection.Visible = true;
                        //txtRejected.Text = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
                        //ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                        //ApprovedReject.Visible = true;
                        //ApprovalRequired.Visible = false;
                        //ddlReview.Attributes.Add("disabled", "true");
                        //txtRejected.Attributes.Add("disabled", "true");
                    }
                    //string Reason = ds.Tables[0].Rows[0]["ReasonType"].ToString();

                    GridToViewTRinMultipleCaseNew();

                    Div1.Visible = true;
                    DivViewTRinMultipleCaseNew.Visible = true;

                }
                else if (IType == "Periodic")
                {
                    //txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                    //txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                    //txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                    //Session["TestReport"] = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                    //txtApplicationNo.Text = ds.Tables[0].Rows[0]["InspectionReportID"].ToString();
                    //txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                    //ReturnedBased = ds.Tables[0].Rows[0]["ReasonType"].ToString();

                    //string createdDate = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                    //DateTime.TryParse(createdDate, out inspectionCreatedDate);
                    //string InspectionType = ds.Tables[0].Rows[0]["IType"].ToString();

                    //voltagelevel.Visible = false;
                    //Type.Visible = false;
                    // GridView2.Columns[3].Visible = false;
                    //GridView2.Columns[5].Visible = false;

                    //DivViewCart.Visible = true;
                    //GridToViewCart();
                    GetTestReportDataIfPeriodic();

                    string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                    if (Status == "Rejected")
                    {
                        Rejection.Visible = true;
                        txtRejected.Text = ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                        ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                        ddlReview.Attributes.Add("disabled", "true");
                        txtRejected.Attributes.Add("disabled", "true");
                        btnBack.Visible = true;
                        btnSubmit.Visible = false;
                    }
                    if (Status == "Return")
                    {
                        ApprovalRequired.Visible = false;
                        btnSubmit.Visible = false;
                        Reason.Visible = true;
                        txtReason.Text = ds.Tables[0].Rows[0]["ReturnReason"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void lnkRedirect_Click(object sender, EventArgs e)
        {
            LinkButton lnkRedirect = (LinkButton)sender;
            string testReportId = lnkRedirect.CommandArgument;
            //Session["InspectionTestReportId"] = testReportId;
            if (txtWorkType.Text.Trim() == "Line")
            {
                Session["LineID"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
            }
            else if (txtWorkType.Text.Trim() == "Substation Transformer")
            {
                Session["SubStationID"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
            }
            else if (txtWorkType.Text.Trim() == "Generating Set")
            {
                Session["GeneratingSetId"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
            }

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Session["PeriodicInspection"] != null)
            {
                Response.Redirect("/SiteOwnerPages/PeroidicInspection.aspx", false);
            }
            else
            {
                Response.Redirect("/Industry_Master/SiteOwnerPages/InspectionHistory_New_IndustryLift.aspx", false);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Session["SiteOwnerId_IndustryLift"] != null)
            {


            }
            else
            {
                Response.Redirect("/login.aspx");
            }
        }
        protected void GridBind(string InspectionId)
        {
            try
            {
                DataSet ds = new DataSet();
                //ds = CEI.ViewDocuments(InspectionId);
                ds = CEI.ViewDocuments_ReturnedInspectionLift_Escalator_IndustryLift(ID);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    statement.Visible = false;
                    if (!hasLinkInAnyRow)
                    {
                        GridView1.Columns[4].Visible = false; // Hide the "Previous Documents" column
                    }
                    else
                    {
                        GridView1.Columns[4].Visible = true; // Show the column if at least one link is found
                    }
                }
                else
                {
                    DocumentDiv.Visible = false;
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    statement.Visible = true;
                    //string script = "alert(\"No Documnet Found\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {

                if (e.CommandName == "Select")
                {
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    // fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //lblerror.Text = fileName;
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
                else
                {

                }


            }
            catch (Exception ex)
            {
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        }
        private void GetTestReportData(string InspectionId)
        {
            try
            {
                DataSet ds = new DataSet();
                //Added By aslam 2-June-2025
                //ds = CEI.GetTestReport_Lift_Escalator_IndustryLift(InspectionId);
                ds = CEI.GetInspectionHistoryLogs(InspectionId);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Added By aslam 2-June-2025
                //Change status to action taken by gurmeet 15-may-2025
                string status = DataBinder.Eval(e.Row.DataItem, "ActionTaken").ToString();
                if (status == "RETURN")
                {
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[2].BackColor = System.Drawing.Color.Blue;
                e.Row.Cells[2].BackColor = ColorTranslator.FromHtml("#9292cc");
            }
        }
        protected void lnkRedirect1_Click1(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                LinkButton lnkRedirect1 = (LinkButton)sender;
                string testReportId = lnkRedirect1.CommandArgument;
                Session["LiftTestReportID_IndustryLift"] = null;
                Session["EscalatorTestReportID_IndustryLift"] = null;
                //Session["InspectionTestReportId"] = btn.CommandArgument;

                if (installationName == "Lift")
                {
                    Session["LiftTestReportID_IndustryLift"] = testReportId;
                    Response.Write("<script>window.open('/Industry_Master/TestReportModal/LiftTestReportModal_IndustryLift.aspx','_blank');</script>");
                }
                else if (installationName == "Escalator")
                {
                    Session["EscalatorTestReportID_IndustryLift"] = testReportId;
                    Response.Write("<script>window.open('/Industry_Master/TestReportModal/EscalatorTestReportModal_IndustryLift.aspx','_blank');</script>");

                }
            }
            catch (Exception ex) { }
        }

        private void GridToViewTRinMultipleCaseNew()
        {
            try
            {
                string ID = Session["InspectionId_IndustryLift"].ToString();
                DataSet dsVC = CEI.GetDetailsToViewTRinMultipleCaseNew_IndustryLift(ID);

                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    Grid_MultipleInspectionTR.DataSource = dsVC;
                    Grid_MultipleInspectionTR.DataBind();
                }
                else
                {
                    Grid_MultipleInspectionTR.DataSource = null;
                    Grid_MultipleInspectionTR.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
            }
        }

        //protected void Grid_MultipleInspectionTR_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    string Count = string.Empty;
        //    string IntimationId = string.Empty;
        //    if (e.CommandName == "Select")
        //    {
        //        Session["LiftTestReportID"] = null;
        //        Session["EscalatorTestReportID"] = null;
        //        Control ctrl = e.CommandSource as Control;
        //        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
        //        Label LblInstallationName = (Label)row.FindControl("LblInstallationName");
        //        Label LblTestReportCount = (Label)row.FindControl("LblTestReportCount");                    
        //        Count = LblTestReportCount.Text.Trim();

        //        Label LblIntimationId = (Label)row.FindControl("LblIntimationId");
        //        IntimationId = LblIntimationId.Text.Trim();

        //        DataSet ds = new DataSet();
        //        ds = CEI.GetData(LblInstallationName.Text.Trim(), IntimationId, Count);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            if (LblInstallationName.Text.Trim() == "Lift")
        //            {
        //                Session["LiftTestReportID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();                                               
        //                Response.Redirect("/TestReportModal/LiftTestReportModal.aspx", false);
        //            }
        //            else if (LblInstallationName.Text.Trim() == "Escalator")
        //            {
        //                  Session["EscalatorTestReportID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
        //                  Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
        //            }                        
        //        }
        //    }

        //    else if (e.CommandName == "View")
        //    {
        //        string fileName = "";
        //        fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
        //        //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
        //        //lblerror.Text = fileName;
        //        string script = $@"<script>window.open('{fileName}','_blank');</script>";
        //        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
        //    }
        //    else if (e.CommandName == "ViewInvoice")
        //    {
        //        string fileName = "";
        //        //fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
        //        fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
        //        string script = $@"<script>window.open('{fileName}','_blank');</script>";
        //        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
        //    }


        //}

        protected void lnkRedirectTR_Click1(object sender, EventArgs e)
        {

            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                Session["LiftTestReportID_IndustryLift"] = null;
                Session["EscalatorTestReportID_IndustryLift"] = null;
                //Session["InspectionTestReportId"] = btn.CommandArgument;
                if (installationName == "Lift")
                {
                    Session["LiftTestReportID_IndustryLift"] = btn.CommandArgument;
                    Response.Redirect("/Industry_Master/TestReportModal/LiftTestReportModal_IndustryLift.aspx", false);
                }
                else if (installationName == "Escalator")
                {
                    Session["EscalatorTestReportID_IndustryLift"] = btn.CommandArgument;
                    Response.Redirect("/Industry_Master/TestReportModal/EscalatorTestReportModal_IndustryLift.aspx", false);
                }
            }
            catch (Exception ex) { }
        }

        protected void lnkRedirectTR_Periodic_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                Label LblRegistrationNo = (Label)row.FindControl("LblRegistrationNo");

                string installationName = lblInstallationName.Text.Trim();
                Session["RegistrationNo_IndustryLift"] = null;
                Session["TestReportID_IndustryLift"] = null;
                Session["RegistrationNo_IndustryLift"] = LblRegistrationNo.Text.Trim();
                Session["TestReportID_IndustryLift"] = btn.CommandArgument;
                if (installationName == "Lift")
                {
                    Response.Redirect("/Industry_Master/TestReportModal/LiftPeriodicTestReportModal_IndustryLift.aspx", false);
                }
                else if (installationName == "Escalator")
                {
                    Response.Redirect("/Industry_Master/TestReportModal/EscalatorPeriodicTestReportModal_IndustryLift.aspx", false);
                }
            }
            catch (Exception ex) { }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label LblPreviousDocument = (Label)e.Row.FindControl("LblPreviousDocument");
                    LinkButton LnkPreviousDocumemtPath = (LinkButton)e.Row.FindControl("LnkPreviousDocumemtPath");

                    // Check if the OldTestReportId is null or empty
                    if (string.IsNullOrEmpty(LblPreviousDocument.Text))
                    {
                        LnkPreviousDocumemtPath.Visible = false;
                    }
                    else
                    {
                        LnkPreviousDocumemtPath.Visible = true;
                        hasLinkInAnyRow = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}