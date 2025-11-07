   using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Contractor
{

    public partial class Contractor_Licence_Renewal : System.Web.UI.Page
    {
        //page created by kalpana
        CEI CEI = new CEI();
        string userID = "";
        string Category = "";
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Renwal"]) != "" && Convert.ToString(Session["Renwal"]) != null)
            {
                this.Page.MasterPageFile = "~/Contractor/ContractorRenewalMaster.Master";
            }
            else
            {
                this.Page.MasterPageFile = "~/Contractor/Contractor.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    if (Session["ContractorID"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["ContractorID"])))
                    {
                        Category = "Contractor";
                        userID = Session["ContractorID"].ToString();
                        HdnUserId.Value = userID;
                        HdnUserType.Value = "Contractor";
                        if (Convert.ToString(Session["Reapply"]).Trim() != "Yes")
                        {
                            GetRenewalData(userID);
                        }
                        ddlLoadBindState1();
                        GetDetails(userID);
                        StaffData(userID);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }


        public void GetRenewalData(string userID)
        {
            try
            {
                DataTable ds = new DataTable();

                ds = CEI.GetRenewalData(userID);
                if (ds.Rows.Count > 0)
                {
                    Response.Redirect("/Contractor/RenewalHistoryContractor.aspx", false);
                }
                else
                {
                    return;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        public void GetDetails(string userID)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetContractorDetailsforRenewal(userID);
            txtname.Text = dt.Rows[0]["Name"].ToString();
            //  txtDOB.Text = dt.Rows[0]["DateOfBirth"].ToString();
            if (dt.Rows[0]["DateOfBirth"] != DBNull.Value)
            {
                DateTime dob = Convert.ToDateTime(dt.Rows[0]["DateOfBirth"]);
                txtDOB.Text = dob.ToString("yyyy-MM-dd");
            }
            if (!string.IsNullOrEmpty(txtDOB.Text))
            {
                txtage.Text = dt.Rows[0]["Age"].ToString();
                if (dt.Rows[0]["Birthday55"] != DBNull.Value)
                {
                    DateTime dob55 = Convert.ToDateTime(dt.Rows[0]["Birthday55"]);
                    txtage55.Text = dob55.ToString("yyyy-MM-dd");
                }
                txtDOB.ReadOnly = true;
            }
            else
            {
                txtDOB.ReadOnly = false;
            }
            txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
            if (!string.IsNullOrEmpty(txtFatherName.Text))
            {
                txtFatherName.ReadOnly = true;
            }
            else
            {
                txtFatherName.ReadOnly = false;
            }
            txtLicenceNew.Text = dt.Rows[0]["LicenceNew"].ToString();
            txtLicenceOld.Text = dt.Rows[0]["LicenceOld"].ToString();
            txtaddress.Text = dt.Rows[0]["ContractorAddress"].ToString();
            txtAddressNew.Text = dt.Rows[0]["RegisteredOffice"].ToString();
            ddlState1.SelectedItem.Text = dt.Rows[0]["State"].ToString();
            ddlLoadBindDistrict1(ddlState1.SelectedItem.Text);
            ddlDistrict1.SelectedItem.Text = dt.Rows[0]["Districtoffirm"].ToString();
            txtPincodeNew.Text = dt.Rows[0]["PinCode"].ToString();
            txtDistrict.Text = dt.Rows[0]["Districtoffirm"].ToString();
            txtVoltageLevel.Text = dt.Rows[0]["Votagelevel"].ToString();
            txtPhone.Text = dt.Rows[0]["ContactNo"].ToString();
            if (!string.IsNullOrEmpty(txtPhone.Text))
            {
                txtPhone.ReadOnly = true;
            }
            else
            {
                txtPhone.ReadOnly = false;
            }
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.ReadOnly = true;
            }
            else
            {
                txtEmail.ReadOnly = false;
            }
            txtexpirydate.Text = dt.Rows[0]["ExpiryDate"].ToString();
            int yearDiff = Convert.ToInt32(dt.Rows[0]["YearDifference"]);
            if (yearDiff >= 5)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertAndRedirect", "alert('Your licence has expired for more than 5 years. Please apply for a new licence.'); window.location='/AdminLogout.aspx';", true);
                return;
            }
            int belated = Convert.ToInt32(dt.Rows[0]["BelatedRenewal"]);
            if (belated == 1)
            {
                rblbelated.SelectedValue = "1";
                days.Visible = true;
            }
            else
            {
                rblbelated.SelectedValue = "0";
                days.Visible = false;
            }
            txtdays.Text = dt.Rows[0]["NoOfDays"].ToString();
        }

        private void ddlLoadBindState1()
        {
            DataSet dsState = new DataSet();
            dsState = CEI.GetddlDrawState();
            ddlState1.DataSource = dsState;
            ddlState1.DataTextField = "StateName";
            ddlState1.DataValueField = "StateID";
            ddlState1.DataBind();
            dsState.Clear();
        }

        private void StaffData(string userid)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetStaffDate(userid);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                NoStaffLable.Visible=false;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                NoStaffLable.Visible=true;

            }
            dt.Dispose();
        }


        protected void rblChangeAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblChangeAddress.SelectedValue == "1")
            {
                NewAddress.Visible = true;
                NewState.Visible = true;
                NewDistrict.Visible = true;
                NewPincode.Visible = true;
                changedInAddress.Visible = true;
            }
            else
            {
                NewAddress.Visible = false;
                NewState.Visible = false;
                NewDistrict.Visible = false;
                NewPincode.Visible = false;
                changedInAddress.Visible = false;
                //txtAddressNew.Text = "";
                //ddlState1.SelectedIndex = 0;
                //ddlDistrict1.SelectedIndex = 0;
                //txtPincodeNew.Text = "";
                rdlchangedonlicence.ClearSelection();


            }
        }

        protected void ddlState1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLoadBindDistrict1(ddlState1.SelectedItem.ToString());
        }
        private void ddlLoadBindDistrict1(string state)
        {
            DataSet dsDistrict = new DataSet();
            dsDistrict = CEI.GetddlDrawDistrict(state);
            ddlDistrict1.DataSource = dsDistrict;
            ddlDistrict1.DataTextField = "District";
            ddlDistrict1.DataValueField = "District";
            ddlDistrict1.DataBind();
            ddlDistrict1.Items.Insert(0, new ListItem("Select", "0"));
            dsDistrict.Clear();
        }

        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            DateTime selectedDOB;
            if (DateTime.TryParse(txtDOB.Text, out selectedDOB))
            {
                DateTime currentDate = DateTime.Now;
                int ageDiff = currentDate.Year - selectedDOB.Year;

                if (ageDiff < 18)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('You must be at least 18 years old.');", true);
                    txtDOB.Text = "";
                    txtage.Text = "";
                    txtage55.Text = "";
                }
                else if (ageDiff >= 65)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('You are not eligible to fill this form as your age is 65 or more.');", true);
                    txtDOB.Text = "";
                    txtage.Text = "";
                    txtage55.Text = "";
                }
                else
                {
                    if (DateTime.TryParseExact(txtDOB.Text, "yyyy-MM-dd",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out DateTime dobDate))
                    {
                        if (dobDate > currentDate)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid Date !!!')", true);
                            txtDOB.Text = "";
                            txtage.Text = "";
                            txtage55.Text = "";
                        }
                        else
                        {
                            TimeSpan ageDifference = currentDate - selectedDOB;
                            int ageYear = (int)(ageDifference.TotalDays / 365.25);
                            int ageMonth = (int)((ageDifference.TotalDays % 365.25) / 30.44);
                            int ageDay = (int)(ageDifference.TotalDays % 30.44);

                            string ageString = $"{ageYear} Years - {ageMonth} Months - {ageDay} Days";
                            txtage.Text = ageString;


                            DateTime fiftyFifthBirthday = selectedDOB.AddYears(55);
                            txtage55.Text = fiftyFifthBirthday.ToString("dd-MM-yyyy");

                            if (ageYear >= 64)
                            {
                                DateTime sixtyFifthBirthday = selectedDOB.AddYears(65);
                                int totalMonthsLeft = ((sixtyFifthBirthday.Year - currentDate.Year) * 12) + (sixtyFifthBirthday.Month - currentDate.Month);

                                if (sixtyFifthBirthday.Day < currentDate.Day)
                                {
                                    totalMonthsLeft--;
                                }

                                DateTime intermediateDate = currentDate.AddMonths(totalMonthsLeft);
                                int remainingDays = (sixtyFifthBirthday - intermediateDate).Days;

                                string timeLeft = $"{totalMonthsLeft} Months - {remainingDays} Days";
                                string script = $"alert('You are eligible for this license only for the remaining {timeLeft}');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert65", script, true);
                            }
                        }
                    }
                }
            }
        }

        protected void ddlRenewalTime_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Category = HdnUserType.Value;
            int DaysDelay = int.TryParse(txtdays.Text, out var value) ? value : 0;

            string fees = CEI.RenewalFees(Category, DaysDelay, Convert.ToInt32(ddlRenewalTime.SelectedValue));
            txtamount.Text = fees;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkDeclaration.Checked && chkdeclaration2.Checked && chkdeclaration3.Checked)
                {
                    if (txtLicenceOld.Text == txtLicenceNew.Text)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Old Certificate Number and New Certificate Number cannot be the same');", true);
                        return;
                    }
                    else
                    {
                        #region for LT,HT,EHT conditions
                        string voltageAppliedForLicence = txtVoltageLevel.Text.Trim();

                        // Count the total
                        int totalRows = GridView1.Rows.Count;

                        // If no rows exist
                        if (totalRows == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not eligible for this. At least one Supervisor or Wireman is required.');", true);
                            return;
                        }

                        int supervisorCount = 0;
                        int wiremanCount = 0;

                        // count Supervisor/Wireman
                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            Label lblCategory = row.FindControl("lblCategory") as Label;
                            string role = lblCategory?.Text.Trim();

                            if (role == "Supervisor")
                            {
                                supervisorCount++;
                            }
                            else if (role == "Wireman")
                            {
                                wiremanCount++;
                            }
                        }

                        // Validate based on voltage level
                        if (voltageAppliedForLicence == "650V")
                        {
                            if ((supervisorCount + wiremanCount) < 2)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                    "alert('For 650V, minimum 2 employees required.');", true);
                                return;
                            }

                            if (supervisorCount < 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                    "alert('At least 1 Supervisor is required.');", true);
                                return;
                            }
                        }
                        else if (voltageAppliedForLicence == "11KV" || voltageAppliedForLicence == "33KV")
                        {
                            if ((supervisorCount + wiremanCount) < 3)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                    "alert('For 11KV/33KV, minimum 3 employees required.');", true);
                                return;
                            }

                            if (supervisorCount < 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                    "alert('At least 1 Supervisor is required.');", true);
                                return;
                            }
                        }
                        else if (voltageAppliedForLicence == "66KV" || voltageAppliedForLicence == "132KV" ||
                                 voltageAppliedForLicence == "220KV" || voltageAppliedForLicence == "EHT Level")
                        {
                            if ((supervisorCount + wiremanCount) < 5)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                    "alert('For 66KV and above, minimum 5 employees required.');", true);
                                return;
                            }

                            if (supervisorCount < 2)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                    "alert('At least 2 Supervisor is required.');", true);
                                return;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are are not eligible for this.');", true);
                            return;
                        }
                        #endregion

                        string CreatedBy = HdnUserId.Value;
                        int maxFileSize = 1024 * 1024; // 1 MB
                        bool isAllFilesValid = true;

                        // Save files
                        string ContractorLicense = SaveFile(Licence.PostedFile, "ContractorLicense", "Contractor License", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string certificate = SaveFile(Certificate.PostedFile, "Certificate", "Competency Certificate", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string Incometax = SaveFile(IncomeTax.PostedFile, "IncomeTax", "Income Tax Return", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string Calibrationtertificate = SaveFile(CalibrationCertificate.PostedFile, "CalibrationCertificate", "Calibration Certificate", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string WorksExecuted = SaveFile(worksexecuted.PostedFile, "WorksExecuted", "Works Executed", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string annexureIII = SaveFile(AnnexureIII.PostedFile, "AnnexureIII", "Annexure III", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string FormE1 = SaveFile(FormE.PostedFile, "FormE", "Form E", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string Challanfp = SaveFile(Challan.PostedFile, "Challan", "Challan", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string Candidateimage = SaveFile(CandidateImage.PostedFile, "Candidate Image", "Candidate Image", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string Candidatesignature = SaveFile(CandidateSignature.PostedFile, "Candidate Signature", "Candidate Signature", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string AuthorizationLetter = SaveFile(Authorizationletter.PostedFile, "Authorization letter", "Authorization letter", CreatedBy, maxFileSize, ref isAllFilesValid);
                        string Otherdocument = SaveFile(OtherDocument.PostedFile, "Other Document", "Other Document", CreatedBy, maxFileSize, ref isAllFilesValid);

                        if (!isAllFilesValid)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Only PDF or Image files less than 1MB are allowed.');", true);
                            return;
                        }

                        bool check = CEI.CheckIfRenewalApplicationExist(CreatedBy);
                        if (check)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('You have already submitted a renewal application.')", true);
                            return;

                        }
                        else
                        {

                            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                            {
                                con.Open();
                                SqlTransaction tran = con.BeginTransaction();

                                try
                                {
                                    CEI.InsertRenewalDataforContractor(con, tran,
            HdnUserType?.Value ?? string.Empty,
            txtname?.Text.Trim() ?? string.Empty,
            txtFatherName?.Text.Trim() ?? string.Empty,
            txtDOB?.Text.Trim() ?? string.Empty,
            txtage?.Text.Trim() ?? string.Empty,
            DateTime.TryParse(txtage55?.Text, out var dt55) ? dt55 : (DateTime)SqlDateTime.Null,
            txtPANNo?.Text.Trim() ?? string.Empty,
            txtLicenceNew?.Text.Trim() ?? string.Empty,
            txtLicenceOld?.Text.Trim() ?? string.Empty,
            txtexpirydate?.Text ?? string.Empty,
            txtPhone?.Text.Trim() ?? string.Empty,
            txtEmail?.Text.Trim() ?? string.Empty,
            rblChangeAddress.SelectedItem?.ToString() ?? string.Empty,
            txtAddressNew?.Text ?? string.Empty,
            ddlState1.SelectedItem?.ToString() ?? string.Empty,
            ddlDistrict1.SelectedItem?.ToString() ?? string.Empty,
            txtPincodeNew?.Text ?? string.Empty,
            rdlchangedonlicence.SelectedItem?.ToString() ?? string.Empty,
            rblbelated.SelectedItem?.ToString() ?? string.Empty,
            txtdays?.Text.Trim() ?? string.Empty,
            rdlEquipmentsTested.SelectedItem?.ToString() ?? string.Empty,
            ddlRenewalTime.SelectedItem?.ToString() ?? string.Empty,
            txtgrnno?.Text.Trim() ?? string.Empty,
            txtdate?.Text ?? string.Empty,
            txtamount?.Text.Trim() ?? string.Empty,
            rblChangeInStaff.SelectedItem?.ToString() ?? string.Empty,
            txtintimationDate?.Text ?? string.Empty,
            txtVoltageLevel.Text ?? string.Empty,
            CreatedBy
        );


                                    if (!string.IsNullOrEmpty(ContractorLicense))
                                        CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Contractor License", ContractorLicense, 1, CreatedBy);

                                    if (!string.IsNullOrEmpty(certificate))
                                        CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Competency CertificateCertificate of Competency and Wireman Permit, who are working with the Firm", certificate, 1, CreatedBy);

                                    if (!string.IsNullOrEmpty(Incometax))
                                        CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Income Tax Returns and Balance Sheet as specified in the conditions.", Incometax, 1, CreatedBy);

                                    if (!string.IsNullOrEmpty(Calibrationtertificate))
                                        CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Calibration Certificate from NABL or Government Testing Laboratory in respect of Electrical", Calibrationtertificate, 1, CreatedBy);

                                    if (!string.IsNullOrEmpty(WorksExecuted))
                                        CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Details of works executed annually on the basis of Electrical Contractor License", WorksExecuted, 1, CreatedBy);

                                    if (!string.IsNullOrEmpty(annexureIII))
                                        CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Copy of Annexure III", annexureIII, 1, CreatedBy);

                                    if (!string.IsNullOrEmpty(FormE1))
                                        CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Copy of Form \"E\"", FormE1, 1, CreatedBy);

                                    if (!string.IsNullOrEmpty(Challanfp))
                                        CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Deposited Treasury Challan of fees, for the purpose.\r\nHead of A/c: 0043-51-800-99-51—Other Receipt.", Challanfp, 1, CreatedBy);

                                    if (!string.IsNullOrEmpty(Candidateimage))
                                        CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Candidate Image", Candidateimage, 1, CreatedBy);

                                    if (!string.IsNullOrEmpty(Candidatesignature))
                                        CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Candidate Signature", Candidatesignature, 1, CreatedBy);

                                    if (!string.IsNullOrEmpty(AuthorizationLetter))
                                    {
                                        CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Authorization Letter", AuthorizationLetter, 1, CreatedBy);
                                    }
                                    if (!string.IsNullOrEmpty(Otherdocument))
                                    {
                                        CEI.InsertRenewalDocuments(con, tran, HdnUserType.Value, "Other Document", Otherdocument, 1, CreatedBy);
                                    }

                                    tran.Commit();
                                    Session["Reapply"] = "";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Application submitted successfully!')", true);
                                    Response.Redirect("/Contractor/RenewalHistoryContractor.aspx", false);
                                    resetfeild();

                                }
                                catch (Exception ex2)
                                {
                                    tran.Rollback();
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Transaction Failed: " + ex2.Message + "')", true);
                                }
                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please accept all declarations.')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Unexpected Error: " + ex.Message + "')", true);
            }
        }
        private string SaveFile(HttpPostedFile file, string folderName, string prefix, string createdBy, int maxFileSize, ref bool isValid)
        {
            if (file == null || file.ContentLength == 0)
                return null;

            string ext = Path.GetExtension(file.FileName).ToLower();

            bool isFileValid = false;

            if (folderName.Equals("Candidate Image", StringComparison.OrdinalIgnoreCase) ||
                folderName.Equals("Candidate Signature", StringComparison.OrdinalIgnoreCase))
            {
                // Image validation
                isFileValid = IsValidPhoto(file);
            }
            else
            {
                // PDF validation
                isFileValid = ValidatePdfFile(file);
            }

            if (!isFileValid)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert",
                    $"alert('{prefix} has invalid format or exceeds 1MB.');", true);
                isValid = false;
                return null;
            }

            // Set folder path
            string path = $"/Attachment/Renewal/{createdBy}/{folderName}/";
            string directoryPath = HttpContext.Current.Server.MapPath("~" + path);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            // Generate unique file name
            string fileName = $"{prefix}_{DateTime.Now:yyyyMMddHHmmssfff}{ext}";
            string filePath = Path.Combine(directoryPath, fileName);

            // Save file
            file.SaveAs(filePath);

            return path + fileName;
        }


        private bool IsValidPhoto(HttpPostedFile file)
        {
            string ext = Path.GetExtension(file.FileName).ToLower();
            if (ext != ".jpg" && ext != ".jpeg" && ext != ".png") return false;

            if (file.ContentLength > 1048576) return false; // 1MB
            return true;
        }

        private bool ValidatePdfFile(HttpPostedFile file)
        {
            string ext = Path.GetExtension(file.FileName).ToLower();
            if (ext != ".pdf") return false;

            if (file.ContentLength > 1048576) return false; // 1MB
            return true;
        }


        private void resetfeild()
        {
            ddlRenewalTime.SelectedValue = "0";
            txtgrnno.Text = "";
            txtdate.Text = "";
            txtDOB.Text = "";
            txtamount.Text = "";
            chkDeclaration.Checked = false;
            chkdeclaration2.Checked = false;
            chkdeclaration3.Checked = false;
            txtPANNo.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            rdlEquipmentsTested.SelectedIndex = -1;
            rblChangeAddress.SelectedIndex = -1;
            rdlchangedonlicence.SelectedIndex = -1;

            rblChangeInStaff.SelectedIndex = -1;
            txtintimationDate.Text = "";

        }

        protected void rblChangeInStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblChangeInStaff.SelectedValue == "1")
            {
                DateOFIntimation.Visible = true;
            }
            else
            {
                DateOFIntimation.Visible = false;
                txtintimationDate.Text ="";
            }
        }
    }
}