﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        //Page Created By Neha 
        CEI CEI = new CEI();
        string TRID = string.Empty;
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
                            txtRegistrationNo.Text = Session["RegistrationNosessionPass"].ToString();
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
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ApplicantTypeID = ds.Tables[0].Rows[0]["ApplicantTypeCode"].ToString();
                Session["ApplicantTypeID"] = ApplicantTypeID.ToString();
            }
            else
            { }
        }

        private void GridtoViewAllRecords(string InstallationType, string CreatedBy)
        {
            DataSet ds = new DataSet();
            ds = CEI.GetRenewalLiftDataGridOfAllREcords(InstallationType, CreatedBy);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        private void GridDocument()
        {
            GetApplicantType();
            string ApplicantType = Session["ApplicantTypeID"].ToString();
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
                    DateTime lastExpiryDate = Convert.ToDateTime(txtLastexpirydate.Text);
                    DateTime memoDate = Convert.ToDateTime(txtMemoDate.Text);

                    // Call the date validation method
                    if (ToCheckDatesForLiftRenewal(lastExpiryDate, memoDate))
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
                                TRID = CEI.InsertPeriodicLiftData(ddlInstallationType.SelectedItem.ToString(), txtRegistrationNo.Text, txtLastexpirydate.Text, filePathInfo, txtLastApprovalDate.Text, txtDateofErection.Text, txtMake.Text,
                                                 txtSerialNo.Text, Type, txtControlType.Text, txtCapacity.Text, weight, districtValue, txtMemoNo.Text, txtMemoDate.Text, txtSiteAddress.Text, SiteOwnerID, transaction);
                            }
                            else
                            {
                                string TestReportId = Session["EscalatorTestReportID"].ToString();
                                int InspectionId = int.Parse(Session["InspectionId"].ToString());
                                DataTable dt = new DataTable();
                                dt = CEI.InsertReturnPeriodicLiftData(TestReportId, ddlInstallationType.SelectedItem.ToString(), txtRegistrationNo.Text, txtLastexpirydate.Text, filePathInfo, txtLastApprovalDate.Text, txtDateofErection.Text, txtMake.Text,
                                                     txtSerialNo.Text, Type, txtControlType.Text, txtCapacity.Text, weight, districtValue, txtMemoNo.Text, txtMemoDate.Text, txtSiteAddress.Text, InspectionId, SiteOwnerID);
                                TRID = dt.Rows[0]["TestReportId"].ToString();
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

                                    CEI.UploadDocumentforLiftPeriodic(TRID, txtRegistrationNo.Text, ddlInstallationType.SelectedItem.ToString(), LblDocumentID.Text,
                                                                     LblDocumentName.Text, fileName, path + "/" + fileName1, SiteOwnerID, transaction);
                                }
                            }
                        }

                        if (!allDocumentsUploaded)
                        {
                            return;
                        }

                        transaction.Commit();
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

                    else
                    {
                        Response.Write("<script>alert('The date (month and day) of the FirstExpiryDate from Memo Date must match the Last Expiry Date.');</script>");
                    }
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
            txtMake.ReadOnly = false;
            txtSerialNo.ReadOnly = false;
            RadioBtnType.Enabled = true;
            RadioBtnEscType.Enabled = true;
            txtControlType.ReadOnly = false;
            txtCapacity.ReadOnly = false;
            txtWeight.ReadOnly = false;
            txtSiteAddress.ReadOnly = false;
            ddlDistrict.Visible = true;
            txtDistrict.Visible = false;
            txtDateofErection.ReadOnly = false;
            txtMemoNo.ReadOnly = false;
            txtMemoDate.ReadOnly = false;
            txtLastApprovalDate.ReadOnly = false;
            txtLastexpirydate.ReadOnly = false;

            txtMake.Text = "";
            txtSerialNo.Text = "";
            RadioBtnType.SelectedIndex = -1;
            RadioBtnEscType.SelectedIndex = -1;
            txtControlType.Text = "";
            txtCapacity.Text = "";
            txtWeight.Text = "";
            txtSiteAddress.Text = "";
            ddlDistrict.ClearSelection();
            txtDistrict.Text = "";
            txtDateofErection.Text = "";
            txtMemoNo.Text = "";
            txtMemoDate.Text = "";
            txtLastApprovalDate.Text = "";
            txtLastexpirydate.Text = "";
        }

        protected void ddlInstallationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset();
            txtRegistrationNo.Text = "";
            ddlInstallationType.SelectedItem.ToString();
            Session["InstallationType"] = ddlInstallationType.SelectedItem.ToString();

            divLabelLiftAttachments.Visible = true;
            divLiftAttachments.Visible = true;
            string CreatedBy = Session["SiteOwnerId"].ToString();

            GridtoViewAllRecords(ddlInstallationType.SelectedItem.ToString(), CreatedBy);
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
            string CreatedBy = Session["SiteOwnerId"].ToString();
            DataSet ds = new DataSet();
            //ds = CEI.GetRenewalLiftData(ddlInstallationType.SelectedItem.ToString(), txtRegistrationNo.Text.Trim(), CreatedBy);
            ds = CEI.GetRenewalLiftData(ddlInstallationType.SelectedItem.ToString(), txtRegistrationNo.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
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
                txtMemoNo.ReadOnly = true;
                txtMemoDate.ReadOnly = true;
                txtLastApprovalDate.ReadOnly = true;
                txtLastexpirydate.ReadOnly = true;
                txtMake.Text = ds.Tables[0].Rows[0]["Make"].ToString();
                txtSerialNo.Text = ds.Tables[0].Rows[0]["LiftSrNo"].ToString();
                //txtMemoNo.Text = ds.Tables[0].Rows[0]["MemoNo"].ToString();

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
                // if (DateTime.TryParse(ds.Tables[0].Rows[0]["Previous_ChallanDate"].ToString(), out PrevChallanDate))
                if (DateTime.TryParse(ds.Tables[0].Rows[0]["LastTransactionDate"].ToString(), out PrevChallanDate))
                {
                    txtLastexpirydate.Text = PrevChallanDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    txtLastexpirydate.Text = "";
                }

                txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                txtSiteAddress.Text = ds.Tables[0].Rows[0]["SiteAddress"].ToString();
                txtMemoNo.Text = ds.Tables[0].Rows[0]["MemoNo"].ToString();
                DateTime MemoDate;
                if (DateTime.TryParse(ds.Tables[0].Rows[0]["MemoDate"].ToString(), out MemoDate))
                {
                    txtMemoDate.Text = MemoDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    txtMemoDate.Text = "";
                }
            }
            else
            {
                Reset();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label LblRegistrationNo = (Label)row.FindControl("LblRegistrationNo");
                string RegistrationNo = LblRegistrationNo.Text;
                //string CreatedBy = Session["SiteOwnerId"].ToString();
                //txtRegistrationNo.Text = RegistrationNo;
                DataSet ds = new DataSet();
                //ds = CEI.GetRenewalLiftData(ddlInstallationType.SelectedItem.ToString(), RegistrationNo, CreatedBy);
                ds = CEI.GetRenewalLiftData(ddlInstallationType.SelectedItem.ToString(), RegistrationNo);
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
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
                    txtMemoNo.ReadOnly = true;
                    txtMemoDate.ReadOnly = true;
                    txtLastApprovalDate.ReadOnly = true;
                    txtLastexpirydate.ReadOnly = true;
                    txtMake.Text = ds.Tables[0].Rows[0]["Make"].ToString();
                    txtSerialNo.Text = ds.Tables[0].Rows[0]["LiftSrNo"].ToString();
                    // txtMemoNo.Text = ds.Tables[0].Rows[0]["MemoNo"].ToString();
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
                    //if (DateTime.TryParse(ds.Tables[0].Rows[0]["Previous_ChallanDate"].ToString(), out PrevChallanDate))
                    if (DateTime.TryParse(ds.Tables[0].Rows[0]["LastTransactionDate"].ToString(), out PrevChallanDate))
                    {
                        txtLastexpirydate.Text = PrevChallanDate.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        txtLastexpirydate.Text = "";
                    }

                    txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    txtSiteAddress.Text = ds.Tables[0].Rows[0]["SiteAddress"].ToString();
                    txtRegistrationNo.Text = ds.Tables[0].Rows[0]["RegistrationNo"].ToString();
                    txtMemoNo.Text = ds.Tables[0].Rows[0]["MemoNo"].ToString();
                    DateTime MemoDate;
                    if (DateTime.TryParse(ds.Tables[0].Rows[0]["MemoDate"].ToString(), out MemoDate))
                    {
                        txtMemoDate.Text = MemoDate.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        txtMemoDate.Text = "";
                    }
                }
                else
                {
                    Reset();
                }
            }
        }

        protected bool ToCheckDatesForLiftRenewal(DateTime lastExpiryDate, DateTime memoDate)
        {
            try
            {
                CEI.ToCheckDatesForLiftRenewal(lastExpiryDate, memoDate);
                return true; 
            }
            catch (SqlException ex)
            {
               foreach (SqlError error in ex.Errors)
                {
                    if (error.Number == 50000 && error.Message.Contains("The date (month and day) of the FirstExpiryDate from Memo Date must match the Last Expiry Date"))
                    {
                       return false;
                    }
                }
                throw new Exception("An unexpected error occurred during the date validation.", ex);
            }
        }
    }
}