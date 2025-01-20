using CEI_PRoject;
using CEIHaryana.Model.Industry;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class InProcess_Returned_Inspection_Lift_Escalator : System.Web.UI.Page
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
                    Session["amount"] = txtAmount.Text;
                    if (txtAmount.Text == "0")
                    {
                        labelApprovalDate.Visible = true;
                        labelInspectionDate.Visible = false;
                        TranscationDetails.Visible = false;
                        labelRejectedDate.Visible = false;
                    }
                    else
                    {
                        labelApprovalDate.Visible = false;
                        labelInspectionDate.Visible = true;
                        TranscationDetails.Visible = true;
                        ChallanDate.Visible = false;
                        labelRejectedDate.Visible = false;
                    }

                    //added by aslam on 23 dec 2024 start 
                    txtelectrical.Text = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Firm/Company")
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
                    //added by aslam on 23 dec 2024 End

                    string Division = ds.Tables[0].Rows[0]["Division"].ToString();
                    //Session["Division"] = Division;
                    ChallanDate.Visible = false;
                    RegNo.Visible = false;

                    DivViewTRinMultipleCaseNew.Visible = true;
                    GridToViewMultipleCaseNew();
                    if (ReturnValu == "1")
                    {
                        grd_Documemnts.Columns[3].Visible = true;
                        grd_Documemnts.Columns[4].Visible = false;
                       // Grid_MultipleInspectionTR.Columns[4].Visible = false;
                        //Grid_MultipleInspectionTR.Columns[5].Visible = false;
                        //Grid_MultipleInspectionTR.Columns[7].Visible = false;
                        //Grid_MultipleInspectionTR.Columns[9].Visible = false;
                    }
                    else if (ReturnValu == "3")
                    {

                        grd_Documemnts.Columns[3].Visible = true;
                        grd_Documemnts.Columns[4].Visible = false;

                        //Grid_MultipleInspectionTR.Columns[5].Visible = true;
                        //Grid_MultipleInspectionTR.Columns[6].Visible = true;
                        //Grid_MultipleInspectionTR.Columns[7].Visible = true;
                        //Grid_MultipleInspectionTR.Columns[8].Visible = true;
                        //Grid_MultipleInspectionTR.Columns[9].Visible = true;
                    }
                    else if (ReturnValu == "2")
                    {

                        grd_Documemnts.Columns[3].Visible = true;
                        grd_Documemnts.Columns[4].Visible = true;
                        Grid_MultipleInspectionTR.Columns[5].Visible = false;
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

                        ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                        ddlReview.Attributes.Add("disabled", "true");

                        if (!string.IsNullOrEmpty(SiteInspectionDate))
                        {
                            InspectionDate.Visible = true;
                            txtInspectionDate.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                            txtInspectionDate.Attributes.Add("disabled", "true");
                        }
                        labelRejectedDate.Visible = false;
                        btnBack.Visible = true;
                        btnSubmit.Visible = false;
                        grd_Documemnts.Columns[4].Visible = false;
                    }
                    if (Status == "Rejected")
                    {
                        InspectionDate.Visible = false;

                        if (!string.IsNullOrEmpty(SiteInspectionDate))
                        {
                            InspectionDate.Visible = true;
                            txtInspectionDate.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                            txtInspectionDate.Attributes.Add("disabled", "true");
                        }
                        labelRejectedDate.Visible = true;
                        labelApprovalDate.Visible = false;
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
                    }
                    if (Status == "Return")
                    {
                        InspectionDate.Visible = false;
                        ApprovalRequired.Visible = false;
                        btnSubmit.Visible = false;
                        RejectionBasis.Visible = false;
                        labelRejectedDate.Visible = false;
                        ddlReview.Attributes.Add("disabled", "true");

                        divTestReportAttachment.Visible = true;
                        




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
                    ChallanDate.Visible = true;
                    //RegNo.Visible = true;
                    txtChallanDate.Text = ds.Tables[0].Rows[0]["PreviousChallanDate"].ToString();
                    txtRegistrationNo.Text = ds.Tables[0].Rows[0]["RegistrationNo"].ToString();
                    txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                    txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                    txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                    string SiteInspectionDate = ds.Tables[0].Rows[0]["InspectionDate"].ToString();
                    txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                    Session["amount"] = txtAmount.Text;
                    if (txtAmount.Text == "0")
                    {
                        labelApprovalDate.Visible = true;
                        labelInspectionDate.Visible = false;
                        TranscationDetails.Visible = false;
                        labelRejectedDate.Visible = false;
                    }
                    else
                    {
                        labelApprovalDate.Visible = false;
                        labelInspectionDate.Visible = true;
                        TranscationDetails.Visible = true;
                        ChallanDate.Visible = false;
                        labelRejectedDate.Visible = false;
                    }
                    //added by aslam on 23 dec 2024 start 
                    txtelectrical.Text = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Firm/Company")
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
                    //added by aslam on 23 dec 2024 End

                    Session["InspectionType"] = ds.Tables[0].Rows[0]["Type_of_Inspection"].ToString();
                    string Division = ds.Tables[0].Rows[0]["Division"].ToString();
                    //Session["Division"] = Division;
                    //divTestReportAttachment.Visible = false;
                    Address.Visible = true;
                    txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();

                   
                    grd_Documemnts.Columns[1].Visible = true;

                    GridView1.Columns[5].Visible = false;
                    //GridView1.Columns[3].Visible = false;
                    
                    DivTestReports.Visible = true;
                    GridToViewTestReports();
                    string ReturnValu = ds.Tables[0].Rows[0]["ReturnedBasedOnDocumentValue"].ToString();
                    if (ReturnValu == "1")
                    {
                        grd_Documemnts.Columns[3].Visible = true;
                        grd_Documemnts.Columns[4].Visible = false;
                       // grd_Documemnts.Columns[5].Visible = true;
                    }
                    else if (ReturnValu == "2")
                    {

                        grd_Documemnts.Columns[3].Visible = true;
                        grd_Documemnts.Columns[4].Visible = true;
                        GridView2.Columns[5].Visible = false;

                    }
                    GridBindDocument();

                    string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                    Session["ApplicationStatus"] = Status;
                    if (Status == "Approved")
                    {
                        InspectionDate.Visible = false;

                        ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                        ddlReview.Attributes.Add("disabled", "true");


                        if (!string.IsNullOrEmpty(SiteInspectionDate))
                        {
                            InspectionDate.Visible = true;
                            txtInspectionDate.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                            txtInspectionDate.Attributes.Add("disabled", "true");
                        }
                        btnBack.Visible = true;
                        btnSubmit.Visible = false;
                    }
                    if (Status == "Rejected")
                    {
                        InspectionDate.Visible = false;

                        if (!string.IsNullOrEmpty(SiteInspectionDate))
                        {
                            InspectionDate.Visible = true;
                            txtInspectionDate.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                            txtInspectionDate.Attributes.Add("disabled", "true");
                        }
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
        private void GetTestReportDataIfPeriodic()
        {
            try
            {
                ID = Session["InProcessInspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetTestReportDataIfPeriodicLift_Return(ID);
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
        private void GridToViewTestReports()
        {
            try
            {
                string ID = Session["InProcessInspectionId"].ToString();
                DataSet dsVC = CEI.GetDetailsToViewCart_Lift_Escalator_Return(ID);

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
                //int checksuccessmessage = 0;
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
                                txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                            }
                            else if (Type == "Periodic")
                            {
                                TxtDivision.Text = ds.Tables[0].Rows[0]["Division"].ToString();
                                txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                                TxtApprovalDate.Text = ds.Tables[0].Rows[0]["LastApprovalDate"].ToString();
                                txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                                txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                                txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();

                            }


                            StaffId = Session["StaffID"].ToString();
                            ID = Session["InProcessInspectionId"].ToString();
                            string InspectionType = Session["InspectionType"].ToString();
                            if (Type == "New")
                            {
                                DataTable dsVC = CEI.InstallationComponentsforLift_Return(ID);
                                if (dsVC != null && dsVC.Rows.Count > 0)
                                {
                                    Grid_MultipleInspectionTR.DataSource = dsVC;
                                    Grid_MultipleInspectionTR.DataBind();
                                }
                            }
                            else
                            {
                                DataSet dsVC = CEI.GetDetailsToViewCart_Lift_Escalator_Return(ID);

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
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid submitted date.'); window.location='InProcessRequest.aspx';", true);
                                    return;
                                }

                                if (inspectionDate < submittedDate)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection/Approval date must be greater equal to application requested date.'); window.location='InProcessRequest.aspx';", true);
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
                                    //commented 3 dec 2024 for 
                                    //string reqType = CEI.GetIndustry_RequestType_New(Convert.ToInt32(ID));
                                    //if (reqType == "Industrysdfsdf")
                                    //{
                                    //    string serverStatus = CEI.CheckServerStatus("https://staging.investharyana.in");
                                    //    // string serverStatus = CEI.CheckServerStatus("https://investharyana.in/api/project-service-logs-external_UHBVN");
                                    //    if (serverStatus != "Server is reachable.")
                                    //    {
                                    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('HEPC Server Is Not Responding . Please Try After Some Time')", true);
                                    //        return;
                                    //    }
                                    //}
                                    transaction = connection.BeginTransaction();
                                    CEI.InspectionFinalAction_Lift(ID, StaffId, ApprovedorReject, Reason, txtInspectionDate.Text, transaction);
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
                                                string lblAmount = (row.FindControl("lblAmount") as Label)?.Text;
                                                if (lblAmount == "0.00" || lblAmount == "0")
                                                {
                                                    txtTranscationDate.Text = "";
                                                    txtTransactionId.Text = "";

                                                }
                                                else
                                                {
                                                    txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                                                    txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();

                                                }
                                                DateTime LblErectionDate = DateTime.Parse((row.FindControl("LblErectionDate") as Label)?.Text);


                                                CEI.InstallationApproval_Lift_New(ID, TestReportId, InstallationType, StaffId, InspectionType, txtRegistrationNo.Text, TxtDivision.Text, lblMake, lblLiftSrNo, lblTypeOfLift,
                                                 lblTypeOfControl, lblCapacity, lblWeight, LblErectionDate, txtAddress.Text, txtDistrict.Text,txtTranscationDate.Text, lblAmount, txtTransactionId.Text, txtTranscationDate.Text, transaction);

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
                                                string lblMemoNo = (row.FindControl("lblMemoNo") as Label)?.Text;
                                                string LblAmount = (row.FindControl("LblAmount") as Label)?.Text;
                                                DateTime LblErectionDate = DateTime.Parse((row.FindControl("LblErectionDate") as Label)?.Text);
                                                DateTime lblLastApprovalDate = DateTime.Parse((row.FindControl("lblLastApprovalDate") as Label)?.Text);
                                                DateTime LblMemoDate = DateTime.Parse((row.FindControl("LblMemoDate") as Label)?.Text);
                                                if (LblAmount == "0.00" || LblAmount == "0")
                                                {
                                                    txtTranscationDate.Text = "";
                                                    txtTransactionId.Text = "";

                                                }
                                                else
                                                {
                                                    txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                                                    txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();

                                                }
                                                // string InstallationName = (row.FindControl("LblInstallation") as Label)?.Text;
                                                CEI.InstallationApproval_Lift(ID, TestReportId, InstallationType, StaffId, InspectionType, txtRegistrationNo.Text, DateTime.Parse(txtChallanDate.Text), TxtDivision.Text, lblMake, lblLiftSrNo, lblTypeOfLift,
                                                lblTypeOfControl, lblCapacity, lblWeight, LblErectionDate, lblLastApprovalDate, txtAddress.Text, txtDistrict.Text, txtTranscationDate.Text, lblMemoNo, LblAmount, txtTransactionId.Text, txtTranscationDate.Text, LblMemoDate, transaction);

                                            }
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata('" + ApprovedorReject + "');", true);

                                        }

                                        transaction.Commit();
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata('" + ApprovedorReject + "');", true);
                                    }

                                    else if (ApprovedorReject == "Rejected")
                                    {
                                        transaction.Commit();
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata2()", true);
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
                                    Session["amount"] = "";
                                    //transaction.Commit();

                                    //commented 3 dec 2024 for 
                                    // checksuccessmessage = 1;

                                    //string actiontype = ApprovedorReject == "Approved" ? "Approved" : "Rejected";
                                    //    Industry_Api_Post_DataformatModel ApiPostformatresult = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(ID), actiontype);

                                    //    if (ApiPostformatresult.PremisesType == "Industryasdasda")
                                    //    {
                                    //        string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);

                                    //        logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
                                    //            "https://staging.investharyana.in/api/project-service-logs-external_UHBVN",
                                    //            new Industry_Inspection_StageWise_JsonDataFormat_Model
                                    //            {
                                    //                actionTaken = ApiPostformatresult.ActionTaken,
                                    //                commentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                    //                //commentDate = ApiPostformatresult.CommentDate,
                                    //                commentDate = ApiPostformatresult.CommentDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                                    //                comments = ApiPostformatresult.Comments,
                                    //                id = ApiPostformatresult.Id,
                                    //                projectid = ApiPostformatresult.ProjectId,
                                    //                serviceid = ApiPostformatresult.ServiceId
                                    //                //projectid = "245df444-1808-4ff6-8421-cf4a859efb4c",
                                    //                //serviceid = "e31ee2a6-3b99-4f42-b61d-38cd80be45b6"
                                    //            },
                                    //            ApiPostformatresult,
                                    //            accessToken
                                    //        );

                                    //        if (!string.IsNullOrEmpty(logDetails.ErrorMessage))
                                    //        {
                                    //            throw new Exception(logDetails.ErrorMessage);
                                    //        }

                                    //        CEI.LogToIndustryApiSuccessDatabase(
                                    //            logDetails.Url,
                                    //            logDetails.Method,
                                    //            logDetails.RequestHeaders,
                                    //            logDetails.ContentType,
                                    //            logDetails.RequestBody,
                                    //            logDetails.ResponseStatusCode,
                                    //            logDetails.ResponseHeaders,
                                    //            logDetails.ResponseBody,
                                    //            new Industry_Api_Post_DataformatModel
                                    //            {
                                    //                InspectionId = ApiPostformatresult.InspectionId,
                                    //                InspectionLogId = ApiPostformatresult.InspectionLogId,
                                    //                IncomingJsonId = ApiPostformatresult.IncomingJsonId,
                                    //                ActionTaken = ApiPostformatresult.ActionTaken,
                                    //                CommentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                    //                CommentDate = ApiPostformatresult.CommentDate,
                                    //                Comments = ApiPostformatresult.Comments,
                                    //                Id = ApiPostformatresult.Id,
                                    //                ProjectId = ApiPostformatresult.ProjectId,
                                    //                ServiceId = ApiPostformatresult.ServiceId,
                                    //            }

                                    //        );
                                    //    }
                                }
                                //commented 3 dec 2024 for 
                                //catch (TokenManagerException ex)
                                //{
                                //    CEI.LogToIndustryApiErrorDatabase(
                                //        ex.RequestUrl,
                                //        ex.RequestMethod,
                                //        ex.RequestHeaders,
                                //        ex.RequestContentType,
                                //        ex.RequestBody,
                                //        ex.ResponseStatusCode,
                                //        ex.ResponseHeaders,
                                //        ex.ResponseBody,
                                //        new Industry_Api_Post_DataformatModel
                                //        {
                                //            InspectionId = ex.InspectionId,
                                //            InspectionLogId = ex.InspectionLogId,
                                //            IncomingJsonId = ex.IncomingJsonId,
                                //            ActionTaken = ex.ActionTaken,
                                //            CommentByUserLogin = ex.CommentByUserLogin,
                                //            CommentDate = ex.CommentDate,
                                //            Comments = ex.Comments,
                                //            Id = ex.Id,
                                //            ProjectId = ex.ProjectId,
                                //            ServiceId = ex.ServiceId,
                                //        }
                                //    );
                                //    string errorMessage = CEI.IndustryTokenApiReturnedErrorMessage(ex);
                                //}
                                //catch (IndustryApiException ex)
                                //{
                                //    CEI.LogToIndustryApiErrorDatabase(
                                //        ex.RequestUrl,
                                //        ex.RequestMethod,
                                //        ex.RequestHeaders,
                                //        ex.RequestContentType,
                                //        ex.RequestBody,
                                //        ex.ResponseStatusCode,
                                //        ex.ResponseHeaders,
                                //        ex.ResponseBody,
                                //        new Industry_Api_Post_DataformatModel
                                //        {
                                //            InspectionId = ex.InspectionId,
                                //            InspectionLogId = ex.InspectionLogId,
                                //            IncomingJsonId = ex.IncomingJsonId,
                                //            ActionTaken = ex.ActionTaken,
                                //            CommentByUserLogin = ex.CommentByUserLogin,
                                //            CommentDate = ex.CommentDate,

                                //            Comments = ex.Comments,
                                //            Id = ex.Id,
                                //            ProjectId = ex.ProjectId,
                                //            ServiceId = ex.ServiceId,
                                //        }
                                //    );
                                //    string errorMessage = CEI.IndustryApiReturnedErrorMessage(ex);
                                //}
                                catch (Exception ex)
                                {
                                    // Handle the exception, log it, etc.
                                    transaction?.Rollback();
                                    string errorMessage = ex.Message.Replace("'", "\\'");
                                    ScriptManager.RegisterStartupScript(this, GetType(), "erroralert", $"alert('{errorMessage}')", true);
                                }
                                finally
                                {
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata('" + ApprovedorReject + "');", true);
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
                Session["RegistrationNo"] = LblRegistrationNo.Text;
                Session["TestReportID"] = LblTestReportId.Text;
                

                if (lblInstallationName != null)
                {
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
                labelInspectionDate.Visible = false;
                labelApprovalDate.Visible = false;
                labelRejectedDate.Visible = true;
            }
            else if (ddlReview.SelectedValue == "1")
            {
                string amount = Session["amount"].ToString();
                if (amount != "0" && amount != "0.00")
                {
                    labelInspectionDate.Visible = true;
                    labelApprovalDate.Visible = false;
                }
                else
                {
                    labelApprovalDate.Visible = true;
                    labelInspectionDate.Visible = false;
                }
                labelRejectedDate.Visible = false;
                //btnPreview.Visible = true;
                //ddlSuggestions.Visible = true;

                //Suggestion.Visible = true;
            }
            else if (ddlReview.SelectedValue == "0")
            {
                string amount = Session["InsAmount"].ToString();
                if (amount != "0" && amount != "0.00")
                {
                    labelInspectionDate.Visible = true;
                    labelApprovalDate.Visible = false;
                }
                else
                {
                    labelApprovalDate.Visible = true;
                    labelInspectionDate.Visible = false;
                }
                labelRejectedDate.Visible = false;

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
                        LnkDocumemtPath2.Text = "Click here to view document";

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
                DataTable dsVC = CEI.InstallationComponentsforLift_Return(ID);

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
                    statement.Visible = true;
                    //string script = "alert(\"No Record Found\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        //protected void lnkRedirectTR(object sender, GridViewRowEventArgs e)
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
                ds = CEI.GetTestReportLift_Return(ID);
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

        protected void lnkRedirect2_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                Label LblRegistrationNo = (Label)row.FindControl("LblRegistrationNo");
                Label LblOldTestReportId = (Label)row.FindControl("LblOldTestReportId");
                Session["RegistrationNo"] = LblRegistrationNo.Text;
                Session["TestReportID"] = LblOldTestReportId.Text;
                if (lblInstallationName != null)
                {
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
            catch (Exception ex) { }
        }

        //protected void Grid_MultipleInspectionTR_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            Label lblOldTestReportId = (Label)e.Row.FindControl("LblOldTestReportId");
        //            LinkButton lnkRedirect = (LinkButton)e.Row.FindControl("lnkRedirectTR1");

        //            // Check if the OldTestReportId is null or empty
        //            if (string.IsNullOrEmpty(lblOldTestReportId.Text))
        //            {
        //                lnkRedirect.Visible = false;
        //            }
        //            else
        //            {
        //                lnkRedirect.Visible = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex) { }
        //}

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblOldTestReportId = (Label)e.Row.FindControl("LblOldTestReportId");
                    LinkButton lnkRedirect = (LinkButton)e.Row.FindControl("lnkRedirect2");

                    // Check if the OldTestReportId is null or empty
                    if (string.IsNullOrEmpty(lblOldTestReportId.Text))
                    {
                        lnkRedirect.Visible = false;
                    }
                    else
                    {
                        lnkRedirect.Visible = true;
                    }
                }
            }
            catch
            {

            }
        }

        protected void Grid_MultipleInspectionTR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblOldTestReportId = (Label)e.Row.FindControl("LblOldTestReportId");
                LinkButton lnkRedirect = (LinkButton)e.Row.FindControl("lnkRedirectTR1");

                
                if (string.IsNullOrEmpty(lblOldTestReportId.Text))
                {
                    lnkRedirect.Visible = false;
                }
                else
                {
                    lnkRedirect.Visible = true;
                }
            }
        }

        protected void lnkRedirectTR1_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                Label LblTestReportId = (Label)row.FindControl("LblOldTestReportId");

                if (lblInstallationName != null)
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


        //protected void Grid_MultipleInspectionTR_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    string Count = string.Empty;
        //    string IntimationId = string.Empty;
        //    if (e.CommandName == "Select")
        //    {
        //        Control ctrl = e.CommandSource as Control;
        //        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
        //        Label LblInstallationName = (Label)row.FindControl("LblInstallationName");
        //        Label LblTestReportCount = (Label)row.FindControl("LblTestReportCount");
        //        //IntimationId = Session["id"].ToString();
        //        Count = LblTestReportCount.Text.Trim();

        //        Label LblIntimationId = (Label)row.FindControl("LblIntimationId");
        //        IntimationId = LblIntimationId.Text.Trim();
        //        Label LblTestReportId = (Label)row.FindControl("LblTestReportId");
        //        //DataSet ds = new DataSet();
        //        //ds = CEI.GetData(LblInstallationName.Text.Trim(), IntimationId, Count);
        //        //if (ds.Tables[0].Rows.Count > 0)
        //        //{

        //        if (LblInstallationName != null)
        //        {
        //            if (LblInstallationName.Text == "Lift")
        //            {
        //                Session["LiftTestReportID"] = LblTestReportId.Text;
        //                Response.Redirect("/TestReportModal/LiftTestReportModal.aspx", false);
        //            }
        //            else if (LblInstallationName.Text == "Escalator")
        //            {
        //                Session["EscalatorTestReportID"] = LblTestReportId.Text;
        //                Response.Redirect("/TestReportModal/EscalatorTestReportModal.aspx", false);
        //            }
        //        }
              
        //    }

     
        //    GetData();


        //}

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
            catch (Exception ex) { }
        }
    }
}