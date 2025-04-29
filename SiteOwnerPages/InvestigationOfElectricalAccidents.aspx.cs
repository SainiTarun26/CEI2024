using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iTextSharp.text.pdf.PdfDocument;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class InvestigationOfElectricalAccidents : System.Web.UI.Page
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
                        //AnimalGridViewBind("Accident_1818587168");
                        string UserId = Convert.ToString(Session["SiteOwnerId"]);
                        HdnUser.Value = UserId;
                        GetDetails(UserId);
                        BindDistrict();
                        ddlLoadBindVoltage();
                        Page.Session["FlagHuman"] = 0;
                        Page.Session["FlagAnimal"] = 0;
                    }
                    else
                    {                        
                        Response.Redirect("~/LogOut.aspx", false);
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("~/LogOut.aspx", false);
            }
        }

        private void GetDetails(string UserId)
        {
            if (!string.IsNullOrEmpty(UserId))
            {
                               
                    DataSet ds = new DataSet();
                    ds = CEI.GetDataAtSiteOwnerPowerutility(UserId);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtUtility.Text = ds.Tables[0].Rows[0]["UtilityName"].ToString();
                        txtZone.Text = ds.Tables[0].Rows[0]["ZoneName"].ToString();
                        txtCircle.Text = ds.Tables[0].Rows[0]["CircleName"].ToString();
                        txtDivision.Text = ds.Tables[0].Rows[0]["DivisionName"].ToString();
                        txtSubdivision.Text = ds.Tables[0].Rows[0]["SubDivision"].ToString();
                    }                
                   else
                   {
                       Response.Redirect("/SiteOwnerLogout.aspx", false);
                   }
            }
            else
            {
                //Response.Redirect("/login.aspx", false);
                Response.Redirect("/SiteOwnerLogout.aspx", false);
            }
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
            catch (Exception ex) { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
            {
            //    if (Convert.ToString(Session["TempUniqueId"]) == null || Convert.ToString(Session["TempUniqueId"]) == "")
            //    {
            //        GenerateUniqueTempId();
            //    }
                if (Convert.ToString(Session["TempUniqueId"]) != null && Convert.ToString(Session["TempUniqueId"]) != "")
                {             
                    //hdnFieldGridView
                    if(hdnFieldGridView.Value != "1" && hdnFieldGridView.Value != "2")
                    {
                         ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                        "alert('Please add Animal/Human Details before submiting the form');", true);
                       return;
                    }

                    #region document validation
                    bool allMandatoryUploaded = true;
                    bool allReasonsProvided = true;
                    string errorMessage = "";                   
                    // Check mandatory documents
                    if(HdnField_Document1.Value != "1") { allMandatoryUploaded = false; errorMessage += "Form A is required.<br>"; }                            
                    if(HdnField_Document2.Value != "1") { allMandatoryUploaded = false; errorMessage += "Investigation/Narrative report of concerned Xen is required.<br>"; }
                    if(HdnField_Document3.Value != "1") { allMandatoryUploaded = false; errorMessage += "Details Investigation/Narrative report of the concerned SDO is required.<br>"; }
                    if(HdnField_Document4.Value != "1" && RadioButtonList4.SelectedValue =="0")  { allMandatoryUploaded = false; errorMessage += "Statements of the concerned JE/ALM/LM/AFM/FM is required.<br>"; }
                    if(HdnField_Document5.Value != "1" && RadioButtonList5.SelectedValue == "0") { allMandatoryUploaded = false; errorMessage += "Statement of eyewitness is required.<br>"; }
                    if(HdnField_Document6.Value != "1" && RadioButtonList6.SelectedValue == "0") { allMandatoryUploaded = false; errorMessage += "Post-mortem report/Medical report is required.<br>"; }
                    if(HdnField_Document7.Value != "1" && RadioButtonList7.SelectedValue == "0") { allMandatoryUploaded = false; errorMessage += "FIR is required.<br>"; }                    
                    if(HdnField_Document8.Value != "1" && RadioButtonList8.SelectedValue == "0") { allMandatoryUploaded = false; errorMessage += "Sketch of accidental site.<br>"; }
                    if(HdnField_Document9.Value != "1" && RadioButtonList9.SelectedValue == "0") { allMandatoryUploaded = false; errorMessage += "Photographs of accidental site.<br>"; }
                    //if (HdnField_Document10.Value == "1"){ allMandatoryUploaded = false; errorMessage += "Other document.<br>"; }
                    //Check non-mandatory documents (if 'No' is selected, reason must be provided)

                    if (RadioButtonList4.SelectedValue == "1" && (string.IsNullOrEmpty(txtReason4.Text) || HdnField_Document4.Value != "1"))
                    {
                        allReasonsProvided = false;
                        errorMessage += "Reason for not uploading Statement of eyewitness is required.<br>";
                    }
                    if (RadioButtonList5.SelectedValue == "1" && (string.IsNullOrEmpty(txtReason5.Text)|| HdnField_Document5.Value != "1"))
                    {
                        allReasonsProvided = false;
                        errorMessage += "Reason for not uploading Post-mortem report is required.<br>";
                    }
                    if (RadioButtonList6.SelectedValue == "1" && (string.IsNullOrEmpty(txtReason6.Text) || HdnField_Document6.Value != "1"))
                    {
                        allReasonsProvided = false;
                        errorMessage += "Reason for not uploading FIR is required.<br>";
                    }
                    if (RadioButtonList7.SelectedValue == "1" && string.IsNullOrEmpty(txtReason7.Text) && HdnField_Document7.Value != "1")
                    {
                        allReasonsProvided = false;
                        errorMessage += "Reason for not uploading Sketch of accidental site is required.<br>";
                    }
                    if (RadioButtonList8.SelectedValue == "1" && string.IsNullOrEmpty(txtReason8.Text) && HdnField_Document8.Value != "1")
                    {
                        allReasonsProvided = false;
                        errorMessage += "Reason for not uploading Other documents is required.<br>";
                    }
                    if (RadioButtonList9.SelectedValue == "1" && string.IsNullOrEmpty(txtReason9.Text) && HdnField_Document9.Value != "1") 
                    {   
                        allReasonsProvided = false;
                        errorMessage += "Reason for not uploading Other documents is required.<br>";
                    }

                    if (!allMandatoryUploaded || !allReasonsProvided)
                    {
                        //lblError.Text = errorMessage;
                        //lblError.ForeColor = System.Drawing.Color.Red;
                        //return;
                        // Add validation error messages dynamically
                        CustomValidator customValidator = new CustomValidator
                        {
                            IsValid = false,
                            ErrorMessage = errorMessage,
                            Display = ValidatorDisplay.None
                        };
                        Page.Validators.Add(customValidator);
                        return;
                    }

                    #endregion

                    int ComponentId = 0; // Convert.ToInt32(HdnField_PopUp_InstallationId.Value);                    

                    if (!string.IsNullOrWhiteSpace(HdnField_PopUp_InstallationId.Value))
                    {
                        bool isValid = int.TryParse(HdnField_PopUp_InstallationId.Value.Trim(), out ComponentId);
                        if (!isValid)
                        {                            
                            ComponentId = 0; // Set a default value
                        }
                    }

                    string district = ddlDistrict.SelectedItem.Text;
                    string Designation = "";
                    string AssignedOfficer = "";
                   
                    if (hdnFieldGridView.Value == "1") //human
                    {
                        foreach (GridViewRow Rows in HumanGridView.Rows)
                        {
                            string type = Rows.Cells[2].Text.Trim(); // 

                            if (type == "Fatal")
                            {
                                Designation = "XEN";
                                break;
                            }
                        }

                        if (Designation != "XEN")
                        {
                            Designation = "AE";
                        }                       
                        
                        DataTable dt = new DataTable();
                        dt = CEI.FetchOfficerFor_Accidental(district, Designation);
                        if (dt == null || dt.Rows.Count < 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "error","alert('please Contact Team');", true);
                            return;
                        }
                        AssignedOfficer = dt.Rows[0]["StaffUserID"].ToString();
                    }
                    else if (hdnFieldGridView.Value == "2" ) //animal
                    {
                        Designation = "JE";
                        DataTable dt = new DataTable();
                        dt = CEI.FetchOfficerFor_Accidental(district, Designation);
                        AssignedOfficer = dt.Rows[0]["StaffUserID"].ToString();
                    }
                    else
                    {
                        return;
                    }

                    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlTransaction transaction = connection.BeginTransaction();
                        try
                        {
                            int x = CEI.InsertAccidentData(txtUtility.Text.Trim(), txtZone.Text.Trim(), txtCircle.Text.Trim(), txtDivision.Text.Trim(),
                                txtSubdivision.Text.Trim(), AssignedOfficer, txtAccidentDate.Text.Trim(), txtAccidentTime.Text.Trim(), ddlDistrict.SelectedItem.Text, txtThana.Text.Trim(),
                                txtTehsil.Text.Trim(), txtVillageCityTown.Text.Trim(), ddlVoltageLevel.SelectedItem.Text, ddlElectricalEquipment.SelectedItem.Text,
                                txtSerialNo.Text.Trim(),txtVoltageLevelAccident.Text.Trim(), ComponentId,
                                //txtOtherCaseElectricalEquipment.Text.Trim(),
                                ddlPremises.SelectedItem.Text, txtOtherPremsesCase.Text.Trim(),
                                Convert.ToString(Session["SiteOwnerId"]), (long)Session["TempUniqueId"], transaction
                                );
                            if (x > 0)
                            {
                                transaction.Commit();
                                Session["TempUniqueId"] = "";
                                Session["TempUniqueId"] = null;
                                Reset();
                                ScriptManager.RegisterStartupScript(this, GetType(), "successful",
                                 "alert('successfully added'); window.location.href = '/SiteOwnerPages/AccidentialHistory_SiteOwner.aspx'; ", true);
                                //Response.Redirect("/SiteOwnerPages/AccidentialHistory_SiteOwner.aspx", false);
                            }
                            else
                            {
                                //return;
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                        }

                    }
                }
            }
            else
            {
                Response.Redirect("~/LogOut.aspx", false);
            }            
        }
        protected void btnAnimalSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {                    
                        if (Convert.ToString(Session["FlagAnimal"]) == "1")
                        {
                        if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                        {
                            if (Convert.ToString(Session["TempUniqueId"]) == null || Convert.ToString(Session["TempUniqueId"]) == "")
                            {
                                GenerateUniqueTempId();
                            }
                            if (Convert.ToString(Session["TempUniqueId"]) != null && Convert.ToString(Session["TempUniqueId"]) != "")
                            {
                                int Number = Convert.ToInt32(txtNumber.Text.Trim());
                                int x = CEI.InsertAnimalData(txtDescriptionAnimal.Text.Trim(), Number, txtOwnerName.Text.Trim(),
                                    txtAddressofOwner.Text.Trim(), ddlFatelTypeAnimal.SelectedItem.ToString(), Convert.ToString(Session["SiteOwnerId"]), (long)Session["TempUniqueId"]
                                    //Convert.ToString(Session["TempUniqueId"])
                                    );
                                if (x > 0)
                                {
                                    hdnFieldGridView.Value = "2";
                                    txtDescriptionAnimal.Text = ""; txtOwnerName.Text = "";
                                    txtAddressofOwner.Text = ""; ddlFatelTypeAnimal.SelectedIndex = 0; txtNumber.Text = "";

                                    ScriptManager.RegisterStartupScript(this, GetType(), "hideModalScript", "hideModal('animalModal');", true);
                                    AnimalGridViewBind(Convert.ToString(Session["TempUniqueId"]));
                                }
                                else
                                {
                                    //return;
                                }
                            }
                        }
                        Session["FlagAnimal"] = 0;
                        }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
        protected void btnHumanSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (Convert.ToString(Session["FlagHuman"]) == "1")
                    {
                        if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                        {

                            if (Convert.ToString(Session["TempUniqueId"]) == null || Convert.ToString(Session["TempUniqueId"]) == "")
                            {
                                GenerateUniqueTempId();
                            }
                            if (Convert.ToString(Session["TempUniqueId"]) != null && Convert.ToString(Session["TempUniqueId"]) != "")
                            {
                                int x = CEI.InsertHumanData(txtHumanName.Text.Trim(), txtHumanFatherName.Text.Trim(), ddlGender.SelectedItem.Text == "Select" ? null : ddlGender.SelectedItem.Text,
                                   txtAge.Text.Trim(), ddlFatelNonFatelHuman.SelectedItem.Text == "Select" ? null : ddlFatelNonFatelHuman.SelectedItem.Text, ddlPersonCategory.SelectedItem.Text == "Select" ? null : ddlPersonCategory.SelectedItem.Text,
                                   txtPostalAddress.Text.Trim(), Convert.ToString(Session["SiteOwnerId"]), (long)Session["TempUniqueId"]//Convert.ToInt32(Session["TempUniqueId"])
                                   );
                                if (x > 0)
                                {
                                    hdnFieldGridView.Value = "1";
                                    txtHumanName.Text = ""; txtHumanFatherName.Text = ""; ddlGender.SelectedIndex = 0; ddlPersonCategory.SelectedIndex = 0;
                                    txtAge.Text = ""; ddlFatelNonFatelHuman.SelectedIndex = 0; txtPostalAddress.Text = "";

                                    ScriptManager.RegisterStartupScript(this, GetType(), "hideModalScript", "hideModal('humanModal');", true);
                                    HumanGridViewBind(Convert.ToString(Session["TempUniqueId"]));
                                }
                                else
                                {
                                    //return;
                                }
                            }
                        }
                        Session["FlagHuman"] = "0";
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }            
        }
        public void AnimalGridViewBind(string Id)
        {                   
            DataTable ds = new DataTable();
            ds = CEI.GetDataAnimalAccident(Id);
            if (ds.Rows.Count > 0 && ds != null)
            {
                AnimalGridView.DataSource = ds;
                AnimalGridView.DataBind();              
            }
            else
            {
                AnimalGridView.DataSource = null;
                AnimalGridView.DataBind();              
            }
        }
        public void HumanGridViewBind(string TempId)
        {           
            DataTable ds = new DataTable();
            ds = CEI.GetDataHumanAccident(TempId);
            if (ds.Rows.Count > 0 && ds != null)
            {
                HumanGridView.DataSource = ds;
                HumanGridView.DataBind();
            }
            else
            {
                HumanGridView.DataSource = null;
                HumanGridView.DataBind();
            }
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
        private bool IsSessionValid()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Session["SiteOwnerId"])))
            {
                if (string.IsNullOrEmpty(Convert.ToString(Session["TempUniqueId"])))
                {
                    GenerateUniqueTempId();
                }
                return true;
            }
            return false;
        }
        private bool IsValidPdf(FileUpload fileUpload)
        {
            if (!fileUpload.HasFile)
            {
                return false;
            }           
            if (Path.GetExtension(fileUpload.FileName).ToLower() != ".pdf")  // Check file extension
            {
                return false;
            }           
            if (fileUpload.PostedFile.ContentLength > 1048576)   // Check file size (1 MB = 1048576 bytes)
            {
                return false;
            }
            return true;
        }       
        private string SaveDocumentWithTransaction(FileUpload fileUpload,Button uploadbutton, LinkButton deleteButton, LinkButton tickButton, string documentName,string IsDocumentUpload,string Reason)
        {
            string fileName = ""; string dbPath = ""; string fullPath ="";

            string CreatedBy = Convert.ToString(Session["SiteOwnerId"]);
            //string TempUniqueId = Convert.ToString(Session["TempUniqueId"]);
            long TempUniqueId =(long)Session["TempUniqueId"];

            if (IsDocumentUpload == "Yes")
            {
                if (!fileUpload.HasFile || !IsValidPdf(fileUpload))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                        "alert('Please upload a valid PDF file (Max: 1MB)');", true);
                    fileUpload.Focus();
                    return null;
                }
                // Ensure directory exists
                string directoryPath = Server.MapPath($"~/Attachment/{TempUniqueId}/{CreatedBy}/");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                // Generate file path and name
                fileName = $"{documentName}_{DateTime.Now:yyyyMMddHHmmssFFF}.pdf";
                dbPath = $"/Attachment/{TempUniqueId}/{CreatedBy}/{fileName}";
                fullPath = Path.Combine(directoryPath, fileName);
                //fileUpload.PostedFile.SaveAs(fullPath);
            }
            else
            {
                if (string.IsNullOrEmpty(Reason))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                        "alert('Please Give Reason);", true);                    
                    return null;
                }
            }
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                                                         
                    string documentId = CEI.InsertDocumentData(TempUniqueId, documentName,IsDocumentUpload, Reason, fileName, dbPath, CreatedBy, transaction);
                    if (!string.IsNullOrEmpty(documentId))
                    {                        
                        deleteButton.CommandArgument = documentId; //bind document id for deleting that reocord
                        fileUpload.Visible = false;
                        uploadbutton.Visible = false;
                        deleteButton.Visible = true;
                        tickButton.Visible = true;
                        
                        if (IsDocumentUpload == "Yes")
                        {
                            fileUpload.PostedFile.SaveAs(fullPath);
                        }

                        //throw new Exception("abcd");
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
                    using (SqlCommand cmd = new SqlCommand("SELECT DocumentPath FROM tbl_AcidentDocumentsDetails WHERE Id = @DocumentId", connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@DocumentId", documentId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            documentPath = result.ToString();
                        }
                    }
                    // Delete from the database
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_AcidentDocumentsDetails WHERE Id = @DocumentId", connection, transaction))
                    {
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
                    //throw new Exception("abcd");
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
       
        #region RadioButton
        protected void RadioButtonList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileUpload4.Visible = false;
            lnkBtn_Tick4.Visible = false;
            txtReason4.Visible = false;
            if (RadioButtonList4.SelectedValue == "1")
            {
                FileUpload4.Visible = false;
                lnkBtn_Tick4.Visible = false;
                txtReason4.Visible = true;
            }
            else
            {
                FileUpload4.Visible = true;               
                txtReason4.Visible = false;
            }
        }
        protected void RadioButtonList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RadioButtonList5.Visible = false;
            FileUpload5.Visible = false;
            lnkBtn_Tick5.Visible = false;
            txtReason4.Visible = false;
            if (RadioButtonList5.SelectedValue == "1")
            {
                FileUpload5.Visible = false;
                lnkBtn_Tick5.Visible = false;
                txtReason5.Visible = true;
            }
            else
            {
                FileUpload5.Visible = true;              
                txtReason5.Visible = false;
            }
        }
        protected void RadioButtonList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RadioButtonList5.Visible = false;
            FileUpload5.Visible = false;
            lnkBtn_Tick6.Visible = false;
            txtReason6.Visible = false;
            if (RadioButtonList6.SelectedValue == "1")
            {
                FileUpload6.Visible = false;
                lnkBtn_Tick6.Visible = false;
                txtReason6.Visible = true;
            }
            else
            {
                FileUpload6.Visible = true;
                lnkBtn_Tick6.Visible = true;
            }
        }
        protected void RadioButtonList7_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RadioButtonList5.Visible = false;
            FileUpload7.Visible = false;
            lnkBtn_Tick7.Visible = false;
            if (RadioButtonList7.SelectedValue == "1")
            {
                FileUpload7.Visible = false;
                lnkBtn_Tick7.Visible = false;
                txtReason7.Visible = true;
            }
            else
            {
                FileUpload7.Visible = true;
                txtReason7.Visible = false;
            }
        }
        protected void RadioButtonList8_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RadioButtonList5.Visible = false;
            FileUpload8.Visible = false;
            lnkBtn_Tick8.Visible = false;
            txtReason8.Visible = false;
            if (RadioButtonList8.SelectedValue == "1")
            {
                FileUpload8.Visible = false;
                lnkBtn_Tick8.Visible = false;
                txtReason8.Visible = true;
            }
            else
            {
                FileUpload8.Visible = true;
                txtReason8.Visible = false;                
            }
        }
        protected void RadioButtonList9_SelectedIndexChanged(object sender, EventArgs e)
        {
            // RadioButtonList5.Visible = false;
            FileUpload9.Visible = false;
            lnkBtn_Tick9.Visible = false;
            txtReason9.Visible = false;
            if (RadioButtonList9.SelectedValue == "1")
            {
                FileUpload9.Visible = false;
                lnkBtn_Tick9.Visible = false;
                txtReason9.Visible = true;
            }
            else
            {
                FileUpload9.Visible = true;
                txtReason9.Visible = false;
            }
        }
        protected void RadioButtonList10_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileUpload10.Visible = false;
            lnkBtn_Tick10.Visible = false;
            txtReason10.Visible = false;
            if (RadioButtonList10.SelectedValue == "1")
            {
                FileUpload10.Visible = false;
                lnkBtn_Tick10.Visible = false;
                txtReason10.Visible = true;
            }
            else
            {
                FileUpload10.Visible = true;
                txtReason10.Visible = false;
            }
        }
        #endregion
        #region upload and delete button
        protected void btnupload1_Click(object sender, EventArgs e)
        {
            if (IsSessionValid())
            {
              string Result =  SaveDocumentWithTransaction(FileUpload1, btnupload1, lnkBtnDelete1, lnkBtnTick, "Reporting electrical accidents-Form A","Yes","");
                if (Result != null && Result !="")
                {
                    HdnField_Document1.Value = "1";
                }
            }
            else
            {
                Response.Redirect("/SiteOwnerLogout.aspx", false);
            }         
        }      
        protected void lnkBtnDelete1_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
              bool IsDelete= DeleteDocumentWithTransaction(fileId, lnkBtnDelete1,lnkBtnTick,FileUpload1, btnupload1);
              if (IsDelete)
              {
                  HdnField_Document1.Value = "0";
              }
            }            
            //int x = CEI.DeleteDocumentWithTransaction(int DocumentId,string CreatedBy);
            //if (x > 0)
            //{
            //    FileUpload1.Visible = true;
            //    btnupload1.Visible = true;
            //    lnkBtnDelete1.Visible = false;
            //    lnkBtnTick.Visible = false;
            //}                       
        }
        protected void btnupload2_Click(object sender, EventArgs e)
        {
            if (IsSessionValid())
            {
                string Result = SaveDocumentWithTransaction(FileUpload2, btnupload2, lnkBtnDelete2, lnkBtn_Tick2, "Details Investigation_Narrative Xen Report", "Yes","");
                if (Result != null && Result != "")
                {
                    HdnField_Document2.Value = "1";
                }
            }
            else
            {
                Response.Redirect("/SiteOwnerLogout.aspx", false);
            }
        }
        protected void lnkBtnDelete2_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
               bool IsDelete= DeleteDocumentWithTransaction(fileId, lnkBtnDelete2, lnkBtn_Tick2, FileUpload2, btnupload2);
               if (IsDelete)
               {
                   HdnField_Document2.Value = "0";
               }
            }
        }
        protected void btnupload3_Click(object sender, EventArgs e)
        {
            if (IsSessionValid())
            {   
                string Result = SaveDocumentWithTransaction(FileUpload3, btnupload3, lnkBtnDelete3, lnkBtn_Tick3, "Details Investigation Report SDO", "Yes", "");
                if (Result != null && Result != "")
                {
                    HdnField_Document3.Value = "1";
                }
            }
            else
            {
                Response.Redirect("/SiteOwnerLogout.aspx", false);
            }
        }
        protected void lnkBtnDelete3_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
               bool IsDelete= DeleteDocumentWithTransaction(fileId, lnkBtnDelete3, lnkBtn_Tick3, FileUpload3, btnupload3);
                if (IsDelete)
                {
                    HdnField_Document3.Value = "0";
                    
                }
            }
        }       
        protected void btnupload4_Click(object sender, EventArgs e)
        {
            if (RadioButtonList4.SelectedValue == "0" || RadioButtonList4.SelectedValue == "1")
            {
                if (IsSessionValid())
                {
                   string Result= SaveDocumentWithTransaction(FileUpload4, btnupload4, lnkBtnDelete4, lnkBtn_Tick4, "Statements of the concerned JE_ALM_LM_AFM_FM", RadioButtonList4.SelectedItem.Text, txtReason4.Text.Trim());                   
                   if (Result != null && Result != "")
                   {
                        HdnField_Document4.Value = "1";
                        RadioButtonList4.Enabled = false;
                        if (RadioButtonList4.SelectedValue == "0")
                        {
                            txtReason4.Visible = false;
                        }
                        else
                        {
                            txtReason4.ReadOnly = true;
                            lnkBtn_Tick4.Visible = false;
                        }
                        
                       
                   }
                }
                else
                {
                    Response.Redirect("/SiteOwnerLogout.aspx", false);
                }
            }           
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                        "alert('Please Select Yes/No ');", true);
                RadioButtonList4.Focus();
                return;
            }
        }
        protected void lnkBtnDelete4_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
               bool IsDelete= DeleteDocumentWithTransaction(fileId, lnkBtnDelete4, lnkBtn_Tick4, FileUpload4, btnupload4);
                if (IsDelete)
                {
                    HdnField_Document4.Value = "0";
                    txtReason4.ReadOnly = false;
                    txtReason4.Text = "";
                    txtReason5.Visible = true;
                    RadioButtonList4.ClearSelection();
                    RadioButtonList4.Enabled = true;
                }
            }
        }
        protected void lnkBtnDelete5_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
               bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkBtnDelete5, lnkBtn_Tick5, FileUpload5, btnupload5);
               if (IsDelete)
               {
                    HdnField_Document5.Value = "0";
                    txtReason5.ReadOnly = false;
                    txtReason5.Text = "";
                    txtReason5.Visible = true;
                    RadioButtonList5.ClearSelection();
                    RadioButtonList5.Enabled = true;
                }
            }
        }
        protected void btnupload5_Click(object sender, EventArgs e)
        {
            if (RadioButtonList5.SelectedValue == "0" || RadioButtonList5.SelectedValue == "1")
            {
                if (IsSessionValid())
                {
                    string Result= SaveDocumentWithTransaction(FileUpload5, btnupload5, lnkBtnDelete5, lnkBtn_Tick5, "Statement of eyewitness", RadioButtonList5.SelectedItem.Text, txtReason5.Text.Trim());
                    if (Result != null && Result != "")
                    {
                        HdnField_Document5.Value = "1";
                        RadioButtonList5.Enabled = false;
                        if (RadioButtonList5.SelectedValue == "0")
                        {                            
                            txtReason5.Visible = false;
                        }
                        else
                        {
                            txtReason5.ReadOnly = true;
                            lnkBtn_Tick5.Visible = false;
                        }                        
                    }
                }
                else
                {
                    Response.Redirect("/SiteOwnerLogout.aspx", false);
                }
            }            
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                        "alert('Please Select Yes/No ');", true);
                RadioButtonList5.Focus();
                return;
            }
        }       
        protected void btnupload6_Click(object sender, EventArgs e)
        {
            if (RadioButtonList6.SelectedValue == "0" || RadioButtonList6.SelectedValue == "1")
            {
                if (IsSessionValid())
                {
                    string Result = SaveDocumentWithTransaction(FileUpload6, btnupload6, lnkBtnDelete6, lnkBtn_Tick6, "Post-mortem report_Medical report", RadioButtonList6.SelectedItem.Text, txtReason6.Text.Trim());
                    if (Result != null && Result != "")
                    {
                        HdnField_Document6.Value = "1";
                        RadioButtonList6.Enabled = false;
                        if (RadioButtonList6.SelectedValue == "0")
                        {
                            txtReason6.Visible = false;
                        }
                        else
                        {
                            txtReason6.ReadOnly = true;
                            lnkBtn_Tick6.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Redirect("/SiteOwnerLogout.aspx", false);
                }
            }           
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                        "alert('Please Select Yes/No ');", true);
                RadioButtonList6.Focus();
                return;
            }
        }
        protected void lnkBtnDelete6_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
                bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkBtnDelete6, lnkBtn_Tick6, FileUpload6, btnupload6);
                if (IsDelete)
                {
                    //HdnField_Document10.Value = "0";
                    txtReason6.ReadOnly = false;
                    txtReason6.Text = "";
                    txtReason6.Visible = true;
                    RadioButtonList6.ClearSelection();
                    RadioButtonList6.Enabled = true;
                }
            }
        }
        protected void btnupload7_Click(object sender, EventArgs e)
        {
            if (RadioButtonList7.SelectedValue == "0" || RadioButtonList7.SelectedValue == "1")
            {
                if (IsSessionValid())
                {
                    string Result = SaveDocumentWithTransaction(FileUpload7, btnupload7, lnkBtnDelete7, lnkBtn_Tick7, "FIR", RadioButtonList7.SelectedItem.Text, txtReason7.Text.Trim());
                    if (Result != null && Result != "")
                    {
                        HdnField_Document7.Value = "1";
                        RadioButtonList7.Enabled = false;
                        if (RadioButtonList7.SelectedValue == "0")
                        {
                            txtReason7.Visible = false;
                        }
                        else
                        {
                            txtReason7.ReadOnly = true;
                            lnkBtn_Tick7.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Redirect("/SiteOwnerLogout.aspx", false);
                }
            }           
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                        "alert('Please Select Yes/No ');", true);
                RadioButtonList7.Focus();
                return;
            }
        }
        protected void lnkBtnDelete7_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
                bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkBtnDelete7, lnkBtn_Tick7, FileUpload7, btnupload7);
                if (IsDelete)
                {
                    HdnField_Document7.Value = "0";
                    txtReason7.ReadOnly = false;
                    txtReason7.Text = "";
                    txtReason7.Visible = true;
                    RadioButtonList7.ClearSelection();
                    RadioButtonList7.Enabled = true;
                }
            }
        }
        protected void lnkBtnDelete8_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
                bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkBtnDelete8, lnkBtn_Tick8, FileUpload8, btnupload8);
                if (IsDelete)
                {
                    HdnField_Document8.Value = "0";
                    txtReason8.ReadOnly = false;
                    txtReason8.Text = "";
                    txtReason8.Visible = true;
                    RadioButtonList8.ClearSelection();
                    RadioButtonList8.Enabled = true;
                }
            }
        }
        protected void btnupload8_Click(object sender, EventArgs e)
        {
            if (RadioButtonList8.SelectedValue == "0" || RadioButtonList8.SelectedValue == "1")
            {
                if (IsSessionValid())
                {
                    string Result = SaveDocumentWithTransaction(FileUpload8, btnupload8, lnkBtnDelete8, lnkBtn_Tick8, "Sketch of accidental site", RadioButtonList8.SelectedItem.Text, txtReason8.Text.Trim());
                    if (Result != null && Result != "")
                    {
                        HdnField_Document8.Value = "1";
                        RadioButtonList8.Enabled = false;
                        if (RadioButtonList8.SelectedValue == "0")
                        {
                            txtReason8.Visible = false;
                        }
                        else
                        {
                            txtReason8.ReadOnly = true;
                            lnkBtn_Tick8.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Redirect("/SiteOwnerLogout.aspx", false);
                }
            }           
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                        "alert('Please Select Yes/No ');", true);
                RadioButtonList8.Focus();
                return;
            }
        }
        protected void btnupload9_Click(object sender, EventArgs e)
        {
            if (RadioButtonList9.SelectedValue == "0" || RadioButtonList9.SelectedValue == "1")
            {
                if (IsSessionValid())
                {
                    string Result = SaveDocumentWithTransaction(FileUpload9, btnupload9, lnkBtnDelete9, lnkBtn_Tick9, "Photographs of accidental site", RadioButtonList9.SelectedItem.Text, txtReason9.Text.Trim());
                    if (Result != null && Result != "")
                    {
                        //HdnField_Document10.Value = "1";
                        HdnField_Document9.Value = "1";
                        RadioButtonList9.Enabled = false;
                        if (RadioButtonList9.SelectedValue == "0")
                        {
                            txtReason9.Visible = false;
                        }
                        else
                        {
                            txtReason9.ReadOnly = true;
                            lnkBtn_Tick9.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Redirect("/SiteOwnerLogout.aspx", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                        "alert('Please Select Yes/No ');", true);
                RadioButtonList9.Focus();
                return;
            }
        }
        protected void lnkBtnDelete9_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
                bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkBtnDelete9, lnkBtn_Tick9, FileUpload9, btnupload9);
                if (IsDelete)
                {
                    HdnField_Document9.Value = "0";
                    txtReason9.ReadOnly = false;
                    txtReason9.Text = "";
                    txtReason9.Visible = true;
                    RadioButtonList9.ClearSelection();
                    RadioButtonList9.Enabled = true;
                }
            }
        }
        protected void btnupload10_Click(object sender, EventArgs e)
        {
            if (RadioButtonList10.SelectedValue == "0" || RadioButtonList10.SelectedValue == "1")
            {
                if (IsSessionValid())
                {
                    string Result = SaveDocumentWithTransaction(FileUpload10, btnupload10, lnkBtnDelete10, lnkBtn_Tick10, "Other document", RadioButtonList10.SelectedItem.Text, txtReason10.Text.Trim());
                    if (Result != null && Result != "")
                    {
                        //HdnField_Document10.Value = "1";
                        RadioButtonList10.Enabled = false;
                        if (RadioButtonList10.SelectedValue == "0")
                        {
                            txtReason10.Visible = false;
                        }
                        else
                        {
                            txtReason10.ReadOnly = true;
                            lnkBtn_Tick10.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Redirect("/SiteOwnerLogout.aspx", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UploadError",
                        "alert('Please Select Yes/No ');", true);
                RadioButtonList10.Focus();
                return;
            }
        }
        protected void lnkBtnDelete10_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int fileId = Convert.ToInt32(btn.CommandArgument);
            if (fileId != 0)
            {
                bool IsDelete = DeleteDocumentWithTransaction(fileId, lnkBtnDelete10, lnkBtn_Tick10, FileUpload10, btnupload10);
                if (IsDelete)
                {
                    //HdnField_Document10.Value = "0";
                    txtReason10.ReadOnly = false;
                    txtReason10.Text = "";
                    txtReason10.Visible = true;
                    RadioButtonList10.ClearSelection();
                    RadioButtonList10.Enabled = true;
                }
            }
        }

        #endregion

        protected void ddlElectricalEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Div_ElectricalEquipment.Visible = false;
            txtOtherCaseElectricalEquipment.Visible = false;
            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue) && ddlDistrict.SelectedValue != "0" &&
                !string.IsNullOrEmpty(ddlVoltageLevel.SelectedValue) && ddlVoltageLevel.SelectedValue != "0")
            {               
                txtVoltage_Popup.Text = ddlVoltageLevel.SelectedItem.Text;
                txtVoltage_Popup.ReadOnly = true;
                txtDistrict_Popup.Text =ddlDistrict.SelectedItem.Text;
                txtDistrict_Popup.ReadOnly = true;
                txtElectricalEquiment_Popup.Text =ddlElectricalEquipment.SelectedItem.Text;
                txtElectricalEquiment_Popup.ReadOnly = true;
                BindInstallation_Site(txtDistrict_Popup.Text, txtVoltage_Popup.Text, txtElectricalEquiment_Popup.Text);
                string script = "$(document).ready(function() { $('#equipmentModal').modal('show'); });";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", script, true);               
            }
            else
            {
                ddlElectricalEquipment.SelectedIndex = 0;
                if ((string.IsNullOrEmpty(ddlDistrict.SelectedValue) || ddlDistrict.SelectedValue == "0") && (string.IsNullOrEmpty(ddlVoltageLevel.SelectedValue) || ddlVoltageLevel.SelectedValue == "0"))
                {
                    ddlDistrict.Style["border"] = "2px solid red";                  
                    ddlVoltageLevel.Style["border"] = "2px solid red";
                    ddlVoltageLevel.Focus();
                    ddlDistrict.Focus();
                }
                else if (string.IsNullOrEmpty(ddlDistrict.SelectedValue) || ddlDistrict.SelectedValue == "0")
                {
                    ddlDistrict.Style["border"] = "2px solid red";
                    ddlDistrict.Focus();
                }
                else if (string.IsNullOrEmpty(ddlVoltageLevel.SelectedValue) || ddlVoltageLevel.SelectedValue == "0")
                {
                    ddlVoltageLevel.Style["border"] = "2px solid red";
                    ddlVoltageLevel.Focus();
                }
            }            
        }
        protected void ddlPremises_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOtherPremsesCase.Visible = false;
            Div_OtherPremisesCase.Visible = false;
            if (ddlPremises.SelectedValue =="3")
            {
                Div_OtherPremisesCase.Visible = true;
                txtOtherPremsesCase.Visible = true;
                txtOtherPremsesCase.Text = "";
            }
        }
               
        private void BindInstallation_Site(string District,string VoltageLevel, string InstallationType)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetinstallationsForAccident(District,VoltageLevel,InstallationType);
                if (ds != null && ds.Tables.Count > 0)
                {
                    GrdView_InstallationList.DataSource = ds;
                    GrdView_InstallationList.DataBind();
                    if (InstallationType == "Line")
                    {
                        GrdView_InstallationList.Columns[4].Visible = false;
                    }
                }
                else
                {
                    GrdView_InstallationList.DataSource = null;
                    GrdView_InstallationList.DataBind();
                }                             
                ds.Clear();
            }
            catch (Exception ex) { }
        }

        private void ddlLoadBindVoltage()
        {
            try
            {
               
                DataSet dsVoltage = new DataSet();
                dsVoltage = CEI.GetddlVoltageLevel();
                //dsVoltage = CEI.GetddlVoltageLevelForContractorIntimation(UserID);
                ddlVoltageLevel.DataSource = dsVoltage;
                ddlVoltageLevel.DataTextField = "Voltagelevel";
                ddlVoltageLevel.DataValueField = "VoltageID";
                ddlVoltageLevel.DataBind();
                ddlVoltageLevel.Items.Insert(0, new ListItem("Select", "0"));
                dsVoltage.Clear();
            }
            catch (Exception ex)
            {
            }

        }

        protected void ddlVoltageLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlElectricalEquipment.SelectedIndex = 0;
            //ddlElectricalEquipment.Items.Clear();
        }

        protected void btnSubmit_Model_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GrdView_InstallationList.Rows)
            {
                RadioButton rdoSelect = (RadioButton)row.FindControl("radiobtn");

                if (rdoSelect != null && rdoSelect.Checked)  
                {
                    Label ID = (Label)row.FindControl("LblID");  
                    Label lblserialNo = (Label)row.FindControl("lblInstallationID");
                    Label lblInstallationType = (Label)row.FindControl("LblTypeofinstallation");
                    Label lblVoltage = (Label)row.FindControl("LblVoltage");
                    Label lblId = (Label)row.FindControl("LblID");
                    if (lblInstallationType.Text == "Line")
                    {
                        LblLineName.Visible = true;
                        lblSerialNO.Visible = false;
                    }
                    txtSerialNo.Text = lblserialNo.Text;
                    txtSerialNo.ReadOnly = true;
                    txtVoltageLevelAccident.Text = lblVoltage.Text;
                    txtVoltageLevelAccident.ReadOnly = true;
                    HdnField_PopUp_InstallationId.Value = lblId.Text;
                    break; 
                }
            }
        }

        protected void btn_NotFound_Click(object sender, EventArgs e)
        {
            txtSerialNo.Text = "";
            txtSerialNo.ReadOnly = false;
            txtVoltageLevelAccident.Text = "";
            txtVoltageLevelAccident.ReadOnly = false;            
        }

        protected void btnHuman_Click(object sender, EventArgs e)
        {
            Session["FlagHuman"] = 1;            
        }

        protected void btnAnimal_Click(object sender, EventArgs e)
        {
            Session["FlagAnimal"] = 1;            
        }


        [System.Web.Services.WebMethod]
        public static void SetSessionValue(string key)
        {
            HttpContext.Current.Session[key] = "1";
            //Session["FlagHuman"] = 1;
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlVoltageLevel.SelectedIndex = 0;
            ddlElectricalEquipment.SelectedIndex = 0;
            //ddlElectricalEquipment.Items.Clear();           
            txtSerialNo.Text = "";
            txtSerialNo.ReadOnly = false;
            txtVoltageLevelAccident.Text = "";
            txtVoltageLevelAccident.ReadOnly = false;
        }

        public void Reset()
        {
            txtUtility.Text = ""; txtZone.Text = ""; txtCircle.Text = ""; txtDivision.Text = "";
            txtSubdivision.Text = ""; txtAccidentDate.Text = ""; txtAccidentTime.Text = ""; ddlDistrict.SelectedIndex = 0; txtThana.Text = "";
            txtTehsil.Text = ""; txtVillageCityTown.Text = ""; ddlVoltageLevel.SelectedIndex = 0; ddlElectricalEquipment.SelectedIndex = 0;
            txtSerialNo.Text = "";
            ddlPremises.SelectedIndex = 0; txtOtherPremsesCase.Text = "";
        }
    }
}