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
using CEIHaryana.Model.Industry;
using System.Configuration;
using System.Data.SqlClient;

namespace CEIHaryana.Officers
{
    public partial class Inspection : System.Web.UI.Page
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
                    GetData();
                    if (Type == "New")
                    {
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
                    count = Convert.ToInt32(ds.Tables[0].Rows[0]["TestReportCount"].ToString());           //Added     
                    IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();

                    GridBindDocument();
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                Rejection.Visible = false;
                if (RadioButtonList2.SelectedValue == "0")
                {
                    Rejection.Visible = false;
                }
                else if (RadioButtonList2.SelectedValue == "1")
                {
                    Rejection.Visible = true;
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
                    fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
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

                    if (RadioButtonList2.SelectedValue != "" && RadioButtonList2.SelectedValue != null)
                    {
                        AcceptorReturn = RadioButtonList2.SelectedValue == "0" ? "Accepted" : "Return";
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

                            if (InstallType == "New")
                            {

                                CEI.updateInspection(ID, StaffId, IntimationId, count, txtWorkType.Text.Trim(), AcceptorReturn, Reason, ddlReasonType.SelectedItem.Value);
                            }

                            else if (InstallType == "Periodic")
                            {
                                CEI.updateInspectionPeriodic(ID, StaffId, IntimationId, txtWorkType.Text.Trim(), AcceptorReturn, Reason, ddlReasonType.SelectedItem.Value);
                            }
                            checksuccessmessage = 1;

                            string actiontype = AcceptorReturn == "Accepted" ? "InProgress" : "Return";
                            Industry_Api_Post_DataformatModel ApiPostformatresult = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(ID), actiontype);

                            if (ApiPostformatresult.PremisesType == "Industry")
                            {
                                // string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                                string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                                // string accessToken = "dfsfdsfsfsdf";

                                logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
                                              "https://investharyana.in/api/project-service-logs-external_UHBVN",
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
                                    if (ddlReasonType.SelectedItem.Value == "0") //Based On Test Report Returned
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataCommonReturn();", true);
                                    }
                                    if (ddlReasonType.SelectedItem.Value == "1") //Based On Documents Returned 
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataCommonReturn();", true);
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
                ID = Session["InspectionId"].ToString();
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
