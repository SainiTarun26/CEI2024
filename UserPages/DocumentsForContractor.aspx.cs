using CEI_PRoject;
using CEIHaryana.Contractor;
using iText.Forms.Form.Element;
using iTextSharp.text;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Documents;
using Button = System.Web.UI.WebControls.Button;
using Label = System.Web.UI.WebControls.Label;

namespace CEIHaryana.UserPages
{
    public partial class DocumentsForContractor : System.Web.UI.Page
    {
        //Page settd by neha 18-June-2025
        string REID = string.Empty;
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                    {
                        //Session["TempUniqueId"] = "";
                        string UserID = Session["ContractorID"].ToString();
                        HdnUserId.Value = UserID;

                        DetailsforDocuments(UserID);
                    }
                    else
                    {
                        Response.Redirect("/AdminLogout.aspx", false);
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }

        private void DetailsforDocuments(string userID)
        {
            DataSet ds = CEI.ToGetNewRegisteredContractorDetails(userID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //string Age = ds.Tables[0].Rows[0]["AgeInYears"].ToString();
                object valueAge = ds.Tables[0].Rows[0]["AgeInYears"];
                int Age = valueAge != DBNull.Value ? Convert.ToInt32(valueAge) : 0;
                object value = ds.Tables[0].Rows[0]["StyleOfCompanyID"];
                int CompanyType = value != DBNull.Value ? Convert.ToInt32(value) : 0;
                // HdnAge.Value = Age;
                HdnAge.Value = Age.ToString();
                HdnTypeOfCompany.Value = CompanyType.ToString();
                GetGridtoUploadDocuments(userID, CompanyType, Age);
            }

            else
            {
                Response.Redirect("/AdminLogout.aspx", false);
            }
            //int ageValue;
            //if (int.TryParse(HdnAge.Value, out ageValue))
            //{
            //    if (ageValue > 55)
            //    {
            //        Medicalfitness.Visible = true;
            //        Hdn_medicalcertificatevisible.Value = "yes";
            //    }
            //    else
            //    {
            //        Medicalfitness.Visible = false;
            //        Hdn_medicalcertificatevisible.Value = "";
            //    }
            //}
        }

        private void GetGridtoUploadDocuments(string userID, int companyType, int age)
        {
            DataTable dt = CEI.GetGridtoUploadDocuments(userID, companyType, age);
            if (dt.Rows.Count > 0)
            {
                Grd_Document.DataSource = dt;
                Grd_Document.DataBind();
            }
            else
            {
                Grd_Document.DataSource = null;
                Grd_Document.DataBind();
                string script = "alert(\"No Record Found for document \");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            dt.Dispose();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
                {
                    CEI.BackToEditDetailsOfNewRegisteredUser(HdnUserId.Value);
                    Response.Redirect("/UserPages/Update_Contractor_Application_Form.aspx", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('There is an issue in Edit!!!')", true);
                }
            }
            catch
            {
                Response.Redirect("/AdminLogout.aspx");
            }
        }

        protected void btn_Preview_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UserPages/Contractor_Registration_Details.aspx", false);
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
            {
                if (HdnUserId.Value == Convert.ToString(Session["ContractorID"]))
                {

                    int CmpnyTypeNAme = Convert.ToInt32(HdnTypeOfCompany.Value);
                    int AgeContractor = Convert.ToInt32(HdnAge.Value);
                    GetGridtoUploadDocuments(HdnUserId.Value, CmpnyTypeNAme, AgeContractor);

                    bool allRequiredDocsUploaded = true;

                    foreach (GridViewRow row in Grd_Document.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField hdnReq = row.FindControl("Req") as HiddenField;
                            HiddenField hdnDocExist = row.FindControl("DocumentExist") as HiddenField;
                            HiddenField hdnRowIdForExistingDoc = row.FindControl("RowIdForExistingDoc") as HiddenField;

                            if (hdnReq == null || hdnDocExist == null || hdnRowIdForExistingDoc == null)
                            {
                                allRequiredDocsUploaded = false;
                                break;
                            }

                            if (hdnReq.Value == "1")
                            {
                                if (hdnDocExist.Value != "1" || string.IsNullOrWhiteSpace(hdnRowIdForExistingDoc.Value))
                                {
                                    allRequiredDocsUploaded = false;
                                    break;
                                }
                            }
                        }
                    }

                    if (!allRequiredDocsUploaded)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please upload all mandatory documents before proceeding.');", true);
                        return;
                    }

                    int TotalAmount = 2520;
                    CEI.InsertContChallanDetails(TotalAmount, txtGRNNO.Text, txttransactionDate.Text, HdnUserId.Value);

                    Response.Redirect("/UserPages/Contractor_Declaration.aspx", false);

                }
                else
                {
                    Response.Redirect("/AdminLogout.aspx", false);
                }
            }
            else
            {
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/AdminLogout.aspx", false);
        }

        protected void Grd_Document_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnDocumentExist = (HiddenField)e.Row.FindControl("DocumentExist");
                HiddenField hdnSaveDocumentID = (HiddenField)e.Row.FindControl("SaveDocumentID");

                LinkButton btnTick = (LinkButton)e.Row.FindControl("btnTick");
                LinkButton btnCross = (LinkButton)e.Row.FindControl("btnCross");
                FileUpload fileUpload = (FileUpload)e.Row.FindControl("FileUpload1");
                Button btnUpload = (Button)e.Row.FindControl("btnUpload");

