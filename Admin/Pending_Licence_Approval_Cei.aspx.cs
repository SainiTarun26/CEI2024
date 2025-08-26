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
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Admin
{
    public partial class Pending_Licence_Approval_Cei : System.Web.UI.Page
    {
        //Page Created by aslam 18-June-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!IsPostBack && Request.UrlReferrer != null)
                    {
                        string referrerUrl = Request.UrlReferrer.ToString();

                        if (!referrerUrl.Contains("New_Registration_Information.aspx") && !referrerUrl.Contains("New_Registration_Information_Contractor.aspx"))
                        {
                            Session["PreviousPageUrl2"] = referrerUrl;
                        }
                    }


                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty && Convert.ToString(Session["Application_Id"]) != null && Convert.ToString(Session["Application_Id"]) != string.Empty)
                    {
                        hdn_Lic_ApplicationId.Value = Session["Application_Id"].ToString();
                        Session["Application_Id"] = null;

                        string var_Lic_ApplicationId = hdn_Lic_ApplicationId.Value;

                        if (!string.IsNullOrEmpty(var_Lic_ApplicationId))
                        {
                            GetHeaderDetailsWithId(var_Lic_ApplicationId);
                            BindApplicationLogDetails(var_Lic_ApplicationId);
                            LoadLicenceCeiDownloadFilePaths(var_Lic_ApplicationId);
                        }

                    }
                    else
                    {
                        Session["AdminId"] = null;
                        Response.Redirect("/AdminLogout.aspx", false);
                    }

                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.ToString().Replace("'", "\\'");
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('An unexpected error occurred: {errorMessage}');", true);
                return;
            }

        }
        private void GetHeaderDetailsWithId(string licApplicationId)
        {
            ucLicenceDetails.BindHeaderDetails(licApplicationId);
        }


        private void BindApplicationLogDetails(string licApplicationId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.Get_Licence_ApplicationLogDetails(licApplicationId);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();

                    string script = "alert(\"No record found for this application.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);
                }

                ds.Dispose();
            }
            catch (Exception ex)
            {
                string errorScript = "alert(\"An error occurred: " + ex.Message.Replace("'", "\\'") + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", errorScript, true);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["AdminId"].ToString() != null)
            {
                try
                {
                    string applicationId = ucLicenceDetails.ApplicationId;
                    string remarks = TextBox1.Text.Trim();
                    string actionTaken = ddlReview.SelectedValue;

                    if (string.IsNullOrEmpty(applicationId))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Application ID is required.');", true);
                        return;
                    }
                    if (actionTaken == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please select an action.');", true);
                        return;
                    }
                    if (string.IsNullOrEmpty(remarks))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please enter remarks.');", true);
                        return;
                    }

                    int result = CEI.Insert_Licence_CeiApprovalRejection(applicationId, remarks, actionTaken, Session["AdminId"].ToString());

                    if (result == 1)
                    {
                        string actionText = ddlReview.SelectedItem.Text;
                        string message = $"Application {actionText} successfully.";
                        ScriptManager.RegisterStartupScript(this, GetType(), "successMessage", $"alert('{message}'); window.location='Pending_Licence_Approval_Cei_List.aspx';", true);
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", "alert('Failed to save . Please try again later.');", true);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "exceptionMessage", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
            else
            {
                Session["AdminId"] = null;
                Response.Redirect("/AdminLogout.aspx");
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Session["PreviousPageUrl2"] != null)
            {
                Response.Redirect(Session["PreviousPageUrl2"].ToString(), false);
            }
        }


        private void LoadLicenceCeiDownloadFilePaths(string applicationId)
        {
            DataSet ds = CEI.GetLicenceCeiDownloadFilePaths(applicationId);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string issueLetterPath = row["XenVerifiedLetterPath"]?.ToString();
                string momDocPath = row["SupMeetingDocPath"]?.ToString();
                hfIssueLetterPath.Value = issueLetterPath;
                hfMomDocumentPath.Value = momDocPath;
                LettersView.Visible = !string.IsNullOrWhiteSpace(issueLetterPath) && !string.IsNullOrWhiteSpace(momDocPath);
            }
            else
            {
                lnkbtnDownloadIssueLetter.Visible = false;
                lnkMomDocument.Visible = false;
                LettersView.Visible = false;
            }
        }

        protected void lnkbtnDownloadIssueLetter_Click(object sender, EventArgs e)
        {
            HandleDownload(hfIssueLetterPath.Value);
        }

        protected void lnkMomDocument_Click(object sender, EventArgs e)
        {
            HandleDownload(hfMomDocumentPath.Value);
        }

        private void HandleDownload(string relativeFilePath)
        {
            if (string.IsNullOrEmpty(relativeFilePath))
            {
                ShowAlert("File not available.");
                return;
            }
            string physicalPath = Server.MapPath(relativeFilePath);

            if (File.Exists(physicalPath))
            {
                string fileUrl = ResolveUrl(relativeFilePath);
                string script = $"window.open('{fileUrl}', '_blank');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenFileInNewTab", script, true);
            }
            else
            {
                ShowAlert("File not found. Please try again later.");
            }
        }

        private void ShowAlert(string message)
        {
            string safeMessage = message.Replace("'", "\\'");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", $"alert('{safeMessage}');", true);
        }

    }
}