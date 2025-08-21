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

namespace CEIHaryana.Superintendent
{   
    public partial class Pending_Final_Recommendations : System.Web.UI.Page
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

                    if (Convert.ToString(Session["SuperidentId"]) != null && Convert.ToString(Session["SuperidentId"]) != string.Empty && Convert.ToString(Session["Application_Id"]) != null && Convert.ToString(Session["Application_Id"]) != string.Empty)
                    {
                        hdn_Lic_ApplicationId.Value = Session["Application_Id"].ToString();
                        Session["Application_Id"] = null;

                        string var_Lic_ApplicationId = hdn_Lic_ApplicationId.Value;

                        if (!string.IsNullOrEmpty(var_Lic_ApplicationId))
                        {
                            GetHeaderDetailsWithId(var_Lic_ApplicationId);
                            BindApplicationLogDetails(var_Lic_ApplicationId);
                        }


                    }
                    else
                    {
                        Session["SuperidentId"] = null;
                        Response.Redirect("/OfficerLogout.aspx", false);
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
            if (Session["SuperidentId"] != null && !string.IsNullOrWhiteSpace(Session["SuperidentId"].ToString()) && !string.IsNullOrWhiteSpace(ucLicenceDetails.ApplicationId))
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
                    string fileExtension = Path.GetExtension(CustomFile.PostedFile.FileName).ToLower();
                    string fixfileName = "MinutesOfMeeting" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + fileExtension;

                    int AppNo = int.Parse(applicationId.Split('-')[1]);

                    MinutesofMeetingAttachmentSaveMethod_Validation(fixfileName);
                    string savePathMomdb =  MinutesofMeetingAttachmentSaveMethod(fixfileName, AppNo);

                    int result = CEI.Insert_Licence_SupFinalRecommendation(applicationId, remarks, actionTaken, Session["SuperidentId"].ToString(), savePathMomdb);

                    if (result == 1)
                    {
                        string actionText = ddlReview.SelectedItem.Text;
                        string message = $"Application {actionText} successfully.";
                        ScriptManager.RegisterStartupScript(this, GetType(), "successMessage", $"alert('{message}'); window.location='Pending_Final_Recommendations_List.aspx';", true);
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", "alert('Failed to save recommendation. Please try again later.');", true);
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
                Session["SuperidentId"] = null;
                Response.Redirect("/OfficerLogout.aspx");
            }

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Session["PreviousPageUrl2"] != null)
            {
                Response.Redirect(Session["PreviousPageUrl2"].ToString(), false);
            }
        }

        private void MinutesofMeetingAttachmentSaveMethod_Validation(string fixfileName)
        {
            string fileName;
            HttpPostedFile postedFile = CustomFile.PostedFile;

            // Validate if the file is selected
            if (postedFile == null || postedFile.ContentLength == 0)
            {
                throw new Exception("No file selected. Please upload a Transfer Order document.");
            }

            // Validate the file type - only PDF allowed
            string fileExtension = Path.GetExtension(postedFile.FileName).ToLower();
            if (fileExtension != ".pdf")
            {
                throw new Exception("Only PDF files are allowed. Please upload a PDF file.");
            }

            // Validate the file size - 2MB max
            int maxFileSize = 2 * 1024 * 1024; // 2MB
            if (postedFile.ContentLength > maxFileSize)
            {
                throw new Exception("The file size exceeds the 2MB limit. Please upload a file smaller than 2MB.");
            }

        }
        private string MinutesofMeetingAttachmentSaveMethod(string fixfileName, int applicationId)
        {
            string fileName = Path.GetFileName(CustomFile.PostedFile.FileName);

            string relativeDirectory = $"/Attachment/LicenceMinutesMeetingSupDocs/{applicationId}/";
            string absoluteDirectoryPath = Server.MapPath("~" + relativeDirectory);

            if (!Directory.Exists(absoluteDirectoryPath))
            {
                Directory.CreateDirectory(absoluteDirectoryPath);
            }

            string absoluteFilePath = Path.Combine(absoluteDirectoryPath, fixfileName);
            CustomFile.SaveAs(absoluteFilePath);
            return relativeDirectory + fixfileName; 
        }

    }
}