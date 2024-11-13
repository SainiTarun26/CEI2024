using CEI_PRoject;
using CEIHaryana.Model.Industry;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
	public partial class ReturnedInspections : System.Web.UI.Page
	{

        CEI CEI = new CEI();
        private static int count;
        private static string IntimationId, AcceptorReturn, Reason, StaffId;
        string Type = string.Empty;
        string InstallType = string.Empty;
        string ToEmail = string.Empty;
        string CCemail = string.Empty;
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Session["InspectionId"] = "1001373";
                    GetData();
                    if (Type == "New")
                    {
                        GridBindDocument();
                        GetTestReportData();
                    }
                    else if (Type == "Periodic")
                    {

                        GetTestReportDataIfPeriodic();
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
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetTestReportDataIfPeriodic(ID);
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

        public void GetData()
        {
            try
            {
                ID = Session["InspectionId"].ToString();

                DataSet dsa = new DataSet();
                dsa = CEI.GetEmails(ID);
                txtInspectionReportID.Text = dsa.Tables[0].Rows[0]["Id"].ToString();
                txtPremises.Text = dsa.Tables[0].Rows[0]["Inspectiontype"].ToString();
                 ToEmail = dsa.Tables[0].Rows[0]["ToEmail"].ToString();
                 CCemail = dsa.Tables[0].Rows[0]["CCemail"].ToString();
                Session["ToEmail"] = ToEmail.Trim();
                if (CCemail.Trim() != null && CCemail.Trim()!="") {
                    Session["CCemail"] = CCemail.Trim();
                }
                else
                {
                    Session["CCemail"] = "";
                }
                DataSet ds = new DataSet();
                ds = CEI.InspectionData(ID);
                Type = ds.Tables[0].Rows[0]["IType"].ToString();

                if (Type == "New")
                {
                    txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                    txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
                    txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                    if (txtWorkType.Text == "Line")
                    {
                        Capacity.Visible = false;
                        LineVoltage.Visible = true;
                        txtLineVoltage.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                    }
                    else
                    {
                        LineVoltage.Visible = false;
                        Capacity.Visible = true;
                        txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                    }
                    txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                    txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                    txtSiteOwnerContact.Text = ds.Tables[0].Rows[0]["SiteownerContactNumber"].ToString();
                    txtContractorName.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
                    txtContractorPhoneNo.Text = ds.Tables[0].Rows[0]["ContractorContactNo"].ToString();
                    txtContractorEmail.Text = ds.Tables[0].Rows[0]["ContractorEmail"].ToString();
                    txtSupervisorName.Text = ds.Tables[0].Rows[0]["SupervisorName"].ToString();
                    txtSupervisorEmail.Text = ds.Tables[0].Rows[0]["SupervisorEmail"].ToString();
                    txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                    txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                    txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                    // txtInspectionRemark.Text = ds.Tables[0].Rows[0]["InspectionRemarks"].ToString();
                    txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                    //count = Convert.ToInt32(ds.Tables[0].Rows[0]["TestReportCount"].ToString());           //Added     
                    IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();        //Added     
                    string ReturnValu= ds.Tables[0].Rows[0]["ReturnedBasedOnDocumentValue"].ToString();
                    GridBindDocument();
                    ReturnValu = "2";
                    if (ReturnValu == "2")
                    {
                        grd_Documemnts.Columns[3].Visible = false;
                        grd_Documemnts.Columns[4].Visible = false;
                    }
                    else
                        
                    {

                        grd_Documemnts.Columns[3].Visible = false;
                        grd_Documemnts.Columns[4].Visible = false;
                    }
                        DivViewTRinMultipleCaseNew.Visible = true;
                    if (Type == "New")
                    {
                        GridToViewMultipleCaseNew();
                        if (ReturnValu =="1")
                        {

                            Grid_MultipleInspectionTR.Columns[5].Visible = false;
                            Grid_MultipleInspectionTR.Columns[7].Visible = false;
                            Grid_MultipleInspectionTR.Columns[9].Visible = false;
                        }
                        else
                        {

                            Grid_MultipleInspectionTR.Columns[5].Visible = true;
                            Grid_MultipleInspectionTR.Columns[7].Visible = true;
                            Grid_MultipleInspectionTR.Columns[9].Visible = true;
                        }
                    }
                    else
                    {
                        GridToViewTRinMultipleCaseNew();
                    }

                    string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();

                    if (Status.Trim() == "InProcess")
                    {
                        RadioButtonList2.SelectedIndex = RadioButtonList2.Items.IndexOf(RadioButtonList2.Items.FindByValue("0"));
                       RadioButtonList2.Enabled = false;
                        btnBack.Visible = true;
                        btnSubmit.Visible = false;
                    }
                    else if (Status.Trim() == "Return")
                    {
                        RadioButtonList2.SelectedIndex = RadioButtonList2.Items.IndexOf(RadioButtonList2.Items.FindByValue("1"));
                     
                        Rejection.Visible = true;
                        txtRejected.Text = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();

                        btnBack.Visible = true;
                        btnSubmit.Visible = false;
                    }
                    else if (Status.Trim() == "Approved" || Status.Trim() == "Rejected")
                    {
                        RadioButtonList2.Enabled = false;
                        txtRejected.Attributes.Add("disabled", "true");
                        btnBack.Visible = true;
                        btnSubmit.Visible = false;
                    }
                }
                else if (Type == "Periodic")
                {
                    txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                    txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
                    txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                    txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                    txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                    txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                    txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                    txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                    PermisesType.Visible = false;
                    LineVoltage.Visible = false;
                    ContractorName.Visible = false;
                    ContractorPhoneNo.Visible = false;
                    ContractorEmail.Visible = false;
                    SupervisorName.Visible = false;
                    SupervisorEmail.Visible = false;
                    SiteOwnerContact.Visible = false;
                    OwnerAddress.Visible = false;
                    //if (txtApplicantType.Text != "Multiple")
                    //{
                    TRAttached.Visible = true;
                    TRAttachedGrid.Visible = true;
                    GridView1.Columns[7].Visible = false;
                    GridView1.Columns[5].Visible = false;
                    //}
                    //else
                    //{
                    //    TRAttached.Visible = false;
                    //    TRAttachedGrid.Visible = false;
                    //}
                    //TRAttached.Visible = false;
                    //TRAttachedGrid.Visible = false;
                    IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();
                    grd_Documemnts.Columns[1].Visible = true;

                    GridBindDocument();
                    DivViewCart.Visible = true;
                    GridToViewCart();

                    string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                    if (Status.Trim() == "InProcess")
                    {
                        RadioButtonList2.SelectedIndex = RadioButtonList2.Items.IndexOf(RadioButtonList2.Items.FindByValue("0"));
                        RadioButtonList2.Attributes.Add("disabled", "true");
                        RadioButtonList2.Enabled = false;
                        btnBack.Visible = true;
                        btnSubmit.Visible = false;
                    }
                    else if (Status.Trim() == "Return")
                    {
                        RadioButtonList2.SelectedIndex = RadioButtonList2.Items.IndexOf(RadioButtonList2.Items.FindByValue("1"));
                        RadioButtonList2.Attributes.Add("disabled", "true");
                        RadioButtonList2.Enabled = false;
                        Rejection.Visible = true;
                        txtRejected.Text = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
                        btnSubmit.Visible = true;

                        btnBack.Visible = true;
                    }
                    else if (Status.Trim() == "Approved" || Status.Trim() == "Rejected")
                    {
                        RadioButtonList2.Enabled = false;
                        txtRejected.Attributes.Add("disabled", "true");
                        btnBack.Visible = true;
                        btnSubmit.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void GridToViewTRinMultipleCaseNew()
        {
            try
            {
                string ID = Session["InspectionId"].ToString();
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
        private void GridToViewMultipleCaseNew()
        {
            try
            {
                string ID = Session["InspectionId"].ToString();
                DataTable dsVC = CEI.InstallationComponentsforSiteOwner(ID);

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

        protected void lnkRedirect_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            Session["InspectionTestReportId"] = btn.CommandArgument; //txtTestReportId.Text;

            if (txtWorkType.Text.Trim() == "Line")
            {
                Response.Redirect("/TestReportModal/LineTestReportModal.aspx");
            }
            else if (txtWorkType.Text.Trim() == "Substation Transformer")
            {
                Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx");
            }
            else if (txtWorkType.Text.Trim() == "Generating Set")
            {
                Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx");
            }
        }
        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DIV_TRDocuments.Visible = false;
                Check_TRDocuments.Visible = false;

                DIV_ChecklistDocuments.Visible = false;
                Check_ChecklistDocuments.Visible = false;

                Rejection.Visible = false;
                if (RadioButtonList2.SelectedValue == "0")
                {
                    Rejection.Visible = false;
                    RejectionReason.Visible = false;

                }
                else
                {
                    if (RadioButtonList2.SelectedValue == "1")
                    {
                        Rejection.Visible = true;
                        RejectionReason.Visible = false;
                        ddlReasonType.Visible = true;
                        ddlRejectionReasonType.Visible = false;
                    }
                    else
                    {

                        Rejection.Visible = true;
                        RejectionReason.Visible = true;
                        ddlReasonType.Visible = false;
                        ddlRejectionReasonType.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //
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
                   // fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    fileName = "https://localhost:44393" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        }
        protected void ddlReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlReview.SelectedValue == "2")
            //{
            //    Rejection.Visible = true;
            //}
            //else
            //{
            //    Rejection.Visible = false;
            //}
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                if (status == "RETURN")
                {
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].BackColor = ColorTranslator.FromHtml("#9292cc");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int checksuccessmessage = 0;
            try
            {
                if (Session["InspectionId"].ToString() != null && Session["InspectionId"].ToString() != "" && Session["StaffID"].ToString() != null)
                {
                    StaffId = Session["StaffID"].ToString();
                    ID = Session["InspectionId"].ToString();

                    bool isRemarksValid = true;

                    //Remarks validation started
                    #region Remarksvalidation

                    foreach (GridViewRow row in Grid_TRDocuments.Rows)
                    {
                        CheckBox chkSelect = (CheckBox)row.FindControl("chk_Select");
                        TextBox txtRemarks = (TextBox)row.FindControl("txt_Remarks");

                        if (chkSelect != null && chkSelect.Checked && (txtRemarks == null || string.IsNullOrWhiteSpace(txtRemarks.Text)))
                        {
                            isRemarksValid = false;
                            break;
                        }
                    }

                    foreach (GridViewRow row in grd_ChecklistDocumemnts.Rows)
                    {
                        CheckBox chkSelect = (CheckBox)row.FindControl("chk_Select");
                        TextBox txtRemarks = (TextBox)row.FindControl("txt_RemarksforOwnerDoc");

                        if (chkSelect != null && chkSelect.Checked && (txtRemarks == null || string.IsNullOrWhiteSpace(txtRemarks.Text)))
                        {
                            isRemarksValid = false;
                            break;
                        }
                    }

                    if (!isRemarksValid)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please fill in remarks for selected rows.');", true);
                        return;
                    }

                    #endregion
                    //End Code for validation

                    if (RadioButtonList2.SelectedValue != "" && RadioButtonList2.SelectedValue != null)
                    {
                        //AcceptorReturn = RadioButtonList2.SelectedValue == "0" ? "Accepted" : "Return";
                        Reason = string.IsNullOrEmpty(txtRejected.Text) ? null : txtRejected.Text;

                        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

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
                            DataSet ds = new DataSet();
                            ds = CEI.GetTypeOfInspection(ID);
                            InstallType = ds.Tables[0].Rows[0]["TypeOfInspection"].ToString();
                            if (RadioButtonList2.SelectedValue == "2")
                            {
                                CEI.UpdateInspectionRejection(ID, StaffId, ddlRejectionReasonType.SelectedItem.ToString(), Reason);
                                CCemail =Session["CCemail"].ToString();
                                ToEmail = Session["ToEmail"].ToString();
                                string subject = "Inspection Application Rejected";
                                string Message = "Your inspection application (ID: '"+ ID + "') has been rejected as response on the mentioned application is not received from beyond 15 working days. We regret any inconvenience this may cause.     \n\n    \n\nThank you for your understanding.    \n\n    \n\nBest regards,     \n\n[CEIHaryana]'";
                                CEI.RejectMessagethroughEmail(ToEmail, CCemail, subject, Message);
                                checksuccessmessage = 1;
                            }
                            else
                            {

                                if (InstallType == "New")
                                {
                                    if (RadioButtonList2.SelectedValue == "0")
                                    {
                                        CEI.InspectionAccepted(ID, StaffId);
                                    }
                                    else if (RadioButtonList2.SelectedValue == "1")
                                    {
                                        if (ddlReasonType.SelectedItem.Value == "1") // Checklist Documents
                                        {
                                            bool AtLeastOneChecked = false;
                                            foreach (GridViewRow row in grd_ChecklistDocumemnts.Rows)
                                            {
                                                CheckBox chkChecklist = (CheckBox)row.FindControl("chk_SelectDoc");
                                                if (chkChecklist != null && chkChecklist.Checked)
                                                {
                                                    AtLeastOneChecked = true;

                                                    Label LabelRowId = (Label)row.FindControl("LabelRowId");
                                                    TextBox txt_RemarksforOwnerDoc = (TextBox)row.FindControl("txt_RemarksforOwnerDoc");

                                                    if (LabelRowId != null && !string.IsNullOrEmpty(txt_RemarksforOwnerDoc.Text))
                                                    {
                                                        CEI.updateReturnRemarksOnBasesOnChecklistDocuments(ID, StaffId, LabelRowId.Text, txt_RemarksforOwnerDoc.Text, ddlReasonType.SelectedItem.Value);
                                                    }
                                                }
                                            }
                                            if (!AtLeastOneChecked)
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please Tick Atleast One Test Report Before Submit'); ", true);
                                            }
                                        }
                                        else if (ddlReasonType.SelectedItem.Value == "2") // Test Report Documents
                                        {
                                            bool AtLeastOneChecked = false;
                                            foreach (GridViewRow row in Grid_TRDocuments.Rows)
                                            {
                                                CheckBox chk = (CheckBox)row.FindControl("chk_Select");
                                                if (chk != null && chk.Checked)
                                                {
                                                    AtLeastOneChecked = true;

                                                    Label Labelid = (Label)row.FindControl("Labelid");
                                                    Label LblIntimationId = (Label)row.FindControl("LblIntimationId");
                                                    TextBox txtRemarks = (TextBox)row.FindControl("txt_Remarks");

                                                    if (Labelid != null && !string.IsNullOrEmpty(txtRemarks.Text))
                                                    {
                                                        CEI.updateReturnRemarksOnBasesOfTrDocuments(ID, StaffId, LblIntimationId.Text, Labelid.Text, txtRemarks.Text, ddlReasonType.SelectedItem.Value);
                                                    }
                                                }
                                            }
                                            if (!AtLeastOneChecked)
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please Tick Atleast One Test Report Before Submit'); ", true);
                                            }
                                        }
                                        else if (ddlReasonType.SelectedItem.Value == "3") // Checklist & Test Report Documents
                                        {
                                            bool isChecklistValid = false;
                                            bool isTestReportValid = false;
                                            bool allRemarksFilled = true;

                                            // Validate Checklist Documents
                                            foreach (GridViewRow row in grd_ChecklistDocumemnts.Rows)
                                            {
                                                CheckBox chkChecklist = (CheckBox)row.FindControl("chk_SelectDoc");
                                                TextBox txt_RemarksforOwnerDoc = (TextBox)row.FindControl("txt_RemarksforOwnerDoc");

                                                if (chkChecklist != null && chkChecklist.Checked)
                                                {
                                                    isChecklistValid = true;

                                                    if (txt_RemarksforOwnerDoc == null || string.IsNullOrEmpty(txt_RemarksforOwnerDoc.Text))
                                                    {
                                                        allRemarksFilled = false;
                                                        break;
                                                    }
                                                }
                                            }

                                            // Validate Test Report Documents
                                            foreach (GridViewRow row in Grid_TRDocuments.Rows)
                                            {
                                                CheckBox chk = (CheckBox)row.FindControl("chk_Select");
                                                TextBox txtRemarks = (TextBox)row.FindControl("txt_Remarks");

                                                if (chk != null && chk.Checked)
                                                {
                                                    isTestReportValid = true;

                                                    if (txtRemarks == null || string.IsNullOrEmpty(txtRemarks.Text))
                                                    {
                                                        allRemarksFilled = false;
                                                        break;
                                                    }
                                                }
                                            }

                                            if (!isChecklistValid || !isTestReportValid)
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please tick at least one document in both Checklist and Test Report Documents before submitting.');", true);
                                            }
                                            else if (!allRemarksFilled)
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please ensure all checked rows have remarks filled in.');", true);
                                            }
                                            else
                                            {
                                                // Process Checklist Documents
                                                foreach (GridViewRow row in grd_ChecklistDocumemnts.Rows)
                                                {
                                                    CheckBox chkChecklist = (CheckBox)row.FindControl("chk_SelectDoc");
                                                    if (chkChecklist != null && chkChecklist.Checked)
                                                    {
                                                        Label LabelRowId = (Label)row.FindControl("LabelRowId");
                                                        TextBox txt_RemarksforOwnerDoc = (TextBox)row.FindControl("txt_RemarksforOwnerDoc");

                                                        if (LabelRowId != null && !string.IsNullOrEmpty(txt_RemarksforOwnerDoc.Text))
                                                        {
                                                            CEI.updateReturnRemarksOnBasesOnChecklistDocuments(ID, StaffId, LabelRowId.Text, txt_RemarksforOwnerDoc.Text, ddlReasonType.SelectedItem.Value);
                                                        }
                                                    }
                                                }

                                                // Process Test Report Documents
                                                foreach (GridViewRow row in Grid_TRDocuments.Rows)
                                                {
                                                    CheckBox chk = (CheckBox)row.FindControl("chk_Select");
                                                    if (chk != null && chk.Checked)
                                                    {
                                                        Label Labelid = (Label)row.FindControl("Labelid");
                                                        Label LblIntimationId = (Label)row.FindControl("LblIntimationId");
                                                        TextBox txtRemarks = (TextBox)row.FindControl("txt_Remarks");

                                                        if (Labelid != null && !string.IsNullOrEmpty(txtRemarks.Text))
                                                        {
                                                            CEI.updateReturnRemarksOnBasesOfTrDocuments(ID, StaffId, LblIntimationId.Text, Labelid.Text, txtRemarks.Text, ddlReasonType.SelectedItem.Value);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        //if (!AtLeastOneChecked)
                                        //{
                                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please Tick Atleast One Document Before Submit'); ", true);
                                        //}
                                        // }
                                        //CEI.updateInspection(ID, StaffId, IntimationId, 0, txtWorkType.Text.Trim(), AcceptorReturn, Reason, ddlReasonType.SelectedItem.Value);
                                    }
                                }
                                else if (InstallType == "Periodic")
                                {
                                    CEI.updateInspectionPeriodic(ID, StaffId, IntimationId, txtWorkType.Text.Trim(), AcceptorReturn, Reason, ddlReasonType.SelectedItem.Value);
                                }

                                checksuccessmessage = 1;
                            }

                            string actiontype = AcceptorReturn == "Accepted" ? "InProgress" : "Return";
                            Industry_Api_Post_DataformatModel ApiPostformatresult = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(ID), actiontype);

                            if (ApiPostformatresult.PremisesType == "Industry")
                            {
                                // string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                                string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                                // string accessToken = "dfsfdsfsfsdf";

                                logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
                                              "https://staging.investharyana.in/api/project-service-logs-external_UHBVN",
                                              new Industry_Inspection_StageWise_JsonDataFormat_Model
                                              {
                                                  actionTaken = ApiPostformatresult.ActionTaken,
                                                  commentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                                  commentDate = ApiPostformatresult.CommentDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                                                  comments = ApiPostformatresult.Comments,
                                                  id = ApiPostformatresult.Id,
                                                  projectid = ApiPostformatresult.ProjectId,
                                                  serviceid = ApiPostformatresult.ServiceId
                                              }, ApiPostformatresult, accessToken);

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
                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
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
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction if an error occurs
                            //transaction.Rollback();
                            // Handle the exception, log it, etc.
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('An error occurred.');", true);
                        }
                        finally
                        {
                            if (checksuccessmessage == 1)
                            {
                                if (AcceptorReturn == "Accepted")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                                }
                                else
                                {
                                    if (RadioButtonList2.SelectedValue == "2")
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataOfRejection();", true);
                                    }
                                    else
                                    {
                                        if (ddlReasonType.SelectedItem.Value != null)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Inspection Returned to Site Owner');", true);

                                            Response.Redirect("/Officers/AcceptedOrReject.aspx", false);
                                        }
                                        //if (ddlReasonType.SelectedItem.Value == "1") //Based On Documents Returned 
                                        //{
                                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataCommonReturn();", true);
                                        //}
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Please select the yes or no');", true);
                    }
                }
                else
                {
                    Response.Redirect("/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
        private void GridToViewCart()
        {
            try
            {
                string ID = Session["InspectionId"].ToString();
                DataSet dsVC = CEI.GetDetailsToViewCart(ID);

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
        protected void lnkRedirect1_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();

                Session["InspectionTestReportId"] = btn.CommandArgument;

                if (installationName == "Line")
                {
                    Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                }
                else if (installationName == "Substation Transformer")
                {
                    Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                }
                else if (installationName == "Generating Set")
                {
                    Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);
                }
            }
            catch (Exception ex) { }
        }
        protected void lnkRedirectTR_Click1(object sender, EventArgs e)
        {

            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();

                Session["InspectionTestReportId"] = btn.CommandArgument;

                if (installationName == "Line")
                {
                    Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                }
                else if (installationName == "Substation Transformer")
                {
                    Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                }
                else if (installationName == "Generating Set")
                {
                    Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);
                }
            }
            catch (Exception ex) { }
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

                DataSet ds = new DataSet();
                ds = CEI.GetData(LblInstallationName.Text.Trim(), IntimationId, Count);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (LblInstallationName.Text.Trim() == "Line")
                    {
                        Session["LineID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();

                        Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                    }
                    else if (LblInstallationName.Text.Trim() == "Substation Transformer")
                    {
                        Session["SubStationID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                        Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                    }
                    else if (LblInstallationName.Text.Trim() == "Generating Set")
                    {
                        Session["GeneratingSetId"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                        Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);

                    }
                }
            }

            else if (e.CommandName == "View")
            {
                string fileName = "";
                //fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                //lblerror.Text = fileName;
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else if (e.CommandName == "ViewInvoice")
            {
                string fileName = "";
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }


        }
        protected void Grid_MultipleInspectionTR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label LblInstallationName = (Label)e.Row.FindControl("LblInstallationName");
                    LinkButton linkButtonInvoice = (LinkButton)e.Row.FindControl("lnkInstallaionInvoice");
                    LinkButton LinkButtonReport = (LinkButton)e.Row.FindControl("lnkManufacturingReport");
                    LinkButton lnkPreviousInstallaionInvoice = (LinkButton)e.Row.FindControl("lnkPreviousInstallaionInvoice");
                    LinkButton lnkPreviosManufacturingReport = (LinkButton)e.Row.FindControl("lnkPreviosManufacturingReport");
                    if (LblInstallationName.Text.Trim() == "Line")
                    {
                        linkButtonInvoice.Visible = false;
                        LinkButtonReport.Visible = false;
                    }
                    else
                    {
                        linkButtonInvoice.Visible = true;
                        LinkButtonReport.Visible = true;
                    }
                    if (lnkPreviosManufacturingReport.Text.Trim()==""|| lnkPreviosManufacturingReport == null)
                    {
                        lnkPreviosManufacturingReport.Visible = false;

                    }
                    else
                    {
                        lnkPreviosManufacturingReport.Visible = true;
                        lnkPreviosManufacturingReport.Text = "View Document";
                    }
                    if (lnkPreviousInstallaionInvoice.Text.Trim()==""|| lnkPreviousInstallaionInvoice == null)
                    {
                        lnkPreviousInstallaionInvoice.Visible = false;

                    }
                    else
                    {
                        lnkPreviousInstallaionInvoice.Visible = true;
                        lnkPreviousInstallaionInvoice.Text = "View Document";
                    }

                }
            }
            catch (Exception ex)
            {

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
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Officers/NewApplications.aspx", false);

        }
        protected void GridBindDocument()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewReturnDocuments(ID);
                if (ds.Tables.Count > 0)
                {
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
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
        private void GetTestReportData()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetReturnedTestReport(ID);
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
        protected void ddlReasonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlReasonType.SelectedValue == "0")
            //{}else
            if (ddlReasonType.SelectedValue == "1")
            {
                DIV_ChecklistDocuments.Visible = true;
                Check_ChecklistDocuments.Visible = true;

                GridChecklistDocuments();

                DIV_TRDocuments.Visible = false;
                Check_TRDocuments.Visible = false;
            }
            else if (ddlReasonType.SelectedValue == "2")
            {
                DIV_TRDocuments.Visible = true;
                Check_TRDocuments.Visible = true;

                GridTRDocuments();

                DIV_ChecklistDocuments.Visible = false;
                Check_ChecklistDocuments.Visible = false;
            }
            else if (ddlReasonType.SelectedValue == "3")
            {
                DIV_ChecklistDocuments.Visible = true;
                Check_ChecklistDocuments.Visible = true;
                DIV_TRDocuments.Visible = true;
                Check_TRDocuments.Visible = true;

                GridChecklistDocuments();
                GridTRDocuments();
            }
            else
            {
                DIV_ChecklistDocuments.Visible = false;
                Check_ChecklistDocuments.Visible = false;
                DIV_TRDocuments.Visible = false;
                Check_TRDocuments.Visible = false;
            }
        }
        private void GridTRDocuments()
        {
            try
            {
                string ID = Session["InspectionId"].ToString();
                DataSet dsVC = CEI.SelectRemarksDocumentsattachedinTR(ID);

                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    Grid_TRDocuments.DataSource = dsVC;
                    Grid_TRDocuments.DataBind();
                }
                else
                {
                    Grid_TRDocuments.DataSource = null;
                    Grid_TRDocuments.DataBind();
                    string script = "alert('No Record Found');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
            }
        }

        private void GridChecklistDocuments()
        {

            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewDocuments(ID);
                if (ds.Tables.Count > 0)
                {
                    grd_ChecklistDocumemnts.DataSource = ds;
                    grd_ChecklistDocumemnts.DataBind();
                }
                else
                {
                    grd_ChecklistDocumemnts.DataSource = null;
                    grd_ChecklistDocumemnts.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            { }
        }
    }
}