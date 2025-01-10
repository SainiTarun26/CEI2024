using AjaxControlToolkit;
using CEI_PRoject;
using CEIHaryana.Contractor;
using CEIHaryana.Model.Industry;
using CEIHaryana.UserPages;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media.TextFormatting;
using Label = System.Web.UI.WebControls.Label;

namespace CEIHaryana.Officers
{
    public partial class InProcessInspection_Lift_Escalator : System.Web.UI.Page
    {

        CEI CEI = new CEI();
        private static int lineNumber = 0;
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        private static string ApprovedorReject, Reason, StaffId, Suggestions;
        string Type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //if (Request.UrlReferrer != null)
                    //{
                    //    Session["PreviousPage"] = Request.UrlReferrer.ToString();
                    //}
                    //     Session["StaffID"] = "XEN_HI";
                    //Session["InProcessInspectionId"] = "1002603";
                    if (Session["StaffID"] != null && Session["StaffID"].ToString() != "")
                    {
                        lineNumber = 0;
                        GetData();
                        //BindSuggestions();

                        if (Type == "New")
                        {
                            GetTestReportData();

                        }
                        else if (Type == "Periodic")
                        {
                            GetTestReportDataIfPeriodic();
                        }

                        Page.Session["ClickCount"] = "0";

                    }
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }


