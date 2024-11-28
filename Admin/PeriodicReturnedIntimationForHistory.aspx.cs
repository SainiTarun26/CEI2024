using System;
using System.Collections.Generic;
using System.Configuration;
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
    public partial class PeriodicReturnedIntimationForHistory : System.Web.UI.Page
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
                    if (Convert.ToString(Session["AdminID"]) != null && Convert.ToString(Session["AdminID"]) != "")
                    {
                        GetDetailsWithId();
                    }
                    else
                    {
                        Response.Redirect("/Login.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Login.aspx", false);
            }
        }

        private void GetTestReportDataIfPeriodic()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetTestReportDataIfPeriodic(ID);
                string TestReportId = string.Empty;
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
        private void GetDetailsWithId()
        {
            try
            {
                ID = Session["InspectionId"].ToString();

                DataSet ds = new DataSet();
                ds = CEI.InspectionData(ID);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Type = ds.Tables[0].Rows[0]["IType"].ToString();

                    if (Type == "Periodic")
                    {
                        txtInspectionReportId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                        txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                        txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                        txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                        txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                        txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                        txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();

                        txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        ContractorName.Visible = false;
                        SupervisorName.Visible = false;
                        LineVoltage.Visible = false;

                        txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                        txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                        txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                        TypeOfInspection.Visible = false;

                        txtInspectionReportId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                        txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                        txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                        txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                        txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                        txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                        txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        ContractorName.Visible = false;
                        SupervisorName.Visible = false;
                        LineVoltage.Visible = false;

                        txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                        txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                        txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                        TypeOfInspection.Visible = false;
                        TRAttached.Visible = true;
                        TRAttachedGrid.Visible = true;
                        IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();

                        GridBindDocumentPeriodic();
                        GetTestReportDataIfPeriodic();
                        GridToViewCart();

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
                Console.WriteLine($"An error occurred: {ex.Message}");
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
                if (Session["InspectionId"].ToString() != null && Session["InspectionId"].ToString() != "" && Session["AdminID"].ToString() != null)
                {
                    StaffId = Session["AdminID"].ToString();
                    ID = Session["InspectionId"].ToString();
                    AssignFrom = Session["AdminID"].ToString();

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

                                    if (RdbtnAccptReturn.SelectedValue == "2")
                                    {
                                        CEI.UpdateInspectionRejection(ID, StaffId, ddlRejectionReasonType.SelectedItem.ToString(), Reason);

                                        checksuccessmessage = 1;
                                    }
                                    else
                                    {
                                        CEI.updateInspectionPeriodic(ID, StaffId, IntimationId, txtWorkType.Text.Trim(), AcceptorReturn, Reason, DdlReturnInPeriodic.SelectedItem.Value);

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
                    Response.Redirect("/Login.aspx");
                }
            }
            catch (Exception ex) { }
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
                }
            }
            catch (Exception ex)
            { }
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
        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    ID = Session["InspectionId"].ToString();
                    fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    // fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            { }
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
            { }
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
            if (RdbtnAccptReturn.SelectedValue == "1") //No(Return)
            {
                Return.Visible = true;
                DivReason.Visible = true;
                DivRejectionReasonType.Visible = false;

            }
            else if (RdbtnAccptReturn.SelectedValue == "2") //Reject
            {
                DivRejectionReasonType.Visible = true;
                DivReason.Visible = true;
                Return.Visible = false;
            }
            else if (RdbtnAccptReturn.SelectedValue == "0")
            {
                DivRejectionReasonType.Visible = false;
                DivReason.Visible = false;

                Return.Visible = false;
            }
        }
        protected void RadioButtonAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonAction.SelectedValue == "1") //Transfer
            {
                TransferButton.Visible = true;
                btnUpdate.Visible = true;
                Action.Visible = false;
                Return.Visible = false;
                DivReason.Visible = false;
                DivRejectionReasonType.Visible = false;
            }
            else if (RadioButtonAction.SelectedValue == "0") //Process
            {
                TransferButton.Visible = false;
                Action.Visible = true;
                Return.Visible = false;
                btnUpdate.Visible = true;
            }
        }
        protected void GridBindDocumentPeriodic()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewReturnDocumentsForPeriodic(ID);
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
            catch (Exception ex) { }
        }
        protected void lnkRedirectTRr_Click1(object sender, EventArgs e)
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
        #region Return
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
                fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else if (e.CommandName == "ViewInvoice")
            {
                string fileName = "";
                fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
        }
        #endregion
    }
}