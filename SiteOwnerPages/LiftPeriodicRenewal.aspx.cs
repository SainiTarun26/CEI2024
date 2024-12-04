using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Media;
using System.Xml.Linq;
using CEI_PRoject;
using CEIHaryana.Contractor;
using CEIHaryana.Officers;
using CEIHaryana.UserPages;
using Org.BouncyCastle.Asn1.Cmp;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class LiftPeriodicRenewal : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        GetApplicantType();
                        //BindDistrict();
                    }
                }
            }
            catch { }
        }

        private void BindDistrict()
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDistrict();
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "AreaCovered";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch
            {}
        }

        private void GetApplicantType()
        {
            string OwnerId = Session["SiteOwnerId"].ToString();
            string ApplicantTypeID = string.Empty;

            DataSet ds = new DataSet();
            ds = CEI.GetApplicantTypeForLift(OwnerId);
            ApplicantTypeID = ds.Tables[0].Rows[0]["ApplicantTypeCode"].ToString();
            //ApplicantTypeID = "AT001";
            Session["ApplicantTypeID"] = ApplicantTypeID.ToString();
        }

        private void GridDocument()
        {
            string ApplicantType = Session["ApplicantTypeID"].ToString();
            // int InstallationTypeID = "4";
            int InstallationTypeID = 0;
            string InspectionType = "Periodic";
            string InstallationType = Session["InstallationType"].ToString();

            if (InstallationType == "Lift")
            {
                InstallationTypeID = 4;
            }
            else if (InstallationType == "Escalator")
            {
                InstallationTypeID = 10;
            }

            DataTable ds = CEI.GetDocumentsForLiftRenewal(ApplicantType, InstallationTypeID, InspectionType, InstallationType);
            if (ds != null && ds.Rows.Count > 0)
            {
                Grd_Document.DataSource = ds;
                Grd_Document.DataBind();
            }
            else
            {
                Grd_Document.DataSource = null;
                Grd_Document.DataBind();
                string script = "alert('No Record Found for document');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
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

                if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                {
                    String SiteOwnerID = Session["SiteOwnerId"].ToString();
                    string filePathInfo = "";

                    if (customFile.HasFile && customFile.PostedFile != null)
                    {
                        string fileExtension = Path.GetExtension(customFile.PostedFile.FileName).ToLower();

                        // Validate file size and type
                        if (customFile.PostedFile.ContentLength <= 1048576 && fileExtension == ".pdf")
                        {
                            string fileName = "PreviousChallan" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + fileExtension;
                            string directoryPath = Server.MapPath($"~/Attachment/{SiteOwnerID}/{txtRegistrationNo.Text}/PreviousChallan/");

                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            string filePathInfo2 = Path.Combine(directoryPath, fileName);
                            customFile.SaveAs(filePathInfo2);

                            filePathInfo = $"~/Attachment/{SiteOwnerID}/{txtRegistrationNo.Text}/PreviousChallan/{fileName}";
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('Please upload a PDF file that is no larger than 1 MB.');", true);
                            return;
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('Please select a file to upload.');", true);
                        return;
                    }

                    CEI.InsertPeriodicLiftData(ddlInstallationType.SelectedItem.ToString(), txtRegistrationNo.Text, txtPrevChallanDate.Text, filePathInfo, txtMake.Text,
                                               txtSerialNo.Text, txtLiftType.Text, txtControlType.Text, ddlCapacity.SelectedItem.ToString(), ddlDistrict.SelectedItem.ToString(), txtSiteAddress.Text, SiteOwnerID, transaction);

                    // Upload Attachments
                    foreach (GridViewRow row in Grd_Document.Rows)
                    {
                        Label LblDocumentID = (Label)row.FindControl("LblDocumentID");
                        Label LblDocumentName = (Label)row.FindControl("LblDocumentName");
                        Label LblShortName = (Label)row.FindControl("LblShortName");

                        string fileName = LblShortName.Text;
                        string fileNameWithoutExtension = fileName;
                        int index = fileName.IndexOf(".pdf");
                        if (index > 0)
                        {
                            fileNameWithoutExtension = fileName.Substring(0, index);
                        }

                        FileUpload fileUploadDoc1 = row.FindControl("FileUpload1") as FileUpload;

                        // Check if a file is uploaded
                        if (fileUploadDoc1 != null && fileUploadDoc1.HasFile)
                        {
                            if (!Directory.Exists(Server.MapPath("/Attachment/" + SiteOwnerID + "/" + txtRegistrationNo.Text + "/" + "CheckListDocuments" + "/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerID + "/" + txtRegistrationNo.Text + "/" + "CheckListDocuments" + "/"));
                            }
                            string path = "/Attachment/" + SiteOwnerID + "/" + txtRegistrationNo.Text + "/" + "CheckListDocuments";
                            string fileName1 = fileNameWithoutExtension + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                            string filePathInfo1 = Server.MapPath(path + "/" + fileName1);
                            fileUploadDoc1.PostedFile.SaveAs(filePathInfo1);

                            CEI.UploadDocumentforLiftPeriodic(txtRegistrationNo.Text, ddlInstallationType.SelectedItem.ToString(), LblDocumentID.Text,
                                                              LblDocumentName.Text, fileName, path + "/" + fileName1, SiteOwnerID, transaction);

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "alert('Document uploaded successfully.');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('Please upload the document.');", true);
                            return;
                        }
                    }

                    transaction.Commit();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "alert('All documents uploaded successfully.');", true);
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", $"alert('Error: {ex.Message}');", true);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        protected void ddlInstallationType_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlInstallationType.SelectedItem.ToString();
            Session["InstallationType"] = ddlInstallationType.SelectedItem.ToString();

            divLabelLiftAttachments.Visible = true;
            divLiftAttachments.Visible = true;
            BindDistrict();
            GridDocument();

            string selectedValue = ddlInstallationType.SelectedValue;

            if (selectedValue == "1")
            {
                divLiftDetails.Visible = true;
                divdetails.Visible = true;
                divEscalatorDetails.Visible = false;
                lblTypeOfLift.InnerText = "Type of Lift";
            }
            else if (selectedValue == "2")
            {
                divLiftDetails.Visible = false;
                divdetails.Visible = true;
                divEscalatorDetails.Visible = true;
                lblTypeOfLift.InnerText = "Type of Escalator";
            }
            else
            {
                lblTypeOfLift.InnerText = "Type of Lift";
            }
        }
    }
}