                if (hdnDocumentExist != null)
                {
                    bool documentExists = hdnDocumentExist.Value == "1";

                    // Show/Hide tick and cross buttons
                    if (btnTick != null) btnTick.Visible = documentExists;
                    if (btnCross != null) btnCross.Visible = documentExists;

                    // Hide FileUpload and Upload button if document exists
                    if (fileUpload != null) fileUpload.Visible = !documentExists;
                    if (btnUpload != null) btnUpload.Visible = !documentExists;
                    if (documentExists && hdnSaveDocumentID != null)
                    {
                        hdnSaveDocumentID.Value = "0";
                    }
                }
                else
                {
                    if (btnTick != null) btnTick.Visible = false;
                    if (btnCross != null) btnCross.Visible = false;

                    if (fileUpload != null) fileUpload.Visible = true;
                    if (btnUpload != null) btnUpload.Visible = true;
                    if (hdnSaveDocumentID != null)
                    {
                        hdnSaveDocumentID.Value = "1";
                    }
                }
            }
        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Button btnUpload = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpload.NamingContainer;

            FileUpload fileUpload = row.FindControl("FileUpload1") as FileUpload;
            LinkButton btnTick = row.FindControl("btnTick") as LinkButton;
            LinkButton btnCross = row.FindControl("btnCross") as LinkButton;
            Label lblInstruction = row.FindControl("lblInstruction") as Label;

            if (fileUpload == null || !fileUpload.HasFile)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select a file.');", true);
                return;
            }

            int rowIndex = row.RowIndex;

            // ✅ Fetch values from DataKeys
            int documentId = Convert.ToInt32(Grd_Document.DataKeys[rowIndex]["DocumentID"]);
            string documentName = Grd_Document.DataKeys[rowIndex]["DocumentName"].ToString();
            string documentShortName = Grd_Document.DataKeys[rowIndex]["DocumentShortName"].ToString();

            try
            {
                string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();
                int fileSize = fileUpload.PostedFile.ContentLength;

                // ✅ Validation
                if (fileSize > 1048576)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('File must be under 1MB.');", true);
                    return;
                }

                if (documentId == 31 || documentId == 32)
                {
                    if (!(fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Only image files allowed.');", true);
                        return;
                    }
                }
                else
                {
                    if (fileExtension != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Only PDF files allowed.');", true);
                        return;
                    }
                }

                string CreatedBy = Convert.ToString(Session["ContractorID"] ?? "TestUser");
                string safeDocumentName = MakeSafeFileName(documentShortName);
                string safeCreatedBy = MakeSafeFileName(CreatedBy);

                string directoryPath = Server.MapPath($"~/Attachment/License_Documents/{safeCreatedBy}/{safeDocumentName}/");
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                string fileName = $"{safeDocumentName}_{DateTime.Now:yyyyMMddHHmmssFFF}{fileExtension}";
                string fullPath = Path.Combine(directoryPath, fileName);

                fileUpload.SaveAs(fullPath);
                string dbPath = $"/Attachment/License_Documents/{safeCreatedBy}/{safeDocumentName}/{fileName}";

                // Save to database
                string Utrn = txtGRNNO.Text;  // if available
                string challandate = txttransactionDate.Text;

                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        CEI.InsertDocumentOfNewUserApplicationContractor(
                            documentName, documentId.ToString(), fileName, dbPath,
                            Utrn, challandate, CreatedBy, transaction
                        );
                        transaction.Commit();
                    }
                    catch (Exception dbEx)
                    {
                        transaction.Rollback();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('DB error: {dbEx.Message}');", true);
                        return;
                    }
                }

                // ✅ Update UI
                if (btnTick != null) btnTick.Visible = true;
                if (btnCross != null) btnCross.Visible = true;
                if (fileUpload != null) fileUpload.Visible = false;
                if (lblInstruction != null) lblInstruction.Visible = false;
                if (btnUpload != null) btnUpload.Visible = false;

                //if (hdnSaveDocumentID != null)
                //    hdnSaveDocumentID.Value = "1";

                DataTable dt = ViewState["DocumentData"] as DataTable;
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DocumentID"].ToString() == documentId.ToString())
                        {
                            dr["SaveDocumentID"] = "1";
                            break;
                        }
                    }
                    ViewState["DocumentData"] = dt;
                }

                ////btnNext.Visible = AllDocumentsUploaded();
                int CompanyTypeNAme = Convert.ToInt32(HdnTypeOfCompany.Value);
                int AgeOfCon = Convert.ToInt32(HdnAge.Value);
                GetGridtoUploadDocuments(HdnUserId.Value, CompanyTypeNAme, AgeOfCon);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Upload error: {ex.Message}');", true);
            }
        }


        private string MakeSafeFileName(string input)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                input = input.Replace(c, '_');
            }
            return input;
        }
        protected void Grd_Document_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Company = Convert.ToInt32(HdnTypeOfCompany.Value);
            int ContAge = Convert.ToInt32(HdnAge.Value);

            if (e.CommandName == "CustomDelete")
            {
                string docId = e.CommandArgument.ToString();

                if (!string.IsNullOrEmpty(docId))
                {
                    CEI.DeleteNewConDocumentById(Convert.ToInt32(docId));
                }
            }
            GetGridtoUploadDocuments(HdnUserId.Value, Company, ContAge);
        }
    }
}