        private void GetTestReportDataIfPeriodic()
        {
            try
            {
                ID = Session["InProcessInspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetTestReportDataIfPeriodic_Lift(ID);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0)
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
            catch (Exception ex) { }
        }

        protected void lnkRedirect_Click(object sender, EventArgs e)
        {

            //LinkButton lnkRedirect = (LinkButton)sender;
            //string testReportId = lnkRedirect.CommandArgument;
            //Session["InspectionTestReportId"] = testReportId;
            //if (txtWorkType.Text.Trim() == "Line")
            //{
            //    Response.Write("<script>window.open('/TestReportModal/LiTestReportModal.aspx','_blank');</script>");
            //}
            //else if (txtWorkType.Text.Trim() == "Substation Transformer")
            //{
            //    Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
            //}
            //else if (txtWorkType.Text.Trim() == "Generating Set")
            //{
            //    Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
            //}
        }
        private void GetData()
        {
            try
            {
                ID = Session["InProcessInspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.InspectionDataFor_Lift(ID);
                Type = ds.Tables[0].Rows[0]["IType"].ToString();
                lblInspectionType.Text = ds.Tables[0].Rows[0]["Type_of_Inspection"].ToString();
                lblInstallation.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                txtUserType.Text = ds.Tables[0].Rows[0]["UserType"].ToString();

                if (Type == "New")
                {
                    txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();

                    txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
                    txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                    Session["InstallationType"] = txtWorkType.Text;

                    txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                    txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                    string SiteInspectionDate = ds.Tables[0].Rows[0]["InspectionDate"].ToString();
                    Session["InspectionType"] = ds.Tables[0].Rows[0]["Type_of_Inspection"].ToString();
                    string ReturnValu = ds.Tables[0].Rows[0]["ReturnedBasedOnDocumentValue"].ToString();
                    GridBindDocument();
                    txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                    txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                    //txtAmount.Visible = false;
                    txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                    if (txtAmount.Text == "0")
                    {
                        labelApprovalDate.Visible = true;
                        labelInspectionDate.Visible = false;
                        TranscationDetails.Visible = false;
                    }
                    else
                    {
                        labelApprovalDate.Visible = false;
                        labelInspectionDate.Visible = true;
                        TranscationDetails.Visible = true;
                        ChallanDate.Visible = false;
                    }
                    //addedby aslam on 23 dec 2024 Start
                    txtelectrical.Text = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Firm/Organization/Company/Department")
                    {
                        agency.Visible = true;
                        individual.Visible = false;
                        txtagency.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        txtagency.ReadOnly = true;

                        DivOtherDepartment.Visible = true;
                        DivPancard_TanNo.Visible = false;
                        txtTanNumber.Text = ds.Tables[0].Rows[0]["PanOrTan"].ToString();


                    }
                    else if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Individual Person")
                    {
                        txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        txtSiteOwnerName.ReadOnly = true;
                        DivPancard_TanNo.Visible = true;
                        DivOtherDepartment.Visible = false;
                        txtPAN.Text = ds.Tables[0].Rows[0]["PanOrTan"].ToString();
                    }
                    //addedby aslam on 23 dec 2024 End

                    string Division = ds.Tables[0].Rows[0]["Division"].ToString();
                    //Session["Division"] = Division;
                    //ChallanDate.Visible = false;
                    RegNo.Visible = false;

                    DivViewTRinMultipleCaseNew.Visible = true;
                    GridToViewMultipleCaseNew();
                    if (ReturnValu == "1")
                    {
                        grd_Documemnts.Columns[3].Visible = true;
                        grd_Documemnts.Columns[4].Visible = true;
                        //Grid_MultipleInspectionTR.Columns[5].Visible = false;
                        //Grid_MultipleInspectionTR.Columns[7].Visible = false;
                        //Grid_MultipleInspectionTR.Columns[9].Visible = false;
                    }
                    else if (ReturnValu == "3")
                    {

                        grd_Documemnts.Columns[3].Visible = true;
                        grd_Documemnts.Columns[4].Visible = true;
                        Grid_MultipleInspectionTR.Columns[5].Visible = true;
                        Grid_MultipleInspectionTR.Columns[6].Visible = true;
                        Grid_MultipleInspectionTR.Columns[7].Visible = true;
                        Grid_MultipleInspectionTR.Columns[8].Visible = true;
                        Grid_MultipleInspectionTR.Columns[9].Visible = true;
                    }
                    else if (ReturnValu == "2")
                    {

                        grd_Documemnts.Columns[3].Visible = false;
                        grd_Documemnts.Columns[4].Visible = false;
                        //Grid_MultipleInspectionTR.Columns[5].Visible = true;
                        //Grid_MultipleInspectionTR.Columns[6].Visible = true;
                        //Grid_MultipleInspectionTR.Columns[7].Visible = true;
                        //Grid_MultipleInspectionTR.Columns[8].Visible = true;
                        //Grid_MultipleInspectionTR.Columns[9].Visible = true;
                    }
                    else
                    {
                        grd_Documemnts.Columns[3].Visible = true;
                        grd_Documemnts.Columns[4].Visible = false;
                        //Grid_MultipleInspectionTR.Columns[5].Visible = false;
                        //Grid_MultipleInspectionTR.Columns[6].Visible = true;
                        //Grid_MultipleInspectionTR.Columns[7].Visible = false;
                        //Grid_MultipleInspectionTR.Columns[8].Visible = true;
                        //Grid_MultipleInspectionTR.Columns[9].Visible = false;
                    }

                    string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                    Session["ApplicationStatus"] = Status;
                    if (Status == "Approved")
                    {
                        InspectionDate.Visible = false;
                        InsDate.Visible = true;
                        txtDATE.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                        if (txtAmount.Text == "0")

                        {
                            AppDate.Visible = true;
                            inDate.Visible = false;
                        }
                        else
                        {
                            AppDate.Visible = false;
                            inDate.Visible = true;
                        }

                        ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                        ddlReview.Attributes.Add("disabled", "true");
                        grd_Documemnts.Columns[3].Visible = true;
                        grd_Documemnts.Columns[4].Visible = false;
                        //txtDATE.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                        //if (!string.IsNullOrEmpty(SiteInspectionDate))
                        //    {
                        //        InspectionDate.Visible = true;
                        //        txtInspectionDate.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                        //        txtInspectionDate.Attributes.Add("disabled", "true");
                        //    }
                        btnBack.Visible = true;
                        btnSubmit.Visible = false;
                    }
                    if (Status == "Rejected")
                    {
                        InspectionDate.Visible = false;
                        InsDate.Visible = true;
                        txtDATE.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                        if (txtAmount.Text == "0")

                        {
                            AppDate.Visible = true;
                            inDate.Visible = false;
                        }
                        else
                        {
                            AppDate.Visible = false;
                            inDate.Visible = true;
                        }

                        //if (!string.IsNullOrEmpty(SiteInspectionDate))
                        //    {
                        //        InspectionDate.Visible = true;
                        //        txtInspectionDate.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                        //        txtInspectionDate.Attributes.Add("disabled", "true");
                        //    }
                        Rejection.Visible = true;
                        txtRejected.Text = ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                        txtRejectionBasis.Text = ds.Tables[0].Rows[0]["RejctionReasonType"].ToString();
                        ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                        ddlReview.Attributes.Add("disabled", "true");
                        txtRejected.Attributes.Add("disabled", "true");
                        txtRejectionBasis.Attributes.Add("disabled", "true");
                        if (txtRejectionBasis.Text == "" || txtRejectionBasis.Text == null)
                        {
                            RejectionBasis.Visible = false;
                            Rejection.Visible = false;

                        }
                        else
                        {
                            RejectionBasis.Visible = true;
                            Rejection.Visible = true;
                        }
                        btnBack.Visible = true;
                        btnSubmit.Visible = false;
                        grd_Documemnts.Columns[3].Visible = true;
                        grd_Documemnts.Columns[4].Visible = false;
                    }
                    if (Status == "Return")
                    {
                        InspectionDate.Visible = false;
                        ApprovalRequired.Visible = false;
                        btnSubmit.Visible = false;
                        RejectionBasis.Visible = false;

                        ddlReview.Attributes.Add("disabled", "true");

                        divTestReportAttachment.Visible = false;





                    }
                }
                else if (Type == "Periodic")
                {
                    grd_Documemnts.Columns[4].Visible = false;
                    txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    //InspectionType.Visible = false;
                    txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
                    txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                    Session["InstallationType"] = txtWorkType.Text;
                    //ChallanDate.Visible = true;
                    //RegNo.Visible = true;
                    txtChallanDate.Text = ds.Tables[0].Rows[0]["PreviousChallanDate"].ToString();
                    txtRegistrationNo.Text = ds.Tables[0].Rows[0]["RegistrationNo"].ToString();
                    txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                    txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                    txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                    txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                    if (txtAmount.Text == "0")
                    {
                        labelApprovalDate.Visible = true;
                        labelInspectionDate.Visible = false;
                        TranscationDetails.Visible = false;
                    }
                    else
                    {
                        labelApprovalDate.Visible = false;
                        labelInspectionDate.Visible = true;
                        TranscationDetails.Visible = true;
                        ChallanDate.Visible = false;
                    }
                    //addedby aslam on 23 dec 2024 Start
                    txtelectrical.Text = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Firm/Organization/Company/Department")
                    {
                        agency.Visible = true;
                        individual.Visible = false;
                        txtagency.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        txtagency.ReadOnly = true;

                        DivOtherDepartment.Visible = true;
                        DivPancard_TanNo.Visible = false;
                        txtTanNumber.Text = ds.Tables[0].Rows[0]["PanOrTan"].ToString();


                    }
                    else if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Individual Person")
                    {
                        txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        txtSiteOwnerName.ReadOnly = true;
                        DivPancard_TanNo.Visible = true;
                        DivOtherDepartment.Visible = false;
                        txtPAN.Text = ds.Tables[0].Rows[0]["PanOrTan"].ToString();
                    }
                    //addedby aslam on 23 dec 2024 End

                    Session["InspectionType"] = ds.Tables[0].Rows[0]["Type_of_Inspection"].ToString();
                    string Division = ds.Tables[0].Rows[0]["Division"].ToString();
                    //Session["Division"] = Division;
                    //divTestReportAttachment.Visible = false;
                    Address.Visible = true;
                    txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();

                    string SiteInspectionDate = ds.Tables[0].Rows[0]["InspectionDate"].ToString();
                    grd_Documemnts.Columns[1].Visible = true;

                    GridView1.Columns[5].Visible = false;
                    GridView1.Columns[3].Visible = false;

                    DivTestReports.Visible = true;
                    GridToViewTestReports();

                    GridBindDocument();

                    string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                    Session["ApplicationStatus"] = Status;
                    if (Status == "Approved")
                    {
                        InspectionDate.Visible = false;
                        InsDate.Visible = true;

                        txtDATE.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                        if (txtAmount.Text == "0")

                        {
                            AppDate.Visible = true;
                            inDate.Visible = false;
                        }
                        else
                        {
                            AppDate.Visible = false;
                            inDate.Visible = true;
                        }
                        ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                        ddlReview.Attributes.Add("disabled", "true");


                        //if (!string.IsNullOrEmpty(SiteInspectionDate))
                        //{
                        //    InspectionDate.Visible = true;
                        //    txtInspectionDate.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                        //    txtInspectionDate.Attributes.Add("disabled", "true");
                        //}
                        btnBack.Visible = true;
                        btnSubmit.Visible = false;
                    }
                    if (Status == "Rejected")
                    {
                        InspectionDate.Visible = false;
                        InsDate.Visible = true;
                        txtDATE.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                        if (txtAmount.Text == "0")

                        {
                            AppDate.Visible = true;
                            inDate.Visible = false;
                        }
                        else
                        {
                            AppDate.Visible = false;
                            inDate.Visible = true;
                        }
                        //if (!string.IsNullOrEmpty(SiteInspectionDate))
                        //    {
                        //        InspectionDate.Visible = true;
                        //        txtInspectionDate.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                        //        txtInspectionDate.Attributes.Add("disabled", "true");
                        //    }
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
                        InspectionDate.Visible = false;
                        ApprovalRequired.Visible = false;
                        btnSubmit.Visible = false;
                        ddlReview.Attributes.Add("disabled", "true");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void GridToViewTestReports()
        {
            try
            {
                string ID = Session["InProcessInspectionId"].ToString();
                DataSet dsVC = CEI.GetDetailsToViewCart_Lift_Escalator(ID);

                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = dsVC;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    string script = "alert('No Record Found');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
            }
        }

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    //ID = Session["InspectionId"].ToString();
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    // fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }

            }
            catch (Exception ex)
            {
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            int ClickCount = 0;
            ClickCount = Convert.ToInt32(Session["ClickCount"]);
            if (ClickCount < 1)
            {
                ClickCount = ClickCount + 1;
                Session["ClickCount"] = ClickCount;
                int checksuccessmessage = 0;
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    SqlTransaction transaction = null;
                    try
                    {


                        connection.Open();
                        if (Session["InProcessInspectionId"].ToString() != null && Session["InProcessInspectionId"].ToString() != "" && Session["StaffID"].ToString() != null)
                        {
                            ID = Session["InProcessInspectionId"].ToString();
                            DataSet ds = new DataSet();
                            ds = CEI.InspectionDataFor_Lift(ID);
                            Type = ds.Tables[0].Rows[0]["IType"].ToString();

                            if (Type == "New")
                            {
                                TxtDivision.Text = ds.Tables[0].Rows[0]["Division"].ToString();
                                txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                                txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                                txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                            }
                            else if (Type == "Periodic")
                            {
                                TxtDivision.Text = ds.Tables[0].Rows[0]["Division"].ToString();
                                txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                                TxtApprovalDate.Text = ds.Tables[0].Rows[0]["LastApprovalDate"].ToString();
                                txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                                txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                                TxtMemoNo.Text = ds.Tables[0].Rows[0]["MemoNo"].ToString();
                            }


                            StaffId = Session["StaffID"].ToString();
                            ID = Session["InProcessInspectionId"].ToString();
                            string InspectionType = Session["InspectionType"].ToString();
                            if (Type == "New")
                            {
                                DataTable dsVC = CEI.InstallationComponentsforLift(ID);
                                if (dsVC != null && dsVC.Rows.Count > 0)
                                {
                                    Grid_MultipleInspectionTR.DataSource = dsVC;
                                    Grid_MultipleInspectionTR.DataBind();
                                }
                            }
                            else
                            {
                                DataSet dsVC = CEI.GetDetailsToViewCart_Lift_Escalator(ID);

                                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                                {
                                    GridView2.DataSource = dsVC;
                                    GridView2.DataBind();
                                }

                            }
                            //string InstallationType = Session["InstallationType"].ToString();
                            // string Division = Session["Division"].ToString();
                            String SubmittedDate = Session["lblSubmittedDate"].ToString();

                            if (ddlReview.SelectedValue != null && ddlReview.SelectedValue != "" && ddlReview.SelectedValue != "0")
                            {
                                DateTime inspectionDate;
                                if (!DateTime.TryParse(txtInspectionDate.Text, out inspectionDate))
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid inspection date.');", true);
                                    return;
                                }

                                DateTime submittedDate;
                                if (!DateTime.TryParse(Session["lblSubmittedDate"].ToString(), out submittedDate))
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid submitted date.');", true);
                                    return;
                                }

                                if (inspectionDate < submittedDate)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection/Approval date must be greater equal to application requested date.');", true);
                                    return;
                                }

                                ApprovedorReject = ddlReview.SelectedItem.ToString();
                                Reason = string.IsNullOrEmpty(txtRejected.Text) ? null : txtRejected.Text.Trim();

                                //if (Suggestion.Visible == true)
                                //{
                                //    Suggestions = string.IsNullOrEmpty(txtSuggestion.Text) ? null : txtSuggestion.Text.Trim();
                                //}

                                try
                                {
                                    string reqType = CEI.GetIndustry_RequestType_New(Convert.ToInt32(ID));
                                    if (reqType == "Industry")
                                    {
                                        string serverStatus = CEI.CheckServerStatus("https://staging.investharyana.in");
                                        // string serverStatus = CEI.CheckServerStatus("https://investharyana.in/api/project-service-logs-external_UHBVN");
                                        if (serverStatus != "Server is reachable.")
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('HEPC Server Is Not Responding . Please Try After Some Time')", true);
                                            return;
                                        }
                                    }
                                    transaction = connection.BeginTransaction();
                                    CEI.InspectionFinalAction_Lift(ID, StaffId, ApprovedorReject, Reason, TxtMemoNo.Text, txtInspectionDate.Text, transaction);
                                    if (ApprovedorReject == "Approved")
                                    {
                                        if (InspectionType == "New")
                                        {
                                            foreach (GridViewRow row in Grid_MultipleInspectionTR.Rows)
                                            {

                                                string TestReportId = (row.FindControl("LblTestReportId") as Label)?.Text;
                                                string InstallationType = (row.FindControl("LblInstallationName") as Label)?.Text;
                                                string lblMake = (row.FindControl("lblMake") as Label)?.Text;
                                                string lblLiftSrNo = (row.FindControl("lblLiftSrNo") as Label)?.Text;
                                                string lblTypeOfLift = (row.FindControl("lblTypeOfLift") as Label)?.Text;
                                                string lblTypeOfControl = (row.FindControl("lblTypeOfControl") as Label)?.Text;
                                                string lblCapacity = (row.FindControl("lblCapacity") as Label)?.Text;
                                                string lblWeight = (row.FindControl("lblWeight") as Label)?.Text;
                                                DateTime LblErectionDate = DateTime.Parse((row.FindControl("LblErectionDate") as Label)?.Text);


                                                CEI.InstallationApproval_Lift_New(ID, TestReportId, InstallationType, StaffId, InspectionType, txtRegistrationNo.Text, TxtDivision.Text, lblMake, lblLiftSrNo, lblTypeOfLift,
                                                  lblTypeOfControl, lblCapacity, lblWeight, LblErectionDate, txtAddress.Text, txtDistrict.Text, DateTime.Parse(txtTranscationDate.Text), transaction);

                                            }
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata('" + ApprovedorReject + "');", true);

                                        }
                                        if (InspectionType == "Periodic")
                                        {
                                            foreach (GridViewRow row in GridView2.Rows)
                                            {

                                                string TestReportId = (row.FindControl("lblTestReport") as Label)?.Text;
                                                string InstallationType = (row.FindControl("LblInstallationName") as Label)?.Text;
                                                string lblMake = (row.FindControl("lblMake") as Label)?.Text;
                                                string lblLiftSrNo = (row.FindControl("lblLiftSrNo") as Label)?.Text;
                                                string lblTypeOfLift = (row.FindControl("lblTypeOfLift") as Label)?.Text;
                                                string lblTypeOfControl = (row.FindControl("lblTypeOfControl") as Label)?.Text;
                                                string lblCapacity = (row.FindControl("lblCapacity") as Label)?.Text;
                                                string lblWeight = (row.FindControl("lblWeight") as Label)?.Text;
                                                string LblRegistrationNo = (row.FindControl("LblRegistrationNo") as Label)?.Text;
                                                string LblMemoNo = (row.FindControl("LblMemoNo") as Label)?.Text;
                                                DateTime LblErectionDate = DateTime.Parse((row.FindControl("LblErectionDate") as Label)?.Text);
                                                DateTime lblLastApprovalDate = DateTime.Parse((row.FindControl("lblLastApprovalDate") as Label)?.Text);

                                                // string InstallationName = (row.FindControl("LblInstallation") as Label)?.Text;
                                                CEI.InstallationApproval_Lift(ID, TestReportId, InstallationType, StaffId, InspectionType, txtRegistrationNo.Text, DateTime.Parse(txtChallanDate.Text), TxtDivision.Text, lblMake, lblLiftSrNo, lblTypeOfLift,
                                                 lblTypeOfControl, lblCapacity, lblWeight, LblErectionDate, lblLastApprovalDate, txtAddress.Text, txtDistrict.Text, LblMemoNo, txtTranscationDate.Text, transaction);

                                            }
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata('" + ApprovedorReject + "');", true);

                                        }

                                        transaction.Commit();
                                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata('" + ApprovedorReject + "');", true);
                                    }
                                    else if (ApprovedorReject == "Rejected")
                                    {
                                        transaction.Commit();
                                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata2()", true);
                                    }



                                    else
                                    {
                                        //transaction.Commit();
                                        ddlReview.Focus();
                                        return;
                                    }

                                    //if (ApprovedorReject == "Rejected")
                                    //{
                                    //    CEI.InspectionFinalAction_Lift(ID, "", StaffId, InstallationType, InspectionType, ApprovedorReject, Reason, txtInspectionDate.Text, txtChallanDate.Text, txtRegistrationNo.Text, Division);
                                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection Request has been Rejected.');", true);
                                    //}
                                    Session["InspectionType"] = "";
                                    Session["InstallationType"] = "";
                                    //transaction.Commit();

                                    //commented 3 dec 2024 for 
                                    checksuccessmessage = 1;

                                    string actiontype = ApprovedorReject == "Approved" ? "Approved" : "Rejected";

                                    List<Industry_Api_Post_DataformatModel> ApiPostformatResults = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(ID), actiontype);
                                    foreach (var ApiPostformatresult in ApiPostformatResults)
                                    {
                                        if (ApiPostformatresult.PremisesType == "Industryasdasda")
                                        {
                                            string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);

                                            logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
                                                "https://staging.investharyana.in/api/project-service-logs-external_UHBVN",
                                                new Industry_Inspection_StageWise_JsonDataFormat_Model
                                                {
                                                    actionTaken = ApiPostformatresult.ActionTaken,
                                                    commentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                                    //commentDate = ApiPostformatresult.CommentDate,
                                                    commentDate = ApiPostformatresult.CommentDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                                                    comments = ApiPostformatresult.Comments,
                                                    id = ApiPostformatresult.Id,
                                                    projectid = ApiPostformatresult.ProjectId,
                                                    serviceid = ApiPostformatresult.ServiceId
                                                    //projectid = "245df444-1808-4ff6-8421-cf4a859efb4c",
                                                    //serviceid = "e31ee2a6-3b99-4f42-b61d-38cd80be45b6"
                                                },
                                                ApiPostformatresult,
                                                accessToken
                                            );

                                            if (!string.IsNullOrEmpty(logDetails.ErrorMessage))
                                            {
                                                throw new Exception(logDetails.ErrorMessage);
                                            }

                                            CEI.LogToIndustryApiSuccessDatabase(
                                                logDetails.Url,
                                                logDetails.Method,
                                                logDetails.RequestHeaders,
                                                logDetails.ContentType,
                                                logDetails.RequestBody,
                                                logDetails.ResponseStatusCode,
                                                logDetails.ResponseHeaders,
                                                logDetails.ResponseBody,
                                                new Industry_Api_Post_DataformatModel
                                                {
                                                    InspectionId = ApiPostformatresult.InspectionId,
                                                    InspectionLogId = ApiPostformatresult.InspectionLogId,
                                                    IncomingJsonId = ApiPostformatresult.IncomingJsonId,
                                                    ActionTaken = ApiPostformatresult.ActionTaken,
                                                    CommentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                                    CommentDate = ApiPostformatresult.CommentDate,
                                                    Comments = ApiPostformatresult.Comments,
                                                    Id = ApiPostformatresult.Id,
                                                    ProjectId = ApiPostformatresult.ProjectId,
                                                    ServiceId = ApiPostformatresult.ServiceId,
                                                }

                                            );
                                        }
                                    }
                                }
                                //commented 3 dec 2024 for 
                                catch (TokenManagerException ex)
                                {
                                    CEI.LogToIndustryApiErrorDatabase(
                                        ex.RequestUrl,
                                        ex.RequestMethod,
                                        ex.RequestHeaders,
                                        ex.RequestContentType,
                                        ex.RequestBody,
                                        ex.ResponseStatusCode,
                                        ex.ResponseHeaders,
                                        ex.ResponseBody,
                                        new Industry_Api_Post_DataformatModel
                                        {
                                            InspectionId = ex.InspectionId,
                                            InspectionLogId = ex.InspectionLogId,
                                            IncomingJsonId = ex.IncomingJsonId,
                                            ActionTaken = ex.ActionTaken,
                                            CommentByUserLogin = ex.CommentByUserLogin,
                                            CommentDate = ex.CommentDate,
                                            Comments = ex.Comments,
                                            Id = ex.Id,
                                            ProjectId = ex.ProjectId,
                                            ServiceId = ex.ServiceId,
                                        }
                                    );
                                    string errorMessage = CEI.IndustryTokenApiReturnedErrorMessage(ex);
                                }
                                catch (IndustryApiException ex)
                                {
                                    CEI.LogToIndustryApiErrorDatabase(
                                        ex.RequestUrl,
                                        ex.RequestMethod,
                                        ex.RequestHeaders,
                                        ex.RequestContentType,
                                        ex.RequestBody,
                                        ex.ResponseStatusCode,
                                        ex.ResponseHeaders,
                                        ex.ResponseBody,
                                        new Industry_Api_Post_DataformatModel
                                        {
                                            InspectionId = ex.InspectionId,
                                            InspectionLogId = ex.InspectionLogId,
                                            IncomingJsonId = ex.IncomingJsonId,
                                            ActionTaken = ex.ActionTaken,
                                            CommentByUserLogin = ex.CommentByUserLogin,
                                            CommentDate = ex.CommentDate,

                                            Comments = ex.Comments,
                                            Id = ex.Id,
                                            ProjectId = ex.ProjectId,
                                            ServiceId = ex.ServiceId,
                                        }
                                    );
                                    string errorMessage = CEI.IndustryApiReturnedErrorMessage(ex);
                                }
                                catch (Exception ex)
                                {
                                    // Handle the exception, log it, etc.
                                    transaction?.Rollback();
                                    string errorMessage = ex.Message.Replace("'", "\\'");
                                    ScriptManager.RegisterStartupScript(this, GetType(), "erroralert", $"alert('{errorMessage}')", true);
                                }
                                finally
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata('" + ApprovedorReject + "');", true);
                                    transaction?.Dispose();
                                    connection.Close();
                                }
                            }
                            else
                            {
                                ddlReview.Focus();
                                return;
                            }
                        }
                        else
                        {
                            Response.Redirect("/Login.aspx");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the outer exception, log it, etc.
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('An error occurred.');", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('You double click on Button.'); window.location='InProcessRequest.aspx'", true);
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Response.Redirect("/Officers/InProcessRequest.aspx", false);
            try
            {
                string Status = Session["ApplicationStatus"].ToString();
                {
                    if (Status == "Approved" || Status == "Rejected" || Status == "Return")
                    {
                        //Response.Redirect("/Officers/InProcessRequest.aspx", false);
                        Response.Redirect("/Officers/AcceptedOrReject.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("/Officers/InProcessRequest.aspx", false);

                    }
                    Session["ApplicationStatus"] = "";
                }
                //string previousPageUrl = Session["PreviousPage"] as string;
                //if (!string.IsNullOrEmpty(previousPageUrl))
                //{

                //    Response.Redirect(previousPageUrl, false);
                //    Session["PreviousPage"] = null;

                //}
            }
            catch { }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                Label lblSubmittedDate = (Label)e.Row.FindControl("lblSubmittedDate");
                Session["lblSubmittedDate"] = lblSubmittedDate.Text;
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
        protected void lnkRedirect1_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                Label LblRegistrationNo = (Label)row.FindControl("LblRegistrationNo");
                Label LblTestReportId = (Label)row.FindControl("lblTestReport");

                if (lblInstallationName != null)
                {
                    if (txtUserType.Text == "Industry")
                    {
                        Session["RegistrationNo_IndustryLift"] = LblRegistrationNo.Text;
                        Session["TestReportID_IndustryLift"] = LblTestReportId.Text;
                        if (lblInstallationName.Text == "Lift")
                        {
                            Response.Redirect("/Industry_Master/TestReportModal/LiftPeriodicTestReportModal_IndustryLift.aspx", false);
                        }
                        else if (lblInstallationName.Text == "Escalator")
                        {
                            Response.Redirect("/Industry_Master/TestReportModal/EscalatorPeriodicTestReportModal_IndustryLift.aspx", false);
                        }
                    }
                    else if (txtUserType.Text != "Industry")
                    {
                        Session["RegistrationNo"] = LblRegistrationNo.Text;
                        Session["TestReportID"] = LblTestReportId.Text;
                        if (lblInstallationName.Text == "Lift")
                        {
                            Response.Redirect("/TestReportModal/LiftPeriodicTestReportModal.aspx", false);
                        }
                        else if (lblInstallationName.Text == "Escalator")
                        {
                            Response.Redirect("/TestReportModal/EscalatorPeriodicTestReportModal.aspx", false);
                        }

                    }


                }

            }
            catch (Exception ex) { }
        }


