using CEI_PRoject;
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
    public partial class Inspection_Lift_Periodic_IndustryLift : System.Web.UI.Page
    {
        //page created by aslam 16-oct-2025
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
                    if (Convert.ToString(Session["SiteOwnerId_PeriodicIndustryLift"]) != null && Convert.ToString(Session["SiteOwnerId_PeriodicIndustryLift"]) != "")
                    {
                        if (Convert.ToString(Session["InspectionId_PeriodicIndustryLift"]) != null && Convert.ToString(Session["InspectionId_PeriodicIndustryLift"]) != "")
                        {
                            ID = Session["InspectionId_PeriodicIndustryLift"].ToString();
                            GetDetailsWithId(ID);
                            GridBind(ID);
                            GetTestReportData(ID);
                            Session["PreviousPage_PeriodicIndustryLift"] = "";
                        }
                    }
                    else
                    {
                        Response.Redirect("/LogOut.aspx", false);
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
                if (Convert.ToString(Session["InspectionId_PeriodicIndustryLift"]) != null && Convert.ToString(Session["InspectionId_PeriodicIndustryLift"]) != "")
                {
                    ID = Session["InspectionId_PeriodicIndustryLift"].ToString();
                    DataSet ds = new DataSet();
                    //ds = CEI.GetTestReportDataIfPeriodic(ID);
                    ds = CEI.GetDetailsToViewCart_Lift_Escalator_PeriodicIndustryLift(ID);

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
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "alert('your inspectionid is lost,please go back');", true);
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
                ds = CEI.InspectionData_Lift_Escalator_PeriodicIndustryLift(ID);

                IType = ds.Tables[0].Rows[0]["IType"].ToString();
                txtInspectionType.Text = ds.Tables[0].Rows[0]["IType"].ToString();
                txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                string createdDate = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                DateTime.TryParse(createdDate, out inspectionCreatedDate);
                txtApplicationNo.Text = ds.Tables[0].Rows[0]["InspectionReportID"].ToString();
                txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();

                if (IType == "Periodic")
                {
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
        protected void btnBack_Click(object sender, EventArgs e)
        {
          Response.Redirect("/Industry_Master/SiteOwnerPages/InspectionHistory_Periodic_IndustryLift.aspx", false);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Session["SiteOwnerId_PeriodicIndustryLift"] != null)
            {


            }
            else
            {
                Response.Redirect("/LogOut.aspx");
            }
        }
        protected void GridBind(string InspectionId)
        {
            try
            {
                DataSet ds = new DataSet();
                //ds = CEI.ViewDocuments(InspectionId);
                ds = CEI.ViewDocuments_ReturnedInspectionLift_Escalator_PeriodicIndustryLift(ID);
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
                Session["LiftTestReportID_PeriodicIndustryLift"] = null;
                Session["EscalatorTestReportID_PeriodicIndustryLift"] = null;
                //Session["InspectionTestReportId"] = btn.CommandArgument;

                if (installationName == "Lift")
                {
                    Session["LiftTestReportID_PeriodicIndustryLift"] = testReportId;
                    Response.Write("<script>window.open('/Industry_Master/TestReportModal/LiftTestReportModal_IndustryLift.aspx','_blank');</script>");
                }
                else if (installationName == "Escalator")
                {
                    Session["EscalatorTestReportID_PeriodicIndustryLift"] = testReportId;
                    Response.Write("<script>window.open('/Industry_Master/TestReportModal/EscalatorTestReportModal_IndustryLift.aspx','_blank');</script>");

                }
            }
            catch (Exception ex) { }
        }

        private void GridToViewTRinMultipleCaseNew()
        {
            try
            {
                string ID = Session["InspectionId_PeriodicIndustryLift"].ToString();
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

        protected void lnkRedirectTR_Click1(object sender, EventArgs e)
        {

            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                Session["LiftTestReportID_PeriodicIndustryLift"] = null;
                Session["EscalatorTestReportID_PeriodicIndustryLift"] = null;
                //Session["InspectionTestReportId"] = btn.CommandArgument;
                if (installationName == "Lift")
                {
                    Session["LiftTestReportID_PeriodicIndustryLift"] = btn.CommandArgument;
                    Response.Redirect("/Industry_Master/TestReportModal/LiftTestReportModal_IndustryLift.aspx", false);
                }
                else if (installationName == "Escalator")
                {
                    Session["EscalatorTestReportID_PeriodicIndustryLift"] = btn.CommandArgument;
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
                Session["RegistrationNo_PeriodicIndustryLift"] = null;
                Session["TestReportID_PeriodicIndustryLift"] = null;
                Session["RegistrationNo_PeriodicIndustryLift"] = LblRegistrationNo.Text.Trim();
                Session["TestReportID_PeriodicIndustryLift"] = btn.CommandArgument;
                if (installationName == "Lift")
                {
                    Response.Redirect("/Industry_Master/TestReportModal/LiftPeriodicTestReportModal_PeriodicIndustryLift.aspx", false);
                }
                else if (installationName == "Escalator")
                {
                    Response.Redirect("/Industry_Master/TestReportModal/EscalatorPeriodicTestReportModal_PeriodicIndustryLift.aspx", false);
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
        protected void lnkReturn_Command(object sender, CommandEventArgs e)
        {
            string inspectionId = e.CommandArgument.ToString();
            InspectionReturnDetails.GetReturnDetails(inspectionId);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowReturnModal", "$('#ownerModal').modal('show');", true);
        }
    }
}