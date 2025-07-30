using CEI_PRoject;
using CEIHaryana.Contractor;
using iText.Forms.Form.Element;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Button = System.Web.UI.WebControls.Button;

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
                        string UserID = Session["ContractorID"].ToString();
                        HdnUserId.Value = UserID;

                        DetailsforDocuments(UserID);
                    }
                    else
                    {
                        Response.Redirect("/LogOut.aspx", false);
                    }
                }
              
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        private void DetailsforDocuments(string userID)
        {
            DataSet ds = CEI.ToGetNewUserDetails(userID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string Age = ds.Tables[0].Rows[0]["AgeInYears"].ToString();
                HdnAge.Value = Age;
            }
            else
            {
            }
            int ageValue;
            if (int.TryParse(HdnAge.Value, out ageValue))
            {
                if (ageValue > 55)
                {
                    Medicalfitness.Visible = true;
                    Hdn_medicalcertificatevisible.Value = "yes";
                }
                else
                {
                    Medicalfitness.Visible = false;
                    Hdn_medicalcertificatevisible.Value = "";
                }
            }
        }

        private string SaveDocumentWithTransaction(FileUpload fileUpload, Button uploadbutton, int DocumentId, LinkButton deleteButton, LinkButton tickButton, string documentName, string Utrn, string challandate)
        {
            string fileName = ""; string dbPath = ""; string fullPath = "";

            string CreatedBy = Convert.ToString(HdnUserId.Value);
            long TempUniqueId = (long)Session["TempUniqueId"];
            string DocumentNametoSave = documentName.Replace(" ", "_").Replace("/", "_");

            if (!fileUpload.HasFile || !IsValidPdf(fileUpload))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UploadError", "alert('Please upload a valid PDF file (Max: 1MB)');", true);
                fileUpload.Focus();
                return null;
            }
            // Ensure directory exists
            string directoryPath = Server.MapPath($"~/Attachment/License_Documents/{TempUniqueId}/{CreatedBy}/");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            // Generate file path and name
            fileName = $"{DocumentNametoSave}_{DateTime.Now:yyyyMMddHHmmssFFF}.pdf";
            dbPath = $"/Attachment/License_Documents/{TempUniqueId}/{CreatedBy}/{fileName}";
            fullPath = Path.Combine(directoryPath, fileName);

            // Save the uploaded file to the server folder
            fileUpload.SaveAs(fullPath);
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    string documentId = CEI.InsertDocumentOfNewUserApplication(TempUniqueId, documentName, DocumentId, fileName, dbPath, Utrn, challandate, CreatedBy, transaction);
                    if (!string.IsNullOrEmpty(documentId))
                    {
                        deleteButton.CommandArgument = documentId;
                        fileUpload.Visible = false;
                        uploadbutton.Visible = false;
                        deleteButton.Visible = true;
                        tickButton.Visible = true;
                        transaction.Commit();
                        return documentId;
                    }
                    else
                    {
                        transaction.Rollback();
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    string errorMessage = ex.Message.Replace("'", "\\'");
                    ScriptManager.RegisterStartupScript(this, GetType(), "erroralert", $"alert('{errorMessage}')", true);
                    return null;
                }
                finally
                {
                    transaction?.Dispose();
                    connection.Close();
                }
            }
        }

        private bool IsValidPdf(FileUpload fileUpload)
        {
            if (!fileUpload.HasFile)
            {
                return false;
            }
            if (Path.GetExtension(fileUpload.FileName).ToLower() != ".pdf")
            {
                return false;
            }
            if (fileUpload.PostedFile.ContentLength > 1048576)   // Check file size (1 MB = 1048576 bytes)
            {
                return false;
            }
            return true;
        }

        private bool IsSessionValid()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(HdnUserId.Value)))
            {
                if (string.IsNullOrEmpty(Convert.ToString(Session["TempUniqueId"])))
                {
                    GenerateUniqueTempId();
                }
                return true;
            }
            return false;
        }

        private void GenerateUniqueTempId()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1000000000, int.MaxValue);
            string currentDate = DateTime.Now.ToString("ddMMyyyy");

            string combined = randomNumber.ToString() + currentDate; // "127878893816042025"
            long finalNumber = long.Parse(combined); // Convert to long
            Session["TempUniqueId"] = finalNumber;
        }

        private bool DeleteDocumentWithTransaction(int documentId, LinkButton deleteButton, LinkButton tickButton, FileUpload fileUpload, Button uploadButton)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    string documentPath = null;
                    using (SqlCommand cmd = new SqlCommand("sp_GetDocumentPathOfNewUser", connection, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DocumentId", documentId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            documentPath = result.ToString();
                        }
                    }
                    // Delete from the database
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteDocumentOfNewUser", connection, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DocumentId", documentId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    // Delete from the server
                    if (!string.IsNullOrEmpty(documentPath))
                    {
                        string fullPath = Server.MapPath(documentPath);
                        if (File.Exists(fullPath))
                        {
                            File.Delete(fullPath);
                        }
                    }
                    transaction.Commit();
                    // Reset UI Elements
                    fileUpload.Visible = true;
                    uploadButton.Visible = true;
                    deleteButton.Visible = false;
                    tickButton.Visible = false;
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    string errorMessage = ex.Message.Replace("'", "\\'");
                    ScriptManager.RegisterStartupScript(this, GetType(), "erroralert", $"alert('{errorMessage}')", true);
                    return false;
                }
                finally
                {
                    transaction?.Dispose();
                    connection.Close();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsSessionValid())
            {
                string Result = SaveDocumentWithTransaction(FileUpload1, Button1, 44, lnkbtn_Delete1, lnkbtn_Save1, "Last Three Year Income Tax Returns and Balance Sheet", null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document1.Value = "1";
                    lnkbtn_Delete1.Visible = true;
                    lnkbtn_Save1.Visible = true;
                    text1.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void lnkbtn_Delete1_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
                bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete1, lnkbtn_Save1, FileUpload1, Button1);
                if (IsDelete)
                {
                    HdnField_Document1.Value = "0";
                    text1.Visible = true;
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsSessionValid())
            {
                if (ddlIdproof.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Validation", "alert('First Select the Id proof you want to Upload');", true);
                    return;
                }

                string selectedIdProof = ddlIdproof.SelectedItem.Text;
                string Result = SaveDocumentWithTransaction(FileUpload2, Button2, 33, lnkbtn_Delete2, lnkbtn_Save2, selectedIdProof , null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document2.Value = "1";
                    lnkbtn_Delete2.Visible = true;
                    lnkbtn_Save2.Visible = true;
                    text2.Visible = false;
                    ddlIdproof.Enabled = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void lnkbtn_Delete2_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
                bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete2, lnkbtn_Save2, FileUpload2, Button2);
                if (IsDelete)
                {
                    HdnField_Document2.Value = "0";
                    ddlIdproof.Enabled = true;
                    text2.Visible = true;
                    ddlIdproof.SelectedIndex = 0;
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (IsSessionValid())
            {
                string Result = SaveDocumentWithTransaction(FileUpload3, Button3, 43, lnkbtn_Delete3, lnkbtn_Save3, "Calibration Certificate from NABL or Government testing laboratory respect of electrical equipment’s invoices", null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document3.Value = "1";
                    lnkbtn_Delete3.Visible = true;
                    lnkbtn_Save3.Visible = true;
                    text3.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void lnkbtn_Delete3_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
                bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete3, lnkbtn_Save3, FileUpload3, Button3);
                if (IsDelete)
                {
                    HdnField_Document3.Value = "0";
                    text3.Visible = true;
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (IsSessionValid())
            {
                string Result = SaveDocumentWithTransaction(FileUpload4, Button4, 42, lnkbtn_Delete4, lnkbtn_Save4, "Copy of Annexure 3 & 5", null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document4.Value = "1";
                    lnkbtn_Delete4.Visible = true;
                    lnkbtn_Save4.Visible = true;
                    text4.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void lnkbtn_Delete4_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
                bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete4, lnkbtn_Save4, FileUpload4, Button4);
                if (IsDelete)
                {
                    HdnField_Document4.Value = "0";
                    text4.Visible = true;
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (IsSessionValid())
            {
                string Result = SaveDocumentWithTransaction(FileUpload5, Button5, 38, lnkbtn_Delete5, lnkbtn_Save5, "Medical fitness certificate from Government/Government approved Hospital in case he is above 55 years of age on the date of submission of application", null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document5.Value = "1";
                    lnkbtn_Delete5.Visible = true;
                    lnkbtn_Save5.Visible = true;
                    text5.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void lnkbtn_Delete5_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
                bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete5, lnkbtn_Save5, FileUpload5, Button5);
                if (IsDelete)
                {
                    HdnField_Document5.Value = "0";
                    text5.Visible = true;
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (IsSessionValid())
            {
                if (string.IsNullOrWhiteSpace(txtUtrNo.Text) || string.IsNullOrWhiteSpace(txtdate.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Validation", "alert('UTR No. and Date are required.');", true);
                    return;
                }
                string Result = SaveDocumentWithTransaction(FileUpload6, Button6, 40, lnkbtn_Delete6, lnkbtn_Save6, "Copy of treasury challan of fees deposited in any treasury of Haryana", txtUtrNo.Text, txtdate.Text);
                if (Result != null && Result != "")
                {
                    HdnField_Document6.Value = "1";
                    lnkbtn_Delete6.Visible = true;
                    lnkbtn_Save6.Visible = true;
                    txtdate.ReadOnly = true;
                    txtUtrNo.ReadOnly = true;
                    text6.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void lnkbtn_Delete6_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
                bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete6, lnkbtn_Save6, FileUpload6, Button6);
                if (IsDelete)
                {
                    HdnField_Document6.Value = "0";
                    txtdate.ReadOnly = false;
                    txtUtrNo.ReadOnly = false;
                    text6.Visible = true;
                    txtdate.Text = "";
                    txtUtrNo.Text = "";
                }
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(HdnUserId.Value) != null && Convert.ToString(HdnUserId.Value) != "")
                {
                    if (Convert.ToString(Session["TempUniqueId"]) != null && Convert.ToString(Session["TempUniqueId"]) != "")
                    {
                        //if (chkDeclaration.Checked == true)
                        //{
                            bool allMandatoryUploaded = true;
                            string errorMessage = "";
                            if (HdnField_Document1.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Last Three Year Income Tax Returns and Balance Sheet.<br>"; }
                            if (HdnField_Document2.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Id proof.<br>"; }
                            if (HdnField_Document3.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Calibration Certificate from NABL or Government testing laboratory respect of electrical equipment’s invoices.<br>"; }
                            if (HdnField_Document4.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Copy of Annexure 3 & 5.<br>"; }
                            if (Convert.ToString(Hdn_medicalcertificatevisible.Value) == "yes" && Convert.ToString(Hdn_medicalcertificatevisible.Value) != "")
                            {
                                if (HdnField_Document5.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Medical fitness certificate (for age > 55).<br>"; }
                            }
                            if (HdnField_Document6.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Copy of treasury challan of fees deposited in any treasury of Haryana.<br>"; }
                            if (HdnField_Document7.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Candidate Image.<br>"; }
                            if (HdnField_Document8.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload Candidate Signature.<br>"; }
                            //if (HdnField_Document9.Value != "1") { allMandatoryUploaded = false; errorMessage += "Please Upload blue prints Drawing.<br>"; }

                            if (!allMandatoryUploaded)
                            {
                                string[] lines = errorMessage.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);
                                string formattedMessage = "";
                                for (int i = 0; i < lines.Length; i++)
                                {
                                    formattedMessage += $"{i + 1}. {lines[i].Trim()}\\n";
                                }

                                string script = $"alert('{formattedMessage}');";
                                ClientScript.RegisterStartupScript(this.GetType(), "alertMessage", script, true);

                                return;
                            }

                            Response.Redirect("/UserPages/Contractor_Declaration.aspx", false);

                            //string UniqueNumber = Session["TempUniqueId"].ToString().Trim();
                            //if (Convert.ToString(UniqueNumber) != null && Convert.ToString(UniqueNumber) != "")
                            //{
                            //    CEI.ToSaveDocumentsdataofNewregistration(UniqueNumber, HdnUserId.Value, "Contractor");
                            //    Session["TempUniqueId"] = "";
                            //    Session["TempUniqueId"] = null;
                            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "if (confirm('New User Registration Process completed successfully.')) { window.location.href = '/Login.aspx'; }", true);
                            //}
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Please accept declaration first to proceed.')", true);
                        //}
                    }
                    else
                    {
                        Response.Redirect("/LogOut.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("/LogOut.aspx", false);
                }
            }
            catch (Exception)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/Login.aspx");
        }

        private string SaveDocumentWithTransactionIfPhoto(FileUpload fileUpload, Button uploadbutton, int DocumentId, LinkButton deleteButton, string documentName, string Utrn, string challandate)
        {
            string fileName = ""; string dbPath = ""; string fullPath = "";

            string CreatedBy = Convert.ToString(HdnUserId.Value);
            long TempUniqueId = (long)Session["TempUniqueId"];
            string DocumentNametoSave = documentName.Replace(" ", "_").Replace("/", "_");

            if (!fileUpload.HasFile || !IsValidPhoto(fileUpload))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UploadError", "alert('Please upload a valid image file (.jpg, .jpeg, .png) (Max: 1MB)');", true);
                fileUpload.Focus();
                return null;
            }

            // Ensure directory exists
            string directoryPath = Server.MapPath($"~/Attachment/License_Documents/{TempUniqueId}/{CreatedBy}/");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Get extension and generate file name accordingly
            string extension = Path.GetExtension(fileUpload.FileName).ToLower();
            fileName = $"{DocumentNametoSave}_{DateTime.Now:yyyyMMddHHmmssFFF}{extension}";
            dbPath = $"/Attachment/License_Documents/{TempUniqueId}/{CreatedBy}/{fileName}";
            fullPath = Path.Combine(directoryPath, fileName);

            // Save image file
            fileUpload.SaveAs(fullPath);

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    string documentId = CEI.InsertDocumentOfNewUserApplication(TempUniqueId, documentName, DocumentId, fileName, dbPath, Utrn, challandate, CreatedBy, transaction);
                    if (!string.IsNullOrEmpty(documentId))
                    {
                        deleteButton.CommandArgument = documentId;
                        fileUpload.Visible = false;
                        uploadbutton.Visible = false;
                        deleteButton.Visible = true;
                        //tickButton.Visible = true;
                        transaction.Commit();
                        return documentId;
                    }
                    else
                    {
                        transaction.Rollback();
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    string errorMessage = ex.Message.Replace("'", "\\'");
                    ScriptManager.RegisterStartupScript(this, GetType(), "erroralert", $"alert('{errorMessage}')", true);
                    return null;
                }
                finally
                {
                    transaction?.Dispose();
                    connection.Close();
                }
            }
        }

        private bool IsValidPhoto(FileUpload fileUpload)
        {
            if (!fileUpload.HasFile) return false;

            string ext = Path.GetExtension(fileUpload.FileName).ToLower();
            if (ext != ".jpg" && ext != ".jpeg" && ext != ".png") return false;

            if (fileUpload.PostedFile.ContentLength > 1048576) return false; // 1MB

            return true;
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            if (IsSessionValid())
            {
                string Result = SaveDocumentWithTransactionIfPhoto(FileUpload7, Button7, 31, lnkbtn_Delete7, "Candidate Image", null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document7.Value = "1";
                    lnkbtn_Delete7.Visible = true;
                    lnkbtn_Save7.Visible = true;
                    text7.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void lnkbtn_Delete7_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
                bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete7, lnkbtn_Save7, FileUpload7, Button7);
                if (IsDelete)
                {
                    HdnField_Document7.Value = "0";
                    text7.Visible = true;
                }
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if (IsSessionValid())
            {
                string Result = SaveDocumentWithTransactionIfPhoto(FileUpload8, Button8, 32, lnkbtn_Delete8, "Candidate Signature", null, null);
                if (Result != null && Result != "")
                {
                    HdnField_Document8.Value = "1";
                    lnkbtn_Delete8.Visible = true;
                    lnkbtn_Save8.Visible = true;
                    text8.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void lnkbtn_Delete8_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
                bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete8, lnkbtn_Save8, FileUpload8, Button8);
                if (IsDelete)
                {
                    HdnField_Document8.Value = "0";
                    text8.Visible = true;
                }
            }
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
                Response.Redirect("/LogOut.aspx");
            }
        }

        //protected void Button9_Click(object sender, EventArgs e)
        //{
        //    if (IsSessionValid())
        //    {
        //        string Result = SaveDocumentWithTransaction(FileUpload9, Button9, 9, lnkbtn_Delete9, lnkbtn_Save9, "Whether blue prints is available", null, null);
        //        if (Result != null && Result != "")
        //        {
        //            HdnField_Document9.Value = "1";
        //            lnkbtn_Delete9.Visible = true;
        //            lnkbtn_Save9.Visible = true;
        //        }
        //    }
        //    else
        //    {
        //        Response.Redirect("/LogOut.aspx", false);
        //    }
        //}

        //protected void lnkbtn_Delete9_Click(object sender, EventArgs e)
        //{
        //    LinkButton btn = (LinkButton)sender;
        //    int fileId = Convert.ToInt32(btn.CommandArgument);
        //    if (fileId != 0)
        //    {
        //        bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkbtn_Delete9, lnkbtn_Save9, FileUpload9, Button9);
        //        if (IsDelete)
        //        {
        //            HdnField_Document9.Value = "0";
        //        }
        //    }
        //}
    }
}