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

namespace CEIHaryana.Officers
{
    public partial class Returned_Inspection_Lift_Escalator : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private static int count;
        private static string IntimationId, AcceptorReturn, Reason, StaffId;
        string Type = string.Empty;
        string InstallType = string.Empty;
        string ToEmail = string.Empty;
        string CCemail = string.Empty;
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        private bool allRowsContainLine = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetData();
                    if (Type == "New")
                    {
                        GetTestReportData();
                        ViewState["AllRowsAreLine"] = true;
                    }
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }

        public void GetData()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.InspectionData_Lift_Escalator(ID);
                Type = ds.Tables[0].Rows[0]["IType"].ToString();

                if (Type == "New")
                {
                    txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
                    txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                    lblInspectionType.Text = ds.Tables[0].Rows[0]["Type_of_Inspection"].ToString();
                    lblInstallation.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                    txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                    txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                    txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                    txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                    txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                    IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();
                    if (txtAmount.Text == "0")
                    {
                        TranscationDetails.Visible = false;
                    }
                    else
                    {
                        TranscationDetails.Visible = true;
                    }

                    string ReturnValue = ds.Tables[0].Rows[0]["ReturnedBasedOnDocumentValue"].ToString();

                    GridBindDocument();
                    DivViewTRinMultipleCaseNew.Visible = true;

                    GridToViewTRinMultipleCaseNew();
                    if (ReturnValue == "1")
                    {
                        grd_Documemnts.Columns[3].Visible = false;
                     
                    }
                    else if (ReturnValue == "2")
                    {
                        Grid_MultipleInspectionTR.Columns[4].Visible = false;
                    }
                    else
                    {
                        grd_Documemnts.Columns[2].Visible = false;
                        Grid_MultipleInspectionTR.Columns[3].Visible = false;
                    }

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
                        txtRejected.Attributes.Add("disabled", "true");

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

                ID = Session["InspectionId"].ToString();

                DataSet dsa = new DataSet();
                dsa = CEI.GetEmails(ID);
                try
                {
                    ToEmail = dsa.Tables[0].Rows[0]["ToEmail"].ToString();
                    CCemail = dsa.Tables[0].Rows[0]["CCemail"].ToString();
                    Session["ToEmail"] = ToEmail.Trim();
                    if (CCemail.Trim() != null && CCemail.Trim() != "")
                    {
                        Session["CCemail"] = CCemail.Trim();
                    }
                    else
                    {
                        Session["CCemail"] = "";
                    }
                }
                catch
                {
                    Session["ToEmail"] = "";

                    Session["CCemail"] = "";
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
                DataSet dsVC = CEI.ViewTRinMultipleCaseNewReturned_Lift_Escalator(ID);

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
            }
        }
        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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

                        RejectionReason.Visible = true;
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
            }

        }
        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    //fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int checksuccessmessage = 0;
            try
            {
                if (Session["InspectionId"].ToString() != null && Session["InspectionId"].ToString() != "" && Session["StaffID"].ToString() != null)
                {
                    StaffId = Session["StaffID"].ToString();
                    ID = Session["InspectionId"].ToString();

                    if (RadioButtonList2.SelectedValue != "" && RadioButtonList2.SelectedValue != null)
                    {
                        // AcceptorReturn = RadioButtonList2.SelectedValue == "0" ? "Accepted" : "Return";
                        AcceptorReturn = RadioButtonList2.SelectedValue == "0" ? "Accepted" :
                                         RadioButtonList2.SelectedValue == "1" ? "Return" :
                                         RadioButtonList2.SelectedValue == "2" ? "Rejected" : "";
                        Reason = string.IsNullOrEmpty(txtRejected.Text) ? null : txtRejected.Text;

                        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
                        //SqlTransaction transaction = null;
                        try
                        {
                            //string reqType = CEI.GetIndustry_RequestType_New(Convert.ToInt32(ID));
                            //if (reqType == "Industry")
                            //{
                            //    string serverStatus = CEI.CheckServerStatus("https://staging.investharyana.in");
                            //    // string serverStatus = CEI.CheckServerStatus("https://investharyana.in/api/project-service-logs-external_UHBVN");
                            //    if (serverStatus != "Server is reachable.")
                            //    {
                            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('HEPC Server Is Not Responding . Please Try After Some Time')", true);
                            //        return;
                            //    }
                            //}
                            DataSet ds = new DataSet();
                            ds = CEI.GetTypeOfInspection(ID);
                            InstallType = ds.Tables[0].Rows[0]["TypeOfInspection"].ToString();
                            if (RadioButtonList2.SelectedValue == "2")
                            {
                                CEI.UpdateInspectionRejection_Lift_Escalator(ID, StaffId, ddlRejectionReasonType.SelectedItem.ToString(), Reason);
                                CCemail = Session["CCemail"].ToString();
                                ToEmail = Session["ToEmail"].ToString();
                                if (ToEmail.Trim() != "" && ToEmail != null)
                                {
                                    string subject = "Inspection Application Rejected";
                                    string Message = "Your inspection application (ID: '" + ID + "') has been rejected as response on the mentioned application is not received from beyond 15 working days. We regret any inconvenience this may cause.     \n\nThank you for your understanding.     \n\nBest regards,     \n\n[CEIHaryana]'";
                                    CEI.RejectMessagethroughEmail(ToEmail, CCemail, subject, Message);
                                    checksuccessmessage = 1;
                                }
                                else
                                { }
                            }
                            else
                            {
                                if (InstallType == "New")
                                {
                                    if (RadioButtonList2.SelectedValue == "0")
                                    {
                                        CEI.InspectionAccepted_Lift_Escalator(ID, StaffId);
                                        CCemail = Session["CCemail"].ToString();
                                        ToEmail = Session["ToEmail"].ToString();
                                        if (ToEmail.Trim() != "" && ToEmail != null)
                                        {
                                            string subject = "Inspection Application Accepted";
                                            string Message = "We are pleased to inform you that your inspection application (ID: '" + ID + "') has been Accepted by the officer . Please login to your Portal with your credentials to check return remarks     \n\n    \n\nShould you have any questions or need assistance, feel free to reach out.     \n\nBest regards,     \n\n[CEIHaryana]'";
                                            CEI.RejectMessagethroughEmail(ToEmail, CCemail, subject, Message);
                                        }
                                        else
                                        { }
                                    }
                                    else if (RadioButtonList2.SelectedValue == "1")
                                    {
                                        CEI.Update_NewInspectionReturn_Lift_Escalator(ID, StaffId, IntimationId, txtWorkType.Text.Trim(), AcceptorReturn, Reason, ddlReasonType.SelectedItem.Value, ddlReasonType.SelectedItem.Text);
                                    }
                                    checksuccessmessage = 1;
                                }
                                //string actiontype = AcceptorReturn == "Accepted" ? "InProgress" : "Return";
                                //string actiontype = AcceptorReturn == "Accepted" ? "InProgress" :
                                //                    AcceptorReturn == "Return" ? "Return" :
                                //                    AcceptorReturn == "Rejected" ? "Rejected" : "";
                                //Industry_Api_Post_DataformatModel ApiPostformatresult = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(ID), actiontype);
                                //if (ApiPostformatresult.PremisesType == "Industry")
                                //{
                                //    // string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                                //    string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                                //    // string accessToken = "dfsfdsfsfsdf";
                                //    logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
                                //                  "https://staging.investharyana.in/api/project-service-logs-external_UHBVN",
                                //                  new Industry_Inspection_StageWise_JsonDataFormat_Model
                                //                  {
                                //                      actionTaken = ApiPostformatresult.ActionTaken,
                                //                      commentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                //                      commentDate = ApiPostformatresult.CommentDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                                //                      comments = ApiPostformatresult.Comments,
                                //                      id = ApiPostformatresult.Id,
                                //                      projectid = ApiPostformatresult.ProjectId,
                                //                      serviceid = ApiPostformatresult.ServiceId
                                //                  }, ApiPostformatresult, accessToken);
                                //    if (!string.IsNullOrEmpty(logDetails.ErrorMessage))
                                //    {
                                //        throw new Exception(logDetails.ErrorMessage);
                                //    }
                                //    CEI.LogToIndustryApiSuccessDatabase(
                                //    logDetails.Url,
                                //    logDetails.Method,
                                //    logDetails.RequestHeaders,
                                //    logDetails.ContentType,
                                //    logDetails.RequestBody,
                                //    logDetails.ResponseStatusCode,
                                //    logDetails.ResponseHeaders,
                                //    logDetails.ResponseBody,
                                //    new Industry_Api_Post_DataformatModel
                                //    {
                                //        InspectionId = ApiPostformatresult.InspectionId,
                                //        InspectionLogId = ApiPostformatresult.InspectionLogId,
                                //        IncomingJsonId = ApiPostformatresult.IncomingJsonId,
                                //        ActionTaken = ApiPostformatresult.ActionTaken,
                                //        CommentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                //        CommentDate = ApiPostformatresult.CommentDate,
                                //        Comments = ApiPostformatresult.Comments,
                                //        Id = ApiPostformatresult.Id,
                                //        ProjectId = ApiPostformatresult.ProjectId,
                                //        ServiceId = ApiPostformatresult.ServiceId,
                                //    }
                                //);
                                //}
                            }
                        }
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
                        //    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                        //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                        //    //  ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
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
                        //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                        //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                        //    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                        //}
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
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Inspection Returned to Site Owner'); window.location='NewApplications.aspx'", true);

                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Please select the Action Required for Inspection');", true);
                    }
                }
                else
                {
                    Response.Redirect("/Login.aspx");
                }
            }
            catch (Exception ex)
            { }
        }
        protected void lnkRedirectPreviousTR_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                Label LblOldTestReportId = (Label)row.FindControl("LblOldTestReportId");

                string url = string.Empty;
                if (installationName == "Lift")
                {
                    Session["LiftTestReportID"] = LblOldTestReportId.Text;
                    url = "/TestReportModal/LiftTestReportModal.aspx";
                }
                if (installationName == "Escalator")
                {
                    Session["EscalatorTestReportID"] = LblOldTestReportId.Text;
                     url = "/TestReportModal/EscalatorTestReportModal.aspx";
                }
                string script = $@"<script>window.open('{url}', '_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenLiftTestReportInNewTab", script);
                return;


            }
            catch (Exception ex) { }
        }

        protected void lnkRedirectNewTR_Click1(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                Label LblTestReportId = (Label)row.FindControl("LblTestReportId");

                string url = string.Empty;
                if (installationName == "Lift")
                {
                    Session["LiftTestReportID"] = LblTestReportId.Text;
                   url = "/TestReportModal/LiftTestReportModal.aspx";
                }
                if (installationName == "Escalator")
                {
                    Session["EscalatorTestReportID"] = LblTestReportId.Text;
                    url = "/TestReportModal/EscalatorTestReportModal.aspx";
                }
                string script = $@"<script>window.open('{url}', '_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenLiftTestReportInNewTab", script);
                return;


            }
            catch (Exception ex) { }
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
                    if (LblInstallationName.Text.Trim() == "Line")
                    {
                        Grid_MultipleInspectionTR.Columns[5].Visible = false;
                        Grid_MultipleInspectionTR.Columns[6].Visible = false;
                        linkButtonInvoice.Visible = false;
                        LinkButtonReport.Visible = false;
                    }
                    else
                    {
                        Grid_MultipleInspectionTR.Columns[5].Visible = true;
                        Grid_MultipleInspectionTR.Columns[6].Visible = true;
                        linkButtonInvoice.Visible = true;
                        LinkButtonReport.Visible = true;
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
                ds = CEI.ViewDocuments_ReturnedInspectionLift_Escalator(ID);
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
            }
        }
        private void GetTestReportData()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetTestReport_Lift_EscalatorIfReturned(ID);
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
    }
}