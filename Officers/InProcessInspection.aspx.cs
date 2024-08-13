using AjaxControlToolkit;
using CEI_PRoject;
using CEIHaryana.Model.Industry;
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
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Label = System.Web.UI.WebControls.Label;

namespace CEIHaryana.Officers
{
    public partial class InProcessInspection : System.Web.UI.Page
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
                    if (Session["StaffID"] != null && Session["StaffID"].ToString() != "")
                    {
                        lineNumber = 0;
                        GetData();
                        GetTestReportData();
                        btnPreview.Visible = false;
                    }
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }



        protected void lnkRedirect_Click(object sender, EventArgs e)
        {

            LinkButton lnkRedirect = (LinkButton)sender;
            string testReportId = lnkRedirect.CommandArgument;
            Session["InspectionTestReportId"] = testReportId;
            if (txtWorkType.Text.Trim() == "Line")
            {
                Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
            }
            else if (txtWorkType.Text.Trim() == "Substation Transformer")
            {
                Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
            }
            else if (txtWorkType.Text.Trim() == "Generating Set")
            {
                Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
            }
        }
        private void GetData()
        {
            try
            {
                ID = Session["InProcessInspectionId"].ToString();
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
                    string SiteInspectionDate = ds.Tables[0].Rows[0]["InspectionDate"].ToString();
                    Session["InspectionType"] = ds.Tables[0].Rows[0]["Type_of_Inspection"].ToString();
                    GridBindDocument();

                    string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();

                    if (Status == "Approved")
                    {
                        InspectionDate.Visible = false;
                        txtSuggestion.Text = ds.Tables[0].Rows[0]["Suggestion"].ToString();
                        if (!string.IsNullOrEmpty(txtSuggestion.Text))
                        {
                            Suggestion.Visible = true;
                            txtSuggestion.ReadOnly = true;
                        }
                        ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                        ddlReview.Attributes.Add("disabled", "true");
                        txtSuggestion.Attributes.Add("disabled", "true");

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
                        //ApprovedReject.Visible = true;
                        //ApprovalRequired.Visible = false;
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

                        // Rejection.Visible = true;
                        //txtRejected.Text = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
                        ddlReview.Attributes.Add("disabled", "true");
                        //txtRejected.Attributes.Add("disabled", "true");
                        //txtRejected.ReadOnly = true;

                    }
                }
                else if (Type == "Periodic")
                {
                    txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    InspectionType.Visible = false;
                    txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
                    txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                    if (txtWorkType.Text == "Line")
                    {
                        Capacity.Visible = false;
                        LineVoltage.Visible = false;
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
                    Session["InspectionType"] = ds.Tables[0].Rows[0]["Type_of_Inspection"].ToString();
                    divTestReportAttachment.Visible = false;
                    Address.Visible = false;
                    SiteOwnerContact.Visible = false;
                    ContractorName.Visible = false;
                    ContractorPhoneNo.Visible = false;
                    ContractorEmail.Visible = false;
                    divSupervisorName.Visible = false;
                    SupervisorEmail.Visible = false;
                    string SiteInspectionDate = ds.Tables[0].Rows[0]["InspectionDate"].ToString();
                    grd_Documemnts.Columns[1].Visible = true;
                    GridBindDocument();

                    string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();

                    if (Status == "Approved")
                    {
                        InspectionDate.Visible = false;
                        txtSuggestion.Text = ds.Tables[0].Rows[0]["Suggestion"].ToString();
                        if (!string.IsNullOrEmpty(txtSuggestion.Text))
                        {
                            Suggestion.Visible = true;
                            txtSuggestion.ReadOnly = true;
                        }
                        ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                        ddlReview.Attributes.Add("disabled", "true");
                        txtSuggestion.Attributes.Add("disabled", "true");

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
        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    //ID = Session["InspectionId"].ToString();

                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
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
            int checksuccessmessage = 0;
            try
            {
                if (Session["InProcessInspectionId"].ToString() != null && Session["InProcessInspectionId"].ToString() != "" && Session["StaffID"].ToString() != null)
                {
                    StaffId = Session["StaffID"].ToString();
                    ID = Session["InProcessInspectionId"].ToString();
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

                        if (inspectionDate <= submittedDate)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection date must be greater than submitted date.');", true);
                            return;
                        }

                        ApprovedorReject = ddlReview.SelectedItem.ToString();
                        Reason = string.IsNullOrEmpty(txtRejected.Text) ? null : txtRejected.Text.Trim();

                        if (Suggestion.Visible == true)
                        {
                            Suggestions = string.IsNullOrEmpty(txtSuggestion.Text) ? null : txtSuggestion.Text.Trim();
                        }

                            try
                            {
                                string reqType = CEI.GetIndustry_RequestType_New(Convert.ToInt32(ID));
                                if (reqType == "Industry")
                                {
                                string serverStatus = CEI.CheckServerStatus("https://staging.investharyana.in");
                                // string serverStatus = CEI.CheckServerStatus("https://staging.investharyana.in/api/project-service-logs-external_UHBVN");
                                if (serverStatus != "Server is reachable.")
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('HEPC Server Is Not Responding . Please Try After Some Time')", true);
                                        return;
                                    }
                                }


                                CEI.InspectionFinalAction(ID, StaffId, ApprovedorReject, Reason, Suggestions, txtInspectionDate.Text);
                         
                                checksuccessmessage = 1;

                                string actiontype = ApprovedorReject == "Approved" ? "Approved" : "Rejected";
                                Industry_Api_Post_DataformatModel ApiPostformatresult = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(ID), actiontype);

                                if (ApiPostformatresult.PremisesType == "Industry")
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

                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata('" + ApprovedorReject + "');", true);
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
                                // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                              //  ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                            }
                            catch (Exception ex)
                            {
                             
                                // Handle the exception, log it, etc.
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('An error occurred.');", true);
                            }
                            finally
                            {
                                if (checksuccessmessage == 1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata('" + ApprovedorReject + "');", true);
                                }
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


        protected void ddlSuggestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lineNumber == 0)
            {
                lineNumber = 1;
            }
            else
            {
                lineNumber++;
            }
            string selectedItemText = ddlSuggestion.SelectedItem.Text;
            txtSuggestion.Text += lineNumber + ". " + selectedItemText + "\n";
            ddlSuggestion.Items.Remove(ddlSuggestion.SelectedItem);
            //lineNumber++;
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlReview.SelectedValue == "1")
                {
                    if (Session["InProcessInspectionId"].ToString() != null && Session["InProcessInspectionId"].ToString() != "")
                    {
                        ID = Session["InProcessInspectionId"].ToString();
                        string InspectionType = Session["InspectionType"].ToString();

                        
                        SqlCommand cmd = new SqlCommand("Sp_insertTempInspection");
                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                        cmd.Connection = con;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                            con.Open();
                        }
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@inspectionId", ID);
                        cmd.Parameters.AddWithValue("@suggestion", txtSuggestion.Text.Trim());
                        cmd.Parameters.AddWithValue("@ReasionRejection", txtRejected.Text == null ? null : txtRejected.Text);
                        cmd.Parameters.AddWithValue("@InspectionType", InspectionType);
                        DateTime initialIssueDate;
                        if (DateTime.TryParse(txtInspectionDate.Text, out initialIssueDate) && initialIssueDate != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@inspectionDate", initialIssueDate);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@inspectionDate", DBNull.Value);
                        }
                        int x = cmd.ExecuteNonQuery();
                        con.Close();
                        if (x > 0)
                        {
                            btnPreview.Visible = false;

                            if (InspectionType == "New")
                            {
                                Response.Redirect("/Print_Forms/PrintCertificate1.aspx", false);
                            }
                            else
                            {
                                Response.Redirect("/Print_Forms/PeriodicApprovalCertificate.aspx", false);
                            }


                        }
                        //btnPreview.Visible = false;
                       
                    }
                    
                    // }
                }
               
            }
            catch (Exception ex)
            {

                //throw;
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Officers/InProcessRequest.aspx", false);
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

        protected void ddlReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rejection.Visible = false;
            Suggestion.Visible = false;
            ddlSuggestions.Visible = false;
            btnPreview.Visible = false;
            if (ddlReview.SelectedValue == "2")
            {
                Rejection.Visible = true;
            }
            else if (ddlReview.SelectedValue == "1")
            {
                btnPreview.Visible = true;
                ddlSuggestions.Visible = true;
                Suggestion.Visible = true;
            }
        }

        protected void GridBindDocument()
        {
            try
            {
                ID = Session["InProcessInspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewDocuments(ID);
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
                ID = Session["InProcessInspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetTestReport(ID);
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
    }
}