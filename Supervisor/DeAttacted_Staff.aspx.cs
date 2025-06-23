using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.Supervisor
{
    public partial class DeAttacted_Staff : System.Web.UI.Page
    {
        //Page created y Neeraj on 23-June-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {

                    if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != string.Empty)
                    {
                        hdnId.Value = Session["SupervisorID"].ToString();
                        DataTable dt = new DataTable();
                        dt = CEI.GetSupervisiorStatus(hdnId.Value);
                        if (dt.Rows.Count > 0)
                        {
                            string ApplicationStatus = dt.Rows[0]["ApplicationStatus"].ToString();

                            if (ApplicationStatus == "Submit")
                            {
                                Response.Redirect("/Supervisor/DeattachmentRequest.aspx", false);
                            }
                        }
                        else
                        {
                            GetContractorDetails(hdnId.Value);
                        }
                    }
                    else
                    {
                        Session["SupervisorID"] = "";
                        Response.Redirect("/SupervisorLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        public void GetContractorDetails(string SupervisiorId)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetContractorDetails(SupervisiorId);
            if (dt.Rows.Count > 0)
            {
                txtControctorId.Text= dt.Rows[0]["ContractorID"].ToString();
                txtContractorName.Text = dt.Rows[0]["Name"].ToString();
                txtLicenceNo.Text = dt.Rows[0]["UserId"].ToString();
                txtFirmName.Text = dt.Rows[0]["FirmName"].ToString();
                TxtEmailId.Text = dt.Rows[0]["Email"].ToString();
                TxtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                txtReId.Text = dt.Rows[0]["REID"].ToString();
            }
            else
            {
                btnToDeattach.Visible = false;
                string script = $"alert('Not attached any Contractor.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                return;
            }

        }

        public bool CheckValidation()
        {
            if (string.IsNullOrWhiteSpace(txtContractorName.Text))
            {
                txtContractorName.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Contractor Name does not exist.');", true);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLicenceNo.Text))
            {
                txtLicenceNo.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Licence Number does not exist.');", true);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirmName.Text))
            {
                txtFirmName.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Firm does not exist.');", true);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtEmailId.Text))
            {
                TxtEmailId.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Email id does not exist.');", true);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtContactNo.Text))
            {
                TxtContactNo.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Contact number does not exist.');", true);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                txtRemarks.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('Please enter Remarks.');", true);
                return false;
            }

            return true;
        }

        protected void btnToDeattach_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["SupervisorID"]) == hdnId.Value)
            {
                if (!CheckValidation())
                {
                    return; 
                }

                
                string[] allowedExtensions = { ".pdf" };
                int maxFileSize = 1 * 1024 * 1024;
                if (fileAttachment.HasFile && fileAttachment.PostedFile != null && fileAttachment.PostedFile.ContentLength <= maxFileSize)
                {
                    string ext = Path.GetExtension(fileAttachment.FileName).ToLower();
                    if (!allowedExtensions.Contains(ext))
                    {
                        string alertScript = "alert('Only PDF files are allowed.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                        return;
                    }
                    string directoryPath = Server.MapPath("~/Attachment/Supervisior/DeAttached/" + txtReId.Text);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string fileName = "DeAttached" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                    string fullPath = Path.Combine(directoryPath, fileName);
                    string filePathInfo = "/Attachment/Supervisior/DeAttached/" + txtReId.Text + "/" + fileName;

                    fileAttachment.SaveAs(fullPath);

                    int x = CEI.InsertDataForDeAttachment(txtControctorId.Text, filePathInfo, txtRemarks.Text, hdnId.Value, txtReId.Text);

                    if (x > 0)
                    {

                        CEI.emailForDeattachmentRequest(TxtEmailId.Text);
                        string script = $"alert('De-attachment request submitted successfully!!.'); window.location='IntimationData.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                    }
                }
                else
                {
                    string alertScript = "alert('Please upload PDF file under 1MB.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }
            }
            else
            {
                Session["SupervisorID"] = "";
                Response.Redirect("/SupervisorLogout.aspx");
            }

        }
    }
}