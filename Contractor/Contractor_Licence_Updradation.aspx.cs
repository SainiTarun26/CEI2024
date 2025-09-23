using CEI_PRoject;
using CEIHaryana.UserPages;
using iText.StyledXmlParser.Node;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Contractor
{
    public partial class Contractor_Licence_Updradation : System.Web.UI.Page
    {
        //page created by Neha
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = (MasterPage)Master;
                var loginTypeLabel = (Label)master.FindControl("LoginType");
                if (loginTypeLabel != null)
                {
                    loginTypeLabel.Text = "Contractor / Upgradation Application";
                }

                if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                {
                    string ContractorId = Convert.ToString(Session["ContractorID"]);
                    HFContractor.Value = ContractorId;
                    int exist = CEI.CheckPendingContractorUpgradationRequest(ContractorId);
                    if (exist > 0)
                    {
                        string script = "alert('Your request for upgradation is already in process!'); window.location='/Contractor/ConractorUpgradationHistory.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertAndRedirect", script, true);

                    }
                    else
                    {
                        int partnerCount = CEI.GetUpgradationContractorPartnerCount(HFContractor.Value);
                        if (partnerCount > 0)
                        {
                            DdlPartnerOrDirector.SelectedValue = "1";
                            ADDpartner.Visible = true;

                        }
                        else
                        {
                            DdlPartnerOrDirector.ClearSelection();
                        }
                        GetContractorDetails(ContractorId);
                        ddlLoadBindState();
                        PartnersModalDirectorData(ContractorId);
                        GetEmployeeGridData(ContractorId);
                    }
                }
            }
        }

        private void ddlLoadBindVoltage()
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

        private void GetEmployeeGridData(string contractorId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.WorkIntimationGridData(contractorId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView4.DataSource = ds;
                    GridView4.DataBind();
                }
                else
                {
                    GridView4.DataSource = null;
                    GridView4.DataBind();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('An Error Occured');", true);
            }
        }

        private void GetContractorDetails(string ContractorId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetContractorDataForUpgradation(ContractorId);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtFirmName.Text = ds.Tables[0].Rows[0]["FirmName"].ToString();
                    txtContractName.Text = ds.Tables[0].Rows[0]["Name"].ToString();

                    txtOldCertificateNo.Text = ds.Tables[0].Rows[0]["LicenceOld"].ToString();
                    txtNewCertificateNo.Text = ds.Tables[0].Rows[0]["LicenceNew"].ToString();
                    txtGstNumber.Text = ds.Tables[0].Rows[0]["GSTNumber"].ToString();
                    txtBusinessAddress.Text = ds.Tables[0].Rows[0]["RegisteredOffice"].ToString();
                    txtBusinessEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                    ddlBusinessStateBind();
                    //ddlBusinessState.Text = ds.Tables[0].Rows[0]["State"].ToString();

                    string t1 = ds.Tables[0].Rows[0]["State"].ToString().Trim();
                    string t2 = ds.Tables[0].Rows[0]["Districtoffirm"].ToString().Trim();
                    ddlBusinessState.SelectedItem.Text = t1;

                    ////ListItem itemst = ddlBusinessState.Items.FindByText(t1);
                    ////if (itemst != null)
                    ////{
                    ////    ddlBusinessState.ClearSelection();
                    ////    itemst.Selected = true;
                    ////}

                    ddlLoadBindBusinessDistrict(t1);

                    //ddlBusinessDistrict.SelectedItem.Text = t2;

                    ddlBusinessDistrict.ClearSelection();
                    ListItem li = ddlBusinessDistrict.Items.FindByText(t2);
                    if (li != null)
                    {
                        ddlBusinessDistrict.ClearSelection();
                        li.Selected = true;
                    }

                    //ddlBusinessDistrict.Text = ds.Tables[0].Rows[0]["Districtoffirm"].ToString();
                    txtBusinessPin.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();
                    txtBusinessPhoneNo.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    txtCurrentVoltage.Text = ds.Tables[0].Rows[0]["Votagelevel"].ToString().Trim();
                    if (txtCurrentVoltage.Text == "650V")
                    {
                        divbluePrint.Visible = false;
                    }
                    else
                    {
                        divbluePrint.Visible = true;
                    }

                    string voltageLevel = ds.Tables[0].Rows[0]["Votagelevel"]?.ToString()?.Trim();
                    HFVoltage.Value = voltageLevel;
                    ddlLoadBindVoltage();
                    if (!string.IsNullOrEmpty(voltageLevel) && ddlVoltageLevel.Items.FindByValue(voltageLevel) != null)
                    {
                        ddlVoltageLevel.SelectedValue = voltageLevel;
                    }
                    else
                    {
                        ddlVoltageLevel.SelectedIndex = 0; // fallback
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ddlBusinessStateBind()
        {
            try
            {
                DataSet dsBusinessState = new DataSet();
                dsBusinessState = CEI.GetddlDrawState();
                ddlBusinessState.DataSource = dsBusinessState;
                ddlBusinessState.DataTextField = "StateName";
                ddlBusinessState.DataValueField = "StateID";
                ddlBusinessState.DataBind();
                ddlBusinessState.Items.Insert(0, new ListItem("Select", "0"));
                dsBusinessState.Clear();
            }
            catch (Exception)
            {
            }
        }

        private void ddlLoadBindState()
        {
            try
            {
                DataSet dsState = new DataSet();
                dsState = CEI.GetddlDrawState();
                ddlState.DataSource = dsState;
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateID";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("Select", "0"));
                dsState.Clear();
            }
            catch (Exception)
            {
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLoadBindDistrict(ddlState.SelectedItem.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "$('#myModal').modal('show');", true);
            }
            catch { }
        }

        private void ddlLoadBindDistrict(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "District";
                ddlDistrict.DataValueField = "District";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                try
                {
                    if (HFContractor.Value != null && HFContractor.Value != "")
                    {
                        //String ConId = Convert.ToString(Session["ContractorID"]);
                        if (e.CommandName == "DeleteRecord")
                        {
                            int id = Convert.ToInt32(e.CommandArgument);
                            CEI.DeleteContractorPartnerinUpgradation(id);
                            PartnersModalDirectorData(HFContractor.Value);
                        }
                    }
                }
                catch (Exception Ex)
                { }
            }
            catch { }
        }

        private void PartnersModalDirectorData(string LoginID)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetUpgradationContractorPartnersData(LoginID);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();

                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            dt.Dispose();
        }

        protected void btnModalSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                if (HFContractor.Value != null && HFContractor.Value != "")
                {
                    string Createdby = HFContractor.Value;
                    int partnerCount = CEI.GetUpgradationContractorPartnerCount(Createdby);

                    if (partnerCount >= 5)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "limitAlert", "alert('Only 5 partners are allowed.');", true);
                        return;
                    }
                    CEI.UpgradationContractorPartners(ddlAuthority.SelectedItem.ToString(), txtName.Text.Trim(), txtAddress.Text.Trim(),
                        ddlState.SelectedItem.ToString(), ddlDistrict.SelectedItem.ToString(), txtPinCode.Text.Trim(), Createdby);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "$('#myModal').modal('show');", true);

                    PartnersModalDirectorData(Createdby);
                    //Session["PartnerDirector"] = "Added";
                    ResetModal();

                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('An Error occurred.');", true);
            }
        }

        private void ResetModal()
        {
            ddlAuthority.SelectedValue = "0";
            txtName.Text = "";
            txtAddress.Text = "";
            ddlState.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";
            txtPinCode.Text = "";
        }

        protected void ddlCompanyStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCompanyStyle.SelectedValue == "1")
            {
                Lbl1.Visible = true;
                Lbl2.Visible = false;
                Lbl3.Visible = false;
                Lbl4.Visible = false;
                DivAgentName.Visible = false;
                txtAgentName.Text = "";
            }
            else if (ddlCompanyStyle.SelectedValue == "2")
            {
                Lbl1.Visible = false;
                Lbl2.Visible = true;
                Lbl3.Visible = false;
                Lbl4.Visible = false;
                DivAgentName.Visible = true;
            }
            else if (ddlCompanyStyle.SelectedValue == "3")
            {
                Lbl1.Visible = false;
                Lbl2.Visible = false;
                Lbl3.Visible = true;
                Lbl4.Visible = false;
                DivAgentName.Visible = false;
                txtAgentName.Text = "";
            }
            else if (ddlCompanyStyle.SelectedValue == "4")
            {
                Lbl1.Visible = false;
                Lbl2.Visible = false;
                Lbl3.Visible = false;
                Lbl4.Visible = true;
                DivAgentName.Visible = false;
                txtAgentName.Text = "";
            }
        }

        protected void ddlBusinessState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLoadBindBusinessDistrict(ddlBusinessState.SelectedItem.ToString());
        }

        private void ddlLoadBindBusinessDistrict(string State)
        {
            DataSet dsDistrict = new DataSet();
            dsDistrict = CEI.GetddlDrawDistrict(State);
            ddlBusinessDistrict.DataSource = dsDistrict;
            ddlBusinessDistrict.DataTextField = "District";
            ddlBusinessDistrict.DataValueField = "District";
            ddlBusinessDistrict.DataBind();
            ddlBusinessDistrict.Items.Insert(0, new ListItem("Select", "0"));
            dsDistrict.Clear();
        }

        protected void ddlSameNameLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSameNameLicense.SelectedValue == "1") // "Yes"
                {
                    DivLicenseNo.Visible = true;
                    DivLicenseIssueDateifSameName.Visible = true;
                }
                else
                {
                    DivLicenseNo.Visible = false;
                    DivLicenseIssueDateifSameName.Visible = false;

                    txtLicenseNo.Text = "";
                    txtLicenseIssue.Text = "";
                }
            }
            catch
            {

            }
        }

        protected void ddlLicenseGranted_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLicenseGranted.SelectedValue == "1") // "Yes" selected
                {
                    divIssueAuthority.Visible = true;
                    divLicenseIssueDate.Visible = true;
                    divLicenseExpiry.Visible = true;
                    divDetailsOfWorkPermit.Visible = true;
                    //divLicensePreviouslyGranted.Visible = true;
                }
                else
                {
                    divIssueAuthority.Visible = false;
                    divLicenseIssueDate.Visible = false;
                    divLicenseExpiry.Visible = false;
                    divDetailsOfWorkPermit.Visible = false;
                    //divLicensePreviouslyGranted.Visible = false;
                    txtIssusuingName.Text = "";
                    txtIssuedateOtherState.Text = "";
                    txtLicenseExpiry.Text = "";
                    txtWorkPermitUndertaken.Text = "";
                }

            }
            catch { }
        }

        protected void DdlPartnerOrDirector_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the selected value is "YES"
            if (DdlPartnerOrDirector.SelectedValue == "1")
            {
                ADDpartner.Visible = true;
            }
            else
            {
                ADDpartner.Visible = false;
            }
        }

        protected void btnShowPartnerDiv_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "$('#myModal').modal('show');", true);
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DropDownList2.SelectedValue == "1") // "Yes" selected
                {
                    DdlPenelity.Visible = true;
                    ShowPenelity.Visible = true;
                    DivPenelity.Visible = true;
                }
                else
                {
                    DdlPenelity.Visible = false;
                    ShowPenelity.Visible = false;
                    DivPenelity.Visible = false;
                    txtPenalities.Text = "";
                }

            }
            catch { }
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

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(Session["ContractorID"])))
                {
                    string userId = Session["ContractorID"].ToString();
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {

                            #region for LT,HT,EHT conditions
                            string voltageAppliedForLicence = ddlVoltageLevel.Text.Trim();

                            // Count the total
                            int totalRows = GridView4.Rows.Count;

                            // If no rows exist
                            if (totalRows == 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not eligible for this. At least one Supervisor or Wireman is required.');", true);
                                return;
                            }

                            int supervisorCount = 0;
                            int wiremanCount = 0;

                            // count Supervisor/Wireman
                            foreach (GridViewRow row in GridView4.Rows)
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

                            // Collect form data
                            string name = txtContractName.Text.Trim();
                            string FirmName = txtFirmName.Text.Trim();
                            string dob = txtDob.Text.Trim();
                            string currentAge = txtCurrentAge.Text.Trim();
                            string oldCertificateNo = txtOldCertificateNo.Text.Trim();
                            string newCertificateNo = txtNewCertificateNo.Text.Trim();
                            string CurrentVLevel = txtCurrentVoltage.Text.Trim();
                            string voltageLevel = ddlVoltageLevel.Text.Trim();
                            string gstNumber = txtGstNumber.Text.Trim();
                            string companyStyle = ddlCompanyStyle.SelectedItem.Text.Trim();
                            string agentName = txtAgentName.Text.Trim();
                            string companyName = txtNameOfCompany.Text.Trim();
                            string officeInHaryana = ddlOffice.SelectedItem.Text.Trim();
                            string address = txtBusinessAddress.Text.Trim();
                            string businessState = ddlBusinessState.SelectedItem.Text.Trim();
                            string businessDistrict = ddlBusinessDistrict.SelectedItem.Text.Trim();
                            string pinCode = txtBusinessPin.Text.Trim();
                            string businessEmail = txtBusinessEmail.Text.Trim();
                            string businessPhoneNo = txtBusinessPhoneNo.Text.Trim();
                            string authorizedPerson = txtauthorizedperson.Text.Trim();
                            string hasProductionUnit = ddlUnitOrNot.SelectedItem.Text.Trim();
                            string sameNameLicense = ddlSameNameLicense.SelectedItem.Text.Trim();
                            string licenseNo = txtLicenseNo.Text.Trim();
                            string licenseIssueDate = txtLicenseIssue.Text.Trim();
                            string licenseGrantedInOtherState = ddlLicenseGranted.SelectedItem.Text.Trim();
                            string issuingAuthority = txtIssusuingName.Text.Trim();
                            string authorityIssueDate = txtIssuedateOtherState.Text.Trim();
                            string authorityLicenseExpiry = txtLicenseExpiry.Text.Trim();
                            string workPermitDetails = txtWorkPermitUndertaken.Text.Trim();
                            string hasPartnersOrDirectors = DdlPartnerOrDirector.SelectedItem.Text.Trim();
                            string BluePrint = ddlBluePrint.SelectedItem.Text.Trim();
                            string workUnderRegulation29 = DdlWorkUnderLicenceConditionsandregulation29.SelectedItem.Text.Trim();
                            string annexureAvailable = ddlAnnexureOrNot.SelectedItem.Text.Trim();
                            string hasPenalties = DropDownList2.SelectedItem.Text.Trim();
                            string penaltiesDescription = txtPenalities.Text.Trim();
                            string grnNo = txtGrNNo.Text.Trim();
                            string challanDate = txtChallanDate.Text.Trim();
                            string challanAmount = txtTotalAmount.Text.Trim();

                            // upgradation data
                            ////int result = CEI.InsertUpgradationContractorData(name, FirmName,
                            ////    dob, currentAge, oldCertificateNo, newCertificateNo, CurrentVLevel, voltageLevel, gstNumber,
                            ////    companyStyle, agentName, companyName, officeInHaryana, address, businessState,
                            ////    businessDistrict, pinCode, businessEmail, businessPhoneNo, authorizedPerson,
                            ////    hasProductionUnit, sameNameLicense, licenseNo, licenseIssueDate, licenseGrantedInOtherState,
                            ////    issuingAuthority, authorityIssueDate, authorityLicenseExpiry, workPermitDetails,
                            ////    hasPartnersOrDirectors, BluePrint, workUnderRegulation29, annexureAvailable, hasPenalties,
                            ////    penaltiesDescription, grnNo, challanDate, userId
                            ////);
                            int result = CEI.InsertUpgradationContractorData(
                            conn, transaction, name, FirmName,
                                dob, currentAge, oldCertificateNo, newCertificateNo, CurrentVLevel, voltageLevel, gstNumber,
                                companyStyle, agentName, companyName, officeInHaryana, address, businessState,
                                businessDistrict, pinCode, businessEmail, businessPhoneNo, authorizedPerson,
                                hasProductionUnit, sameNameLicense, licenseNo, licenseIssueDate, licenseGrantedInOtherState,
                                issuingAuthority, authorityIssueDate, authorityLicenseExpiry, workPermitDetails,
                                hasPartnersOrDirectors, BluePrint, workUnderRegulation29, annexureAvailable, hasPenalties,
                                penaltiesDescription, grnNo, challanDate, userId
                            );

                            string baseFolder = Server.MapPath("~/Attachment/LicenceUpgadation/Contractor/" + userId + "/");

                            if (!Directory.Exists(baseFolder))
                            {
                                Directory.CreateDirectory(baseFolder);
                            }

                            var uploadedDocuments = new List<(int DocumentID, string DocumentName, string FilePath)>();

                            // Add only if file exists
                            if (FileUpload2.HasFile)
                                uploadedDocuments.Add((58, "Certificate of Competency and Wireman Permit", SavePdfFile(FileUpload2, "Certificate_of_Competency_and_Wireman_Permit", userId, baseFolder)));

                            if (FileUpload3.HasFile)
                                uploadedDocuments.Add((43, "Calibration Certificate", SavePdfFile(FileUpload3, "CalibrationCertificateOfElectricalEquipment", userId, baseFolder)));

                            if (FileUpload4.HasFile)
                                uploadedDocuments.Add((59, "Details of works executed annually on the basis of Electrical Contractor License", SavePdfFile(FileUpload4, "Details_of_works_executed_annually", userId, baseFolder)));

                            if (FileUpload5.HasFile)
                                uploadedDocuments.Add((42, "Copy Of Annexure 3 & 5", SavePdfFile(FileUpload5, "CopyofAnnexure3&5", userId, baseFolder)));

                            if (FileUpload6.HasFile)
                                uploadedDocuments.Add((17, "Copy of treasury challan of fees deposited in any treasury of Haryana", SavePdfFile(FileUpload6, "TreasuryChallan", userId, baseFolder)));

                            //if (FileUpload7.HasFile)
                            //    uploadedDocuments.Add((60, "Head of accounts: ‗0043-Taxes and Duties on Electricity", SavePdfFile(FileUpload7, "TaxesandDutiesOnElectricity_OtherReceipts", userId, baseFolder)));

                            if (FileUpload8.HasFile)
                                uploadedDocuments.Add((57, "Authorized person signing documents", SavePdfFile(FileUpload8, "Authorized_Signatory_Approval_Letter", userId, baseFolder)));

                            if (FileUpload9.HasFile)
                                uploadedDocuments.Add((38, "Medical Certificate", SavePdfFile(FileUpload9, "MedicalFitnessCertificate", userId, baseFolder)));

                            if (FileUpload10.HasFile)
                                uploadedDocuments.Add((50, "Income tax return for last 1 year", SavePdfFile(FileUpload10, "Income_tax_return_for_last_1st_year", userId, baseFolder)));

                            if (FileUpload11.HasFile)
                                uploadedDocuments.Add((51, "Income tax return for last 2 year", SavePdfFile(FileUpload11, "Income_tax_return_for_last_2nd_year", userId, baseFolder)));

                            if (FileUpload12.HasFile)
                                uploadedDocuments.Add((52, "Income tax return for last 3 year", SavePdfFile(FileUpload12, "Income_tax_return_for_last_3rd_year", userId, baseFolder)));

                            if (FileUpload1.HasFile)
                                uploadedDocuments.Add((53, "Balance sheet of last 1st year", SavePdfFile(FileUpload1, "Balance_sheet_of_last_1st_year", userId, baseFolder)));

                            if (FileUpload13.HasFile)
                                uploadedDocuments.Add((54, "Balance sheet of last 2nd year", SavePdfFile(FileUpload13, "Balance_sheet_of_last_2nd_year", userId, baseFolder)));

                            if (FileUpload14.HasFile)
                                uploadedDocuments.Add((55, "Balance sheet of last 3rd year", SavePdfFile(FileUpload14, "Balance_sheet_of_last_3rd_year", userId, baseFolder)));


                            //foreach (var doc in uploadedDocuments)
                            //{
                            //    if (!string.IsNullOrEmpty(doc.FilePath))
                            //    {
                            //        int docResult = CEI.InsertContractorUpgradationDocument("Contractor", doc.DocumentID, doc.DocumentName, doc.FilePath, userId);

                            //    }
                            //}
                            foreach (var doc in uploadedDocuments)
                            {
                                if (!string.IsNullOrEmpty(doc.FilePath))
                                {
                                    int docResult = CEI.InsertContractorUpgradationDocument(
                                        conn, transaction, "Contractor", doc.DocumentID, doc.DocumentName, doc.FilePath, userId
                                    );
                                }
                            }

                            // Commit transaction if everything went fine
                            transaction.Commit();
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Upgradation applied successfully!');", true);
                            string script = "alert('Upgradation applied successfully!'); window.location='/Contractor/ConractorUpgradationHistory.aspx';";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertAndRedirect", script, true);
                        }


                        catch (Exception innerEx)
                        {
                            // Rollback on any error
                            transaction.Rollback();



                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.Replace("'", "\\'") + "');</script>");
            }

        }

        private string SavePdfFile(FileUpload fileUpload, string filePrefix, string userId, string baseFolder)
        {
            if (!fileUpload.HasFile)
                return "";

            if (Path.GetExtension(fileUpload.FileName).ToLower() != ".pdf")
                throw new Exception($"{filePrefix} must be a PDF file.");

            if (fileUpload.PostedFile.ContentLength > 1048576)
                throw new Exception($"{filePrefix} must be less than 1 MB.");

            string fileName = filePrefix + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
            string savePath = Path.Combine(baseFolder, fileName);

            fileUpload.PostedFile.SaveAs(savePath);

            return $"/Attachment/LicenceUpgadation/Contractor/{userId}/{fileName}";
        }
    }
}