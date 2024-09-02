using AjaxControlToolkit;
using CEI_PRoject;
using CEIHaryana.Model;
using CEIHaryana.Model.Industry;
using CEIHaryana.Officers;
using iText.StyledXmlParser.Jsoup.Nodes;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Input;
using System.Xml.Linq;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class GenerateInspection_Industry : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        Industry_Api_Post_DataformatModel ApiPostformatresult = new Industry_Api_Post_DataformatModel();
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        //IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        //string id = string.Empty;
        string fileExtension = string.Empty;
        string fileExtension2 = string.Empty;
        string fileExtension3 = string.Empty;
        string fileExtension4 = string.Empty;
        string IntimationId = string.Empty;

        int inspectionCountRes = 0;
        int inspectionIdRes = 0;



        // string Count = string.Empty;
        private static string PremisesType, ApplicantTypeCode, id, Category, InstallationTypeId, Count, PaymentMode,
            ApplicantType, InstallationType, AssigDesignation, InspectionType, PlantLocation;
        private static int TotalAmount;
        string LoginId = string.Empty;
        //string id = string.Empty;
        List<(string Installtypes, string DocumentID, string DocSaveName, string FileName, string FilePath)> uploadedFiles = new List<(string, string, string, string, string)>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId_Industry"] != null || Request.Cookies["SiteOwnerId_Industry"] != null)
                    {
                        getWorkIntimationData();
                        Session["PreviousPage_Industry"] = Request.Url.ToString();
                        Grd_Document.RowDataBound += Grd_Document_RowDataBound;
                    }
                }
            }
            catch
            {
                Response.Redirect("/Industry/IndustryServices.aspx");
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if (e.Row.RowType == DataControlRowType.Header)
                //{
                //    CheckBox chkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
                //    chkSelectAll.Attributes.Add("onclick", "SelectAllCheckboxes(this)");
                //}

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int reportTypeColumnIndex = 7;
                    TableCell reportTypeCell = e.Row.Cells[reportTypeColumnIndex];

                    if (reportTypeCell.Text == "Returned")
                    {
                        e.Row.CssClass = "ReturnedRowColor";
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void getWorkIntimationData()
        {
            id = Session["id_Industry"].ToString();
            Session["PendingIntimations_Industry"] = id;
            DataSet ds = new DataSet();
            ds = CEI.SiteOwnerInstallations_Industry(id, Session["ReturnedTestReportId_Industry"].ToString());
            if (ds.Tables.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getWorkIntimationData();
        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow rows in GridView1.Rows)
                {
                    if (rows.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chk = rows.FindControl("CheckBox1") as CheckBox;

                        if (chk != null && chk.ClientID == ((CheckBox)sender).ClientID)
                        {

                        }
                        else
                        {
                            chk.Checked = false;
                        }
                    }
                }
                GridViewRow row = ((Control)sender).NamingContainer as GridViewRow;

                if (row != null)
                {
                    Label lblCategory = (Label)row.FindControl("lblCategory");
                    Label lblApplicant = (Label)row.FindControl("lblApplicant");
                    Label lblVoltageLevel = (Label)row.FindControl("lblVoltageLevel");
                    Label lblDivision = (Label)row.FindControl("lblDivision");
                    Label lblDistrict = (Label)row.FindControl("lblDistrict");
                    Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                    Label lblPremises = (Label)row.FindControl("lblPermises");
                    Label lblApplicantTypeCode = (Label)row.FindControl("lblApplicantTypeCode");
                    Label lblDesignation = (Label)row.FindControl("lblDesignation");
                    Label lblTypeOfPlant = (Label)row.FindControl("LblTypeofPlant");
                    Label LblSactionLoad = (Label)row.FindControl("LblSactionLoad");
                    if (LblSactionLoad.Text == "1")
                    {
                        SactionVoltage.Visible = true;
                    }


                    CheckBox chk = (CheckBox)row.FindControl("CheckBox1");

                    DropDownList ddlDocumentFor = Documents.FindControl("ddlDocumentFor") as DropDownList;

                    inspectionCountRes = Convert.ToInt32(((HtmlInputHidden)row.FindControl("InspectionCount")).Value.Replace("\r\n", ""));
                    inspectionIdRes = Convert.ToInt32(((HtmlInputHidden)row.FindControl("InspectionId")).Value.Replace("\r\n", ""));



                    if (ddlDocumentFor != null)
                    {
                        ddlDocumentFor.Items.Clear();
                        ddlDocumentFor.Items.Add(new ListItem("Select", "0"));
                        int checkedCount = 0;
                        foreach (GridViewRow CurrentRow in GridView1.Rows)
                        {
                            CheckBox chkSelect = CurrentRow.FindControl("CheckBox1") as CheckBox;

                            if (chkSelect != null && chkSelect.Checked)
                            {
                                checkedCount++;
                                Label lblNoOfInstallation = CurrentRow.FindControl("lblNoOfInstallations") as Label;

                                if (lblNoOfInstallations != null)
                                {
                                    // Add values to the DropDownList
                                    string category = lblCategory.Text;
                                    string noOfInstallations = lblNoOfInstallation.Text;
                                    ddlDocumentFor.Items.Add(new ListItem($"{category} - {noOfInstallations}", $"{category}_{noOfInstallations}"));
                                }
                            }
                        }
                        if (checkedCount > 1)
                        {
                            ddlDocumentFor.Items.Add(new ListItem("Select All", "1"));
                        }
                    }

                    if (chk.Checked)
                    {
                        TotalPayment.Visible = true;
                        ChallanDetail.Visible = true;

                        txtInspectionDetails.Text = Session["SiteOwnerId_Industry"].ToString() + "-" + lblCategory.Text + "-" + lblVoltageLevel.Text;
                        Session["SelectedCategory_Industry"] = lblCategory.Text;
                        Session["SelectedApplicant_Industry"] = lblApplicant.Text;
                        Session["SelectedVoltageLevel_Industry"] = lblVoltageLevel.Text;
                        Session["SelectedDivision_Industry"] = lblDivision.Text;
                        Session["SelectedDistrict_Industry"] = lblDistrict.Text;
                        Session["SelectedNoOfInstallations_Industry"] = lblNoOfInstallations.Text;
                        PremisesType = lblPremises.Text;
                        ApplicantTypeCode = lblApplicantTypeCode.Text;
                        Category = lblCategory.Text;
                        Count = lblNoOfInstallations.Text;

                        //ApplicantType = lblApplicant.Text;
                        //if (ApplicantType == "Private/Personal Installation")
                        //{
                        //    ApplicantType = "Private And Personal";
                        //}
                        //if (ApplicantType == "Other Department/Organization") 
                        //{
                        //    ApplicantType = "Other Department";
                        //} 

                        InspectionType = "New";
                        AssigDesignation = lblDesignation.Text;
                        PlantLocation = lblTypeOfPlant.Text;

                        UploadDocuments.Visible = true;
                        FeesDetails.Visible = true;
                        PaymentDetails.Visible = true;
                        btnSubmit.Visible = true;
                        btnReset.Visible = true;

                        GetDocumentUploadData(ApplicantTypeCode, Category, InspectionType, AssigDesignation, PlantLocation, inspectionIdRes);
                        PaymentGridViewBind();
                        GetOtherDetails_ForReturnedInspection(inspectionIdRes);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                //Handle the exception appropriately
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblCategory = (Label)row.FindControl("lblCategory");
                    Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                    IntimationId = Session["id_Industry"].ToString();
                    Count = lblNoOfInstallations.Text.Trim();
                    DataSet ds = new DataSet();
                    ds = CEI.GetData_Industry(lblCategory.Text.Trim(), IntimationId, Count);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (lblCategory.Text.Trim() == "Line")
                        {
                            //Session["LineID_Industry"] = ds.Tables[0].Rows[0]["ID"].ToString();// gurmeet 4 may, to testreportid instead of id 
                            Session["LineID_Industry"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();

                            Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                        }
                        else if (lblCategory.Text.Trim() == "Substation Transformer")
                        {
                            //Session["SubStationID_Industry"] = ds.Tables[0].Rows[0]["ID"].ToString();
                            Session["SubStationID_Industry"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                            Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                        }
                        else if (lblCategory.Text.Trim() == "Generating Set")
                        {
                            //Session["GeneratingSetId_Industry"] = ds.Tables[0].Rows[0]["ID"].ToString();
                            Session["GeneratingSetId_Industry"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                            Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);

                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception)
            {
            }
        }

        #region visibilty
        // protected void Visibility()
        //{
        //    Uploads.Visible = true;
        //    if (txtWorkType.Text == "Line")
        //    {
        //        if (txtApplicantType.Text.Trim() == "Supplier Installation")
        //        {
        //            LineSubstationSupplier.Visible = true;
        //            SupplierSub.Visible = true;
        //        }
        //        else if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
        //        {
        //            LinePersonal.Visible = true;
        //            SupplierSub.Visible = true;
        //        }
        //    }
        //    else if (txtWorkType.Text == "Substation Transformer")
        //    {
        //        if (txtApplicantType.Text.Trim() == "Supplier Installation")
        //        {
        //            LineSubstationSupplier.Visible = true;
        //        }
        //        else if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
        //        {
        //            PersonalSub.Visible = true;
        //        }
        //    }
        //    else if (txtWorkType.Text == "Generating Set")
        //    {
        //        if (txtApplicantType.Text.Trim() == "Private/Personal Installation")
        //        {
        //            PersonalGenerating.Visible = true;
        //        }
        //        else
        //        {
        //            PersonalGenerating.Visible = false;
        //        }
        //    }
        //    else
        //    {
        //        LineSubstationSupplier.Visible = false;
        //        SupplierSub.Visible = false;
        //        PersonalGenerating.Visible = false;
        //    }

        //}
        #endregion
        private string GetDocumentIDFromFileUploadID(string fileUploadID)
        {
            string[] parts = fileUploadID.Split('_');
            if (parts.Length > 1)
            {
                return parts[1];
            }
            return null;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string serverStatus = CEI.CheckServerStatus("https://staging.investharyana.in");
            // string serverStatus = CEI.CheckServerStatus("https://staging.investharyana.in/api/project-service-logs-external_UHBVN");
            if (serverStatus != "Server is reachable.")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('HEPC Server Is Not Responding . Please Try After Some Time')", true);
                return;
            }


            //string script = "<script type=\"text/javascript\">window.onload = function() { printDiv('printableDiv'); }</script>";
            //ClientScript.RegisterStartupScript(this.GetType(), "print", script);
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MyFunction()", true);
            try
            {
                bool atLeastOneInspectionChecked = false;
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
                    string lblCategory = Session["SelectedCategory_Industry"].ToString().Trim();
                    string lblApplicant = Session["SelectedApplicant_Industry"].ToString().Trim();
                    string lblVoltageLevel = Session["SelectedVoltageLevel_Industry"].ToString().Trim();
                    string lblDivision = Session["SelectedDivision_Industry"].ToString().Trim();
                    string lblDistrict = Session["SelectedDistrict_Industry"].ToString().Trim();
                    string lblNoOfInstallations = Session["SelectedNoOfInstallations_Industry"].ToString().Trim();
                    string District = lblDistrict.Trim();
                    string Assign = string.Empty;
                    string To = lblDivision.Trim();
                    string input = lblVoltageLevel.Trim();
                    string CreatedBy = Session["SiteOwnerId_Industry"].ToString();
                    string FileName = string.Empty;
                    string ChallanAttachment = string.Empty;
                    string DemandNotice = string.Empty;
                    string LineLength = string.Empty;
                    string FeesLeft = string.Empty;
                    string transcationId = string.Empty;
                    string TranscationDate = string.Empty;
                    int maxFileSize = 1048576;

                    IntimationId = Session["id_Industry"].ToString();
                    Count = lblNoOfInstallations.Trim();
                    DataSet ds = new DataSet();
                    ds = CEI.GetData_Industry(lblCategory.Trim(), IntimationId, Count);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (lblCategory.Trim() == "Line")
                        {
                            id = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                            LineLength = ds.Tables[0].Rows[0]["LineLength"].ToString();
                        }
                        else
                        {
                            id = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                        }
                    }

                    if (ChallanDetail.Visible == true)
                    {
                        //if (FileUpload14.HasFile && FileUpload14.PostedFile.ContentLength <= 500 * 1024)
                        //{
                        //    string ext = Path.GetExtension(FileUpload14.PostedFile.FileName).ToLower();

                        //    if (ext == ".pdf") // Check if the file extension is PDF
                        //    {
                        //        FileName = "ChallanReport" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                        //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/ChallanReport/")))
                        //        {
                        //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/ChallanReport/"));
                        //        }
                        //        string path = "/Attachment/" + CreatedBy + "/ChallanReport/";
                        //        string filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/ChallanReport/" + FileName);

                        //        FileUpload14.SaveAs(filePathInfo2);
                        //        ChallanAttachment = path + FileName;
                        //    }
                        //    else
                        //    {
                        //        string alert = "alert('File Format Not Supported. Only PDF files are allowed.');";
                        //        ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
                        //        return;
                        //    }
                        //}
                        //else
                        //{
                        //    string alert = "alert('File exceeds maximum size limit (500 KB) or no file uploaded.');";
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
                        //    return;
                        //}

                        if (txttransactionId.Text != "")
                        {
                            transcationId = txttransactionId.Text.Trim();
                            TranscationDate = string.IsNullOrEmpty(txttransactionDate.Text) ? null : txttransactionDate.Text;
                        }
                        else
                        {
                            txttransactionDate.Focus();
                            txttransactionId.Focus();
                            return;
                        }
                    }
                    if (RadioButtonList2.SelectedValue != null)
                    {
                        PaymentMode = RadioButtonList2.SelectedItem.ToString();
                    }
                    double kVA = 0.0;
                    double kW = 0.0;
                    if (double.TryParse(txtSaction.Text.Trim(), out kW))
                    {

                        double powerFactor = 0.9;
                        kVA = kW / powerFactor;
                    }
                    string filePath = string.Empty;
                    HttpPostedFile postedFile = customFile.PostedFile;
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        if (postedFile.ContentLength <= maxFileSize)
                        {
                            string fileName = Path.GetFileName(postedFile.FileName);
                            string fileExtension = Path.GetExtension(fileName).ToLower();
                            if (fileExtension == ".pdf" || fileExtension == ".doc" || fileExtension == ".docx")
                            {
                                FileName = "DemandNotice_" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + fileExtension;
                                string folderPath = Server.MapPath("~/DemandNotices/");
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }
                                filePath = Path.Combine(folderPath, FileName);
                                postedFile.SaveAs(filePath);
                                DemandNotice = "~/DemandNotices/" + FileName;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "FileFormatError", "alert('File Format Not Supported. Only PDF, DOC, DOCX files are allowed.');", true);
                                return;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "FileSizeError", "alert('File exceeds maximum size limit (1 MB).');", true);
                            return;
                        }
                    }

                    InsertFilesIntoDatabase(CreatedBy, txtContact.Text, id, ApplicantTypeCode, IntimationId, PremisesType, lblApplicant.Trim(), lblCategory.Trim(), lblVoltageLevel.Trim(),
                    LineLength, Count, District, To, PaymentMode, txtDate.Text, txtInspectionRemarks.Text.Trim(), CreatedBy, TotalAmount, transcationId, TranscationDate, ChallanAttachment, Convert.ToInt32(InspectionIdClientSideCheckedRow.Value)
                      , kVA.ToString(), DemandNotice);

                    //Session["PrintInspectionID_Industry"] = id.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please First tick the any one installation for inspection')", true);
                }
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        public void UploadCheckListDocInCollection(string Category, string CreatedByy, string intimationids, string InstallTypes, string InstallTypeCount)
        {
            foreach (GridViewRow row in Grd_Document.Rows)
            {
                FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                string Req = ((HtmlInputHidden)row.FindControl("Req")).Value.Replace("\r\n", "");
                string DocSaveName = ((HtmlInputHidden)row.FindControl("DocumentShortName")).Value.Replace("\r\n", "");
                string DocumentID = ((HtmlInputHidden)row.FindControl("DocumentID")).Value.Replace("\r\n", "");
                string DocName = row.Cells[1].Text.Replace("\r\n", "");

                if (Convert.ToInt32(InspectionIdClientSideCheckedRow.Value) == 0)
                {
                    if (Req == "1")
                    {

                        if (!fileUpload.HasFile && Req == "1")
                        {
                            string message = DocName + " is mandatory to upload.";
                            throw new Exception(message);

                        }

                    }
                }

                if (fileUpload.HasFile)
                {
                    string CreatedBy = CreatedByy;
                    if (Path.GetExtension(fileUpload.FileName).ToLower() == ".pdf")
                    {

                        if (fileUpload.PostedFile.ContentLength <= 1048576)
                        {
                            string FileName = Path.GetFileName(fileUpload.PostedFile.FileName);

                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InstallTypes + "/" + InstallTypeCount + "/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InstallTypes + "/" + InstallTypeCount + "/"));
                            }

                            string ext = fileUpload.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/" + intimationids + "/" + InstallTypes + "/" + InstallTypeCount + "/";
                            //string fileName = DocSaveName + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            string fileName = DocSaveName + "." + ext;

                            string filePathInfo2 = "";

                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InstallTypes + "/" + InstallTypeCount + "/" + fileName);

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

        public void InsertFilesIntoDatabase(string para_CreatedBy, string para_txtContact, string para_id, string para_ApplicantTypeCode, string para_IntimationId, string para_PremisesType, string para_lblApplicant, string para_lblCategory, string para_lblVoltageLevel,
                  string para_LineLength, string para_Count, string para_District, string para_To, string para_PaymentMode, string para_txtDate, string para_txtInspectionRemarks, string para_CreatedByy, int para_TotalAmount, string para_transcationId, string para_TranscationDate, string para_ChallanAttachment, int para_InspectID, string para_kVA
            , string para_DemandNotice)
        {
            int checksuccessmessage = 0;
            // Insert the uploaded files into the database
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    CEI.InsertInspectionDataNewCode_Industry(para_txtContact, para_id, para_ApplicantTypeCode, para_IntimationId, para_PremisesType, para_lblApplicant, para_lblCategory, para_lblVoltageLevel,
                    para_LineLength, para_Count, para_District, para_To, para_PaymentMode, para_txtDate, para_txtInspectionRemarks, para_CreatedByy, para_TotalAmount, para_transcationId, para_TranscationDate, para_ChallanAttachment, para_InspectID, para_kVA, para_DemandNotice, transaction);

                    string generatedIdCombinedDetails = CEI.InspectionId();
                    string[] SplitResultPartsArray = generatedIdCombinedDetails.Split('|');
                    Session["PendingPaymentId_Industry"] = SplitResultPartsArray[0];
                    string firstValue = SplitResultPartsArray[0]; // Extract the first value
                    Session["PrintInspectionID_Industry"] = firstValue;
                    UploadCheckListDocInCollection(SplitResultPartsArray[2], para_CreatedByy, SplitResultPartsArray[1], SplitResultPartsArray[2], SplitResultPartsArray[3]);


                    foreach (var file in uploadedFiles)
                    {
                        //string query = "INSERT INTO tbl_InspectionAttachment (InspectionId,InstallationType,DocumentID,DocumentName,fileName, DocumentPath,CreatedDate,CreatedBy,Status) VALUES (@InspectionId,@InstallationType,@DocumentID,@DocSaveName,@FileName, @FilePath,getdate(),@CreatedBy,1)";
                        string query = "sp_InsertInspectionAttachments_Industry";

                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@InspectionId", SplitResultPartsArray[0]);
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
                    Session["InspectionLinkDisable"] = 2;

                    checksuccessmessage = 1;



                    //string actiontype = para_InspectID == 0 ? "Submit" : "ReSubmit";
                    string actiontype = "Submit";

                    Industry_Api_Post_DataformatModel ApiPostformatresult = CEI.GetIndustry_OutgoingRequestFormat(Convert.ToInt32(SplitResultPartsArray[0]), actiontype, Session["projectid_Temp"].ToString(), Session["Serviceid_Temp"].ToString(), Session["SiteOwnerId_Industry"].ToString());

                    if (ApiPostformatresult.PremisesType == "Industry")
                    {
                        // string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                        string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                        // string accessToken = "dfsfdsfsfsdf";

                        logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
                            "https://staging.investharyana.in/api/project-service-logs-external_UHBVN",
                                      new Industry_Inspection_StageWise_JsonDataFormat_Model
                                      {
                                          actionTaken = ApiPostformatresult.ActionTaken,
                                          commentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                          //commentDate = ApiPostformatresult.CommentDate,
                                          commentDate = ApiPostformatresult.CommentDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                                          comments = ApiPostformatresult.Comments,
                                          id = ApiPostformatresult.Id,
                                          projectid = ApiPostformatresult.ProjectId,
                                          serviceid = ApiPostformatresult.ServiceId
                                          //projectid = "245df444-1808-4ff6-8421-cf4a859efb4c",
                                          //serviceid = "e31ee2a6-3b99-4f42-b61d-38cd80be45b6"
                                      }, ApiPostformatresult, accessToken);

                        if (!string.IsNullOrEmpty(logDetails.ErrorMessage))
                        {
                            throw new Exception(logDetails.ErrorMessage);
                        }


                        CEI.LogToIndustryApiSuccessDatabase(
                        logDetails.Url,
                        logDetails.Method,
                        logDetails.RequestHeaders,
                        logDetails.ContentType,
                        logDetails.RequestBody,
                        logDetails.ResponseStatusCode,
                        logDetails.ResponseHeaders,
                        logDetails.ResponseBody,

                        new Industry_Api_Post_DataformatModel
                        {
                            InspectionId = ApiPostformatresult.InspectionId,
                            InspectionLogId = ApiPostformatresult.InspectionLogId,
                            IncomingJsonId = ApiPostformatresult.IncomingJsonId,
                            ActionTaken = ApiPostformatresult.ActionTaken,
                            CommentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                            CommentDate = ApiPostformatresult.CommentDate,

                            Comments = ApiPostformatresult.Comments,
                            Id = ApiPostformatresult.Id,
                            ProjectId = ApiPostformatresult.ProjectId,
                            ServiceId = ApiPostformatresult.ServiceId,
                        }

                    );

                    }

                    //SendJsonDataToIndustryApi(SplitResultPartsArray[0]);

                    // Session["PrintInspectionID_Industry"] = id.ToString();
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Inspection Request Submitted Successfully')", true);

                    //Response.Redirect("/SiteOwnerPages/InspectionRequestPrint.aspx", false);

                }
                catch (TokenManagerException ex)
                {
                    CEI.LogToIndustryApiErrorDatabase(
                        ex.RequestUrl,
                        ex.RequestMethod,
                        ex.RequestHeaders,
                        ex.RequestContentType,
                        ex.RequestBody,
                        ex.ResponseStatusCode,
                        ex.ResponseHeaders,
                        ex.ResponseBody,
                        new Industry_Api_Post_DataformatModel
                        {
                            InspectionId = ex.InspectionId,
                            InspectionLogId = ex.InspectionLogId,
                            IncomingJsonId = ex.IncomingJsonId,
                            ActionTaken = ex.ActionTaken,
                            CommentByUserLogin = ex.CommentByUserLogin,
                            CommentDate = ex.CommentDate,
                            Comments = ex.Comments,
                            Id = ex.Id,
                            ProjectId = ex.ProjectId,
                            ServiceId = ex.ServiceId,
                        }
                    );
                    string errorMessage = CEI.IndustryTokenApiReturnedErrorMessage(ex);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    //   ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                }
                catch (IndustryApiException ex)
                {
                    CEI.LogToIndustryApiErrorDatabase(
                        ex.RequestUrl,
                        ex.RequestMethod,
                        ex.RequestHeaders,
                        ex.RequestContentType,
                        ex.RequestBody,
                        ex.ResponseStatusCode,
                        ex.ResponseHeaders,
                        ex.ResponseBody,
                        new Industry_Api_Post_DataformatModel
                        {
                            InspectionId = ex.InspectionId,
                            InspectionLogId = ex.InspectionLogId,
                            IncomingJsonId = ex.IncomingJsonId,
                            ActionTaken = ex.ActionTaken,
                            CommentByUserLogin = ex.CommentByUserLogin,
                            CommentDate = ex.CommentDate,

                            Comments = ex.Comments,
                            Id = ex.Id,
                            ProjectId = ex.ProjectId,
                            ServiceId = ex.ServiceId,
                        }
                    );

                    //   string errorMessage = CEI.IndustryApiReturnedErrorMessage(ex);

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.ResponseBody.ToString() + "')", true);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                }
                catch (Exception ex)
                {
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
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please fill All details carefully')", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    }
                }
                finally
                {
                    if (checksuccessmessage == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    }

                    connection.Close();
                }

            }

        }



        protected void ddlDocumentFor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void PaymentGridViewBind()
        {
            try
            {
                if (Category == "Line")
                {
                    InstallationTypeId = "1";
                }
                else if (Category == "Substation Transformer")
                {
                    InstallationTypeId = "2";
                }
                else if (Category == "Generating Set")
                {
                    InstallationTypeId = "3";
                }
                string InspectionType = "New";
                DataTable ds = new DataTable();
                ds = CEI.Payment_Industry(id, Count, InstallationTypeId, InspectionType);
                if (ds.Rows.Count > 0 && ds != null)
                {
                    GridViewPayment.DataSource = ds;
                    GridViewPayment.DataBind();
                    TotalAmount = Convert.ToInt32(GridViewPayment.Rows[0].Cells[2].Text);
                    //      txtPayment.Text = Convert.ToString(TotalAmount);
                }
                else
                {
                    GridViewPayment.DataSource = null;
                    GridViewPayment.DataBind();
                    string script = "alert(\"Please Fill the Form first for knowing Payment \");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                //
            }
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChallanDetail.Visible = true;
            if (RadioButtonList2.SelectedValue == "0")
            {
                ChallanDetail.Visible = false;
            }
            else if (RadioButtonList2.SelectedValue == "1")
            {
                ChallanDetail.Visible = true;
            }
        }

        private void GetDocumentUploadData(string ApplicantType, string Category, string InspectionType, string AssigDesignation, string PlantLocation, int inspectionIdPrm)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetDocumentlist_Industry(ApplicantType, Category, InspectionType, AssigDesignation, PlantLocation, inspectionIdPrm);
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
        protected void Grd_Document_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    //ID = Session["InspectionId_Industry"].ToString();

                    fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    // fileName = "https://localhost:44393/" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
            }
            catch (Exception ex)
            {
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        }


        protected void Grd_Document_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //this code will work in case of New Upload documents  First Time Fresh Records
                if (inspectionCountRes == 0)
                {
                    LinkButton lnkDocumemtPath = (LinkButton)e.Row.FindControl("LnkDocumemtPath");


                    string commandArgument = lnkDocumemtPath.CommandArgument;


                    if (string.IsNullOrEmpty(commandArgument))
                    {
                        // Get the index of the column containing the LinkButton
                        int columnIndex = GetColumnIndexByName(Grd_Document, "Uploaded Documents");

                        // Hide the column containing the LinkButton
                        e.Row.Cells[columnIndex].Visible = false;

                        // Find and hide the header cell of the column
                        GridViewRow headerRow = Grd_Document.HeaderRow;
                        if (headerRow != null && headerRow.Cells.Count > columnIndex)
                        {
                            headerRow.Cells[columnIndex].Visible = false;
                        }
                    }
                }

                //this code will work in case of already uploaded documents
                if (inspectionCountRes > 0)
                {
                    LinkButton lnkDocumemtPath1 = (LinkButton)e.Row.FindControl("LnkDocumemtPath");

                    string commandArgument1 = lnkDocumemtPath1.CommandArgument;

                    if (string.IsNullOrEmpty(commandArgument1))
                    {
                        // Disable the LinkButton
                        lnkDocumemtPath1.Enabled = false;
                    }
                }
            }
        }


        //protected void Grd_Document_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        // Find the LinkButton control in the row
        //        LinkButton lnkDocumemtPath = (LinkButton)e.Row.FindControl("LnkDocumemtPath");

        //        // Get the command argument
        //        string commandArgument = lnkDocumemtPath.CommandArgument;

        //        // Check if command argument is blank or null
        //        if (string.IsNullOrEmpty(commandArgument))
        //        {
        //            // Get the index of the column containing the LinkButton
        //            int columnIndex = GetColumnIndexByName(Grd_Document, "Uploaded Documents");

        //            // Hide the column containing the LinkButton
        //            e.Row.Cells[columnIndex].Visible = false;

        //            // Hide the header of the column
        //            Grd_Document.HeaderRow.Cells[columnIndex].Visible = false;
        //        }
        //    }
        //}

        // Function to get the index of a column by its header text
        private int GetColumnIndexByName(GridView grid, string headerText)
        {
            for (int i = 0; i < grid.HeaderRow.Cells.Count; i++)
            {
                if (grid.HeaderRow.Cells[i].Text.ToLower() == headerText.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }

        //public Industry_Api_Post_DataformatModel GetIndustry_OutgoingRequestFormat(int _inspectionIdparams, string _actionType, SqlTransaction transaction )
        //{
        //    string query = "sp_Industry_Create_OutgoingRequest_Format";

        //        using (SqlCommand command = new SqlCommand(query,transaction.Connection,transaction))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@InspectionId", _inspectionIdparams);
        //            command.Parameters.AddWithValue("@ActionType", _actionType);

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    var model = new Industry_Api_Post_DataformatModel
        //                    {
        //                        PremisesType = reader["PremisesType"].ToString(),
        //                        InspectionId = Convert.ToInt32(reader["InspectionId"]),
        //                        InspectionLogId = Convert.ToInt32(reader["InspectionLogId"]),
        //                        IncomingJsonId = Convert.ToInt32(reader["IncomingJsonId"]),
        //                        ActionTaken = reader["ActionTaken"].ToString(),
        //                        CommentByUserLogin = reader["CommentByUserLogin"].ToString(),
        //                        CommentDate = Convert.ToDateTime(reader["CommentDate"]),
        //                        Comments = reader["Comments"].ToString(),
        //                        Id = reader["Id"].ToString(),
        //                        ProjectId = reader["ProjectId"].ToString(),
        //                        ServiceId = reader["ServiceId"].ToString()
        //                    };

        //                    return model;
        //                }
        //            }
        //        }


        //    return null;
        //}


        private void GetOtherDetails_ForReturnedInspection(int inspectionIdPrm)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            string query = "Sp_GetOtherDetails_ForReturnedInspection_Industry";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InspectionId", inspectionIdPrm);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txttransactionId.Text = reader["TransactionId"].ToString();
                    }
                    reader.Close();
                }
            }
        }


        //protected void SendJsonDataToIndustryApi(string inspectionidforjson)
        //{
        //    var inputObject = new Industry_Inspection_StageWise_JsonDataFormat_Model
        //    {
        //        actionTaken = "ServiceFormEdited",
        //        commentByUserLogin = Session["SiteOwnerId_Industry"].ToString(),
        //        commentDate = DateTime.Now,
        //        id = inspectionidforjson,
        //        projectid = "projectid",
        //        serviceid = "serviceid"
        //    };
        //  string url = "https://staging.investharyana.in/api/project-service-logs-external_UHBVN";
        //    CEI.Post_Industry_Inspection_StageWise_JsonData(url, inputObject);

        //}

        //protected void SendJsonDataToIndustryApi(string inspectionidforjson)
        //{
        //    var inputObject = new Industry_Inspection_StageWise_JsonDataFormat_Model
        //    {
        //        actionTaken = "ServiceFormEdited",
        //        commentByUserLogin = Session["SiteOwnerId_Industry"].ToString(),
        //        commentDate = DateTime.Now,
        //        id = inspectionidforjson,
        //        projectid = "projectid",
        //        serviceid = "serviceid"
        //    };
        //    string url = "https://staging.investharyana.in/api/project-service-logs-external_UHBVN";
        //    Industry_Inspection_StageWise_ReturnedJsonDataFormat_ViewModel response = CEI.Post_Industry_Inspection_StageWise_JsonData(url, inputObject);

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        var inputsendingobj = new
        //        {
        //            inspectionidparam = Convert.ToInt32(id),
        //            SiteOwnerIdIndustryparam = Session["SiteOwnerId_Industry"].ToString()
        //        };
        //        var inputparams = JsonConvert.SerializeObject(inputsendingobj);
        //        CEI.AfterSubmitInspection_SaveApiResponse_InDatabase(inputparams);

        //        //  CEI.AfterSubmitInspection_SaveApiResponse_InDatabase(Convert.ToInt32(id), Session["SiteOwnerId_Industry"].ToString());
        //    }
        //}

    }
}