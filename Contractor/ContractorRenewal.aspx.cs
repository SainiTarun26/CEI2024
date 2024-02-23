using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Contractor
{
    public partial class ContractorRenewal : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                {
                    GetContractorDetails();
                    GetGridData();
                }
            }
        }
        private void GetContractorDetails()
        {
            try
            {
                string id = Session["ContractorID"].ToString();

                DataSet ds = new DataSet();

                ds = CEI.GetContractorDataForRenewal(id);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtLicenceNo.Text = ds.Tables[0].Rows[0]["LicenceNo"].ToString();

                    ddlLoadBindState();
                    string issueDate = ds.Tables[0].Rows[0]["IntialIssueDate"].ToString();
                    txtIssueDate.Text = DateTime.Parse(issueDate).ToString("yyyy-MM-dd");

                    string ExpiryDate = ds.Tables[0].Rows[0]["ExpiryDate"].ToString();
                    txtExpiryDate.Text = DateTime.Parse(ExpiryDate).ToString("yyyy-MM-dd");
                    if (!string.IsNullOrEmpty(txtExpiryDate.Text))
                    {
                        DateTime selectedExpiryDate;
                        if (DateTime.TryParse(txtExpiryDate.Text, out selectedExpiryDate))
                        {
                            DateTime currentDate = DateTime.Now;
                            if (selectedExpiryDate < currentDate)
                            {
                                divExtended.Visible = true;
                                txtExtendedBy.Text = CEI.CalculateDate(currentDate, selectedExpiryDate);
                            }
                        }
                    }

                    if (txtDOB.Text != "")
                    {
                        DateTime selectedDOB;
                        if (DateTime.TryParse(txtDOB.Text, out selectedDOB))
                        {
                            DateTime currentDate = DateTime.Now;
                            txtAge.Text = CEI.CalculateDate(currentDate, selectedDOB);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Invalid Date format. Please enter a valid date.');", true);
                            txtDOB.Text = "";
                            txtAge.Text = "";
                        }
                    }
                    else
                    {
                    }
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtContactNo.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["BranchOffice"].ToString();
                    txtpincode.Text = ds.Tables[0].Rows[0]["BranchPinCode"].ToString();
                    string state = ds.Tables[0].Rows[0]["BranchState"].ToString();
                    state = "Haryana ";

                    DdlState.SelectedIndex = DdlState.Items.IndexOf(DdlState.Items.FindByText(state));
                    string District = ds.Tables[0].Rows[0]["BranchDistrictoffirm"].ToString();
                    DdlState.SelectedIndex = DdlState.Items.IndexOf(DdlState.Items.FindByText(state));
                    ddlLoadBindDistrict(state);
                    DdlDistrict.SelectedValue = District;
                }
            }
            catch { }
        }
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
            { }
        }
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
            { }
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
                        }
                        else if (ageDiff > 65)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('You are not eligible to fill this form.');", true);
                            txtDOB.Text = "";
                            txtAge.Text = "";
                        }
                        else
                        {
                            // Calculate age
                            TimeSpan ageDifference = currentDate - selectedDOB;
                            int ageYear = (int)(ageDifference.TotalDays / 365.25);
                            int ageMonth = (int)((ageDifference.TotalDays % 365.25) / 30.44);
                            int ageDay = (int)(ageDifference.TotalDays % 30.44);
                            string ageString = $"{ageYear} Years - {ageMonth} Months - {ageDay} Days";
                            txtAge.Text = ageString;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Invalid Date format. Please enter a valid date.');", true);
                        txtDOB.Text = "";
                        txtAge.Text = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please enter your date of birth.');", true);
                }
            }
            catch { }
        }
        protected void DdlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlState.SelectedValue != null)
            {
                ddlLoadBindDistrict(DdlState.SelectedItem.ToString());
            }
        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RadioButtonList1.SelectedValue == "1")
                {
                    txtAddress.ReadOnly = true;
                    DdlState.Enabled = false;
                    DdlDistrict.Enabled = false;
                    txtpincode.ReadOnly = true;
                }
                else
                {
                    txtAddress.ReadOnly = false;
                    DdlState.Enabled = true;
                    DdlDistrict.Enabled = true;
                    //DdlState.Attributes.Remove("disabled");
                    txtpincode.ReadOnly = false;
                }
            }
            catch { }
        }
        protected void GetassigneddatatoContractor()
        {
            try
            {
                string ID = string.Empty;
                ID = Session["id"].ToString();
                DataTable ds = new DataTable();
                ds = CEI.GetStaffAssignedToContractor(ID);
                if (ds.Rows.Count > 0)
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
            catch
            {
            }
        }
        public void GetGridData()
        {
            try
            {
                string LoginID = string.Empty;
                LoginID = Session["ContractorID"].ToString();
                hdnId.Value = LoginID;

                DataSet ds = new DataSet();
                ds = CEI.WorkIntimationGridData(LoginID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
            catch { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check.Checked == true)
                {
                    if (Session["ContractorID"] != null)
                    {
                        string ContractorId = Session["ContractorID"].ToString();
                        //DataTable dt = new DataTable();
                        //dt = CEI.GetContractorLicenceRenewalData(ContractorId);
                        //if (dt != null && dt.Rows.Count > 0)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowAlert", "alert('This User Already Applied For Licence Renewal');", true);
                        //    return;
                        //}

                        int maxFileSize = 2 * 1024 * 1024;
                        string FileName = string.Empty;
                        string flpPhotourl = string.Empty;
                        string flpPhotourl1 = string.Empty;
                        string flpPhotourl2 = string.Empty;
                        string flpPhotourl3 = string.Empty;
                        string flpPhotourl4 = string.Empty;
                        string flpPhotourl5 = string.Empty;
                        string flpPhotourl6 = string.Empty;
                        string flpPhotourl7 = string.Empty;
                        string flpPhotourl8 = string.Empty;
                        if (EquipCertificate.PostedFile != null && EquipCertificate.PostedFile.ContentLength > 0)
                        {
                            if (EquipCertificate.PostedFile.ContentLength > maxFileSize || !Path.GetExtension(EquipCertificate.PostedFile.FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Equipment tested certificate must be a PDF file with a maximum size of 2MB.')", true);
                                return;
                            }
                            string fileName = "EquipCertificate" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                            string directoryPath = Path.Combine(HttpContext.Current.Server.MapPath($"~/Attachment/{ContractorId}/EquipCertificate/"));
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            string filePath = Path.Combine(directoryPath, fileName);
                            EquipCertificate.PostedFile.SaveAs(filePath);
                            flpPhotourl = $"~/Attachment/{ContractorId}/EquipCertificate/{fileName}";
                        }
                        if (IncomeTax.PostedFile != null && IncomeTax.PostedFile.ContentLength > 0)
                        {
                            if (IncomeTax.PostedFile.ContentLength > maxFileSize || !Path.GetExtension(IncomeTax.PostedFile.FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Income Tax Returns certificate must be a PDF file with a maximum size of 2MB.')", true);
                                return;
                            }
                            string fileName = "IncomeTax" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                            string directoryPath = Path.Combine(HttpContext.Current.Server.MapPath($"~/Attachment/{ContractorId}/IncomeTax/"));
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            string filePath = Path.Combine(directoryPath, fileName);
                            IncomeTax.PostedFile.SaveAs(filePath);
                            flpPhotourl1 = $"~/Attachment/{ContractorId}/IncomeTax/{fileName}";
                        }
                        if (BalanceSheet.PostedFile != null && BalanceSheet.PostedFile.ContentLength > 0)
                        {
                            if (BalanceSheet.PostedFile.ContentLength > maxFileSize || !Path.GetExtension(BalanceSheet.PostedFile.FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Balance Sheet must be a PDF file with a maximum size of 2MB.')", true);
                                return;
                            }
                            string fileName = "BalanceSheet" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                            string directoryPath = Path.Combine(HttpContext.Current.Server.MapPath($"~/Attachment/{ContractorId}/BalanceSheet/"));
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            string filePath = Path.Combine(directoryPath, fileName);
                            BalanceSheet.PostedFile.SaveAs(filePath);
                            flpPhotourl2 = $"~/Attachment/{ContractorId}/BalanceSheet/{fileName}";
                        }
                        if (CalibCertificate.PostedFile != null && CalibCertificate.PostedFile.ContentLength > 0)
                        {
                            if (CalibCertificate.PostedFile.ContentLength > maxFileSize || !Path.GetExtension(CalibCertificate.PostedFile.FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Calibration Certificate must be a PDF file with a maximum size of 2MB.')", true);
                                return;
                            }
                            string fileName = "CalibCertificate" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                            string directoryPath = Path.Combine(HttpContext.Current.Server.MapPath($"~/Attachment/{ContractorId}/CalibCertificate/"));
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            string filePath = Path.Combine(directoryPath, fileName);
                            CalibCertificate.PostedFile.SaveAs(filePath);
                            flpPhotourl3 = $"~/Attachment/{ContractorId}/CalibCertificate/{fileName}";
                        }
                        if (WorkDetails.PostedFile != null && WorkDetails.PostedFile.ContentLength > 0)
                        {
                            if (WorkDetails.PostedFile.ContentLength > maxFileSize || !Path.GetExtension(WorkDetails.PostedFile.FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details of work must be a PDF file with a maximum size of 2MB.')", true);
                                return;
                            }
                            string fileName = "WorkDetails" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                            string directoryPath = Path.Combine(HttpContext.Current.Server.MapPath($"~/Attachment/{ContractorId}/WorkDetails/"));
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            string filePath = Path.Combine(directoryPath, fileName);
                            WorkDetails.PostedFile.SaveAs(filePath);
                            flpPhotourl4 = $"~/Attachment/{ContractorId}/WorkDetails/{fileName}";
                        }
                        if (AnnexureIII.PostedFile != null && AnnexureIII.PostedFile.ContentLength > 0)
                        {
                            if (AnnexureIII.PostedFile.ContentLength > maxFileSize || !Path.GetExtension(AnnexureIII.PostedFile.FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Copy of AnnexureIII must be a PDF file with a maximum size of 2MB.')", true);
                                return;
                            }
                            string fileName = "AnnexureIII" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                            string directoryPath = Path.Combine(HttpContext.Current.Server.MapPath($"~/Attachment/{ContractorId}/AnnexureIII/"));
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            string filePath = Path.Combine(directoryPath, fileName);
                            AnnexureIII.PostedFile.SaveAs(filePath);
                            flpPhotourl5 = $"~/Attachment/{ContractorId}/AnnexureIII/{fileName}";
                        }
                        if (Form_E.PostedFile != null && Form_E.PostedFile.ContentLength > 0)
                        {
                            if (Form_E.PostedFile.ContentLength > maxFileSize || !Path.GetExtension(Form_E.PostedFile.FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Copy of Form_E must be a PDF file with a maximum size of 2MB.')", true);
                                return;
                            }
                            string fileName = "Form_E" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                            string directoryPath = Path.Combine(HttpContext.Current.Server.MapPath($"~/Attachment/{ContractorId}/Form_E/"));
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            string filePath = Path.Combine(directoryPath, fileName);
                            Form_E.PostedFile.SaveAs(filePath);
                            flpPhotourl6 = $"~/Attachment/{ContractorId}/Form_E/{fileName}";
                        }
                        if (TreasuryChallan.PostedFile != null && TreasuryChallan.PostedFile.ContentLength > 0)
                        {
                            if (TreasuryChallan.PostedFile.ContentLength > maxFileSize || !Path.GetExtension(TreasuryChallan.PostedFile.FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Copy of Treasury Challan must be a PDF file with a maximum size of 2MB.')", true);
                                return;
                            }
                            string fileName = "TreasuryChallan" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                            string directoryPath = Path.Combine(HttpContext.Current.Server.MapPath($"~/Attachment/{ContractorId}/TreasuryChallan/"));
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            string filePath = Path.Combine(directoryPath, fileName);
                            TreasuryChallan.PostedFile.SaveAs(filePath);
                            flpPhotourl7 = $"~/Attachment/{ContractorId}/TreasuryChallan/{fileName}";
                        }

                        if (FeeReciept.PostedFile != null && FeeReciept.PostedFile.ContentLength > 0)
                        {
                            if (FeeReciept.PostedFile.ContentLength > maxFileSize || !Path.GetExtension(FeeReciept.PostedFile.FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Payment receipt must be a PDF file with a maximum size of 2MB.')", true);
                                return;
                            }
                            string fileName = "FeeReciept" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                            string directoryPath = Path.Combine(HttpContext.Current.Server.MapPath($"~/Attachment/{ContractorId}/FeeReciept/"));
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            string filePath = Path.Combine(directoryPath, fileName);
                            FeeReciept.PostedFile.SaveAs(filePath);
                            flpPhotourl8 = $"~/Attachment/{ContractorId}/FeeReciept/{fileName}";

                        }

                        int x = CEI.InsertRenewalContractorRequestData(txtLicenceNo.Text.Trim(), txtExpiryDate.Text.Trim(), txtExtendedBy.Text.Trim(), txtDOB.Text.Trim(), txtAge.Text.Trim(),
                            txtEmail.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), DdlState.SelectedItem.ToString(), DdlDistrict.SelectedItem.ToString(),
                            txtpincode.Text.Trim(), RadioButtonList2.SelectedItem.ToString(), txtTreasuryName.Text.Trim(), txtchallanNo.Text.Trim(), txtChallanDate.Text.Trim(),
                            txtRemittedAmount.Text.Trim(), flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl6, flpPhotourl7,
                            flpPhotourl8, ContractorId);
                        if (x > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Requested Successfully !!!')", true);
                            Reset();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Renewal Request for this Contractor is already submitted !!!')", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('You have to check the declaration first !!!')", true);
                }
            }
            catch { }
        }
        private void Reset()
        {
            txtExtendedBy.Text = ""; txtDOB.Text = ""; txtAge.Text = ""; txtEmail.Text = ""; txtContactNo.Text = ""; txtAddress.Text = "";
            DdlState.SelectedValue = "0"; DdlDistrict.SelectedValue = "0"; txtpincode.Text = ""; txtTreasuryName.Text = ""; txtTreasuryName.Text = "";
            txtChallanDate.Text = ""; txtRemittedAmount.Text = ""; txtEquipCertificate.Text = ""; txtIncomeTax.Text = ""; txtBalanceSheet.Text = "";
            txtCalibCertificate.Text = ""; txtWorkDetails.Text = ""; txtAnnexureIII.Text = ""; txtForm_E.Text = ""; txtTreasuryChallan.Text = "";
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList2.SelectedValue == "1")
            {
                divPaymentMode.Visible = true;
            }
            else
            {
                divPaymentMode.Visible = false;
            }
        }
    }
}