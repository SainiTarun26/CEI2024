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
    public partial class Returned_PeriodicInspection_Lift_Escalator : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private static int count;
        private static string IntimationId, AcceptorReturn, Reason, StaffId;
        string Type = string.Empty;
        string InstallType = string.Empty;
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if ((Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty) &&
                        (Convert.ToString(Session["InspectionId"]) != null && Convert.ToString(Session["InspectionId"]) != string.Empty))
                    {
                        GetData();
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
                ds = CEI.GetTestReportDataIfPeriodic_Lift_EscalatorIfReturned(ID);
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

                DataSet ds = new DataSet();
                ds = CEI.InspectionData_Lift_Escalator(ID);
                Type = ds.Tables[0].Rows[0]["IType"].ToString();
                lblInspectionType.Text = ds.Tables[0].Rows[0]["Type_of_Inspection"].ToString();
                lblInstallation.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
                txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();

                if (txtAmount.Text == "0")
                {
                    TranscationDetails.Visible = false;
                }
                else
                {
                    TranscationDetails.Visible = true;
                }
                OwnerAddress.Visible = false;
                TRAttached.Visible = true;
                TRAttachedGrid.Visible = true;
                IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();
                string ReturnValue = ds.Tables[0].Rows[0]["ReturnedBasedOnDocumentValue"].ToString();
                GridBindDocument();
                DivViewCart.Visible = true;
                GridToViewTestReportsAndAttachments();
                if (ReturnValue == "1")
                {
                    grd_Documemnts.Columns[3].Visible = false;
                    grd_Documemnts.Columns[4].Visible = false;
                    grd_Documemnts.Columns[5].Visible = false;

                }
                else if (ReturnValue == "2")
                {

                    GridView2.Columns[5].Visible = false;
                }
                else
                {
                    grd_Documemnts.Columns[2].Visible = false;
                    GridView2.Columns[5].Visible = false;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void lnkRedirect_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            Session["InspectionTestReportId"] = btn.CommandArgument;

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
                Rejection.Visible = false;
                if (RadioButtonList2.SelectedValue == "0")
                {
                    Rejection.Visible = false;
                }
                else
                {
                    if (RadioButtonList2.SelectedValue == "1")
                    {
                        Rejection.Visible = true;
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
            { }

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
            { }
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
                        //AcceptorReturn = RadioButtonList2.SelectedValue == "0" ? "Accepted" : "Return";
                        AcceptorReturn = RadioButtonList2.SelectedValue == "0" ? "Accepted" :
                                         RadioButtonList2.SelectedValue == "1" ? "Return" :
                                         RadioButtonList2.SelectedValue == "2" ? "Rejected" : "";
                        Reason = string.IsNullOrEmpty(txtRejected.Text) ? null : txtRejected.Text;

                        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

                        try
                        {
                            //string reqType = CEI.GetIndustry_RequestType_New(Convert.ToInt32(ID));
                            //if (reqType == "Industry")
                            //{
                            //    string serverStatus = CEI.CheckServerStatus("https://staging.investharyana.in");
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

                                checksuccessmessage = 1;
                            }
                            else
                            {
                                CEI.updateInspectionPeriodic_lift_Escalator(ID, StaffId, IntimationId, txtWorkType.Text.Trim(), AcceptorReturn, Reason, ddlReasonType.SelectedItem.Value, ddlReasonType.SelectedItem.Text);
                                checksuccessmessage = 1;
                            }
                            //string actiontype = AcceptorReturn == "Accepted" ? "InProgress" : "Return";
                            string actiontype = AcceptorReturn == "Accepted" ? "InProgress" :
                                                AcceptorReturn == "Return" ? "Return" :
                                                AcceptorReturn == "Rejected" ? "Rejected" : "";
                            //Industry_Api_Post_DataformatModel ApiPostformatresult = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(ID), actiontype);

                            //if (ApiPostformatresult.PremisesType == "Industry")
                            //{
                            //    string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                            //    logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
                            //                   "https://staging.investharyana.in/api/project-service-logs-external_UHBVN",
                            //                   new Industry_Inspection_StageWise_JsonDataFormat_Model
                            //                   {
                            //                       actionTaken = ApiPostformatresult.ActionTaken,
                            //                       commentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                            //                       commentDate = ApiPostformatresult.CommentDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                            //                       comments = ApiPostformatresult.Comments,
                            //                       id = ApiPostformatresult.Id,
                            //                       projectid = ApiPostformatresult.ProjectId,
                            //                       serviceid = ApiPostformatresult.ServiceId
                            //                   }, ApiPostformatresult, accessToken);

                            //    if (!string.IsNullOrEmpty(logDetails.ErrorMessage))
                            //    {
                            //        throw new Exception(logDetails.ErrorMessage);
                            //    }
                            //    CEI.LogToIndustryApiSuccessDatabase(
                            //     logDetails.Url,
                            //     logDetails.Method,
                            //     logDetails.RequestHeaders,
                            //     logDetails.ContentType,
                            //     logDetails.RequestBody,
                            //     logDetails.ResponseStatusCode,
                            //     logDetails.ResponseHeaders,
                            //     logDetails.ResponseBody,

                            //     new Industry_Api_Post_DataformatModel
                            //     {
                            //         InspectionId = ApiPostformatresult.InspectionId,
                            //         InspectionLogId = ApiPostformatresult.InspectionLogId,
                            //         IncomingJsonId = ApiPostformatresult.IncomingJsonId,
                            //         ActionTaken = ApiPostformatresult.ActionTaken,
                            //         CommentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                            //         CommentDate = ApiPostformatresult.CommentDate,

                            //         Comments = ApiPostformatresult.Comments,
                            //         Id = ApiPostformatresult.Id,
                            //         ProjectId = ApiPostformatresult.ProjectId,
                            //         ServiceId = ApiPostformatresult.ServiceId,
                            //     }

                            // );

                            //}

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
                                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataOfRejection();", true);
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Inspection Request Rejected Successfully'); window.location='NewApplications.aspx'", true);
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
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Please select Option in Action Required');", true);
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
        private void GridToViewTestReportsAndAttachments()
        {
            try
            {
                string ID = Session["InspectionId"].ToString();
                //DataSet dsVC = CEI.GetDetailsToViewCart_Lift_Escalator(ID);
                DataSet dsVC = CEI.GetPeriodicViewTRReturned_Lift_Escalator(ID);

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
                Label LblOldTestReportId = (Label)row.FindControl("LblOldTestReportId");
                Label LblRegistrationNo = (Label)row.FindControl("LblRegistrationNo");
                //Session["InspectionTestReportId"] = btn.CommandArgument;
                // Session["RegistrationNo"] = btn.CommandArgument;
                Session["RegistrationNo"] = LblRegistrationNo.Text;
                string url = string.Empty;
                if (installationName == "Lift")
                {
                    Session["TestReportID"] = LblOldTestReportId.Text;
                    url = "/TestReportModal/LiftPeriodicTestReportModal.aspx";
                }
                if (installationName == "Escalator")
                {
                    Session["TestReportID"] = LblOldTestReportId.Text;
                    url = "/TestReportModal/EscalatorPeriodicTestReportModal.aspx";
                }

                string script = $@"<script>window.open('{url}', '_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenLiftTestReportInNewTab", script);

                //Response.Redirect("/TestReportModal/LiftTestReportModal.aspx", false);
                return;
            }
            catch (Exception ex) { }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblOldTestReportId = (Label)e.Row.FindControl("LblOldTestReportId");
                    LinkButton lnkRedirect = (LinkButton)e.Row.FindControl("lnkRedirect");

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
            catch (Exception ex)
            {
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
                Label LblTestReportId = (Label)row.FindControl("LblTestReportId");
                Label LblRegistrationNo = (Label)row.FindControl("LblRegistrationNo");
                //Session["RegistrationNo"] = btn.CommandArgument;
                Session["RegistrationNo"] = LblRegistrationNo.Text;
                string url = string.Empty;
                if (installationName == "Lift")
                {
                    Session["TestReportID"] = LblTestReportId.Text;
                    url = "/TestReportModal/LiftPeriodicTestReportModal.aspx";
                }
                if (installationName == "Escalator")
                {
                    Session["TestReportID"] = LblTestReportId.Text;
                    url = "/TestReportModal/EscalatorPeriodicTestReportModal.aspx";
                }

                string script = $@"<script>window.open('{url}', '_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenLiftTestReportInNewTab", script);

                return;
            }
            catch (Exception ex) { }
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
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                    statements.Visible = false;
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                    //string script = "alert(\"No Record Found\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    statements.Visible = true;
                }
                if (statements.Visible)
                {
                    ddlReasonType.Items.Clear();
                    ddlReasonType.Items.Add(new ListItem("Select", "0"));
                    ddlReasonType.Items.Add(new ListItem("Test Report/Test Report Documents", "1"));
                }
                else
                {
                    ddlReasonType.Items.Clear();
                    ddlReasonType.Items.Add(new ListItem("Select", "0"));
                    ddlReasonType.Items.Add(new ListItem("Test Report/Test Report Documents", "1"));
                    ddlReasonType.Items.Add(new ListItem("Tresury Challan/Other Documents", "2"));
                }
                ds.Dispose();
            }
            catch (Exception ex)
            { }
        }

    }
}