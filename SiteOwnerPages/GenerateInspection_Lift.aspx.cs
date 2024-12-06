using CEI_PRoject;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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
    public partial class GenerateInspection_Lift : System.Web.UI.Page
    {
        CEI CEI = new CEI();       
        string fileExtension = string.Empty;
        string fileExtension2 = string.Empty;
        string fileExtension3 = string.Empty;
        string fileExtension4 = string.Empty;
        string IntimationId = string.Empty;
        int ServiceType = 0;
        int inspectionCountRes = 0;
        int inspectionIdRes = 0;
        string InstallationId = string.Empty;
        //protected decimal totalAmount = 0;        

        string strPreviousRowID = string.Empty;

        // string Count = string.Empty;
        private static string  ApplicantTypeCode, id, Category, Count, PaymentMode,
            ApplicantType,
            //InstallationType, PlantLocation
            AssigDesignation, InspectionType;      
        string LoginId, PlantLocationRoofTop, PlantLocationGroundMounted = string.Empty;        
        List<(string Installtypes, string DocumentID, string DocSaveName, string FileName, string FilePath)> uploadedFiles = new List<(string, string, string, string, string)>();
        string TestReportId = string.Empty;
                

        // Declare for total amoun and quantity
        private int totalQuantity = 0;
        private decimal totalAmountSum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        Session["Amount"] = "";
                        getWorkIntimationData();
                        Session["PreviousPage"] = Request.Url.ToString();
                        Grd_Document.RowDataBound += Grd_Document_RowDataBound;                       
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/login.aspx");
            }
        }
        protected void GridViewPayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
                int quantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"));
                decimal totalAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
                // Update the footer totals
                totalQuantity += quantity;
                totalAmountSum += totalAmount;
            }
            // Check if the row is a footer row to display the totals
            if (e.Row.RowType == DataControlRowType.Footer)
            {                
                Label lblFooterQuantity = (Label)e.Row.FindControl("lblFooterQuantity");
                Label lblFooterAmount = (Label)e.Row.FindControl("lblFooterAmount");
               
                lblFooterQuantity.Text = totalQuantity.ToString();
                lblFooterAmount.Text = totalAmountSum.ToString();
                Session["Amount"] = totalAmountSum.ToString(); 
            }
        }

      

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {                
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int reportTypeColumnIndex = 7;
                    TableCell reportTypeCell = e.Row.Cells[reportTypeColumnIndex];
                    Label lblTypeOf = (Label)e.Row.FindControl("lblCategory");
                    LinkButton linkButton = (LinkButton)e.Row.FindControl("LnkInovoice");
                    LinkButton LinkButton3 = (LinkButton)e.Row.FindControl("lnkReport");

                    if (reportTypeCell.Text == "Returned")
                    {
                        e.Row.CssClass = "ReturnedRowColor";
                    }
                    if (lblTypeOf.Text.Trim() == "Line")
                    {
                         // linkButton.Visible = false;
                         // LinkButton3.Visible = false;
                    }
                    else
                    {
                        // linkButton.Visible = true;
                        // LinkButton3.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }
        private void getWorkIntimationData()
        {
            id = Session["IntimationId_LiftEscalator"].ToString();
            Session["PendingIntimations"] = id;
            DataSet ds = new DataSet();
            ds = CEI.SiteOwnerInstallations_Lift(id);
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
        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {               
                int liftCount = 0;
                int EscalatorCount = 0;
                string selectedTypess = string.Empty;

                foreach (GridViewRow rows in GridView1.Rows)
                {                   
                    CheckBox chk = (CheckBox)rows.FindControl("CheckBox1");
                   
                    if (chk != null && chk.Checked)
                    {                       
                        Label lblTyps = (Label)rows.FindControl("lblCategory");

                        if (lblTyps.Text.ToLower() == "lift")
                        {
                            liftCount++;
                        }
                        else if (lblTyps.Text.ToLower() == "escalator")
                        {
                            EscalatorCount++;
                        }
                        
                        string type = lblTyps.Text;
                        if (type == "Lift" && !selectedTypess.Contains("4"))
                        {
                            selectedTypess += "4,";
                        }
                        else if (type == "Escalator" && !selectedTypess.Contains("10"))
                        {
                            selectedTypess += "10,";
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
                    //Label lblPremises = (Label)row.FindControl("lblPermises");
                    Label lblApplicantTypeCode = (Label)row.FindControl("lblApplicantTypeCode");
                    Label lblDesignation = (Label)row.FindControl("lblDesignation");
                    Label lblTypeOfPlant = (Label)row.FindControl("LblTypeofPlant");
                    //Label LblSactionLoad = (Label)row.FindControl("LblSactionLoad");
                    Label lblReportType = (Label)row.FindControl("lblReportType");
                    Label lblIntimationId = (Label)row.FindControl("lblIntimationId");
                    Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                    TestReportId = lblTestReportId.Text;
                    
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
                            UploadDocuments.Visible = true;
                        }
                        else
                        {
                            UploadDocuments.Visible = false;
                            TestReportId = null;
                        }
                    }
                    string CreatedBy = Session["SiteOwnerId"].ToString();
                    TotalPayment.Visible = true;
                    ChallanDetail.Visible = true;

                    //Session["SelectedCategory"] = lblCategory.Text;
                    //Session["SelectedVoltageLevel"] = lblVoltageLevel.Text;
                    //Count = lblNoOfInstallations.Text;
                    //Session["SelectedNoOfInstallations"] = lblNoOfInstallations.Text;
                    HdnApplicantType.Value = lblApplicant.Text;                    
                    HdnDivision.Value = lblDivision.Text;
                    HdnDistrict.Value = lblDistrict.Text;
                    
                    //PremisesType = lblPremises.Text;
                    ApplicantTypeCode = lblApplicantTypeCode.Text;
                    Category = lblCategory.Text;
                    
                    if (Session["Duplicacy"].ToString().Trim() == "0")
                    {
                        CEI.DeleteduplicateHistory(lblIntimationId.Text, CreatedBy);
                        Session["Duplicacy"] = "1";
                    }
                    else
                    {

                    }
                    DataTable dt = new DataTable();
                    dt = CEI.GetApplicantCode(lblCategory.Text);
                    if (dt.Rows.Count > 0)
                    {
                        InstallationId = dt.Rows[0]["Id"].ToString();
                    }
                    else
                    {
                    }

                    if (chk.Checked)
                    {
                        CEI.InsertPaymentHistory_Lift(id, int.Parse(lblNoOfInstallations.Text), int.Parse(InstallationId),                           
                            CreatedBy);
                    }                  
                    else
                    {
                        CEI.DeletePaymentHistory(id, int.Parse(lblNoOfInstallations.Text), int.Parse(InstallationId), CreatedBy);
                    }
                    InspectionType = "New";
                    AssigDesignation = lblDesignation.Text;                   
                    UploadDocuments.Visible = true;                   
                    FeesDetails.Visible = true;
                    PaymentDetails.Visible = true;
                    btnSubmit.Visible = true;
                    btnReset.Visible = true;
                    
                    PlantLocationRoofTop = null;
                    PlantLocationGroundMounted = null;
                    GetDocumentUploadData(ApplicantTypeCode,InspectionType, PlantLocationRoofTop, PlantLocationGroundMounted, inspectionIdRes);
                    //Session["InstallationTypeID"] = int.Parse(InstallationId);

                    if (selectedTypess.EndsWith(","))
                    {
                        selectedTypess = selectedTypess.Substring(0, selectedTypess.Length - 1);
                    }
                    PaymentGridViewBind(selectedTypess, liftCount, EscalatorCount);
                    string Installationtypes = string.Empty;
                    //if(liftCount == 1 && EscalatorCount == 1)
                    //{
                    //    Installationtypes = "Lift/Escalator";
                    //}
                    //else
                    
                    if (liftCount == 0 && EscalatorCount == 1)
                    {
                        Installationtypes = "Escalator";
                    }
                    else if (liftCount == 1 && EscalatorCount == 0)
                    {
                        Installationtypes = "Lift";
                    }
                    else if (liftCount > 1)
                    {
                        if (EscalatorCount > 1)
                        {
                            Installationtypes = "Lift/Escalator";
                        }                        
                        else
                        {
                            Installationtypes = "MultiLift";
                        }
                    }
                    else if (EscalatorCount > 1)
                    {
                        if (liftCount > 1)
                        {
                            Installationtypes = "Lift/Escalator";
                        }
                        else
                        {
                            Installationtypes = "MultiEscalator";
                        }                        
                    }                   
                    
                    hdnInstallationType.Value = Installationtypes;

                    GetOtherDetails_ForReturnedInspection(inspectionIdRes);                    
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
                    Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                    if (lblCategory.Text.Trim() == "Lift")
                    {
                        Session["LiftTestReportID"] = lblTestReportId.Text;
                        Response.Redirect("/TestReportModal/LiftTestReportModal.aspx", false);
                    }
                    else if (lblCategory.Text.Trim() == "Escalator")
                    {
                        Session["EscalatorTestReportID"] = lblTestReportId.Text;
                        //Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                    }
                }
            }
            catch (Exception)
            {
            }
        }        
        private string GetDocumentIDFromFileUploadID(string fileUploadID)
        {
            string[] parts = fileUploadID.Split('_');
            if (parts.Length > 1)
            {
                return parts[1];
            }
            return null;
        }
        protected void lnkFile_Click(object sender, EventArgs e)
        {
            string fileName = Session["File"].ToString();
            string folderPath = Server.MapPath(fileName);
            string filePath = Path.Combine(folderPath);

            if (System.IO.File.Exists(filePath))
            {
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else
            {
                string errorMessage = "An error occurred: " + "Loading failed Please try Again later";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
            }
            Session["File"] = "";
        }        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["IntimationId_LiftEscalator"]) != null )
            {
                string CreatedBy = Session["SiteOwnerId"].ToString();
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
                        string lblCategory = string.Empty;
                        
                        if (hdnInstallationType.Value != null && hdnInstallationType.Value != "")
                        {
                            lblCategory = hdnInstallationType.Value;
                        }
                        else
                        {
                            return;
                        }

                        IntimationId = Session["IntimationId_LiftEscalator"].ToString();

                        //string lblApplicant = Session["SelectedApplicant"].ToString().Trim();
                        //string lblVoltageLevel = Session["SelectedVoltageLevel"].ToString().Trim();
                        //string lblDivision = Session["SelectedDivision"].ToString().Trim();
                        //string lblDistrict = Session["SelectedDistrict"].ToString().Trim();

                        string District = HdnDistrict.Value;
                        //string 
                        ApplicantType = HdnApplicantType.Value;
                        string Division = HdnDivision.Value;
                        string transcationId = string.Empty;
                        string TranscationDate = string.Empty;
                        decimal TotalAmount = Convert.ToDecimal(Session["Amount"]);
                        //string StaffAssigned = string.Empty;
                        string Assigned = string.Empty;
                        string InstallationTypeID = string.Empty;

                        //Count = lblNoOfInstallations.Trim();
                        if (ChallanDetail.Visible == true)
                        {
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
                        //StaffAssigned = "XEN";
                        ServiceType = 4;
                        DataSet dsp = new DataSet();
                        dsp = CEI.ToGetStaffIdforPeriodic(Division, "XEN", District);
                        if (dsp.Tables.Count > 0 && dsp.Tables[0].Rows.Count > 0)
                        {
                            Assigned = dsp.Tables[0].Rows[0]["StaffUserId"].ToString();
                        }
                        InstallationTypeID = "10";//Session["InstallationTypeID"].ToString();
                        InsertFilesIntoDatabase(InstallationTypeID, CreatedBy, txtContact.Text, ApplicantTypeCode, IntimationId, ApplicantType, lblCategory.Trim(),
                    District, Division, PaymentMode, txtDate.Text, txtInspectionRemarks.Text.Trim(), CreatedBy, TotalAmount, Assigned, transcationId, TranscationDate, Convert.ToInt32(InspectionIdClientSideCheckedRow.Value),
                    ServiceType);
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
        public void UploadCheckListDocInCollection(string Category, string CreatedByy, string intimationids, string InstallTypes, string InspectionId)
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

                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InspectionId + "/"+ InstallTypes + "/" )))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InspectionId +"/" + InstallTypes + "/"));
                            }

                            string ext = fileUpload.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + CreatedBy + "/" + intimationids + "/"+ InspectionId +"/" + InstallTypes + "/";
                            //string fileName = DocSaveName + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            //string fileName = DocSaveName + "." + ext;
                            string fileName = DocSaveName + ".pdf";

                            string filePathInfo2 = "";

                            filePathInfo2 = Server.MapPath("~/Attachment/" + CreatedBy + "/" + intimationids + "/" + InspectionId +"/" + InstallTypes + "/" + fileName);

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

        public void InsertFilesIntoDatabase(string InstallationTypeID, string para_CreatedBy, string para_txtContact, string para_ApplicantTypeCode, string para_IntimationId, string para_lblApplicant, string para_lblCategory,
             string para_District, string para_To, string para_PaymentMode, string para_txtDate, string para_txtInspectionRemarks, string para_CreatedByy, decimal para_TotalAmount, string para_Assigned, string para_transcationId, string para_TranscationDate, int para_InspectID,
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
                    CEI.InsertInspectionDataNewCode_Lift(para_txtContact, para_ApplicantTypeCode, para_IntimationId, para_lblApplicant, para_lblCategory,
                    para_District, para_To, para_PaymentMode, para_txtDate, para_txtInspectionRemarks, para_CreatedByy, para_TotalAmount, para_Assigned, para_transcationId, para_TranscationDate, para_InspectID, ServiceType, transaction);

                    string generatedIdCombinedDetails = CEI.InspectionId();
                    string[] SplitResultPartsArray = generatedIdCombinedDetails.Split('|');
                    Session["PendingPaymentId"] = SplitResultPartsArray[0];
                    string InspectionId = SplitResultPartsArray[0]; // Extract the first value
                    Session["PrintInspectionID"] = InspectionId;
                    UploadCheckListDocInCollection("MultipleInstallationType", para_CreatedByy, SplitResultPartsArray[1], "MultipleInstallationType", InspectionId);

                    foreach (var file in uploadedFiles)
                    {
                        
                        string query = "sp_InsertInspectionAttachments";

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
                //try
                //{
                //    if (isInsertSuccessful == true)
                //    {
                //        foreach (GridViewRow rows in GridView1.Rows)
                //        {
                //            CheckBox chk = (CheckBox)rows.FindControl("CheckBox1");

                //            if (chk != null && chk.Checked)
                //            {
                //                Label lblIntimationId = (Label)rows.FindControl("lblIntimationId");
                //                Label lblCategorys = (Label)rows.FindControl("lblCategory");
                //                Label lblNoOfInstallation = (Label)rows.FindControl("lblNoOfInstallations");
                //                CEI.UpdateInstallationHistory(lblCategorys.Text, lblIntimationId.Text, para_CreatedBy, int.Parse(lblNoOfInstallation.Text));
                //            }
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                //    return;
                //}
            }
        }
        protected void ddlDocumentFor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }  
        protected void PaymentGridViewBind(string selectedType,int LiftCount,int EscaltorCount)
        {
            try
            {
                
                DataTable dsa = new DataTable();
                dsa = CEI.Payment_Lift(selectedType, LiftCount, EscaltorCount);
                if (dsa.Rows.Count > 0 && dsa != null)
                {
                    GridViewPayment.DataSource = dsa;
                    GridViewPayment.DataBind();
                }
                else
                {
                    GridViewPayment.DataSource = null;
                    GridViewPayment.DataBind();
                    string script = "alert(\"Please Fill the Form first for knowing Payment \");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "serverscript", script, true);
                }
                dsa.Dispose();
            }
            catch (Exception ex)
            {
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
        private void GetDocumentUploadData(string ApplicantType, string InspectionType, string PlantLocationRoofTop, string PlantLocationGroundMounted, int inspectionIdPrm)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetDocumentlistfornewInspection(ApplicantType, 4, InspectionType, PlantLocationRoofTop, PlantLocationGroundMounted, inspectionIdPrm);
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
               
                    //fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
            }
            catch (Exception ex)
            {
                //lblerror.Text = ex.Message.ToString()+"---"+ fileName;
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
                        //customFile.Visible = true;
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
                        //customFile.Visible = false;
                    }
                }
            }
        }
        
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
        private void GetOtherDetails_ForReturnedInspection(int inspectionIdPrm)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            string query = "Sp_GetOtherDetails_ForReturnedInspection";

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
                        if (reader["TransctionDate"] != DBNull.Value)
                        {
                            txttransactionDate.Text = Convert.ToDateTime(reader["TransctionDate"]).ToString("yyyy-MM-dd");
                        }
                        txtInspectionRemarks.Text = reader["InspectionRemarks"].ToString();
                        //txtSaction.Text = reader["SactionVoltage"].ToString();
                        //customFileLocation.Text = reader["DemandDocument"].ToString();
                        //Session["File"] = customFileLocation.Text;
                    }
                    reader.Close();
                }
            }
        }
    }
}