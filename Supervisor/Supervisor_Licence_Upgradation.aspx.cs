using CEI_PRoject;
using CEIHaryana.UserPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.Supervisor
{
    public partial class Supervisor_Licence_Upgradation : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = (MasterPage)Master;
                var loginTypeLabel = (Label)master.FindControl("LoginType");
                if (loginTypeLabel != null)
                {
                    loginTypeLabel.Text = "Supervisor / Upgradation Application";
                }

                if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                {
                    string ID = Convert.ToString(Session["SupervisorID"]);
                    int exist = CEI.CheckPendingSupervisorUpgradationRequest(ID);
                    if (exist > 0)
                    {
                        string script = "alert('Your request for upgradation is already in process!'); window.location='/Supervisor/SupervisorUpgradationHistory.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertAndRedirect", script, true);

                    }
                    else
                    {
                        GetSupervisorDetails(ID);
                    }
                    
                    //ddlLoadBindVoltage();
                    //ddlQualificationBind();
                }
            }
        }

        private void ddlQualificationBind()
        {
            DataSet dsQualification = new DataSet();
            dsQualification = CEI.GetQualification();
            ddlQualification.DataSource = dsQualification;
            ddlQualification.DataTextField = "Qualificaton";
            ddlQualification.DataValueField = "QualificationValue";
            ddlQualification.DataBind();
            ddlQualification.Items.Insert(0, new ListItem("Select", "0"));
            dsQualification.Clear();
        }

        private void ddlLoadBindVoltage()
        {
            try
            {
                DataSet dsVoltage = new DataSet();
                string Voltage = HFVoltage.Value;
                dsVoltage = CEI.GetVoltageLevelForUpgradationLicence(Voltage);
                ddlVoltageLevel.DataSource = dsVoltage;
                ddlVoltageLevel.DataTextField = "Voltagelevel";
                ddlVoltageLevel.DataValueField = "VoltageID";
                ddlVoltageLevel.DataBind();
                ddlVoltageLevel.Items.Insert(0, new ListItem("Select", "0"));
                dsVoltage.Clear();

            }
            catch (Exception)
            {

            }
        }

        private void GetSupervisorDetails(string ID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetSuperviserForUpgradation(ID);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtSupervisorName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtOldCertificateNo.Text = ds.Tables[0].Rows[0]["CertificateOld"].ToString();
                    txtNewCertificateNo.Text = ds.Tables[0].Rows[0]["CertificateNew"].ToString();
                    txtIssueDate.Text = ds.Tables[0].Rows[0]["DateofIntialissue"].ToString();
                    ///txtPresentScope.Text = ds.Tables[0].Rows[0]["votagelevel"].ToString(); //Existing voltage level
                    txtAddress.Text = ds.Tables[0].Rows[0]["FullAddress"].ToString();
                    ////txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                   

                    ddlStateBind();
                    string t1 = ds.Tables[0].Rows[0]["State"].ToString();
                    string t2 = ds.Tables[0].Rows[0]["District"].ToString();
                    ddlState.SelectedItem.Text = t1;
                    //ddlState.SelectedValue = t1;
                    ListItem item = ddlState.Items.FindByText(t1.Trim());
                    if (item != null)
                    {
                        ddlState.ClearSelection();
                        item.Selected = true;
                    }

                    ddlDistrictBind(t1);

                    ddlDistrict.ClearSelection();
                    ListItem li = ddlDistrict.Items.FindByText(t2);
                    if (li != null)
                    {
                        ddlDistrict.ClearSelection();
                        li.Selected = true;
                    }

                    ///txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    txtPin.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();
                    // txtDob.Text = ds.Tables[0].Rows[0]["DOB"].ToString();

                    
                    ddlQualificationBind();

                    // Then set the selected value from the dataset
                    string qualification = ds.Tables[0].Rows[0]["Qualification"].ToString();

                    // Ensure it's not null or empty and exists in the dropdown
                    if (!string.IsNullOrEmpty(qualification) && ddlQualification.Items.FindByValue(qualification) != null)
                    {
                        ddlQualification.SelectedValue = qualification;
                    }
                    else
                    {
                        // Fallback to default if value not found
                        ddlQualification.SelectedIndex = 0;
                    }

                    
                    string voltageLevel = ds.Tables[0].Rows[0]["votagelevel"].ToString();  // Use consistent naming
                    txtCurrentVoltage.Text = ds.Tables[0].Rows[0]["votagelevel"].ToString();
                    HFVoltage.Value= voltageLevel;
                    ddlLoadBindVoltage();
                    if (!string.IsNullOrEmpty(voltageLevel) && ddlVoltageLevel.Items.FindByValue(voltageLevel) != null)
                    {
                        ddlVoltageLevel.SelectedValue = voltageLevel;
                    }
                    else
                    {
                        // Fallback to default if value not found
                        ddlVoltageLevel.SelectedIndex = 0;
                    }

                    DateTime dob;
                    if (DateTime.TryParse(ds.Tables[0].Rows[0]["DOB"].ToString(), out dob))
                    {
                        txtDob.Text = dob.ToString("yyyy-MM-dd");

                        // Calculate age
                        DateTime today = DateTime.Today;
                        int years = today.Year - dob.Year;
                        int months = today.Month - dob.Month;
                        int days = today.Day - dob.Day;

                        if (days < 0)
                        {
                            months--;
                            days += DateTime.DaysInMonth(today.Year, today.Month == 1 ? 12 : today.Month - 1);
                        }

                        if (months < 0)
                        {
                            years--;
                            months += 12;
                        }

                        txtCurrentAge.Text = $"{years} years, {months} months, {days} days";
                        MedicalCertificate.Visible = (years >= 55);


                        if (years < 18)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "underageAlert", "alert('You are not eligible to apply. Age must be more than 18 years.');", true);
                            return;
                        }
                        // ❗ If age is exactly or more than 65
                        if (years >= 65)
                        {
                            string message = "You are not eligible for upgradation as your age is 65 or more.";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{message}');", true);

                            // Submit button or mark as ineligible
                             btnSubmit.Enabled = false;
                            return;
                        }
                        else if (years >= 64)
                        {
                            // Calculate time left till 65
                            DateTime sixtyFifthBirthday = dob.AddYears(65);
                            int totalMonthsLeft = ((sixtyFifthBirthday.Year - today.Year) * 12) + (sixtyFifthBirthday.Month - today.Month);

                            if (sixtyFifthBirthday.Day < today.Day)
                            {
                                totalMonthsLeft--;
                            }

                            DateTime intermediateDate = today.AddMonths(totalMonthsLeft);
                            int remainingDays = (sixtyFifthBirthday - intermediateDate).Days;

                            string timeLeft = $"{totalMonthsLeft} Months - {remainingDays} Days";
                            string script = $"alert('You are eligible for this license only for the remaining {timeLeft}');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
                        }
                    }
                    }
            }
            catch (Exception ex)
            {
            }
        }

        private void ddlDistrictBind(string State)
        {
            DataSet dsDistrict = new DataSet();
            dsDistrict = CEI.GetddlDrawDistrict(State);
            ddlDistrict.DataSource = dsDistrict;
            ddlDistrict.DataTextField = "District";
            ddlDistrict.DataValueField = "District";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
            dsDistrict.Clear();
        }

        private void ddlStateBind()
        {
            try
            {
                DataSet dsBusinessState = new DataSet();
                dsBusinessState = CEI.GetddlDrawState();
                ddlState.DataSource = dsBusinessState;
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateID";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("Select", "0"));
                dsBusinessState.Clear();
            }
            catch (Exception)
            {
            }
        }

        protected void rblbelated_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblbelated.SelectedValue == "1")  //Yes
                {
                    InterviewDate.Visible = true;
                }
                else if (rblbelated.SelectedValue == "0")
                {
                    InterviewDate.Visible = false;
                    txtInterviewDate.Text = "";
                }
            }
            catch (Exception ex)
            { }
        }

        protected void ddlQualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQualification.SelectedItem.ToString() == "Other")
            {
                otherQualification.Visible = true;
            }
            else
            {
                otherQualification.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string userId = Session["SupervisorID"].ToString();
                string baseFolder = Server.MapPath("~/Attachment/LicenceUpgadation/Supervisor/" + userId + "/");

                // Create directory if not exists
                if (!Directory.Exists(baseFolder))
                {
                    Directory.CreateDirectory(baseFolder);
                }

                string dbPathCompetency = "";
                string dbPathExperience = "";
                string dbPathMedicalCertificate = "";

                // ==== Certificate of Competency ====
                if (FileUpload2.HasFile)
                {
                    if (Path.GetExtension(FileUpload2.FileName).ToLower() == ".pdf")
                    {
                        if (FileUpload2.PostedFile.ContentLength <= 1048576) // 1 MB
                        {
                            string fileName = "Competency_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
                            string savePath = Path.Combine(baseFolder, fileName);
                            FileUpload2.PostedFile.SaveAs(savePath);

                            dbPathCompetency = "/Attachment/LicenceUpgadation/Supervisor/" + userId + "/" + fileName;
                        }
                        else
                        {
                            throw new Exception("Competency Certificate must be less than 1 MB.");
                        }
                    }
                    else
                    {
                        throw new Exception("Only PDF files are allowed for Competency Certificate.");
                    }
                }

                // ==== Certificate of Experience ====
                if (FileUpload1.HasFile)
                {
                    if (Path.GetExtension(FileUpload1.FileName).ToLower() == ".pdf")
                    {
                        if (FileUpload1.PostedFile.ContentLength <= 1048576) // 1 MB
                        {
                            string fileName = "Experience_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
                            string savePath = Path.Combine(baseFolder, fileName);
                            FileUpload1.PostedFile.SaveAs(savePath);

                            dbPathExperience = "/Attachment/LicenceUpgadation/Supervisor/" + userId + "/" + fileName;
                        }
                        else
                        {
                            throw new Exception("Experience Certificate must be less than 1 MB.");
                        }
                    }
                    else
                    {
                        throw new Exception("Only PDF files are allowed for Experience Certificate.");
                    }
                }

                // ==== Medical Certificate ====
                if (FileUpload3.HasFile)
                {
                    if (Path.GetExtension(FileUpload3.FileName).ToLower() == ".pdf")
                    {
                        if (FileUpload3.PostedFile.ContentLength <= 1048576) // 1 MB
                        {
                            string fileName = "MedicalCertificate_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
                            string savePath = Path.Combine(baseFolder, fileName);
                            FileUpload3.PostedFile.SaveAs(savePath);

                            dbPathMedicalCertificate = "/Attachment/LicenceUpgadation/Supervisor/" + userId + "/" + fileName;
                        }
                        else
                        {
                            throw new Exception("Medical Certificate must be less than 1 MB.");
                        }
                    }
                    else
                    {
                        throw new Exception("Only PDF files are allowed for Medical Certificate.");
                    }
                }


                string Qualification = "";
                if (txtQualification.Visible == true)
                {
                    Qualification = txtQualification.Text;
                }
                else
                {
                    Qualification = ddlQualification.SelectedValue;

                }

                string SupervisorName = txtSupervisorName.Text.Trim();


                string Age = txtCurrentAge.Text.Trim();
                
                string NewCertificateNo = txtNewCertificateNo.Text.Trim();
                string OldCertificateNo = txtOldCertificateNo.Text.Trim();
                string IssueDate = txtIssueDate.Text.Trim();
                //string PresentScope = txtPresentScope.Text.Trim();
                //string Academic = txtAcademic.Text.Trim();
                //string professional = txtProfessional.Text.Trim();
                string experience = txtExperience.Text.Trim();
                string address = txtAddress.Text.Trim();
                string State = ddlState.SelectedItem.Text.Trim();
                string District = ddlDistrict.SelectedItem.Text.Trim();
                string Pin = txtPin.Text.Trim();
                string UpgradationAppliedErlier = rblbelated.SelectedItem.Text;
                string InterviewDate = txtInterviewDate.Text.Trim();
                string CurrentVoltage = txtCurrentVoltage.Text.Trim();
                string Voltage = ddlVoltageLevel.SelectedValue.Trim();
                //int result = CEI.UpgradationOfSupervisorData(SupervisorName,NewCertificateNo, OldCertificateNo, IssueDate,PresentScope,
                //                                             Qualification, Academic, professional, 
                //                                             experience, address,
                //                                             State, District, Pin, UpgradationAppliedErlier, txtInterviewDate.Text.Trim(), Voltage, dbPathExperience,
                //                                             dbPathCompetency, dbPathMedicalCertificate, userId);
                int result = CEI.UpgradationOfSupervisorData(SupervisorName, txtDob.Text.Trim(), Age, NewCertificateNo, OldCertificateNo, IssueDate,
                                                             Qualification, experience, address,
                                                             State, District, Pin, UpgradationAppliedErlier, txtInterviewDate.Text.Trim(), CurrentVoltage, Voltage, dbPathExperience,
                                                             dbPathCompetency, dbPathMedicalCertificate, userId);

                if (result > 0)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Upgradation applied successfully!');", true);
                    //ReSet();
                   string script = "alert('Upgradation applied successfully!'); window.location='/Supervisor/SupervisorUpgradationHistory.aspx';";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertAndRedirect", script, true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error while saving documents.');", true);
                }
            }
        }

        private void ReSet()
        {
            txtQualification.Text = "";
            //txtAcademic.Text = "";
            //txtProfessional.Text = "";
            txtExperience.Text = "";
            txtInterviewDate.Text = "";
            ddlQualification.ClearSelection();
            ddlVoltageLevel.ClearSelection();

            rblbelated.ClearSelection();
        }

        protected void txtDob_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dob;
                if (DateTime.TryParse(txtDob.Text, out dob))
                {
                    // Format DOB properly for display if needed
                    txtDob.Text = dob.ToString("yyyy-MM-dd");

                    // Calculate age
                    DateTime today = DateTime.Today;
                    int years = today.Year - dob.Year;
                    int months = today.Month - dob.Month;
                    int days = today.Day - dob.Day;

                    if (days < 0)
                    {
                        months--;
                        days += DateTime.DaysInMonth(today.Year, today.Month == 1 ? 12 : today.Month - 1);
                    }

                    if (months < 0)
                    {
                        years--;
                        months += 12;
                    }

                    txtCurrentAge.Text = $"{years} years, {months} months, {days} days";
                    MedicalCertificate.Visible = (years >= 55);

                    if (years < 18)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "underageAlert", "alert('You are not eligible to apply. Age must be more than 18 years.');", true);

                        txtDob.Text = "";
                        txtCurrentAge.Text = "";
                        return;
                    }

                    // Not eligible if age is 65 or above
                    if (years >= 65)
                    {
                        string message = "You are not eligible for upgradation as your age is 65 or more.";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ageLimitAlert", $"alert('{message}');", true);
                        return;
                    }
                    else if (years >= 64)
                    {
                        // Show remaining eligibility
                        DateTime sixtyFifthBirthday = dob.AddYears(65);
                        int totalMonthsLeft = ((sixtyFifthBirthday.Year - today.Year) * 12) + (sixtyFifthBirthday.Month - today.Month);

                        if (sixtyFifthBirthday.Day < today.Day)
                        {
                            totalMonthsLeft--;
                        }

                        DateTime intermediateDate = today.AddMonths(totalMonthsLeft);
                        int remainingDays = (sixtyFifthBirthday - intermediateDate).Days;

                        string timeLeft = $"{totalMonthsLeft} Months - {remainingDays} Days";
                        string script = $"alert('You are eligible for this license only for the remaining {timeLeft}');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "timeLeftAlert", script, true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "invalidDate", "alert('Please enter a valid date of birth.');", true);
                }
            }
            catch (Exception ex)
            {
                // Optionally log error
                ScriptManager.RegisterStartupScript(this, this.GetType(), "error", "alert('An error occurred while processing DOB.');", true);
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDistrictBind(ddlState.SelectedItem.ToString());
        }
    }
}