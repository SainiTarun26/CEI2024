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
using System.Windows.Media.TextFormatting;
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
                        //GetApplicantType();
                        if (Convert.ToString(Session["RegistrationNosessionPass"]) != null && Convert.ToString(Session["RegistrationNosessionPass"]) != "")
                        {
                            txtRegistrationNo.Text = Session["RegistrationNosessionPass"].ToString();
                            if (Session["InstallTypePass"] != null)
                            {
                                if (Session["InstallTypePass"].ToString() == "Lift")
                                {
                                    ddlInstallationType.SelectedValue = "1";

                                }
                                else
                                {
                                    ddlInstallationType.SelectedValue = "2";
                                }
                                ddlInstallationType_SelectedIndexChanged(ddlInstallationType, EventArgs.Empty);
                                txtRegistrationNo.Enabled = false;
                                ddlInstallationType.Enabled = false;
                            }
                            ddlInstallationType.SelectedValue = "1";
                        }
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
            { }
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
            GetApplicantType();
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
                    string districtValue = string.Empty;
                    string Type = string.Empty;

                    if (ddlDistrict.Visible)
                    {
                        districtValue = ddlDistrict.SelectedItem.ToString();
                    }
                    else
                    {
                        districtValue = txtDistrict.Text;
                    }
                    if (RadioBtnType.Visible)
                    {
                        Type = RadioBtnType.SelectedItem.Text;
                    }
                    else if (RadioBtnEscType.Visible)
                    {
                        Type = RadioBtnEscType.SelectedItem.Text;
                    }

                    decimal weight = 0.0m;  

                    // Attempt to parse the weight value
                    if (decimal.TryParse(txtWeight.Text, out weight))
                    {
                        if (Session["ReturnedValue"].ToString() != "1")
                        {
                            CEI.InsertPeriodicLiftData(ddlInstallationType.SelectedItem.ToString(), txtRegistrationNo.Text, txtPrevChallanDate.Text, filePathInfo, txtLastApprovalDate.Text, txtDateofErection.Text, txtMake.Text,
                                              txtSerialNo.Text, Type, txtControlType.Text, txtCapacity.Text, weight, districtValue, txtSiteAddress.Text, SiteOwnerID, transaction);

                        }
                        else
                        {
                            string TestReportId = Session["EscalatorTestReportID"].ToString();
                            int InspectionId = int.Parse(Session["InspectionId"].ToString());
                            CEI.InsertReturnPeriodicLiftData(TestReportId,ddlInstallationType.SelectedItem.ToString(), txtRegistrationNo.Text, txtPrevChallanDate.Text, filePathInfo, txtLastApprovalDate.Text, txtDateofErection.Text, txtMake.Text,
                                              txtSerialNo.Text, Type, txtControlType.Text, txtCapacity.Text, weight, districtValue, txtSiteAddress.Text, InspectionId, SiteOwnerID);
                        }
                    }
                    // Upload Attachments
                    bool allDocumentsUploaded = true;
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

                        if (fileUploadDoc1 != null)
                        {
                            if (!fileUploadDoc1.HasFile)
                            {
                                allDocumentsUploaded = false;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('Please upload the document: " + LblDocumentName.Text + "');", true);
                                return;
                            }
                            else
                            {
                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + SiteOwnerID + "/" + txtRegistrationNo.Text + "/" + "CheckListDocuments" + "/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerID + "/" + txtRegistrationNo.Text + "/" + "CheckListDocuments" + "/"));
                                }

                                string path = "/Attachment/" + SiteOwnerID + "/" + txtRegistrationNo.Text + "/" + "CheckListDocuments";
                                string fileName1 = fileNameWithoutExtension + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                                string filePathInfo1 = Server.MapPath(path + "/" + fileName1);
                                fileUploadDoc1.PostedFile.SaveAs(filePathInfo1);

                                CEI.UploadDocumentforLiftPeriodic(txtRegistrationNo.Text, ddlInstallationType.SelectedItem.ToString(), LblDocumentID.Text,
                                                                 LblDocumentName.Text, fileName, path + "/" + fileName1, SiteOwnerID, transaction);
                            }
                        }
                    }

                    if (!allDocumentsUploaded)
                    {
                        return;
                    }

                    transaction.Commit();
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "alert('Application Submitted successfully.');", true);
                    //Response.Redirect("/SiteOwnerPages/LiftPeriodicRenewal.aspx", false);
                    if (Session["ReturnedValue"].ToString() != "1")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithReturnRedirectdata();", true);
                    }

                    
                    Reset();
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

        private void Reset()
        {
            ddlInstallationType.SelectedValue = "0";
            txtRegistrationNo.Text = "";
            txtPrevChallanDate.Text = "";
            txtMake.Text = "";
            txtSerialNo.Text = "";
            RadioBtnType.ClearSelection();
            txtControlType.Text = "";
            txtCapacity.Text = "";
            txtWeight.Text = "";
            ddlDistrict.SelectedValue = "0";
            txtSiteAddress.Text = "";
            txtDateofErection.Text = "";
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
                RadioBtnType.Visible = true;
                RadioBtnEscType.Visible = false;
                lblMake.InnerText = "Make of Lift";
            }
            else if (selectedValue == "2")
            {
                divLiftDetails.Visible = false;
                divdetails.Visible = true;
                divEscalatorDetails.Visible = true;
                lblTypeOfLift.InnerText = "Type of Escalator";
                RadioBtnEscType.Visible = true;
                RadioBtnType.Visible = false;
                lblMake.InnerText = "Make of Escalator";
            }
            else
            {
                lblTypeOfLift.InnerText = "Type of Lift";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SiteOwnerPages/LiftPeriodic.aspx", false);
        }


        protected void txtRegistrationNo_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = CEI.GetRenewalLiftData(ddlInstallationType.SelectedItem.ToString(), txtRegistrationNo.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtMake.ReadOnly = true;
                txtSerialNo.ReadOnly = true;
                RadioBtnType.Enabled = false;
                RadioBtnEscType.Enabled = false;
                txtControlType.ReadOnly = true;
                txtCapacity.ReadOnly = true;
                txtWeight.ReadOnly = true;
                txtSiteAddress.ReadOnly = true;
                ddlDistrict.Visible = false;
                txtDistrict.Visible = true;
                txtDateofErection.ReadOnly = true;
                txtLastApprovalDate.ReadOnly = true;
                txtPrevChallanDate.ReadOnly = true;
                txtMake.Text = ds.Tables[0].Rows[0]["Make"].ToString();
                txtSerialNo.Text = ds.Tables[0].Rows[0]["LiftSrNo"].ToString();
                string typeOfLift = ds.Tables[0].Rows[0]["TypeOfLift"].ToString();
                
                if (ddlInstallationType.SelectedItem.Text == "Lift")
                {
                    if (typeOfLift == "Passenger lift")
                    {
                        RadioBtnType.SelectedValue = "0"; 
                    }
                    else if (typeOfLift == "Goods Lift")
                    {
                        RadioBtnType.SelectedValue = "1";  
                    }
                }
                else if (ddlInstallationType.SelectedItem.Text == "Escalator")
                {
                    if (typeOfLift == "Travelator")
                    {
                        RadioBtnEscType.SelectedValue = "0"; 
                    }
                    else if (typeOfLift == "Escalator")
                    {
                        RadioBtnEscType.SelectedValue = "1";  
                    }
                }
                txtControlType.Text = ds.Tables[0].Rows[0]["TypeOfControl"].ToString();
                txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                txtWeight.Text = ds.Tables[0].Rows[0]["Weight"].ToString();
                //txtDateofErection.Text = ds.Tables[0].Rows[0]["ErectionDate"].ToString();
                DateTime erectionDate;
                if (DateTime.TryParse(ds.Tables[0].Rows[0]["ErectionDate"].ToString(), out erectionDate))
                {
                    txtDateofErection.Text = erectionDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    txtDateofErection.Text = ""; 
                }
                DateTime LastApprovalDate;
                if (DateTime.TryParse(ds.Tables[0].Rows[0]["LastApprovalDate"].ToString(), out LastApprovalDate))
                {
                    txtLastApprovalDate.Text = LastApprovalDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    txtLastApprovalDate.Text = "";
                }
                DateTime PrevChallanDate;
                if (DateTime.TryParse(ds.Tables[0].Rows[0]["Previous_ChallanDate"].ToString(), out PrevChallanDate))
                {
                    txtPrevChallanDate.Text = PrevChallanDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    txtPrevChallanDate.Text = "";
                }
                txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();              
               txtSiteAddress.Text = ds.Tables[0].Rows[0]["SiteAddress"].ToString();
            }
            else
            {
                //string alertScript = "alert('The  Registration number is Not In Our Database. Please provide a different Registration number.');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
            }

        } 
        protected void btnModalSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = CEI.GetRenewalLiftData(ddlInstallationType.SelectedItem.ToString(), txtSearch.Text.Trim());
            if (ds.Tables.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                string alertScript = "alert('The  Registration number is Not In Our Database. Please provide a different Registration number.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
            }

        }
    }
}