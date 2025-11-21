using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Admin
{
    public partial class Contractor_Supervisor_Upgradation_Details : System.Web.UI.Page
    {
        //page created by neha
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                {
                    GetSubmittedUpgradationApplications(null);
                }
                else
                {
                    Response.Redirect("/Logout.aspx", false);
                }
            }
        }

        private void GetSubmittedUpgradationApplications(string Value)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetSubmittedUpgradationApplications(Value);
            if (dt.Rows.Count > 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
            else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();
                string script = "alert(\"There is no application Applied for Licence Upgradation.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            dt.Dispose();
        }



        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserType.SelectedItem.Text == "Supervisor")
            {

                GetSubmittedUpgradationApplications(ddlUserType.SelectedItem.Text);

            }
            else
            {
                GetSubmittedUpgradationApplications(ddlUserType.SelectedItem.Text);
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            if (e.CommandName == "Select")
            {
                Label lblID = (Label)row.FindControl("lblID");
                Label lblType = (Label)row.FindControl("lblType");
                Session["id"] = lblID.Text;
                if (lblType.Text == "Supervisor")
                {
                    Response.Redirect("/Admin/Supervisor_Upgradation_Details.aspx", false);
                }
                else if (lblType.Text == "Contractor")
                {
                    Response.Redirect("/Admin/Contractor_Upgradation_Details.aspx", false);
                }
            }
            #region download in zip made by navneet
            else if (e.CommandName == "Download")
            {
                string RegNo = e.CommandArgument.ToString();
                Label Categary = (Label)row.FindControl("lblType");
                Label lblApplicationID = (Label)row.FindControl("lblApplicationID");
                Label lblNewCertificate = (Label)row.FindControl("lblNewCertificate");


                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (ZipArchive zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        if (Categary.Text.Trim() != "Contractor")
                        {

                            DataTable dt = CEI.GetUpgradationOSupervisorRecordsDataAtAdmin(Convert.ToInt32(RegNo));
                            // Collect file URLs safely
                            List<string> fileUrls = new List<string>();

                            if (dt.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(dt.Rows[0]["CerificateOfCompetency"]?.ToString()))
                                    fileUrls.Add("https://ceiharyana.com" + dt.Rows[0]["CerificateOfCompetency"]);

                                if (!string.IsNullOrEmpty(dt.Rows[0]["CertificateOfExperience"]?.ToString()))
                                    fileUrls.Add("https://ceiharyana.com" + dt.Rows[0]["CertificateOfExperience"]);

                                if (!string.IsNullOrEmpty(dt.Rows[0]["CertificateOfMedical"]?.ToString()))
                                    fileUrls.Add("https://ceiharyana.com" + dt.Rows[0]["CertificateOfMedical"]);
                            }


                            using (var client = new System.Net.WebClient())
                            {
                                foreach (string fileUrl in fileUrls)
                                {
                                    try
                                    {
                                        byte[] fileBytes = client.DownloadData(fileUrl);
                                        string fileName = Path.GetFileName(fileUrl);

                                        ZipArchiveEntry entry = zip.CreateEntry(fileName, CompressionLevel.Fastest);
                                        using (var entryStream = entry.Open())
                                        {
                                            entryStream.Write(fileBytes, 0, fileBytes.Length);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        // log download error
                                    }
                                }
                            }
                        }
                        else
                        {
                            DataTable dts = CEI.GetUpgradationOfContractorDocumentsAtAdmin(lblNewCertificate.Text.Trim());
                            foreach (DataRow rows in dts.Rows)
                            {
                                string fileUrl = "https://ceiharyana.com" + rows["DocumentPath"].ToString();

                                using (var client = new System.Net.WebClient())
                                {
                                    try
                                    {
                                        byte[] fileBytes = client.DownloadData(fileUrl);
                                        string fileName = Path.GetFileName(fileUrl);

                                        ZipArchiveEntry entry = zip.CreateEntry(fileName, CompressionLevel.Fastest);
                                        using (var entryStream = entry.Open())
                                        {
                                            entryStream.Write(fileBytes, 0, fileBytes.Length);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log error if file missing
                                    }
                                }
                            }
                        }

                        try
                        {
                            Session["id"] = RegNo;
                            if (Categary.Text == "Contractor")
                            {
                                ExportUtility.ExportCleanHtmlToZip(
                                   pagePath: "/Print_Forms/Print_Contractor_Upgradation_Details.aspx",
                                   queryString: "RegNo=" + RegNo,
                                   zip: zip,
                                   outputFileName: "RegistrationInfo.html"
                               );
                            }
                            else
                            {
                                ExportUtility.ExportCleanHtmlToZip(
                                    pagePath: "/Print_Forms/Print_Supervisor_Upgradation_Details.aspx",
                                    queryString: "RegNo=" + RegNo,
                                    zip: zip,
                                    outputFileName: "RegistrationInfo.html"
                                );
                            }

                            Session["id"] = "";
                        }
                        catch (Exception ex)
                        {
                            // log if page not reachable
                        }
                    }

                    // ⚡ Now send ZIP after archive is closed
                    Response.Clear();
                    Response.ContentType = "application/zip";
                    Response.AddHeader("content-disposition", "attachment; filename=" + lblApplicationID.Text + "_Documents.zip");
                    memoryStream.Position = 0; // reset pointer
                    memoryStream.CopyTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            #endregion

            else
            {
                GetSubmittedUpgradationApplications(null);
            }
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView3.PageIndex = e.NewPageIndex;
                GetSubmittedUpgradationApplications(null);
            }
            catch { }
        }
    }
}