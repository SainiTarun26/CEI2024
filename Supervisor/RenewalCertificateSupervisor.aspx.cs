using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class RenewalCertificateSupervisor : System.Web.UI.Page
    {

        CEI CEI = new CEI();
        string SupervisorId = string.Empty;
        string currentCertificateNo = string.Empty;
        string Category = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                {
                    ddlLoadBindState();
                    ddlLoadBindStateForEmployer();
                    // ddlLoadBindStateForchangedEmployer();                    
                    GetSupervisorDetails();
                }

            }
        }

        public void GetSupervisorDetails()
        {

            string SupervisorId = Session["SupervisorID"].ToString();

            DataSet ds = new DataSet();
            ds = CEI.GetSupervisorDataForRenewal(SupervisorId);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                currentCertificateNo = ds.Tables[0].Rows[0]["CertificateNo"].ToString();
                txtCertificate.Text = currentCertificateNo;
                Category= ds.Tables[0].Rows[0]["Category"].ToString();
                ddlLoadBindState();
                string issueDate = ds.Tables[0].Rows[0]["DateofIntialissue"].ToString();
                txtIssueDate.Text = DateTime.Parse(issueDate).ToString("yyyy-MM-dd");
                string ExpiryDate = ds.Tables[0].Rows[0]["DateofExpiry"].ToString();
                txtExpiryDate.Text = DateTime.Parse(ExpiryDate).ToString("yyyy-MM-dd");
                txtAge.Text = ds.Tables[0].Rows[0]["CalculatedAge"].ToString();
                string DOB = ds.Tables[0].Rows[0]["Age"].ToString();
                txtDOB.Text = DateTime.Parse(DOB).ToString("yyyy-MM-dd");
                
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtContactNo.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                TextAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtpincode.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();
                string state = ds.Tables[0].Rows[0]["State"].ToString();
                string District = ds.Tables[0].Rows[0]["District"].ToString();
                DdlState.SelectedIndex = DdlState.Items.IndexOf(DdlState.Items.FindByText(state));
                ddlLoadBindDistrict(state);
                DdlDistrict.SelectedValue = District;
                if (DateTime.TryParse(txtDOB.Text, out DateTime birthDate))
                {
                    DateTime currentDate = DateTime.Now;
                    int year = currentDate.Year - birthDate.Year;
                    if (year > 55)
                    {
                        MedicalCertificateRow.Visible = true;
                    }
                    string CalculateDOB = CEI.CalculateDate(currentDate, birthDate);
                    DivAge.Visible = true;
                    txtAge.Text = CalculateDOB;
                }
                if (!string.IsNullOrEmpty(txtExpiryDate.Text))
                {
                    DateTime selectedExpiryDate;
                    if (DateTime.TryParse(txtExpiryDate.Text, out selectedExpiryDate))
                    {
                        DateTime currentDate = DateTime.Now;
                        if (selectedExpiryDate < currentDate)
                        {
                            DivExtendedDate.Visible = true;
                            CancelPeriodRow.Visible = true;
                            txtBilatedDate.Text = CEI.CalculateDate(currentDate, selectedExpiryDate);
                            //int yearsRemaining = currentDate.Year - selectedExpiryDate.Year;
                            //int monthsRemaining = currentDate.Month - selectedExpiryDate.Month;
                            //int daysRemaining = currentDate.Day - selectedExpiryDate.Day;
                            //if (daysRemaining < 0)
                            //{
                            //    monthsRemaining--;
                            //    int daysInPreviousMonth = DateTime.DaysInMonth(currentDate.Year, (currentDate.Month == 1) ? 12 : currentDate.Month - 1);
                            //    daysRemaining += daysInPreviousMonth;
                            //    if (currentDate.Day < selectedExpiryDate.Day)
                            //    {
                            //        monthsRemaining++;
                            //    }
                            //}
                            //if (monthsRemaining < 0)
                            //{
                            //    yearsRemaining--;
                            //    monthsRemaining += 12;
                            //}
                            //daysRemaining = Math.Abs(daysRemaining);

                            //if(yearsRemaining > 0)
                            //{

                            //}
                            //if(monthsRemaining >0)
                            //{

                            //}
                            //if(daysRemaining >0)
                            //{

                            //}
                            //if(yearsRemaining >0 && monthsRemaining >0 && daysRemaining >0)
                            //{
                            //    txtBilatedDate.Text = $"{yearsRemaining} Years , {monthsRemaining} Months ,  {daysRemaining} Days";
                            //}
                            //else if(monthsRemaining > 0 && daysRemaining >0)
                            //{
                            //    txtBilatedDate.Text = $"{monthsRemaining} Months ,  {daysRemaining} Days";
                            //}
                            //else
                            //{
                            //    txtBilatedDate.Text = $"{daysRemaining} Days";
                            //}

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Invalid date format');", true);
                        Console.WriteLine(".");
                    }
                }
            }
        }
        #region Dropdown for state and district
        private void ddlLoadBindState()
        {
            try
            {
                DataSet dsState = new DataSet();
                dsState = CEI.GetddlDrawState();
                DdlState.DataSource = dsState;
                DdlState.DataTextField = "StateName";
                DdlState.DataValueField = "StateID";
                DdlState.DataBind();
                DdlState.Items.Insert(0, new ListItem("Select", "0"));
                dsState.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }
        private void ddlLoadBindStateForEmployer()
        {
            try
            {
                DataSet dsState = new DataSet();
                dsState = CEI.GetddlDrawState();
                ddlEmployerState.DataSource = dsState;
                ddlEmployerState.DataTextField = "StateName";
                ddlEmployerState.DataValueField = "StateID";
                ddlEmployerState.DataBind();
                ddlEmployerState.Items.Insert(0, new ListItem("Select", "0"));
                dsState.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }
        //private void ddlLoadBindStateForchangedEmployer()
        //{
        //    try
        //    {
        //        DataSet dsState = new DataSet();
        //        dsState = CEI.GetddlDrawState();
        //        txtchangedEmployerState.DataSource = dsState;
        //        txtchangedEmployerState.DataTextField = "StateName";
        //        txtchangedEmployerState.DataValueField = "StateID";
        //        txtchangedEmployerState.DataBind();
        //        txtchangedEmployerState.Items.Insert(0, new ListItem("Select", "0"));
        //        dsState.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        //msg.Text = ex.Message;
        //    }
        //}
        private void ddlLoadBindDistrict(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                DdlDistrict.DataSource = dsDistrict;
                DdlDistrict.DataTextField = "District";
                DdlDistrict.DataValueField = "District";
                DdlDistrict.DataBind();
                DdlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }
        //private void ddlLoadBindDistrictForChangedEmployeer(string state)
        //{
        //    try
        //    {
        //        DataSet dsDistrict = new DataSet();
        //        dsDistrict = CEI.GetddlDrawDistrict(state);
        //        ddlchangedemployerDistrict.DataSource = dsDistrict;
        //        ddlchangedemployerDistrict.DataTextField = "District";
        //        ddlchangedemployerDistrict.DataValueField = "District";
        //        ddlchangedemployerDistrict.DataBind();
        //        ddlchangedemployerDistrict.Items.Insert(0, new ListItem("Select", "0"));
        //        dsDistrict.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        //msg.Text = ex.Message;
        //    }
        //}
        private void ddlLoadBindDistrictForEmployer(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                ddlEmployerDistrict.DataSource = dsDistrict;
                ddlEmployerDistrict.DataTextField = "District";
                ddlEmployerDistrict.DataValueField = "District";
                ddlEmployerDistrict.DataBind();
                ddlEmployerDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }
        #endregion

        protected void DdlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlState.SelectedValue != null)
            {
                ddlLoadBindDistrict(DdlState.SelectedItem.ToString());
            }
        }

        protected void DdlEmployerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DivEmployerName.Visible = false;
                DivLicense.Visible = false;
                DivNameofEmp.Visible = false;
                DivPinCode.Visible = false;
                DivState.Visible = false;
                DivAddress.Visible = false;
                DivDistrict.Visible = false;
                DivEmployerName.Visible = false;
                if (DdlEmployerType.SelectedValue == "1")
                {
                    DivLicense.Visible = true;
                    DivEmployerName.Visible = true;
                }
                else if (DdlEmployerType.SelectedValue == "2")
                {

                    
                    DivNameofEmp.Visible = true;
                    DivPinCode.Visible = true;
                    DivState.Visible = true;
                    DivAddress.Visible = true;
                    DivDistrict.Visible = true;
                    ddlLoadBindStateForEmployer();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            divSubsequentPeriod.Visible = false;
            if (RadioButtonList2.SelectedValue == "0")
            {
                divSubsequentPeriod.Visible = true;                
                GetContractorDetails();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check.Checked == true)
                {
                    if (Session["SupervisorID"] != null)
                    {
                        string SupervisorId = Session["SupervisorID"].ToString();
                        
                        int maxFileSize = 2 * 1024 * 1024;
                        string FileName = string.Empty;
                        string flpPhotourl = string.Empty;
                        string flpPhotourl1 = string.Empty;
                        string flpPhotourl2 = string.Empty;
                        string flpPhotourl3 = string.Empty;
                        //Treasury Document
                        if (TreasuryChallan.PostedFile.FileName.Length > 0)
                        {
                            if (TreasuryChallan.PostedFile.ContentLength > maxFileSize)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "PdfalertWithRedirect('txtTreasuryChallan');", true);
                                return;
                            }
                            FileName = Path.GetFileName(TreasuryChallan.PostedFile.FileName);
                            string ext = Path.GetExtension(TreasuryChallan.PostedFile.FileName).ToLower();
                            if (ext != ".pdf")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('TreasuryChallan document Certifiacte must be a PDF file.')", true);
                                return;
                            }
                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/TreasuryChallan/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/TreasuryChallan/"));
                            }
                            //string ext = Residence.PostedFile.FileName.Split('.')[1];                
                            string path = "/Attachment/" + SupervisorId + "/TreasuryChallan/";
                            string fileName = "TreasuryChallan " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + "pdf";
                            string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/TreasuryChallan/" + fileName);
                            TreasuryChallan.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl = path + fileName;
                        }
                        //presentworkingstatus Document
                        if (PresentWorkingStatus.PostedFile.FileName.Length > 0)
                        {
                            if (PresentWorkingStatus.PostedFile.ContentLength > maxFileSize)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "PdfalertWithRedirect('txtPresentWrkingStatus');", true);
                                return;
                            }
                            FileName = Path.GetFileName(PresentWorkingStatus.PostedFile.FileName);
                            string ext = Path.GetExtension(PresentWorkingStatus.PostedFile.FileName).ToLower();
                            if (ext != ".pdf")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('PresentWorkingStatus document Certifiacte must be a PDF file.')", true);
                                return;
                            }
                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/PresentWorkingStatus/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/PresentWorkingStatus/"));
                            }
                            //string ext = Residence.PostedFile.FileName.Split('.')[1];                
                            string path = "/Attachment/" + SupervisorId + "/PresentWorkingStatus/";
                            string fileName = "PresentWorkingStatus " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + "pdf";
                            string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/PresentWorkingStatus/" + fileName);
                            PresentWorkingStatus.PostedFile.SaveAs(filePathInfo2);
                            flpPhotourl1 = path + fileName;
                        }
                        //Medical Certificate Document
                        if (MedicalCertificateRow.Visible == true)
                        {
                            if (MedicalCertificate.PostedFile.FileName.Length > 0)
                            {
                                if (MedicalCertificate.PostedFile.ContentLength > maxFileSize)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "PdfalertWithRedirect('txtMedicalCertificate');", true);
                                    return;
                                }
                                FileName = Path.GetFileName(MedicalCertificate.PostedFile.FileName);
                                string ext = Path.GetExtension(MedicalCertificate.PostedFile.FileName).ToLower();
                                if (ext != ".pdf")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('MedicalCertificate document Certifiacte must be a PDF file.')", true);
                                    return;
                                }
                                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/MedicalCertificate/")))
                                {
                                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/MedicalCertificate/"));
                                }
                                //string ext = Residence.PostedFile.FileName.Split('.')[1];                
                                string path = "/Attachment/" + SupervisorId + "/MedicalCertificate/";
                                string fileName = "MedicalCertificate " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + "pdf";
                                string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/MedicalCertificate/" + fileName);
                                MedicalCertificate.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl2 = path + fileName;
                            }
                        }
                        // Canel Period Document
                        if (CancelPeriodRow.Visible == true)
                        {
                            if (CancelPeriod.PostedFile.FileName.Length > 0)
                            {
                                if (CancelPeriod.PostedFile.ContentLength > maxFileSize)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "PdfalertWithRedirect('txtCanelPeriod');", true);
                                    return;
                                }
                                FileName = Path.GetFileName(CancelPeriod.PostedFile.FileName);
                                string ext = Path.GetExtension(CancelPeriod.PostedFile.FileName).ToLower();
                                if (ext != ".pdf")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect('')", true);
                                    return;
                                }
                                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/CancelPeriod/")))
                                {
                                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/CancelPeriod/"));
                                }
                                //string ext = Residence.PostedFile.FileName.Split('.')[1];                
                                string path = "/Attachment/" + SupervisorId + "/CancelPeriod/";
                                string fileName = "CancelPeriod " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + "pdf";
                                string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + SupervisorId + "/CancelPeriod/" + fileName);
                                CancelPeriod.PostedFile.SaveAs(filePathInfo2);
                                flpPhotourl3 = path + fileName;
                            }
                        }

                        //string SelectedValue = ddlchangedemployerDistrict.SelectedValue.ToString();
                        //if (string.IsNullOrEmpty(SelectedValue) || SelectedValue == "0")
                        //{
                        //    SelectedValue = null;
                        //}
                        //else
                        //{
                        //    SelectedValue = ddlchangedemployerDistrict.SelectedItem.ToString();
                        //}

                        string Selecteddistrict = ddlEmployerDistrict.SelectedValue.ToString();
                        if (string.IsNullOrEmpty(Selecteddistrict) || Selecteddistrict == "0")
                        {
                            Selecteddistrict = null;
                        }
                        else
                        {
                            Selecteddistrict = ddlEmployerDistrict.SelectedItem.ToString();
                        }

                        //CEI.InsertRenewalSupervisorData(Category,txtBilatedDate.Text.Trim(),currentCertificateNo,txtExpiryDate.Text.Trim(),
                        //    txtDOB.Text.Trim(),txtAge.Text.Trim(),txtEmail.Text.Trim(), txtContactNo.Text.Trim(), TextAddress.Text.Trim(), DdlState.SelectedItem.ToString(),
                        // DdlDistrict.SelectedItem.ToString(), txtpincode.Text.Trim(),
                        // txtTreasuryName.Text.Trim(), txtchallanNo.Text.Trim(), txtChallanDate.Text.Trim(),
                        // TxtAmount.Text.Trim(), DdlEmployerType.SelectedItem.ToString(), txtEmployerLicenceNo.Text.Trim(),
                        // txtContractorName.Text.Trim(), TxtEmployerName.Text.Trim(),
                        //  txtEmployerAddress.Text.Trim(),
                        // ddlEmployerState.SelectedValue == "0" ? null : ddlEmployerState.SelectedItem.ToString(), Selecteddistrict,
                        // TxtEmployerPincode.Text.Trim(), RadioButtonList2.SelectedItem.ToString(),
                        // TxtDateFrom.Text.Trim(), txtDateTo.Text.Trim(), ddlContractorLicence.SelectedValue.ToString(), txtChangedEmployerName.Text.Trim(),
                        // txtchangedEmployerAddress.Text.Trim(),
                        // flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, SupervisorId
                        // );
                        Reset();
                        DataSaved.Visible = true;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "CheckboXalertWithRedirect();", true);
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Some Error Occured,Please Login Again');", true);
                Response.Redirect("/Login.aspx");
            }
        }

        private void Reset()
        {
            txtName.Text = ""; txtCertificate.Text = ""; txtIssueDate.Text = ""; txtExpiryDate.Text = ""; txtBilatedDate.Text = "";
            txtDOB.Text = ""; txtAge.Text = ""; txtEmail.Text = ""; txtContactNo.Text = ""; TextAddress.Text = ""; DdlState.SelectedValue = "0";
            DdlDistrict.SelectedValue = "0"; txtpincode.Text = ""; txtTreasuryName.Text = ""; txtchallanNo.Text = ""; txtChallanDate.Text = "";
            TxtAmount.Text = ""; DdlEmployerType.SelectedValue = "0"; txtEmployerLicenceNo.Text = ""; TxtEmployerName.Text = "";
            txtEmployerAddress.Text = ""; ddlEmployerState.SelectedValue = "0"; ddlEmployerDistrict.SelectedValue = "0"; TxtEmployerPincode.Text = "";
            TxtDateFrom.Text = ""; txtDateTo.Text = ""; txtChangedEmployerName.Text = ""; txtchangedEmployerAddress.Text = "";
            txtTreasuryChallan.Text = ""; txtPresentWrkingStatus.Text = ""; txtMedicalCertificate.Text = ""; txtCanelPeriod.Text = "";
            DivLicense.Visible = false; DivAddress.Visible = false; DivState.Visible = false; DivDistrict.Visible = false; divSubsequentPeriod.Visible = false;
            Check.Checked = false;
        }
       
        private void GetContractorDetails()
        {

            DataSet dsContractor = new DataSet();
            dsContractor = CEI.GetContractorData();
            ddlContractorLicence.DataSource = dsContractor;
            ddlContractorLicence.DataTextField = "ContractorData";
            ddlContractorLicence.DataValueField = "ContractorID";
            ddlContractorLicence.DataBind();
            ddlContractorLicence.Items.Insert(0, new ListItem("Select", "0"));
            dsContractor.Clear();

        }

        protected void ddlEmployerState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmployerState.SelectedValue != null && ddlEmployerState.SelectedValue != "0")
            {
                ddlLoadBindDistrictForEmployer(ddlEmployerState.SelectedItem.ToString());
            }
        }

        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtDOB.Text != "")
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
                            txtAge.Text = "";
                            MedicalCertificateRow.Visible = false;
                        }
                        else if (ageDiff > 65)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('You are not eligible to fill this form,You age is above 65.');", true);
                            txtDOB.Text = "";
                            txtAge.Text = "";
                        }
                        else
                        {
                            //Calculate age
                            DivAge.Visible = true;
                            txtAge.Text = CEI.CalculateDate(selectedDOB, currentDate);
                        }
                    }
                    else
                    {
                        txtDOB.Text = "";
                        txtAge.Text = "";
                        DivAge.Visible = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Invalid Date format. Please enter a valid date.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please enter your date of birth.');", true);
                    MedicalCertificate.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //exception
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void ddlContractorLicence_SelectedIndexChanged(object sender, EventArgs e)
        {
            DivContractorName.Visible = false;
            DivContractorLicenceNo.Visible = false;
            DivContractorAddress.Visible = false;
            if (ddlContractorLicence.SelectedValue != "0")
            {
                string ContractorId = ddlContractorLicence.SelectedValue;
                getContractorDetails(ContractorId);

            }

        }
        public void getContractorDetails(string ContractorID)
        {

            DataSet ds = new DataSet();
            ds = CEI.GetContractorSupData(ContractorID);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DivContractorName.Visible = true;
                DivContractorLicenceNo.Visible = true;
                DivContractorAddress.Visible = true;
                txtChangedEmployerName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtContractorLicenceNo.Text = ds.Tables[0].Rows[0]["LicenceNo"].ToString();
                string RegisteredOffice = ds.Tables[0].Rows[0]["RegisteredOffice"].ToString();
                string State = ds.Tables[0].Rows[0]["State"].ToString();
                string Districtoffirm = ds.Tables[0].Rows[0]["Districtoffirm"].ToString();
                string PinCode = ds.Tables[0].Rows[0]["PinCode"].ToString();
                string adresss = $"{RegisteredOffice} , {State}, {Districtoffirm}, {PinCode}";
                txtchangedEmployerAddress.Text = adresss;
            }
        }

        protected void RadioButtonChangedAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioButtonChangedAddress.SelectedValue == "0")
            {
                TextAddress.ReadOnly = false;
                DdlState.Enabled = false;
                DdlDistrict.Enabled = false;
                txtpincode.ReadOnly = false;
            }
            else
            {
                TextAddress.ReadOnly = true;
                DdlState.Enabled = true;
                DdlDistrict.Enabled = true;
                txtpincode.ReadOnly = true;
            }
        }

        protected void RadioButtonPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DivOfflinePayment.Visible = true;
            if (RadioButtonPayment.SelectedValue=="0")
            {
                DivOfflinePayment.Visible = false;
            }
            
        }
    }
}
