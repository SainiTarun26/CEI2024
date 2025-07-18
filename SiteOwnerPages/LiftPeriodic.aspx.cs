﻿using System;
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
using CEI_PRoject;
using Pipelines.Sockets.Unofficial.Buffers;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class LiftPeriodic : System.Web.UI.Page
    {
        //Page Created By Neha 
        CEI CEI = new CEI();
        //private static string Category, InspectionType, PaymentMode;
        private static string Category, InspectionType;
        string InstallationId = string.Empty;
        private int totalQuantity = 0;
        private decimal totalAmountSum = 0;
        int ServiceType = 0;
        List<(string Installtypes, string DocumentID, string DocSaveName, string FileName, string FilePath)> uploadedFiles = new List<(string, string, string, string, string)>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        String UserId = Convert.ToString(Session["SiteOwnerId"]);
                        HdnUserID.Value = UserId;
                        Session["RegistrationNosessionPass"] = null;
                        Session["InstallTypePass"] = null;
                        Session["ReturnedValue"] = "Treys";
                        BindDistrict(UserId);
                    }
                }
            }
            catch
            { }
        }
        private void BindDistrict(string UserId)
        {
            try
            {
                DataSet dsDistrict = CEI.GetDistrictForLiftRenewal(UserId);
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "ApplicantDistrict";
                ddlDistrict.DataValueField = "ApplicantDistrict";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch
            { }
        }
      
        protected void btnAddnew_Click(object sender, EventArgs e)
        {
            Session["ReturnedValue"] = "Treys";
            Response.Redirect("/SiteOwnerPages/LiftPeriodicRenewal.aspx", false);
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(HdnUserID.Value) != null && Convert.ToString(HdnUserID.Value) != "")
            {
                ddlDistrict.SelectedItem.ToString();
                string District = ddlDistrict.SelectedItem.ToString();
                Session["Duplicacy"] = "0";

                GridBind(District, HdnUserID.Value);               
            }
            else
            {

            }
        }
        private void GridBind(string District,string SiteOwnerId)
        {
             DataTable ds = CEI.GetDataForLiftRenewal(District, SiteOwnerId);
            if (ds != null && ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert('No Record Found for document');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label LblRegistrationNo = (Label)row.FindControl("LblRegistrationNo");
                Label LblCategory = (Label)row.FindControl("LblCategory");
                Label LblTestReportID = (Label)row.FindControl("LblTestReportID");

                Session["RegistrationNo"] = LblRegistrationNo.Text;
                Session["TestReportID"] = LblTestReportID.Text;

                if (LblCategory != null)
                {
                    if (LblCategory.Text == "Lift") 
                    {
                        Response.Redirect("/TestReportModal/LiftPeriodicTestReportModal.aspx", false);
                    }
                    else if (LblCategory.Text == "Escalator")
                    {
                        Response.Redirect("/TestReportModal/EscalatorPeriodicTestReportModal.aspx", false);
                    }
                }
            }
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(HdnUserID.Value) != null && Convert.ToString(HdnUserID.Value) != "")
                {
                    String SiteOwnerId = Convert.ToString(HdnUserID.Value);

                    int liftCount = 0;
                    int EscalatorCount = 0;
                    int LiftCountForPayment = 0;
                    int EscalatorCountForPayment = 0;
                    //int yearsDifference = 0;

                    string selectedTypes = string.Empty;
                    foreach (GridViewRow rows in GridView1.Rows)
                    {
                        CheckBox chk = (CheckBox)rows.FindControl("CheckBox1");
                        if (chk != null && chk.Checked)
                        {
                            Label lblTypes = (Label)rows.FindControl("LblCategory");
                            //Label lblYearsDifference = (Label)rows.FindControl("LblYearsDifference");
                            Label LblAmount = (Label)rows.FindControl("LblAmount");


                            if (lblTypes.Text == "Lift")
                            {
                                liftCount++;
                            }
                            else if (lblTypes.Text == "Escalator")
                            {
                                EscalatorCount++;
                            }
                            string type = lblTypes.Text;
                            if (type == "Lift" && !selectedTypes.Contains("4"))
                            {
                                selectedTypes += "4,";
                            }
                            else if (type == "Escalator" && !selectedTypes.Contains("10"))
                            {
                                selectedTypes += "10,";
                            }

                            //if (int.TryParse(lblYearsDifference.Text, out yearsDifference))
                            decimal Amount;

                            if (decimal.TryParse(LblAmount.Text, out Amount))
                            {
                                if (lblTypes.Text == "Lift" && Amount > 0.00m)
                                {
                                    LiftCountForPayment++;
                                }
                                else if (lblTypes.Text == "Escalator" && Amount > 0.00m)
                                {
                                    EscalatorCountForPayment++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount input.");
                            }
                        }
                        else
                        {
                            Label LblRegistrationNo = (Label)rows.FindControl("LblRegistrationNo");
                            //CEI.TohandleUncheckedCheckbox(LblRegistrationNo.Text, Session["SiteOwnerId"].ToString());
                            CEI.TohandleUncheckedCheckbox(LblRegistrationNo.Text, SiteOwnerId); 
                        }
                    }

                    GridViewRow row = ((Control)sender).NamingContainer as GridViewRow;
                    if (row != null)
                    {
                        Label LblCategory = (Label)row.FindControl("LblCategory");
                        Label LblDistrict = (Label)row.FindControl("LblDistrict");
                        Label LblRegistrationNo = (Label)row.FindControl("LblRegistrationNo");

                        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                        string CreatedBy = Session["SiteOwnerId"].ToString();
                        TotalPayment.Visible = true;
                        ChallanDetail.Visible = true;

                        //Session["SelectedCategory"] = LblCategory.Text;

                        Category = LblCategory.Text;
                        if (Session["Duplicacy"].ToString().Trim() == "0")
                        {
                            CEI.CheckDuplicacyInLift(LblRegistrationNo.Text, CreatedBy);
                            Session["Duplicacy"] = "1";
                        }
                        else
                        { }
                        DataTable dt = new DataTable();
                        dt = CEI.GetApplicantCode(LblCategory.Text);
                        if (dt.Rows.Count > 0)
                        {
                            InstallationId = dt.Rows[0]["Id"].ToString();
                        }
                        else
                        {
                        }
                        if (chk.Checked)
                        {
                            CEI.Update_LiftRenewalPeriodicInspection(LblRegistrationNo.Text, int.Parse(InstallationId), CreatedBy);
                        }
                        else
                        { }
                        InspectionType = "Periodic";
                        FeesDetails.Visible = true;
                        PaymentDetails.Visible = true;
                        btnSubmit.Visible = true;
                        btnReset.Visible = true;

                        if (selectedTypes.EndsWith(","))
                        {
                            selectedTypes = selectedTypes.Substring(0, selectedTypes.Length - 1);
                        }
                        PaymentGridViewBind(selectedTypes, liftCount, EscalatorCount, LiftCountForPayment, EscalatorCountForPayment);
                        string Installationtypes = string.Empty;
                        if (liftCount == 0 && EscalatorCount == 1)
                        {
                            Installationtypes = "Escalator";
                        }
                        else if (liftCount == 1 && EscalatorCount == 0)
                        {
                            Installationtypes = "Lift";
                        }
                        else if (liftCount >= 1)
                        {
                            if (EscalatorCount >= 1)
                            {
                                Installationtypes = "Lift/Escalator";
                            }
                            else
                            {
                                Installationtypes = "MultiLift";
                            }
                        }
                        else if (EscalatorCount >= 1)
                        {
                            if (liftCount >= 1)
                            {
                                Installationtypes = "Lift/Escalator";
                            }
                            else
                            {
                                Installationtypes = "MultiEscalator";
                            }
                        }
                        hdnInstallationType.Value = Installationtypes;
                    }

                    //PaymentDetails.Visible = true;
                    UploadDocuments.Visible = true;
                    btnSubmit.Visible = true;
                    InspectionRemarks.Visible = true;
                }
                else
                { }
            }
            catch (Exception ex)
            { }
        }
        protected void GridViewPayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int quantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"));
                //int totalAmount = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
                decimal totalAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
                // Update the footer totals
                totalQuantity += quantity;
                totalAmountSum += Convert.ToDecimal(totalAmount);

            }
            // Check if the row is a footer row to display the totals
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblFooterQuantity = (Label)e.Row.FindControl("lblFooterQuantity");
                Label lblFooterAmount = (Label)e.Row.FindControl("lblFooterAmount");

                lblFooterQuantity.Text = totalQuantity.ToString();
                //lblFooterAmount.Text = totalAmountSum.ToString();
                //Session["Amount"] = Convert.ToDecimal(totalAmountSum);

                decimal formattedAmount = Math.Round(totalAmountSum, 2);

                lblFooterAmount.Text = formattedAmount.ToString("F2");  // Display amount with 2 decimal places
                Session["Amount"] = lblFooterAmount.Text;
                if (!string.IsNullOrEmpty(lblFooterAmount.Text) && decimal.TryParse(lblFooterAmount.Text, out decimal footerAmount)
                    && footerAmount > 0)
                {
                    BindGridDocumentsBind();
                    PaymentDetails.Visible = true;
                }
                else
                {
                    BindDocumentGridwithOutChallan();
                    PaymentDetails.Visible = false;
                }
            }
        }
        private void BindGridDocumentsBind()
        {
            DataTable ds = new DataTable();
            ds = CEI.GetDocumentforLiftPeriodicRenewal();
            if (ds.Rows.Count > 0)
            {
                Grd_Document.DataSource = ds;
                Grd_Document.DataBind();
            }
            else
            {
                Grd_Document.DataSource = null;
                Grd_Document.DataBind();
                string script = "alert(\"No Record Found for document \");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }
        private void BindDocumentGridwithOutChallan()
        {
            DataTable ds = new DataTable();
            ds = CEI.Get_DocumentGridwithOutChallan();
            if (ds.Rows.Count > 0)
            {
                Grd_Document.DataSource = ds;
                Grd_Document.DataBind();
            }
            else
            {
                Grd_Document.DataSource = null;
                Grd_Document.DataBind();
                string script = "alert(\"No Record Found for document \");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }
        protected void PaymentGridViewBind(string selectedType, int LiftCount, int EscaltorCount, int LiftCountForPayment, int EscalatorCountForPayment)
        {
            try
            {
                DataTable dsa = new DataTable();
                dsa = CEI.Payment_LiftPeriodic(selectedType, LiftCount, EscaltorCount, LiftCountForPayment, EscalatorCountForPayment);
                if (dsa.Rows.Count > 0 && dsa != null)
                {
                    GridViewPayment.DataSource = dsa;
                    GridViewPayment.DataBind();
                }
                else
                {
                    GridViewPayment.DataSource = null;
                    GridViewPayment.DataBind();
                    string script = "alert(\"Please check atleast One checkbox\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);

                    FeesDetails.Visible = false;
                    PaymentDetails.Visible = false;
                    btnSubmit.Visible = false;
                    btnReset.Visible = false;
                    UploadDocuments.Visible = false;
                    InspectionRemarks.Visible = false;
                }
                dsa.Dispose();
            }
            catch (Exception ex)
            {
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
            {
                string CreatedBy = Session["SiteOwnerId"].ToString();
                try
                {
                    bool atLeastOneInspectionChecked = false;
                    bool isFileUploadValid = true;
                    foreach (GridViewRow rows in GridView1.Rows)
                    {
                        CheckBox chk = (CheckBox)rows.FindControl("CheckBox1");

                        if (chk != null && chk.Checked)
                        {
                            atLeastOneInspectionChecked = true;
                            break;
                        }                   
                    }
                    if (atLeastOneInspectionChecked)
                    {

                        foreach (GridViewRow row in Grd_Document.Rows)
                        {
                            // Get the label that holds the document name
                            Label LblDocumentName = (Label)row.FindControl("LblDocumentName");

                            if (LblDocumentName != null)
                            {
                                string documentName = LblDocumentName.Text.Trim();

                                // Only check for file uploads if the document is not "Other Document"
                                if (documentName != "Other Document")
                                {
                                    FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");

                                    if (fileUpload != null && !fileUpload.HasFile)
                                    {
                                        isFileUploadValid = false;  // Set flag to false if no file is uploaded
                                        break;  // Exit loop once invalid file upload is detected
                                    }
                                }
                            }
                        }

                        if (!isFileUploadValid)
                        {
                            // If any mandatory file upload is missing, show an alert and stop the submission
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please upload Treasury Challan.')", true);
                            return;
                        }

                        string lblCategory = string.Empty;

                        if (hdnInstallationType.Value != null && hdnInstallationType.Value != "")
                        {
                            lblCategory = hdnInstallationType.Value;
                        }
                        else
                        {
                            return;
                        }

                        string District = ddlDistrict.SelectedItem.ToString(); 
                        string PaymentMode = string.Empty;
                        string Division = string.Empty;
                        DataSet ds = new DataSet();
                        ds = CEI.GetDivisionByDistrict(District);
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            Division = ds.Tables[0].Rows[0]["Area"].ToString();
                        }
                        decimal TotalAmount = 0;
                        string transcationId = string.Empty;
                        //DateTime TranscationDate = DateTime.Now;
                        string TranscationDate = string.Empty;
                        TotalAmount = Convert.ToDecimal(Session["Amount"]);

                        string Assigned = string.Empty;
                        string InstallationTypeID = string.Empty;

                        if (ChallanDetail.Visible == true)
                        {
                            if (txttransactionId.Text != "")
                            {
                                transcationId = txttransactionId.Text.Trim();
                                TranscationDate = txttransactionDate.Text;
                            }
                            else
                            {
                                txttransactionDate.Focus();
                                txttransactionId.Focus();
                                return;
                            }
                        }
                        string ApplicantType = string.Empty;

                        DataSet dsa = new DataSet();
                        dsa = CEI.GetApplicantTypeForLift(Session["SiteOwnerId"].ToString());
                        ApplicantType = dsa.Tables[0].Rows[0]["ApplicantType"].ToString();

                        if (RadioButtonList2.SelectedValue != null)
                        {
                            PaymentMode = RadioButtonList2.SelectedItem.ToString();
                        }
                        ServiceType = 4;
                        DataSet dsp = new DataSet();
                        dsp = CEI.ToGetStaffIdforPeriodic(Division, "XEN", District);
                        if (dsp.Tables.Count > 0 && dsp.Tables[0].Rows.Count > 0)
                        {
                            Assigned = dsp.Tables[0].Rows[0]["StaffUserId"].ToString();
                        }
                        InstallationTypeID = "10";
                        int inspectionId = 0;
                        if (string.IsNullOrEmpty(InspectionIdClientSideCheckedRow.Value))
                        {
                            inspectionId = 0;
                        }
                        else
                        {
                            inspectionId = Convert.ToInt32(InspectionIdClientSideCheckedRow.Value);
                        }

                        InsertFilesIntoDatabase(InstallationTypeID, CreatedBy, ApplicantType, lblCategory.Trim(), District, Division, PaymentMode,
                   txtInspectionRemarks.Text.Trim(), CreatedBy, TotalAmount, Assigned, transcationId, TranscationDate,
                   inspectionId, ServiceType);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please First tick the any one installation for inspection')", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                    return;
                }
            }
        }
        public void InsertFilesIntoDatabase(string InstallationTypeID, string para_CreatedBy, string para_ApplicantType, string para_lblCategory, string para_District,
            string para_To, string para_PaymentMode, string para_txtInspectionRemarks, string para_CreatedByy, decimal para_TotalAmount,
            string para_Assigned, string para_transcationId, string para_TranscationDate, int para_InspectID,
               int ServiceType)
        {
            bool isInsertSuccessful = true;
            // Insert the uploaded files into the database
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    Session["Duplicacy"] = "2";
                    string InspectionId = CEI.InsertInspectionDataForPeriodic_LiftInspection(para_ApplicantType, para_lblCategory, para_District,
                        para_To, para_PaymentMode, para_txtInspectionRemarks, para_CreatedByy, para_TotalAmount, para_Assigned, para_transcationId, para_TranscationDate, para_InspectID, ServiceType, transaction);
                    Session["PrintInspectionID"] = InspectionId;
                    UploadCheckListDocInCollection(para_lblCategory, para_CreatedByy, para_lblCategory, InspectionId);

                    foreach (var file in uploadedFiles)
                    {
                        string query = "sp_InsertInspectionAttachments";
                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@InspectionId", InspectionId);
                            command.Parameters.AddWithValue("@InstallationType", file.Installtypes);
                            command.Parameters.AddWithValue("@DocumentID", file.DocumentID);
                            command.Parameters.AddWithValue("@DocSaveName", file.DocSaveName);
                            command.Parameters.AddWithValue("@FileName", file.FileName);
                            command.Parameters.AddWithValue("@FilePath", file.FilePath);
                            command.Parameters.AddWithValue("@CreatedBy", para_CreatedBy);
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);

                }
                catch (Exception ex)
                {
                    isInsertSuccessful = false;
                    if (ex.Message == "Please Upload Pdf Files Only")
                    {
                        transaction.Rollback();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                        return;
                    }
                    else if (ex.Message == "Please Upload Pdf Files Less Than 1 Mb Only")
                    {
                        transaction.Rollback();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    }
                    else if (ex.Message.Contains(" is mandatory to upload."))
                    {
                        transaction.Rollback();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    }
                    else
                    {
                        transaction.Rollback();
                        //Commented below to raise errors as per backend                       
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    }
                }
                finally
                {
                    connection.Close();
                }

            }
        }
        public void UploadCheckListDocInCollection(string Category, string CreatedByy, string InstallTypes, string InspectionId)
        {
            if (InstallTypes == "Lift/Escalator")
            {
                InstallTypes = "Lift_Escalator";
            }

            foreach (GridViewRow row in Grd_Document.Rows)
            {
                FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                string DocSaveName = ((HtmlInputHidden)row.FindControl("DocumentShortName")).Value.Replace("\r\n", "");
                string DocumentID = ((HtmlInputHidden)row.FindControl("DocumentID")).Value.Replace("\r\n", "");
                string DocName = row.Cells[1].Text.Replace("\r\n", "");


                if (fileUpload.HasFile)
                {
                    string CreatedBy = CreatedByy;
                    if (Path.GetExtension(fileUpload.FileName).ToLower() == ".pdf")
                    {
                        if (fileUpload.PostedFile.ContentLength <= 1048576)
                        {
                            string FileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/" + InspectionId + "/" + InstallTypes + "/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/" + InspectionId + "/" + InstallTypes + "/"));
                            }
                            string ext = fileUpload.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/" + InspectionId + "/" + InstallTypes + "/";
                            string fileName = DocSaveName + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";

                            string filePathInfo2 = "";

                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/" + InspectionId + "/" + InstallTypes + "/" + fileName);
                            fileUpload.PostedFile.SaveAs(filePathInfo2);
                            uploadedFiles.Add((Category, DocumentID, DocName, fileName, path + fileName));
                        }
                        else
                        {
                            throw new Exception("Please Upload Pdf Files Less Than 1 Mb Only");
                        }
                    }
                    else
                    {
                        throw new Exception("Please Upload Pdf Files Only");
                    }
                }
            }
        }
    }
}

