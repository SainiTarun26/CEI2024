using CEI_PRoject;
using CEIHaryana.SiteOwnerPages;
using iText.StyledXmlParser.Css.Selector.Item;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.Officers
{
    public partial class ActionForCinemaVideo_Talkies : System.Web.UI.Page
    {
        //Page created By Neeraj 20-May-2025
        CEI CEI = new CEI();
        private static string ApprovedorReject;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    hdnStaffId.Value = "";
                    //Session["InProcessInspectionId"] = "1003402";
                    if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty && Convert.ToString(Session["InProcessInspectionId"]) != null && Convert.ToString(Session["InProcessInspectionId"]) != string.Empty)
                    {
                        hdnStaffId.Value = Session["StaffID"].ToString();
                        txtInspectionID.Text = Session["InProcessInspectionId"].ToString();

                        GetData(txtInspectionID.Text);
                        GetInspectionData(txtInspectionID.Text);
                        GridBindDocument(txtInspectionID.Text);
                      // for new Test Report data
                       GetTestReportDataNew(txtInspectionID.Text);

                       

                        Page.Session["ClickCount"] = "0";
                    }
                    else
                    {
                        Session["StaffID"] = "";
                        Response.Redirect("/OfficerLogout.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        private void GetData(string Id)
        {
            try
            {
                if (Convert.ToString(Session["StaffID"]) == hdnStaffId.Value && txtInspectionID.Text != null && txtInspectionID.Text != string.Empty)
                {
                    DataTable dt = CEI.GetSiteOwnerData_Cinema(Id);
                    txtSiteOwnerName.Text = dt.Rows[0]["OwnerName"].ToString();
                    txtPAN.Text = dt.Rows[0]["PANNumber"].ToString();
                    txtCinemaName.Text = dt.Rows[0]["NameOfCinema"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtDistrict.Text = dt.Rows[0]["District"].ToString();
                    txtTransactionId.Text = dt.Rows[0]["TransactionId"].ToString();
                    txtTranscationDate.Text = dt.Rows[0]["TransactionDate"].ToString();
                    txtAmount.Text = dt.Rows[0]["TotalAmount"].ToString();
                    txtInspection.Text = dt.Rows[0]["InspectionDate"].ToString();
                    txtRemarksApprove.Text = dt.Rows[0]["Suggestion"].ToString();
                    txtReasonReject.Text = dt.Rows[0]["ReasonForRejection"].ToString();
                    lblInspectionType.Text = dt.Rows[0]["TypeOfInspection"].ToString();                   
                    lblInstallation.Text = dt.Rows[0]["InstallationType"].ToString();                                     
                    txtApplicationStatus.Text = dt.Rows[0]["ApplicationStatus"].ToString();
                    {
                        if(txtApplicationStatus.Text == "InProcess")
                        {
                            ApprovalRequired.Visible = true;
                            InspectionDate.Visible = true;
                        }
                        else if(txtApplicationStatus.Text == "Approved")
                        {
                           
                            ApprovalRequired.Visible = false;
                            AppRemarks.Visible = true;
                            InspectionDate.Visible = false;
                            ApproveOrReject.Visible = true;
                            InsDate.Visible = true;
                            btnSubmit.Visible = false;
                        }
                        else if(txtApplicationStatus.Text == "Rejected")
                        {
                            ApprovalRequired.Visible = false;
                            ReReason.Visible = true;
                            InspectionDate.Visible = false;
                            ApproveOrReject.Visible = true;
                            InsDate.Visible = false;
                            btnSubmit.Visible = false;
                        }
                        else if (txtApplicationStatus.Text == "Return")
                        {
                            ApprovalRequired.Visible = false;
                            ApproveOrReject.Visible = true;
                            AppRemarks.Visible = false;
                            InsDate.Visible = false;
                            btnSubmit.Visible = false;
                        }
                    }
                }
                else
                {
                    Session["StaffID"] = "";
                    Response.Redirect("/OfficerLogout.aspx");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }

        }
        private void GetInspectionData(string InspectionId)
        {
            try
            {
                DataSet ds = new DataSet();              
                ds = CEI.GetInspectionHistoryLogs(InspectionId);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        private void GetTestReportDataNew(string ID)
        {
            try
            {              
                DataSet dsVC = CEI.GetDetailsToViewCinemaTestReport(ID);
                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    DivTestReports.Visible = true;
                    New.Visible = true;
                    GridView2.DataSource = dsVC;
                    GridView2.DataBind();
                }
                else
                {
                    DivTestReports.Visible = false;
                    GridView2.DataSource = null;
                    GridView2.DataBind();
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
                ds = CEI.ViewDocuments(ID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Lblgrd_Documemnts.Visible = false;
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    Lblgrd_Documemnts.Visible = true;
                    Lblgrd_Documemnts.Text = "Documents Not Uploaded by User.";
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                   
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
            {
                Response.Redirect("/Officers/OfficerDashboard.aspx", false);
            }
            else
            {
                Session["StaffID"] = "";
                Response.Redirect("/OfficerLogout.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["StaffID"]) == hdnStaffId.Value && txtInspectionID.Text != null && txtInspectionID.Text != string.Empty)
            {
                int ClickCount = 0;
                int checksuccessmessage = 0;
                ClickCount = Convert.ToInt32(Session["ClickCount"]);
                if (ClickCount < 1)
                {
                
                    SqlTransaction transaction = null;
                    SqlConnection connection = null;
                    try
                    {
                        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
                        connection = new SqlConnection(connectionString);
                        connection.Open();
                        transaction = connection.BeginTransaction();

                        if (ddlReview.SelectedValue != null && ddlReview.SelectedValue != string.Empty && ddlReview.SelectedValue != "0")
                        {
                            string[] allowedExtensions = { ".pdf" };
                            int maxFileSize = 1 * 1024 * 1024;
                            string filePathInfo = string.Empty;
                          
                                if (ddlReview.SelectedValue == "1")
                                {
                                    if (txtRemarks.Text == "" || txtRemarks.Text == null)
                                    {
                                        string alertScript = "alert('Please provide remarks.');";
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                        return;
                                    }
                                    if (!FileApprovalCertificate.HasFile)
                                    {
                                    string alertScript = "alert('Please upload Approval Certificate.');";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                    return;
                                    }
                            
                                }
                                  
                                if (ddlReview.SelectedValue == "2")
                                {
                                    if (txtRejectReason.Text == "" || txtRejectReason.Text == null)
                                    {
                                        string alertScript = "alert('Please provide reject reason.');";
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                        return;
                                    }

                                }
                                DateTime inspectionDate;
                                if (!DateTime.TryParse(txtInspectionDate.Text, out inspectionDate))
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid inspection date.');", true);
                                    return;
                                }
                                String SubmittedDated = "";
                                foreach (GridViewRow row in GridView1.Rows)
                                {
                                    if (row.RowType == DataControlRowType.DataRow)
                                    {                                       
                                        Label lblSubmittedDate = (Label)row.FindControl("lblSubmittedDate");                           
                                        SubmittedDated = lblSubmittedDate.Text;                               
                                    }
                                }
                                DateTime submittedDate;
                                if (!DateTime.TryParse(SubmittedDated, out submittedDate))
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid submitted date.');", true);
                                    return;
                                }
                                if (inspectionDate.Date < submittedDate.Date)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection/Approval date must be greater equal to the last action date of application.');", true);
                                    return;
                                }

                           
                                DateTime serverDate = DateTime.Now.Date;
                                if (inspectionDate > serverDate)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection date must be less than Today date.');", true);
                                    return;
                                }                                                       
                                ApprovedorReject = ddlReview.SelectedItem.ToString();
                                if (FileApprovalCertificate.HasFile)
                                {
                                    if (FileApprovalCertificate.PostedFile != null && FileApprovalCertificate.PostedFile.ContentLength <= maxFileSize)
                                    {
                                        string ext = Path.GetExtension(FileApprovalCertificate.FileName).ToLower();
                                        if (!allowedExtensions.Contains(ext))
                                        {
                                            string alertScript = "alert('Only PDF files are allowed.');";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                            return;
                                        }

                                        string directoryPath = Server.MapPath("~/Attachment/CinemaCertificate/" + txtPAN.Text + "/" + txtInspectionID.Text);
                                        if (!Directory.Exists(directoryPath))
                                        {
                                            Directory.CreateDirectory(directoryPath);
                                        }

                                        string fileName = "CinemaCertificate" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                                        string fullPath = Path.Combine(directoryPath, fileName);
                                        filePathInfo = "/Attachment/CinemaCertificate/" + txtPAN.Text + "/" + txtInspectionID.Text + "/" + fileName;
                                        FileApprovalCertificate.SaveAs(fullPath);
                                    }
                                    else
                                    {
                                        string alertScript = "alert('Pdf file must be 1MB.');";
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                        return;
                                    }

                                }
                                // For Double Click ----------
                                ClickCount = ClickCount + 1;
                                Session["ClickCount"] = ClickCount;
                                // End ----------------------
                                int x = CEI.InspectionActionCinema(txtInspectionID.Text, hdnStaffId.Value, ApprovedorReject, txtRejectReason.Text, txtRemarks.Text, txtInspectionDate.Text, transaction);
                                    if (x > 0)
                                    {
                                        checksuccessmessage = 1;
                                        if (ApprovedorReject.Trim() == "Approved")
                                        {
                                          int y =  CEI.InsertApprovedCertificatedataCinema(txtInspectionID.Text, filePathInfo, transaction);
                                            if (y > 0)
                                            {
                                                transaction.Commit();
                                                string script = $"alert('Inspection  has been approved Successfully !!.'); window.location='/Officers/AcceptedOrReject.aspx';";
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                                            }
                                            else
                                            {
                                                string alertScript = "alert('Please try again.');";
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                         transaction.Commit();
                                         string script = $"alert('Inspection  has been Rejected.'); window.location='/Officers/AcceptedOrReject.aspx';";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);

                                        }
                                    }
                                    else
                                    {
                                        string alertScript = "alert('Please try again.');";
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                        return;
                                    }
                         

                        }
                        else
                        {
                            ddlReview.Focus();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please take an action to proceed further process.');", true);
                            return;
                          
                        }

                        }
                    catch (Exception ex)
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                        return;
                    }
                    finally
                    {
                        Session["ClickCount"] = 0;
                        if (connection != null && connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('You double click on Button.'); window.location='InProcessRequest.aspx'", true);
                }

            }
            else
            {
                Session["StaffID"] = "";
                Response.Redirect("/OfficerLogout.aspx");
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

        protected void ddlReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlReview.SelectedValue == "1")
            {
                Document.Visible = true;
                ReMark.Visible = true;
                Rejection.Visible = false;
            }
            else if(ddlReview.SelectedValue == "2")
            {
                Document.Visible = false;
                ReMark.Visible = false;
                Rejection.Visible = true;
            }
            else
            {
                ReMark.Visible = false;
                Rejection.Visible = false;
                Document.Visible = false;
            }
        }
    }
}