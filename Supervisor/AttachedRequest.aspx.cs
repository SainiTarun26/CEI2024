using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class AttachedRequest : System.Web.UI.Page
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
                            string Attached = dt.Rows[0]["Attach_DeAttach"].ToString();
                            if (ApplicationStatus == "Submit" && Attached == "Attached")
                            {
                                Response.Redirect("/Supervisor/DeattachmentRequest.aspx", false);
                            }
                            else
                            {
                                //ddlContractorList(hdnId.Value);
                                ddlContractorList();
                            }
                        }
                        else
                        {
                            //ddlContractorList(hdnId.Value);
                            ddlContractorList();
                        }
                        // ddlContractorList(hdnId.Value);
                    }
                    else
                    {
                        Session["SupervisorID"] = "";
                        Response.Redirect("/SupervisorLogout.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        private void ddlContractorList()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetContractorList();
                ddlContractor.DataSource = ds;
                ddlContractor.DataTextField = "ConName";
                ddlContractor.DataValueField = "UserId";
                ddlContractor.DataBind();
                ddlContractor.Items.Insert(0, new ListItem("Select", "0"));
                if (ddlContractor.Items.Count == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Already attach any Contractor.');", true);
                    btnToDeattach.Visible = false;
                }
                ds.Clear();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void ddlContractor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetContractorViewDetails(ddlContractor.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                txtContractorName.Text = dt.Rows[0]["Name"].ToString();
                txtLicenceNo.Text = dt.Rows[0]["UserId"].ToString();
                txtFirmName.Text = dt.Rows[0]["FirmName"].ToString();
                TxtEmailId.Text = dt.Rows[0]["Email"].ToString();
                TxtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                txtControctorId.Text = dt.Rows[0]["ContractorId"].ToString();
            }
            else
            {
                txtContractorName.Text = "";
                txtLicenceNo.Text = "";
                txtFirmName.Text = "";
                TxtEmailId.Text = "";
                TxtContactNo.Text = "";
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
            try
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

                        DataTable dt = new DataTable();
                        dt = CEI.GetSupervisiorReID(hdnId.Value);
                        if (dt.Rows.Count > 0)
                        {
                            txtReId.Text = dt.Rows[0]["REID"].ToString();
                        }
                        else
                        {
                            string alertScript = "alert('Supervisior Id not find.');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                            return;

                        }
                        string directoryPath = Server.MapPath("~/Attachment/Supervisior/Attached/" + txtReId.Text);
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        string fileName = "Attached" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                        string fullPath = Path.Combine(directoryPath, fileName);
                        string filePathInfo = "/Attachment/Supervisior/Attached/" + txtReId.Text + "/" + fileName;

                        fileAttachment.SaveAs(fullPath);

                        int x = CEI.InsertDataForAttachment(txtControctorId.Text, filePathInfo, txtRemarks.Text, hdnId.Value, txtReId.Text);

                        if (x > 0)
                        {

                            // CEI.emailForDeattachmentRequest(TxtEmailId.Text);
                            string script = $"alert('Attachment request submitted successfully!!.'); window.location='DeattachmentRequest.aspx';";
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
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
                //throw;
            }
        }
    }
}