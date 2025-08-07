using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class SelfCertification : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string SC_ID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != string.Empty)
                    {
                        hdnOwnerId.Value = Session["SiteOwnerId"].ToString();
                        DataTable dt = CEI.GetSelfCertificateStatus(hdnOwnerId.Value);
                        if (dt.Rows.Count > 0 && dt.Rows != null)
                        {
                            string ApplicationStatus = dt.Rows[0]["ApplicationStatus"].ToString();
                            if (ApplicationStatus != null && ApplicationStatus != string.Empty && ApplicationStatus != "Rejected")
                            {
                                Response.Redirect("/SiteOwnerPages/SelfCertificationStatus.aspx", false);
                            }
                        }
                        ddlLoadBindVoltage();
                    }
                    else
                    {
                        Session["SiteOwnerId"] = "";
                        Response.Redirect("/SiteOwnerLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        private void ddlLoadBindVoltage()
        {

            DataSet dsVoltage = new DataSet();
            dsVoltage = CEI.GetddlVoltageLevel();
            ddlVoltage.DataSource = dsVoltage;
            ddlVoltage.DataTextField = "Voltagelevel";
            ddlVoltage.DataValueField = "VoltageID";
            ddlVoltage.DataBind();
            ddlVoltage.Items.Insert(0, new ListItem("Select", "0"));
            dsVoltage.Clear();

        }
        protected void chkOtherOption_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherOption.Checked)
            {
                OtherInstallation.Visible = true;
            }
            else
            {
                OtherInstallation.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlTransaction transaction = null;
            SqlConnection connection = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
                connection = new SqlConnection(connectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
                if (Convert.ToString(Session["SiteOwnerId"]) == Convert.ToString(hdnOwnerId.Value))
                {
                    if (chkLineOption.Checked || chkGeneratedOption.Checked || chkSubstationOption.Checked || chkSwitchingOption.Checked || chkSolarOption.Checked || chkOtherOption.Checked)
                    {
                        if (chkOtherOption.Checked)
                        {
                            if (txtOtherInstallation.Text == "" || txtOtherInstallation.Text == null)
                            {
                                string alertScript = "alert('Please define other installation type to Proceed.');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                return;
                            }
                        }
                        if (Convert.ToString(ddlVoltage.SelectedValue) != "0")
                        {
                            string SiteOwnerId = hdnOwnerId.Value;
                            string[] allowedExtensions = { ".pdf" };
                            int maxFileSize = 1 * 1024 * 1024;
                            if (!FileUploadForm1.HasFile && !FileUploadForm2.HasFile && !FileUploadForm3.HasFile)
                            {
                                string alertScript = "alert('Please upload any one among Form I / Form II / Form III files.');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                return;
                            }
                            if (!FileDemandNotice.HasFile)
                            {
                                string alertScript = "alert('Please upload Demand Notice file.');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                return;
                            }
                            if ((FileUploadForm1.HasFile && FileUploadForm1.PostedFile.ContentLength > maxFileSize) || (FileUploadForm2.HasFile && FileUploadForm2.PostedFile.ContentLength > maxFileSize) || (FileUploadForm3.HasFile && FileUploadForm3.PostedFile.ContentLength > maxFileSize) || (FileDemandNotice.HasFile && FileDemandNotice.PostedFile.ContentLength > maxFileSize) || (FileUploadOther.HasFile && FileUploadOther.PostedFile.ContentLength > maxFileSize))
                            {
                                string alertScript = "alert('Please upload files with a maximum size of 1MB.');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                return;
                            }


                            ///get Assign to
                            DataTable dt = CEI.GetAssignTo_CS(SiteOwnerId);
                            string AssignTo = dt.Rows[0]["StaffUserID"].ToString();
                            string SiteOwnerName = dt.Rows[0]["SiteOwnerName"].ToString();
                            string District = dt.Rows[0]["District"].ToString();

                            // FOR INSERT DATA
                            SC_ID = CEI.InsertDataForCS(SiteOwnerName, District, chkLineOption.Checked ? "1" : "0", chkGeneratedOption.Checked ? "1" : "0", chkSubstationOption.Checked ? "1" : "0", chkSwitchingOption.Checked ? "1" : "0", chkSolarOption.Checked ? "1" : "0",
                                chkOtherOption.Checked ? "1" : "0", txtOtherInstallation.Text.Trim(), ddlVoltage.SelectedItem.ToString(), AssignTo, SiteOwnerId, transaction);

                            if (!string.IsNullOrEmpty(SC_ID))
                            {
                                // FOR INSERT DOCUMENTS
                                int x = UploadDocumentd(transaction);
                                if (x > 0)
                                {
                                    transaction.Commit();
                                    string script = $"alert('SELF CERTIFICATION Successfuly Submit!!.'); window.location='SelfCertificationStatus.aspx';";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                                    return;
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
                            ddlVoltage.Focus();
                            string alertScript = "alert('Please Select Voltage Level to Proceed.');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                            return;
                        }
                    }
                    else
                    {
                        string alertScript = "alert('Please Select Installation type to Proceed.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                        return;
                    }
                }
                else
                {
                    Session["SiteOwnerId"] = "";
                    Response.Redirect("/SiteOwnerLogout.aspx", false);
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
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public int UploadDocumentd(SqlTransaction transaction)
        {
            int successCount = 0;
            for (int i = 1; i <= 5; i++)
            {
                FileUpload fileUploadControl = null;
                string fileName = "";
                string DocumentId = "";
                switch (i)
                {
                    case 1:
                        fileUploadControl = FileUploadForm1;
                        fileName = "FORM_I";
                        DocumentId = "1";
                        break;
                    case 2:
                        fileUploadControl = FileUploadForm2;
                        fileName = "FORM_II";
                        DocumentId = "2";
                        break;
                    case 3:
                        fileUploadControl = FileUploadForm3;
                        fileName = "FORM_III";
                        DocumentId = "3";
                        break;
                    case 4:
                        fileUploadControl = FileDemandNotice;
                        fileName = "DemandNotice_ElectricityBill";
                        DocumentId = "4";
                        break;
                    case 5:
                        fileUploadControl = FileUploadOther;
                        fileName = "OtherDocument";
                        DocumentId = "5";
                        break;
                }

                if (fileUploadControl != null && fileUploadControl.HasFile)
                {
                    string folderPath = Server.MapPath("~/Attachment/Self-Certification/" + hdnOwnerId.Value + "/" + SC_ID);
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string fullPath = Path.Combine(folderPath, fileName + ".pdf");
                    string Fileinfo = "/Attachment/Self-Certification/" + hdnOwnerId.Value + "/" + SC_ID + "/" + fileName + ".pdf";

                    fileUploadControl.SaveAs(fullPath);

                    // Save Documents
                    int x = CEI.InsertDocumentForCS(SC_ID, DocumentId, fileName, Fileinfo, hdnOwnerId.Value, transaction);
                    if (x > 0)
                    {
                        successCount++;
                    }
                }
            }
            return successCount;
        }
        //added by kalpana on instructions of vinod and sunil sir 
        protected void ddlVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVoltage.SelectedValue == "650V")
            {
                Form2.Visible = true;
                Form3.Visible = false;
            }

            else if (ddlVoltage.SelectedValue != "0"&& ddlVoltage.SelectedValue != "650V")
            {
                Form3.Visible = true;
                Form2.Visible = false;
            }
            else 
            {
                Form1.Visible = false;
                Form2.Visible = false;
                Form3.Visible = false;
            }
        }
        //
    }
}