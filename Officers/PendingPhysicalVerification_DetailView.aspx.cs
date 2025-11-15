using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.IO;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace CEIHaryana.Officers
{
    public partial class PendingPhysicalVerification_DetailView : System.Web.UI.Page
    {
        //Page created by navneet 18-June-2025
        CEI CEI = new CEI(); string Application_Id; string filePath;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    txtDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
                    if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        BindVenue();
                        Application_Id = Session["Application_Id"].ToString();
                        GetHeaderDetailsWithId(Application_Id);
                        BindApplicationLogDetails(Application_Id);
                        //Session["Application_Id"] = "";
                    }
                    else
                    {
                        Session["StaffID"] = "";
                        Response.Redirect("/OfficerLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorScript = "alert(\"An error occurred: " + ex.Message.Replace("'", "\\'") + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", errorScript, true);
            }
        }
        #region navneet for rdlc 13-nov-2025
        private string bindrdlc()
        {
            string Application_Id = Session["Application_Id"].ToString();
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"{Application_Id}_Letter_{timestamp}.pdf";
            string folderPath = Server.MapPath("~/Attachment/VerificationDocuments/");
            string filePath = Path.Combine(folderPath, fileName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rdlc/Verificationletter.rdlc");

            DataSet dsuser = GetData(Application_Id);
            ReportDataSource rds = new ReportDataSource("DataSet1", dsuser.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();

            Warning[] warnings;
            string[] streamIds;
            string mimeType, encoding, extension;
            byte[] bytes = ReportViewer1.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings
            );

            File.WriteAllBytes(filePath, bytes);

            //Response.Clear();
            //Response.Buffer = true;
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", $"attachment; filename={fileName}");
            //Response.BinaryWrite(bytes);
            //Response.Flush();
            //HttpContext.Current.ApplicationInstance.CompleteRequest();

            return filePath;
        }

        private DataSet GetData(string appid)
        {
            // Your SQL or Data retrieval logic here
            DataSet ds = new DataSet();
            ds = CEI.GetdataforXenletter(appid);
            return ds;
        }


        #endregion
        private void BindVenue()
        {
            DataTable dt = new DataTable();
            dt = CEI.GetVenueforOfficer();
            ddlvenue.DataSource = dt;
            ddlvenue.DataTextField = "Venue";
            ddlvenue.DataValueField = "Venue";
            ddlvenue.DataBind();
            dt.Clear();
        }
        private void GetHeaderDetailsWithId(string licApplicationId)
        {
            ucLicenceDetails.BindHeaderDetails(licApplicationId);
        }
        private void BindApplicationLogDetails(string licApplication_Id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.Get_Licence_ApplicationLogDetails(licApplication_Id);

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
            try
            {
                string EmailId = string.Empty;
                Application_Id = Session["Application_Id"].ToString();
                string StaffID = Session["StaffID"].ToString();
                DataSet ds = CEI.Licence_Cei_Approval_GetHeaderDetails(Application_Id);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    EmailId = ds.Tables[0].Rows[0]["Email"].ToString();
                }

                if (RadioButtonList1.SelectedValue == "Accept")
                {
                    CEI.UpdateXenVerificationstatus(ucLicenceDetails.ApplicationId, StaffID, ddlcorrection.SelectedItem.Text, RadioButtonList1.SelectedValue, txtRemarks.Text, txtCorrectionRemarks.Text, txtDate.Text, txtTime.Text, ddlvenue.SelectedValue, "Ready For Issue Letter", filePath);

                    filePath = bindrdlc();
                    string redirectpath = "https://uat.ceiharyana.com" + filePath;
                    CEI.SentLetterViaEmail(EmailId, redirectpath);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);

                }
                else
                {
                    CEI.UpdateXenVerificationstatus(ucLicenceDetails.ApplicationId, StaffID, ddlcorrection.SelectedItem.Text, RadioButtonList1.SelectedValue.ToString(), txtRemarks.Text, txtCorrectionRemarks.Text, null, null, null, "Verified", null);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                }
            }
            catch (Exception ex)
            {
                string errorScript = "alert(\"An error occurred: " + ex.Message.Replace("'", "\\'") + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", errorScript, true);
            }
        }

        protected void ddlcorrection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcorrection.SelectedValue == "1")
            {
                Correction.Visible = true;
            }
            else
            {

                Correction.Visible = false;
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue.Trim() == "Reject")
            {
                RejectionRemarks.Visible = true;
                AcceptedLabel.Visible = false;
                NeedCorrection.Visible = false;
                VerificationDate.Visible = false;
                Div1.Visible = false;
                Div2.Visible = false;
            }
            else
            {

                RejectionRemarks.Visible = false;
                AcceptedLabel.Visible = true;
                NeedCorrection.Visible = true;
                VerificationDate.Visible = true;
                Div1.Visible = true;
                Div2.Visible = true;
            }
        }
    }
}