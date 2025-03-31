using CEI_PRoject;
using CEIHaryana.Model.Industry;
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

namespace CEIHaryana.Admin
{
    public partial class IntimationHistoryForLift : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private static int lineNumber = 0;
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        private static string  Reason;
        string Type = string.Empty;
        string   AssignFrom;
        string InstallType = string.Empty;
        private static string IntimationId, AcceptorReturn;
        private static int count;
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
                            txtInspectionReportID.Text = Session["InspectionId"].ToString();
                            Session["InspectionId"] = "";
                            lineNumber = 0;
                            GetData(txtInspectionReportID.Text);
                            if (lblInspectionType.Text == "New")
                            {
                                GetTestReportData(txtInspectionReportID.Text);
                            }
                            else if (lblInspectionType.Text == "Periodic")
                            {
                                GetTestReportDataIfPeriodic(txtInspectionReportID.Text);
                            }
                        }
                        else
                        {
                            Session["AdminId"] = "";
                            Response.Redirect("/AdminLogout.aspx", false);
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

        private void GetTestReportDataIfPeriodic(string ID)
        {
            try
            {                
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
            catch (Exception ex) 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;

            }
        }

      
        private void GetData(string ID)
        {
            try
            {
                if (Convert.ToString(ID) != null && Convert.ToString(ID) != string.Empty)
                {
                    DataSet ds = new DataSet();
                    ds = CEI.InspectionDataFor_Lift(ID);
                    lblInspectionType.Text = ds.Tables[0].Rows[0]["IType"].ToString();
                    txtUserType.Text = ds.Tables[0].Rows[0]["UserType"].ToString();                  
                    if (lblInspectionType.Text == "New")
                    {
                        txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                        txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
                        txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                        txtInstallation.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                        txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                        txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                        string SiteInspectionDate = ds.Tables[0].Rows[0]["InspectionDate"].ToString();                  
                        string ReturnValu = ds.Tables[0].Rows[0]["ReturnedBasedOnDocumentValue"].ToString();
                        GridBindDocument(ID);
                        txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                        txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();                      
                        txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                        txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                        txtelectrical.Text = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                        if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Firm/Company")
                        {
                            agency.Visible = true;
                            individual.Visible = false;
                            txtagency.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                            txtagency.ReadOnly = true;
                        }
                        else if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Individual Person")
                        {
                            txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                            txtSiteOwnerName.ReadOnly = true;
                        }
                        string Division = ds.Tables[0].Rows[0]["Division"].ToString();
                        DivViewTRinMultipleCaseNew.Visible = true;
                        GridToViewMultipleCaseNew(ID);
                        if (ReturnValu == "1")
                        {
                            grd_Documemnts.Columns[3].Visible = true;
                            grd_Documemnts.Columns[4].Visible = false;
                        }
                        else if (ReturnValu == "2")
                        {
                            grd_Documemnts.Columns[3].Visible = true;
                            grd_Documemnts.Columns[4].Visible = true;
                            GridView2.Columns[5].Visible = false;
                        }
                    }
                    else if (lblInspectionType.Text == "Periodic")
                    {
                        grd_Documemnts.Columns[4].Visible = false;                              
                        txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
                        txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();                                         
                        txtInstallation.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                        txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                        txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                        txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                        txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                        txtelectrical.Text = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                        if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Firm/Company")
                        {
                            agency.Visible = true;
                            individual.Visible = false;
                            txtagency.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                            txtagency.ReadOnly = true;
                        }
                        else if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Individual Person")
                        {
                            txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                            txtSiteOwnerName.ReadOnly = true;

                        }                     
                        string Division = ds.Tables[0].Rows[0]["Division"].ToString();                     
                        Address.Visible = true;
                        txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                        string SiteInspectionDate = ds.Tables[0].Rows[0]["InspectionDate"].ToString();
                        grd_Documemnts.Columns[1].Visible = true;
                        GridView1.Columns[5].Visible = false;
                        GridView1.Columns[3].Visible = false;
                        DivTestReports.Visible = true;
                        GridToViewTestReports(ID);
                        GridBindDocument(ID);
                    }
                }
                else
                {
                    Response.Redirect("/AdminLogout.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        private void GridToViewTestReports(string ID)
        {
            try
            {               
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

   
        protected void btnBack_Click(object sender, EventArgs e)
        {          
            try
            {
                Session["InspectionId"] = "";
                Response.Redirect("IntimationHistoryForAdmin.aspx", false);
                return;
              
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                Label lblSubmittedDate = (Label)e.Row.FindControl("lblSubmittedDate");             
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
                    Session["InspectionId"] = txtInspectionReportID.Text;
                    if (lblInstallationName.Text == "Lift")
                    {
                        Session["RegistrationNo"] = LblRegistrationNo.Text;
                        Session["TestReportID"] = LblTestReportId.Text;
                        Response.Redirect("/TestReportModal/LiftPeriodicTestReportModal.aspx", false);
                    }
                    else if (lblInstallationName.Text == "Escalator")
                    {
                        Session["RegistrationNo"] = LblRegistrationNo.Text;
                        Session["TestReportID"] = LblTestReportId.Text;
                        Response.Redirect("/TestReportModal/EscalatorPeriodicTestReportModal.aspx", false);
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }


        protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        private void GridToViewMultipleCaseNew(string ID)
        {
            try
            {             
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        protected void GridBindDocument(string ID)
        {
            try
            {             
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
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

      
        private void GetTestReportData(string ID)
        {
            try
            {              
                DataSet ds = new DataSet();
                ds = CEI.GetTestReport_Lift(ID);
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
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void RdbtnAccptReturn_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            Return.Visible = false;
            if (RdbtnAccptReturn.SelectedValue == "1") 
            {
                Return.Visible = true;
                btnUpdate.Visible = true;
                ddlReasonType.Visible = true;
                if (lblInspectionType.Text != null && lblInspectionType.Text != "" && lblInspectionType.Text == "Periodic")
                {

                    DdlReturnInPeriodic.Visible = true;
                    DivReason.Visible = true;
                    DivRejectionReasonType.Visible = false;
                }
                else if (lblInspectionType.Text != null && lblInspectionType.Text != "" && lblInspectionType.Text == "New")
                {
                    DdlReturnInPeriodic.Visible = false;
                    DivReason.Visible = false;
                    DivRejectionReasonType.Visible = false;
                }
                else
                {
                    DivRejectionReasonType.Visible = false;
                }
            }
            else if (RdbtnAccptReturn.SelectedValue == "2")
            {
                DivRejectionReasonType.Visible = true;
                DivReason.Visible = true;

                DIV_ChecklistDocuments.Visible = false;
                Check_ChecklistDocuments.Visible = false;
                DIV_TRDocuments.Visible = false;
                Check_TRDocuments.Visible = false;

                ddlReasonType.SelectedValue = "0";
            }
            else if (RdbtnAccptReturn.SelectedValue == "0")
            {
                DivRejectionReasonType.Visible = false;
                DivReason.Visible = false;
                DIV_ChecklistDocuments.Visible = false;
                Check_ChecklistDocuments.Visible = false;
                DIV_TRDocuments.Visible = false;
                Check_TRDocuments.Visible = false;
            }

        }

 
        private void GridChecklistDocuments(string ID)
        {
            try
            {             
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
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        private void GridTRDocuments(string ID)
        {
            try
            {               
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        protected void ddlReasonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ddlReasonType.SelectedValue == "1")
            {
                DIV_ChecklistDocuments.Visible = true;
                Check_ChecklistDocuments.Visible = true;

                GridChecklistDocuments(txtInspectionReportID.Text);

                DIV_TRDocuments.Visible = false;
                Check_TRDocuments.Visible = false;
            }
            else if (ddlReasonType.SelectedValue == "2")
            {
                DIV_TRDocuments.Visible = true;
                Check_TRDocuments.Visible = true;

                GridTRDocuments(txtInspectionReportID.Text);

                DIV_ChecklistDocuments.Visible = false;
                Check_ChecklistDocuments.Visible = false;
            }
            else if (ddlReasonType.SelectedValue == "3")
            {
                DIV_ChecklistDocuments.Visible = true;
                Check_ChecklistDocuments.Visible = true;
                DIV_TRDocuments.Visible = true;
                Check_TRDocuments.Visible = true;

                GridChecklistDocuments(txtInspectionReportID.Text);
                GridTRDocuments(txtInspectionReportID.Text);
            }
            else
            {
                DIV_ChecklistDocuments.Visible = false;
                Check_ChecklistDocuments.Visible = false;
                DIV_TRDocuments.Visible = false;
                Check_TRDocuments.Visible = false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int checksuccessmessage = 0;
            try
            {
                if (txtInspectionReportID.Text != null && txtInspectionReportID.Text != string.Empty && Session["AdminID"].ToString() != null && Session["AdminID"].ToString() != string.Empty)
                {
                    string  AdminId = Session["AdminID"].ToString();
                    ID = txtInspectionReportID.Text;
                    AssignFrom = AdminId;

                    bool isRemarksValid = true;
                    #region RemarksValidation

                    foreach (GridViewRow row in Grid_TRDocuments.Rows)
                    {
                        CheckBox chkSelect = (CheckBox)row.FindControl("chk_Select");
                        TextBox txtRemark = (TextBox)row.FindControl("txt_Remarks");

                        if (chkSelect != null && chkSelect.Checked && (txtRemark == null || string.IsNullOrWhiteSpace(txtRemark.Text)))
                        {
                            isRemarksValid = false;
                            break;
                        }
                    }

                    foreach (GridViewRow row in grd_ChecklistDocumemnts.Rows)
                    {
                        CheckBox chkSelect = (CheckBox)row.FindControl("chk_Select1");
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
                                        // string serverStatus = CEI.CheckServerStatus("https://staging.investharyana.in/api/project-service-logs-external_UHBVN");
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
                                        CEI.UpdateInspectionRejection(ID, AdminId, ddlRejectionReasonType.SelectedItem.ToString(), Reason);

                                        checksuccessmessage = 1;
                                    }
                                    else
                                    {
                                        if (InstallType == "New")
                                        {
                                            if (RdbtnAccptReturn.SelectedValue == "0")
                                            {
                                                CEI.updateInspectionCEI(ID, AdminId, IntimationId, count, txtWorkType.Text.Trim(), AcceptorReturn, Reason, ddlReasonType.SelectedItem.Value);
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
                                                        CEI.UpdateStatusOfReturnedInspection(ID, AdminId, ddlReasonType.SelectedItem.Value, transaction);

                                                        if (ddlReasonType.SelectedItem.Value == "1") // Checklist Documents
                                                        {
                                                            bool AtLeastOneChecked = false;
                                                            foreach (GridViewRow row in grd_ChecklistDocumemnts.Rows)
                                                            {
                                                                CheckBox chkChecklist = (CheckBox)row.FindControl("chk_Select1");
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
                                                                return;
                                                    }
                                                        }
                                                        else if (ddlReasonType.SelectedItem.Value == "3") // Checklist & Test Report Documents
                                                        {
                                                            bool isChecklistValid = false;
                                                            bool isTestReportValid = false;
                                                            bool allRemarksFilled = true;

                                                            foreach (GridViewRow row in grd_ChecklistDocumemnts.Rows)
                                                            {
                                                                CheckBox chkChecklist = (CheckBox)row.FindControl("chk_Select1");
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
                                                                    CheckBox chkChecklist = (CheckBox)row.FindControl("chk_Select1");
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
                                                   ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                                                   return;
                                                }
                                            }

                                        }

                                        else if (InstallType == "Periodic")
                                        {
                                            CEI.updateInspectionPeriodic(ID, AdminId, IntimationId, txtWorkType.Text.Trim(), AcceptorReturn, Reason, DdlReturnInPeriodic.SelectedItem.Value);
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
                                            if (RdbtnAccptReturn.SelectedValue == "2")
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Inspection Rejected Successfully'); window.location='IntimationHistoryForAdmin.aspx'", true);
                                            }
                                            else
                                            {
                                                if (RdbtnAccptReturn.SelectedValue == "1")
                                                {
                                                    if (ddlReasonType.SelectedItem.Value == "0") //Select
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataCommonReturn();", true);
                                                    }
                                                    else if (ddlReasonType.SelectedItem.Value == "1") //Based On Check Documents Returned 
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataCommonReturn();", true);
                                                    }
                                                    else if (ddlReasonType.SelectedItem.Value == "2") //Based On Test Documents Returned 
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataCommonReturn();", true);
                                                    }
                                                    else if (ddlReasonType.SelectedItem.Value == "3") //Based On Test Documents Returned 
                                                    {
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataCommonReturn();", true);
                                                    }
                                                }
                                                else if (RdbtnAccptReturn.SelectedValue == "0")
                                                {
                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                                                }
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
                    Response.Redirect("/Login.aspx");
                }
               
            }
            catch (Exception ex)
            {
                Response.Redirect("/AdminLogout.aspx", false);
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

        protected void chk_Select_CheckedChanged1(object sender, EventArgs e)
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

        private void GridToViewTRinMultipleCaseNew()
        {
            try
            {              
                DataSet dsVC = CEI.GetDetailsToViewTRinMultipleCaseNew(txtInspectionReportID.Text);

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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
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
                Label LblTestReportId = (Label)row.FindControl("LblTestReportId");
                if (txtUserType.Text == "Industry")
                {
                    if (LblInstallationName != null)
                    {
                        Session["InspectionId"] = txtInspectionReportID.Text;
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
                }
                else if (txtUserType.Text != "Industry")
                {
                    if (LblInstallationName != null)
                    {
                        Session["InspectionId"] = txtInspectionReportID.Text;
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
                Label LblTestReportId = (Label)row.FindControl("LblTestReportId");

                if (txtUserType.Text == "Industry")
                {
                    if (lblInstallationName != null)
                    {
                        Session["InspectionId"] = txtInspectionReportID.Text;
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
                }
                else if (txtUserType.Text != "Industry")
                {
                    if (lblInstallationName != null)
                    {
                        Session["InspectionId"] = txtInspectionReportID.Text;
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

            }
            catch (Exception ex) 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
    }
}