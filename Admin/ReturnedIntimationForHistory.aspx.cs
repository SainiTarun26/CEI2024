using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;
using CEIHaryana.Model.Industry;

namespace CEIHaryana.Admin
{
    public partial class ReturnedIntimationForHistory : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string Id, StaffTo, AssignFrom;
        string Type = string.Empty;

        private static int count;
        private static string IntimationId, AcceptorReturn, Reason, StaffId;
        string InstallType = string.Empty;
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        if (Convert.ToString(Session["InspectionId"]) != null && Convert.ToString(Session["InspectionId"]) != string.Empty)
                        {
                            string InspectionId = Convert.ToString(Session["InspectionId"]);
                            GetDetailsWithId(InspectionId);
                            GetTestReportData(InspectionId);
                        }
                        else
                        {
                            Session["InspectionId"] = "";
                            Response.Redirect("/Admin/IntimationHistoryForAdmin.aspx", false);
                        }
                    }
                    else
                    {
                        Session["AdminId"] = "";
                        Response.Redirect("/AdminLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }
        private void BindDivisions(string District)
        {
            DataSet ds = new DataSet();
            ds = CEI.GetDivisionData(District);
            ddlDivisions.DataSource = ds;
            ddlDivisions.DataTextField = "District";
            ddlDivisions.DataValueField = "District";
            ddlDivisions.DataBind();
            ddlDivisions.Items.Insert(0, new ListItem("Select", "0"));
            ds.Clear();
        }
        private void GetDetailsWithId(string InspectionId)
        {
            try
            {
                //ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.InspectionData(InspectionId);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Type = ds.Tables[0].Rows[0]["IType"].ToString();

                    if (Type == "New")
                    {
                        txtInspectionReportId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                        txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                        txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                        txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                        txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
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
                        txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();

                        txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        txtContractorName.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
                        txtSupervisorName.Text = ds.Tables[0].Rows[0]["SupervisorName"].ToString();

                        txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                        txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                        txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();

                        IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();
                        DivTRinMultipleCaseNew.Visible = true;

                        //GetGridNewInspectionMultiple();

                        string ReturnedValue = ds.Tables[0].Rows[0]["ReturnedBasedOnDocumentValue"].ToString();
                        if (Type == "New")
                        {
                            GridToViewMultipleCaseNew(txtInspectionReportId.Text.Trim());

                            if (ReturnedValue == "1") //ChecklistDocuments
                            {
                                grd_Documemnts.Columns[3].Visible = true;
                                grd_Documemnts.Columns[5].Visible = true;
                                Grid_MultipleInspectionTR.Columns[7].Visible = false;
                                Grid_MultipleInspectionTR.Columns[8].Visible = false;
                                Grid_MultipleInspectionTR.Columns[9].Visible = true;
                                Grid_MultipleInspectionTR.Columns[10].Visible = true;
                                Grid_MultipleInspectionTR.Columns[11].Visible = false;
                            }
                            else if (ReturnedValue == "2") //TestReportDocuments
                            {
                                grd_Documemnts.Columns[3].Visible = false;
                                grd_Documemnts.Columns[5].Visible = false;

                                Grid_MultipleInspectionTR.Columns[7].Visible = true;
                                Grid_MultipleInspectionTR.Columns[8].Visible = true;
                                Grid_MultipleInspectionTR.Columns[9].Visible = true;
                                Grid_MultipleInspectionTR.Columns[10].Visible = true;
                                Grid_MultipleInspectionTR.Columns[11].Visible = true;
                            }
                            else if (ReturnedValue == "3") //BothDocuments
                            {
                                grd_Documemnts.Columns[3].Visible = true;
                                grd_Documemnts.Columns[5].Visible = true;

                                Grid_MultipleInspectionTR.Columns[7].Visible = true;
                                Grid_MultipleInspectionTR.Columns[8].Visible = true;
                                Grid_MultipleInspectionTR.Columns[9].Visible = true;
                                Grid_MultipleInspectionTR.Columns[10].Visible = true;
                                Grid_MultipleInspectionTR.Columns[11].Visible = true;
                            }
                        }
                        else
                        {
                            GetGridNewInspectionMultiple(txtInspectionReportId.Text.Trim());
                        }

                        GridBindDocument(txtInspectionReportId.Text.Trim());
                        BindDivisions(txtDistrict.Text.Trim());
                        string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();

                        if (Status.Trim() == "InProcess")
                        {
                            RdbtnAccptReturn.SelectedIndex = RdbtnAccptReturn.Items.IndexOf(RdbtnAccptReturn.Items.FindByValue("0"));
                            RdbtnAccptReturn.Attributes.Add("disabled", "true");
                            RdbtnAccptReturn.Enabled = false;
                            btnBack.Visible = true;
                            btnUpdate.Visible = false;
                        }
                        else if (Status.Trim() == "Return")
                        {
                            RdbtnAccptReturn.SelectedIndex = RdbtnAccptReturn.Items.IndexOf(RdbtnAccptReturn.Items.FindByValue("1"));
                            RdbtnAccptReturn.Attributes.Add("disabled", "true");
                            RdbtnAccptReturn.Enabled = false;
                            Return.Visible = true;
                            txtRejected.Text = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
                            txtRejected.Attributes.Add("disabled", "true");

                            btnBack.Visible = true;
                            btnUpdate.Visible = false;
                        }
                        else if (Status.Trim() == "Approved" || Status.Trim() == "Rejected")
                        {
                            RdbtnAccptReturn.Enabled = false;
                            txtRejected.Attributes.Add("disabled", "true");
                            btnBack.Visible = true;
                            btnUpdate.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string script = "alert('An error occurred, please try again later');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        private void GetGridNewInspectionMultiple(string InspectionId)
        {
            try
            {
                //string ID = Session["InspectionId"].ToString();
                DataSet dsVC = CEI.GetDetailsToViewTRinMultipleCaseNew(InspectionId);
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

                string script = "alert('An error occurred, please try again later');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true); 
            }
        }
        private void GridToViewMultipleCaseNew(string inspectionReportId)
        {
            try
            {
                //string ID = Session["InspectionId"].ToString();
                DataTable dsVC = CEI.InstallationComponentsforSiteOwner(inspectionReportId);

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

                string script = "alert('An error occurred, please try again later');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/IntimationHistoryForAdmin.aspx", false);
            Session["InspectionId"] = "";
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int checksuccessmessage = 0;
            try
            {
               // if (Session["InspectionId"].ToString() != null && Session["InspectionId"].ToString() != "" && Session["AdminID"].ToString() != null)
                    if (Session["AdminID"].ToString() != "" && Session["AdminID"].ToString() != null)
                    {
                    StaffId = Session["AdminID"].ToString();
                    //ID = Session["InspectionId"].ToString();
                    ID = txtInspectionReportId.Text.Trim();
                    AssignFrom = Session["AdminID"].ToString();

                    bool isRemarksValid = true;
                    #region RemarksValidation

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
                        CheckBox chkSelect = (CheckBox)row.FindControl("chk_SelectDoc");
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

                    if (RadioButtonAction.SelectedValue != "" && RadioButtonAction.SelectedValue != null)
                    {
                        if (RadioButtonAction.SelectedValue == "0")
                        {

                            if (RdbtnAccptReturn.SelectedValue != "" && RdbtnAccptReturn.SelectedValue != null)
                            {
                                AcceptorReturn = RdbtnAccptReturn.SelectedValue == "0" ? "Accepted" : "Return";
                                Reason = string.IsNullOrEmpty(txtRejected.Text) ? null : txtRejected.Text;

                                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

                                try
                                {
                                    string reqType = CEI.GetIndustry_RequestType_New(Convert.ToInt32(ID));
                                    if (reqType == "Industry")
                                    {
                                        string serverStatus = CEI.CheckServerStatus("https://investharyana.in");
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

                                    if (RdbtnAccptReturn.SelectedValue == "2")
                                    {
                                        CEI.UpdateInspectionRejection(ID, StaffId, ddlRejectionReasonType.SelectedItem.ToString(), Reason);

                                        checksuccessmessage = 1;
                                    }
                                    //else
                                    //{
                                    //    CEI.updateInspectionPeriodic(ID, StaffId, IntimationId, txtWorkType.Text.Trim(), AcceptorReturn, Reason, DdlReturnInPeriodic.SelectedItem.Value);

                                    //    checksuccessmessage = 1;
                                    //}
                                    else
                                    {
                                        if (InstallType == "New")
                                        {
                                            if (RdbtnAccptReturn.SelectedValue == "0")
                                            {
                                                CEI.updateInspectionCEI(ID, StaffId, IntimationId, count, txtWorkType.Text.Trim(), AcceptorReturn, Reason, ddlReasonType.SelectedItem.Value);
                                            }
                                            else if (RdbtnAccptReturn.SelectedValue == "1")
                                            {
                                                SqlTransaction transaction = null;
                                                try
                                                {
                                                    using (SqlConnection connection = new SqlConnection(connectionString))
                                                    {
                                                        connection.Open();
                                                        transaction = connection.BeginTransaction();
                                                        CEI.UpdateStatusOfReturnedInspection(ID, StaffId, ddlReasonType.SelectedItem.Value, transaction);

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
                                                                        CEI.updateReturnRemarksOnBasesOnChecklistDocuments(ID, LabelRowId.Text, txt_RemarksforOwnerDoc.Text, transaction);
                                                                    }
                                                                }
                                                            }
                                                            if (AtLeastOneChecked != true)
                                                            {
                                                                transaction.Rollback();
                                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please Tick Atleast One Test Report Before Submit'); ", true);
                                                                return;
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
                                                                        CEI.updateReturnRemarksOnBasesOfTrDocuments(ID, LblIntimationId.Text, Labelid.Text, txtRemarks.Text, transaction);
                                                                    }
                                                                }
                                                            }
                                                            if (!AtLeastOneChecked)
                                                            {
                                                                transaction.Rollback();
                                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please Tick Atleast One Test Report Before Submit'); ", true);
                                                            }
                                                        }
                                                        else if (ddlReasonType.SelectedItem.Value == "3") // Checklist & Test Report Documents
                                                        {
                                                            bool isChecklistValid = false;
                                                            bool isTestReportValid = false;
                                                            bool allRemarksFilled = true;

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
                                                                transaction.Rollback();
                                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please tick at least one document in both Checklist and Test Report Documents before submitting.');", true);
                                                                return;
                                                            }
                                                            else if (!allRemarksFilled)
                                                            {
                                                                transaction.Rollback();
                                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please ensure all checked rows have remarks filled in.');", true);
                                                                return;
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
                                                                            CEI.updateReturnRemarksOnBasesOnChecklistDocuments(ID, LabelRowId.Text, txt_RemarksforOwnerDoc.Text, transaction);
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
                                                                            CEI.updateReturnRemarksOnBasesOfTrDocuments(ID, LblIntimationId.Text, Labelid.Text, txtRemarks.Text, transaction);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        transaction.Commit();
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    transaction.Rollback();
                                                }
                                            }
                                        }
                                        else if (InstallType == "Periodic")
                                        {
                                            CEI.updateInspectionPeriodic(ID, StaffId, IntimationId, txtWorkType.Text.Trim(), AcceptorReturn, Reason, DdlReturnInPeriodic.SelectedItem.Value);
                                        }
                                        checksuccessmessage = 1;
                                    }
                                    string actiontype = AcceptorReturn == "Accepted" ? "InProgress" : "Return";
                                    List<Industry_Api_Post_DataformatModel> ApiPostformatResults = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(ID), actiontype);
                                    foreach (var ApiPostformatresult in ApiPostformatResults)
                                    {
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
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Enter valid reason for your action.');", true);
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
                                            if (RdbtnAccptReturn.SelectedValue == "2")
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Inspection Rejected Successfully'); window.location='IntimationHistoryForAdmin.aspx'", true);
                                            }
                                            else if (RdbtnAccptReturn.SelectedValue == "1")
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Inspection Return to SiteOwner Successfully'); window.location='IntimationHistoryForAdmin.aspx'", true);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Please select an Action for Inspection');", true);
                            }
                        }
                        else
                        {
                            if (ddlToAssign.SelectedValue != null && ddlToAssign.SelectedValue != "0")
                            {
                                StaffTo = ddlToAssign.SelectedValue;
                                CEI.UpdateInspectionDataOnAction(ID, StaffTo, AssignFrom);

                                ddlDivisions.SelectedIndex = 0;
                                ddlToAssign.SelectedIndex = 0;
                                string script = $"alert('Inspection sent to {StaffTo} successfully.'); window.location='IntimationHistoryForAdmin.aspx';";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                            }
                            else
                            {
                                ddlToAssign.Focus();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", "alert('Select Staff before save');", true);
                                return;
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Please select the Process or Transfer');", true);
                    }
                }
                else
                {
                    Response.Redirect("/AdminLogout.aspx");
                }
            }
            catch (Exception ex) { }
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
            catch (Exception ex)
            {

                string script = "alert('An error occurred, please try again later');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
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
                    ID = txtInspectionReportId.Text.Trim();
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {

                string script = "alert('An error occurred, please try again later');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        private void BindDropDownToAssign(string Division)
        {
            try
            {
                DataSet dsAssign = new DataSet();
                dsAssign = CEI.DdlToStaffAssign(Division);
                ddlToAssign.DataSource = dsAssign;
                ddlToAssign.DataTextField = "Staff";
                ddlToAssign.DataValueField = "StaffUserId";
                ddlToAssign.DataBind();
                ddlToAssign.Items.Insert(0, new ListItem("Select", "0"));
                dsAssign.Clear();
            }
            catch (Exception ex)
            {

                string script = "alert('An error occurred, please try again later');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        protected void ddlDivisions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDivisions.SelectedValue != "" && ddlDivisions.SelectedValue != null)
            {
                BindDropDownToAssign(ddlDivisions.SelectedValue);
            }
        }
        protected void RdbtnAccptReturn_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            Return.Visible = false;
            if (RdbtnAccptReturn.SelectedValue == "1") //No(Return)
            {
                Return.Visible = true;
                btnUpdate.Visible = true;
                DivRejectionReasonType.Visible = false;
                DivReason.Visible = false;
            }
            else if (RdbtnAccptReturn.SelectedValue == "2") //Reject
            {
                DivRejectionReasonType.Visible = true;
                DivReason.Visible = true;

                ddlReasonType.SelectedValue = "0";
                DIV_ChecklistDocuments.Visible = false;
                Check_ChecklistDocuments.Visible = false;
                DIV_TRDocuments.Visible = false;
                Check_TRDocuments.Visible = false;
            }
            else //Yes(Accept)
            {
                DivRejectionReasonType.Visible = false;
                DivReason.Visible = false;

                ddlReasonType.SelectedValue = "0";
                DIV_ChecklistDocuments.Visible = false;
                Check_ChecklistDocuments.Visible = false;
                DIV_TRDocuments.Visible = false;
                Check_TRDocuments.Visible = false;
            }
        }
        protected void RadioButtonAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonAction.SelectedValue == "1")
            {
                TransferButton.Visible = true;
                btnUpdate.Visible = true;
                Action.Visible = false;
                Return.Visible = false;
            }
            else
            {
                TransferButton.Visible = false;
                Action.Visible = true;
                Return.Visible = false;
                btnUpdate.Visible = true;
            }
        }
        protected void GridBindDocument(string InspID)
        {
            try
            {
                //ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                //ds = CEI.ViewDocuments(ID);

                ds = CEI.ViewReturnDocuments(InspID);
                if (ds.Tables.Count > 0)
                {
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                string script = "alert('An error occurred, please try again later');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        private void GetTestReportData(string InspectionId)
        {
            try
            {
                //ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetTestReport(InspectionId);
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
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                string script = "alert('An error occurred, please try again later');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        private void GridTRDocuments(string InspectionId)
        {
            try
            {
                //string ID = Session["InspectionId"].ToString();
                DataSet dsVC = CEI.SelectRemarksDocumentsattachedinTR(InspectionId);

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

                string script = "alert('An error occurred, please try again later');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        private void GridChecklistDocuments(string InspectionId)
        {
            try
            {
                //ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewDocuments(InspectionId);
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
            {

                string script = "alert('An error occurred, please try again later');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        protected void chk_SelectDoc_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkBox.NamingContainer;
            TextBox txtRemarks = (TextBox)row.FindControl("txt_RemarksforOwnerDoc");

            txtRemarks.Enabled = chkBox.Checked;

            if (!chkBox.Checked)
            {
                txtRemarks.Text = string.Empty;
            }
        }
        protected void chk_Select_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkBox.NamingContainer;
            TextBox txtRemarks1 = (TextBox)row.FindControl("txt_Remarks");

            txtRemarks1.Enabled = chkBox.Checked;

            if (!chkBox.Checked)
            {
                txtRemarks1.Text = string.Empty;
            }
        }
        protected void ddlReasonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInspectionReportId.Text.Trim()))
            {
                if (ddlReasonType.SelectedValue == "1")
                {
                    DIV_ChecklistDocuments.Visible = true;
                    Check_ChecklistDocuments.Visible = true;

                    GridChecklistDocuments(txtInspectionReportId.Text.Trim());

                    DIV_TRDocuments.Visible = false;
                    Check_TRDocuments.Visible = false;
                }
                else if (ddlReasonType.SelectedValue == "2")
                {
                    DIV_TRDocuments.Visible = true;
                    Check_TRDocuments.Visible = true;

                    GridTRDocuments(txtInspectionReportId.Text.Trim());

                    DIV_ChecklistDocuments.Visible = false;
                    Check_ChecklistDocuments.Visible = false;
                }
                else if (ddlReasonType.SelectedValue == "3")
                {
                    DIV_ChecklistDocuments.Visible = true;
                    Check_ChecklistDocuments.Visible = true;
                    DIV_TRDocuments.Visible = true;
                    Check_TRDocuments.Visible = true;

                    GridChecklistDocuments(txtInspectionReportId.Text.Trim());
                    GridTRDocuments(txtInspectionReportId.Text.Trim());
                }
                else
                {
                    DIV_ChecklistDocuments.Visible = false;
                    Check_ChecklistDocuments.Visible = false;
                    DIV_TRDocuments.Visible = false;
                    Check_TRDocuments.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }

        protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton LnkPreviousDocPath = (LinkButton)e.Row.FindControl("LnkPreviousDocPath");

                    // Check if the control is found and CommandArgument is not empty
                    if (LnkPreviousDocPath != null && !string.IsNullOrWhiteSpace(LnkPreviousDocPath.CommandArgument))
                    {
                        LnkPreviousDocPath.Visible = true;
                        LnkPreviousDocPath.Text = "View Document"; // Set the desired text
                    }
                    else
                    {
                        LnkPreviousDocPath.Visible = false; // Hide the link if no valid path
                    }
                }
            }
            catch (Exception ex)
            {

                string script = "alert('An error occurred, please try again later');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        //protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            LinkButton LnkPreviousDocPath = (LinkButton)e.Row.FindControl("LnkPreviousDocPath");

        //            if (LnkPreviousDocPath != null && LnkPreviousDocPath != "")
        //            {
        //                LnkPreviousDocPath.Visible = true;
        //                LnkPreviousDocPath.Text = "Click here to view document";
        //            }
        //            else
        //            {
        //                LnkPreviousDocPath.Visible = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Consider logging the exception or handling it appropriately
        //    }
        //}

        protected void lnkRedirect_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            Session["InspectionTestReportId"] = btn.CommandArgument;

            if (txtWorkType.Text.Trim() == "Line")
            {
                Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
            }
            else if (txtWorkType.Text.Trim() == "Substation Transformer")
            {
                Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
            }
            else if (txtWorkType.Text.Trim() == "Generating Set")
            {
                Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);
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
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else if (e.CommandName == "ViewInvoice")
            {
                string fileName = "";
               // fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
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
                    if (lnkPreviosManufacturingReport.Text.Trim() == "" || lnkPreviosManufacturingReport == null)
                    {
                        lnkPreviosManufacturingReport.Visible = false;

                    }
                    else
                    {
                        lnkPreviosManufacturingReport.Visible = true;
                        lnkPreviosManufacturingReport.Text = "View Document";
                    }
                    if (lnkPreviousInstallaionInvoice.Text.Trim() == "" || lnkPreviousInstallaionInvoice == null)
                    {
                        lnkPreviousInstallaionInvoice.Visible = false;

                    }
                    else
                    {
                        lnkPreviousInstallaionInvoice.Visible = true;
                        lnkPreviousInstallaionInvoice.Text = "View Document";
                    }
                    if (LblInstallationName.Text.Trim() == "Line")
                    {
                        Grid_MultipleInspectionTR.Columns[9].Visible = false;
                        Grid_MultipleInspectionTR.Columns[10].Visible = false;
                        lnkPreviousInstallaionInvoice.Visible = false;
                        lnkPreviosManufacturingReport.Visible = false;
                        linkButtonInvoice.Visible = false;
                        LinkButtonReport.Visible = false;
                    }
                    else if (LblInstallationName.Text.Trim() == "Switching Station")
                    {
                        Grid_MultipleInspectionTR.Columns[9].Visible = true;
                        Grid_MultipleInspectionTR.Columns[10].Visible = true;
                        lnkPreviousInstallaionInvoice.Visible = false;
                        lnkPreviosManufacturingReport.Visible = true;
                        linkButtonInvoice.Visible = false;
                        LinkButtonReport.Visible = true;
                        ViewState["AllRowsAreLine"] = false;
                    }
                    else
                    {
                        Grid_MultipleInspectionTR.Columns[9].Visible = true;
                        Grid_MultipleInspectionTR.Columns[10].Visible = true;
                        lnkPreviousInstallaionInvoice.Visible = true;
                        lnkPreviosManufacturingReport.Visible = true;
                        linkButtonInvoice.Visible = true;
                        LinkButtonReport.Visible = true;
                        ViewState["AllRowsAreLine"] = false;
                    }
                    //Label LblInstallationName = (Label)e.Row.FindControl("LblInstallationName");
                    if (LblInstallationName.Text.Trim() == "Switching Station")
                    {
                        RadioButtonAction.Items.FindByValue("1").Enabled = false;
                    }

                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    if (ViewState["AllRowsAreLine"] == null || (bool)ViewState["AllRowsAreLine"] == true)
                    {
                        ddlReasonType.Items.Clear();
                        ddlReasonType.Items.Add(new ListItem("Select", "0"));
                        ddlReasonType.Items.Add(new ListItem("Checklist Documents", "1"));
                    }
                    else
                    {
                        ddlReasonType.Items.Clear();
                        ddlReasonType.Items.Add(new ListItem("Select", "0"));
                        ddlReasonType.Items.Add(new ListItem("Checklist Documents", "1"));
                        ddlReasonType.Items.Add(new ListItem("Test Report Documents", "2"));
                        ddlReasonType.Items.Add(new ListItem("Both (Checklist & TestReport Documents)", "3"));
                    }
                }
            }
            catch (Exception ex)
            { }
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
            catch (Exception ex)
            {

                string script = "alert('An error occurred, please try again later');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
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
    }
}