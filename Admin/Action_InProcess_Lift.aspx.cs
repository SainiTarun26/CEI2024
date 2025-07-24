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

namespace CEIHaryana.Admin
{
    public partial class Action_InProcess_Lift : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private static int lineNumber = 0;
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        private static string Reason;
        string Type = string.Empty;
        //added x and y for checking status by neeraj on 6-May-2025
        int x = 0; int y = 0;
        string  AssignFrom;
        string InstallType = string.Empty;
        private static string IntimationId, AcceptorReturn;
        private static int count;
        private static string ApprovedorReject, LiftApprovalRemarks;
        protected void Page_Load(object sender, EventArgs e)
        {
            //page setted by aslam 24-July-2025
            try
            {
                if (!IsPostBack)
                {                   
                        if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                        {
                        if (Convert.ToString(Session["InProcessInspectionId"]) != null && Convert.ToString(Session["InProcessInspectionId"]) != string.Empty)
                        {
                             txtInspectionReportID.Text = Session["InProcessInspectionId"].ToString();
                             Session["InProcessInspectionId"] = "";
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
                if (ID != null && ID != string.Empty)
                {
                    DataSet ds = new DataSet();
                    ds = CEI.InspectionDataFor_Lift(ID);
                    lblInspectionType.Text = ds.Tables[0].Rows[0]["IType"].ToString();
                    txtUserType.Text = ds.Tables[0].Rows[0]["UserType"].ToString();

                    if (lblInspectionType.Text == "New")
                    {                        
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
                        if (txtAmount.Text == "0")
                        {
                            labelApprovalDate.Visible = true;
                            labelInspectionDate.Visible = false;
                        }
                        else
                        {
                            labelApprovalDate.Visible = false;
                            labelInspectionDate.Visible = true;
                        }
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
                        if (txtAmount.Text == "0")
                        {
                            labelApprovalDate.Visible = true;
                            labelInspectionDate.Visible = false;
                        }
                        else
                        {
                            labelApprovalDate.Visible = false;
                            labelInspectionDate.Visible = true;
                        }
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
                        //addedby aslam on 23 dec 2024 End
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
                Session["InProcessInspectionId"] = "";
                Response.Redirect("/Admin/ActionInspectioHistrory.aspx", false);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        //Changed by gurmeet 19-May-2025
        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
        //        Label lblSubmittedDate = (Label)e.Row.FindControl("lblSubmittedDate");
        //        hnSubmittedDate.Value = lblSubmittedDate.Text;
        //        if (status == "RETURN")
        //        {
        //            e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
        //        }
        //    }
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        e.Row.Cells[2].BackColor = ColorTranslator.FromHtml("#9292cc");
        //    }
        //}
        //
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
                    Session["InProcessInspectionId"] = txtInspectionReportID.Text;
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
        protected void chk_Select_CheckedChanged(object sender, EventArgs e)
           {

            CheckBox chkBox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkBox.NamingContainer;
            TextBox txtRemarks = (TextBox)row.FindControl("txt_RemarksforOwnerDoc");

            // Enable or disable the TextBox based on checkbox checked state
            txtRemarks.Enabled = chkBox.Checked;

            if (!chkBox.Checked)
            {
                txtRemarks.Text = string.Empty;
            }
           }

        protected void ddlReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rejection.Visible = false;
           
            if (ddlReview.SelectedValue == "2")
            {
                Rejection.Visible = true;
            }
            //else if (ddlReview.SelectedValue == "1")
            //{
               
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtInspectionReportID.Text != null && txtInspectionReportID.Text != string.Empty && Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
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
                             string AdminId = Session["AdminId"].ToString();
                             ID = txtInspectionReportID.Text;
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
                                    // TxtMemoNo.Text = ds.Tables[0].Rows[0]["MemoNo"].ToString();
                                }                               
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

                                String SubmittedDated = "";// hnSubmittedDate.Value;

                                if (ddlReview.SelectedValue != null && ddlReview.SelectedValue != "" && ddlReview.SelectedValue != "0")
                            {
                                //Changed by gurmeet 19-May-2025
                                foreach (GridViewRow row in GridView1.Rows)
                                   {
                                       if (row.RowType == DataControlRowType.DataRow)
                                       {                                           
                                           Label lblSubmittedDate = (Label)row.FindControl("lblSubmittedDate");
                                           SubmittedDated = lblSubmittedDate.Text;
                                       }
                                   }

                                //Changed by gurmeet 19-May-2025
                                DateTime inspectionDate;
                                    if (!DateTime.TryParse(txtInspectionDate.Text, out inspectionDate))
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid inspection date.');", true);
                                        return;
                                    }

                                    DateTime submittedDate;
                                    if (!DateTime.TryParse(SubmittedDated, out submittedDate))
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid submitted date.');", true);
                                        return;
                                    }

                                    if (inspectionDate < submittedDate)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection/Approval date must be greater or equal to the last action date of application.');", true);
                                        return;
                                    }

                                DateTime serverDate = DateTime.Now.Date;
                                if (inspectionDate.Date > serverDate.Date)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection date must be less than Today date.');", true);
                                    return;
                                }

                                ApprovedorReject = ddlReview.SelectedItem.ToString();
                                    Reason = string.IsNullOrEmpty(txtRejected.Text) ? null : txtRejected.Text.Trim();


                                    try
                                    {
                                        //commented 3 dec 2024 for 
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
                                    txtInspectionDate.Text = DateTime.Parse(txtInspectionDate.Text).ToString("yyyy-MM-dd");
                                    y = CEI.InspectionFinalAction_Lift(ID, AdminId, ApprovedorReject, Reason, txtInspectionDate.Text,"", transaction);
                                        if (ApprovedorReject == "Approved")
                                        {
                                            if (lblInspectionType.Text == "New")
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
                                                    string lblOwner = (row.FindControl("lblOwner") as Label)?.Text;

                                                    CEI.InstallationApproval_Lift_New(ID, TestReportId, InstallationType, AdminId, lblInspectionType.Text, txtRegistrationNo.Text, TxtDivision.Text, lblMake, lblLiftSrNo, lblTypeOfLift,
                                                    lblTypeOfControl, lblCapacity, lblWeight, LblErectionDate, txtAddress.Text, txtDistrict.Text, DateTime.Parse(txtTranscationDate.Text), lblOwner, transaction);

                                                }                                             
                                            }
                                            if (lblInspectionType.Text == "Periodic")
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

                                                ///commented By aslam on 21 july 2025 earlier working by neeraj challandate not required owner name not passing  new method will create
                                                //CEI.InstallationApproval_Lift(ID, TestReportId, InstallationType, AdminId, lblInspectionType.Text, LblRegistrationNo, DateTime.Parse(txtChallanDate.Text), TxtDivision.Text, lblMake, lblLiftSrNo, lblTypeOfLift,
                                                //     lblTypeOfControl, lblCapacity, lblWeight, LblErectionDate, lblLastApprovalDate, txtAddress.Text, txtDistrict.Text, LblMemoNo, txtTranscationDate.Text, transaction);

                                                string ownerNameInMethod = GetOwnerName();

                                               x+= CEI.InstallationApproval_Lift(ID, TestReportId, InstallationType, AdminId, lblInspectionType.Text, LblRegistrationNo, TxtDivision.Text, lblMake, lblLiftSrNo, lblTypeOfLift,
                                                     lblTypeOfControl, lblCapacity, lblWeight, LblErectionDate, lblLastApprovalDate, txtAddress.Text, txtDistrict.Text, LblMemoNo, txtTranscationDate.Text, ownerNameInMethod, transaction);

                                                }                                               
                                            }

                                        if (x > 0 && y > 0)
                                        {
                                            transaction.Commit();
                                            CEI.UpdateLiftApprovedCertificatedata(ID);
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata('" + ApprovedorReject + "');", true);
                                        }
                                        else
                                        {
                                            transaction?.Rollback();
                                            string alertScript = "alert('Please try again.');";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                            return;
                                        }
                                    }
                                        else if (ApprovedorReject == "Rejected")
                                        {
                                            transaction.Commit();
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata2()", true);
                                        }
                                        else
                                        {                                           
                                            ddlReview.Focus();
                                            return;
                                        }                                      
                                      
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
                                    if (checksuccessmessage == 1)
                                    {
                                        Session["ClickCount"] = "";
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata('" + ApprovedorReject + "');", true);

                                    }
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
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                            return;
                        }
                    }
                }
                else
                {
                    Session["ClickCount"] = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('You double click on Button.'); window.location='ActionInspectioHistrory.aspx'", true);
                }
            }
            else
            {
                Response.Redirect("/AdminLogout.aspx", false);
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
                        Session["InProcessInspectionId"] = txtInspectionReportID.Text;
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
                        Session["InProcessInspectionId"] = txtInspectionReportID.Text;
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
                        Session["InProcessInspectionId"] = txtInspectionReportID.Text;
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
                        Session["InProcessInspectionId"] = txtInspectionReportID.Text;
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
        private string GetOwnerName()
        {
            if (agency.Visible)
                return txtagency.Text;
            else if (individual.Visible)
                return txtSiteOwnerName.Text;
            else
                return string.Empty;
        }
    }
}