        protected void ddlReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rejection.Visible = false;
            //Suggestion.Visible = false;
            //ddlSuggestions.Visible = false;
            // btnPreview.Visible = false;
            if (ddlReview.SelectedValue == "2")
            {
                Rejection.Visible = true;
            }
            else if (ddlReview.SelectedValue == "1")
            {
                //btnPreview.Visible = true;
                //ddlSuggestions.Visible = true;

                //Suggestion.Visible = true;
            }
        }

        protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    //Label LblInstallationName = (Label)e.Row.FindControl("LblInstallationName");
                    //LinkButton linkButtonInvoice = (LinkButton)e.Row.FindControl("lnkInstallaionInvoice");
                    LinkButton LnkDocumemtPath2 = (LinkButton)e.Row.FindControl("LnkDocumemtPath2");

                    if (LnkDocumemtPath2.Text.Trim() == "" || LnkDocumemtPath2 == null)
                    {
                        LnkDocumemtPath2.Visible = false;
                    }
                    else
                    {
                        LnkDocumemtPath2.Visible = true;
                        //  LnkDocumemtPath2.Text = "Click here to view document";

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void GridToViewMultipleCaseNew()
        {
            try
            {
                string ID = Session["InProcessInspectionId"].ToString();
                DataTable dsVC = CEI.InstallationComponentsforLift(ID);

                if (dsVC != null && dsVC.Rows.Count > 0)
                {
                    Grid_MultipleInspectionTR.DataSource = dsVC;
                    Grid_MultipleInspectionTR.DataBind();
                }
                else
                {
                    Grid_MultipleInspectionTR.DataSource = null;
                    Grid_MultipleInspectionTR.DataBind();
                    string script = "alert('No Record Found');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
            }
        }
        protected void GridBindDocument()
        {
            try
            {
                ID = Session["InProcessInspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewReturnDocuments_Lift(ID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                    statement.Visible = false;
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                    //string script = "alert(\"No Record Found\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    statement.Visible = true;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        //protected void Grid_MultipleInspectionTR_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {

        //            Label LblInstallationName = (Label)e.Row.FindControl("LblInstallationName");
        //            LinkButton linkButtonInvoice = (LinkButton)e.Row.FindControl("lnkInstallaionInvoice");
        //            LinkButton LinkButtonReport = (LinkButton)e.Row.FindControl("lnkManufacturingReport");
        //            LinkButton lnkPreviousInstallaionInvoice = (LinkButton)e.Row.FindControl("lnkPreviousInstallaionInvoice");
        //            LinkButton lnkPreviosManufacturingReport = (LinkButton)e.Row.FindControl("lnkPreviosManufacturingReport");
        //            if (lnkPreviosManufacturingReport.Text.Trim() == "" || lnkPreviosManufacturingReport == null)
        //            {
        //                lnkPreviosManufacturingReport.Visible = false;

        //            }
        //            else
        //            {
        //                lnkPreviosManufacturingReport.Visible = true;
        //                lnkPreviosManufacturingReport.Text = "View Document";
        //            }
        //            if (lnkPreviousInstallaionInvoice.Text.Trim() == "" || lnkPreviousInstallaionInvoice == null)
        //            {
        //                lnkPreviousInstallaionInvoice.Visible = false;

        //            }
        //            else
        //            {
        //                lnkPreviousInstallaionInvoice.Visible = true;
        //                lnkPreviousInstallaionInvoice.Text = "View Document";
        //            }
        //            if (LblInstallationName.Text.Trim() == "Line")
        //            {
        //                lnkPreviousInstallaionInvoice.Visible = false;
        //                lnkPreviosManufacturingReport.Visible = false;
        //                linkButtonInvoice.Visible = false;
        //                LinkButtonReport.Visible = false;
        //            }
        //            else
        //            {
        //                lnkPreviousInstallaionInvoice.Visible = true;
        //                lnkPreviosManufacturingReport.Visible = true;
        //                linkButtonInvoice.Visible = true;
        //                LinkButtonReport.Visible = true;
        //                ViewState["AllRowsAreLine"] = false;
        //            }


        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        private void GetTestReportData()
        {
            try
            {
                ID = Session["InProcessInspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetTestReport_Lift(ID);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0)
                {
                    //TestRportId = ds.Tables[0].Rows[0]["TestRportId"].ToString();
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
                //Session["TestRportId"] = TestRportId;

                ds.Dispose();
            }
            catch (Exception ex) { }
        }



        private void GridToViewTRinMultipleCaseNew()
        {
            try
            {
                string ID = Session["InProcessInspectionId"].ToString();
                DataSet dsVC = CEI.GetDetailsToViewTRinMultipleCaseNew(ID);

                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    Grid_MultipleInspectionTR.DataSource = dsVC;
                    Grid_MultipleInspectionTR.DataBind();
                }
                else
                {
                    Grid_MultipleInspectionTR.DataSource = null;
                    Grid_MultipleInspectionTR.DataBind();
                    string script = "alert('No Record Found');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
            }
        }


        protected void Grid_MultipleInspectionTR_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Count = string.Empty;
            string IntimationId = string.Empty;
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label LblInstallationName = (Label)row.FindControl("LblInstallationName");
                Label LblTestReportCount = (Label)row.FindControl("LblTestReportCount");
                //IntimationId = Session["id"].ToString();
                Count = LblTestReportCount.Text.Trim();

                Label LblIntimationId = (Label)row.FindControl("LblIntimationId");
                IntimationId = LblIntimationId.Text.Trim();
                Label LblTestReportId = (Label)row.FindControl("LblTestReportId");
                //DataSet ds = new DataSet();
                //ds = CEI.GetData(LblInstallationName.Text.Trim(), IntimationId, Count);
                //if (ds.Tables[0].Rows.Count > 0)
                //{

                if (LblInstallationName != null)
                {
                    if (txtUserType.Text == "Industry")
                    {
                        if (LblInstallationName.Text == "Lift")
                        {
                            Session["LiftTestReportID_IndustryLift"] = LblTestReportId.Text;
                            Response.Redirect("/Industry_Master/TestReportModal/LiftTestReportModal_IndustryLift.aspx", false);
                        }
                        else if (LblInstallationName.Text == "Escalator")
                        {
                            Session["EscalatorTestReportID_IndustryLift"] = LblTestReportId.Text;
                            Response.Redirect("/Industry_Master/TestReportModal/EscalatorTestReportModal_IndustryLift.aspx", false);
                        }
                    }
                    else if (txtUserType.Text != "Industry")
                    {
                        if (LblInstallationName.Text == "Lift")
                        {
                            Session["LiftTestReportID"] = LblTestReportId.Text;
                            Response.Redirect("/TestReportModal/LiftTestReportModal.aspx", false);
                        }
                        else if (LblInstallationName.Text == "Escalator")
                        {
                            Session["EscalatorTestReportID"] = LblTestReportId.Text;
                            Response.Redirect("/TestReportModal/EscalatorTestReportModal.aspx", false);
                        }

                    }                       
                }
                // Response.Redirect("/TestReportModal/LiftTestReportModal.aspx", false);
                //if (LblInstallationName.Text.Trim() == "Line")
                //{
                //    Session["LineID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();

                //    Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                //}
                //else if (LblInstallationName.Text.Trim() == "Substation Transformer")
                //{
                //    Session["SubStationID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                //    Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                //}
                //else if (LblInstallationName.Text.Trim() == "Generating Set")
                //{
                //    Session["GeneratingSetId"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                //    Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);

                //}
                //}
            }

            //else if (e.CommandName == "View")
            //{
            //    string fileName = "";
            //    // fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
            //    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
            //    //lblerror.Text = fileName;
            //    string script = $@"<script>window.open('{fileName}','_blank');</script>";
            //    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            //}
            //else if (e.CommandName == "ViewInvoice")
            //{
            //    string fileName = "";
            //    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
            //    //fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
            //    string script = $@"<script>window.open('{fileName}','_blank');</script>";
            //    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            //}
            GetData();


        }

        protected void lnkRedirectTR_Click1(object sender, EventArgs e)
        {

            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                Label LblTestReportId = (Label)row.FindControl("LblTestReportId");

                if (lblInstallationName != null)
                {
                    if (txtUserType.Text == "Industry")
                    {
                        if (lblInstallationName.Text == "Lift")
                        {
                            Session["LiftTestReportID_IndustryLift"] = LblTestReportId.Text;
                            Response.Redirect("/Industry_Master/TestReportModal/LiftTestReportModal_IndustryLift.aspx", false);
                        }
                        else if (lblInstallationName.Text == "Escalator")
                        {
                            Session["EscalatorTestReportID_IndustryLift"] = LblTestReportId.Text;
                            Response.Redirect("/Industry_Master/TestReportModal/EscalatorTestReportModal_IndustryLift.aspx", false);
                        }
                    }
                    else if (txtUserType.Text != "Industry")
                    {
                        if (lblInstallationName.Text == "Lift")
                        {
                            Session["LiftTestReportID"] = LblTestReportId.Text;
                            Response.Redirect("/TestReportModal/LiftTestReportModal.aspx", false);
                        }
                        else if (lblInstallationName.Text == "Escalator")
                        {
                            Session["EscalatorTestReportID"] = LblTestReportId.Text;
                            Response.Redirect("/TestReportModal/EscalatorTestReportModal.aspx", false);
                        }
                    }
                }

                //if (installationName == "Line")
                //{
                //    Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                //}
                //else if (installationName == "Substation Transformer")
                //{
                //    Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                //}
                //else if (installationName == "Generating Set")
                //{
                //    Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);
                //}
            }
            catch (Exception ex) { }
        }

    }
}