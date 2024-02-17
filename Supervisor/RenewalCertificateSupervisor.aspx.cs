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
        string Id = string.Empty;
        string CreatedBy = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                {
                    GetSupervisorDetails();
                    ddlLoadBindStateForchangedEmployer();
                    ddlLoadBindStateForEmployer();
                }

            }
        }

        public void GetSupervisorDetails()
        {

            string id = Session["SupervisorID"].ToString();

            DataSet ds = new DataSet();
            ds = CEI.GetSupervisorDataForRenewal(id);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();

                txtCertificate.Text = ds.Tables[0].Rows[0]["CertificateNo"].ToString();

                //if(NewCertificate != null && NewCertificate !="")
                //{
                //    txtCertificate.Text = NewCertificate;
                //}
                //else
                //{
                //    txtCertificate.Text = oldCertificate;
                //}
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

                if (!string.IsNullOrEmpty(txtExpiryDate.Text))
                {
                    DateTime selectedExpiryDate;
                    if (DateTime.TryParse(txtExpiryDate.Text, out selectedExpiryDate))
                    {
                        DateTime currentDate = DateTime.Now;

                        if (selectedExpiryDate < currentDate)
                        {
                            TimeSpan remainingDays = selectedExpiryDate - currentDate;
                            int daysRemaining = (int)remainingDays.TotalDays;
                            txtBilatedDate.Text = Math.Abs(daysRemaining).ToString() + " Days";
                        }
                        else
                        {
                            txtBilatedDate.Text = ""; // Or handle differently if needed
                        }
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
        private void ddlLoadBindStateForchangedEmployer()
        {
            try
            {
                DataSet dsState = new DataSet();
                dsState = CEI.GetddlDrawState();
                txtchangedEmployerState.DataSource = dsState;
                txtchangedEmployerState.DataTextField = "StateName";
                txtchangedEmployerState.DataValueField = "StateID";
                txtchangedEmployerState.DataBind();
                txtchangedEmployerState.Items.Insert(0, new ListItem("Select", "0"));
                dsState.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
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
            {
                //msg.Text = ex.Message;
            }
        }
        private void ddlLoadBindDistrictForChangedEmployeer(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                ddlchangedemployerDistrict.DataSource = dsDistrict;
                ddlchangedemployerDistrict.DataTextField = "District";
                ddlchangedemployerDistrict.DataValueField = "District";
                ddlchangedemployerDistrict.DataBind();
                ddlchangedemployerDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }
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
                DivLicense.Visible = false;
                DivNameofEmp.Visible = false;
                DivPinCode.Visible = false;
                DivState.Visible = false;
                DivAddress.Visible = false;
                DivDistrict.Visible = false;
                if (DdlEmployerType.SelectedValue == "1")
                {
                    DivLicense.Visible = true;
                }
                else if (DdlEmployerType.SelectedValue == "2")
                {
                    DivLicense.Visible = false;
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
                ddlLoadBindStateForchangedEmployer();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Check.Checked == true)
            {
                if (Session["SupervisorID"] != null)
                {
                    string id = Session["SupervisorID"].ToString();
                    CreatedBy = Session["SupervisorID"].ToString();
                }
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
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Residence document must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(TreasuryChallan.PostedFile.FileName);
                    string ext = Path.GetExtension(TreasuryChallan.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Residence document Certifiacte must be a PDF file.')", true);
                        return;
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + Id + "/TreasuryChallan/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + Id + "/TreasuryChallan/"));
                    }
                    //string ext = Residence.PostedFile.FileName.Split('.')[1];                
                    string path = "/Attachment/" + Id + "/TreasuryChallan/";
                    string fileName = "TreasuryChallan " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ".pdf";
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + Id + "/TreasuryChallan/" + fileName);
                    TreasuryChallan.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl = path + fileName;
                }
                //presentworkingstatus Document
                if (PresentWorkingStatus.PostedFile.FileName.Length > 0)
                {
                    if (PresentWorkingStatus.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('PresentWorkingStatus document must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(PresentWorkingStatus.PostedFile.FileName);
                    string ext = Path.GetExtension(PresentWorkingStatus.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('PresentWorkingStatus document Certifiacte must be a PDF file.')", true);
                        return;
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + Id + "/PresentWorkingStatus/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + Id + "/PresentWorkingStatus/"));
                    }
                    //string ext = Residence.PostedFile.FileName.Split('.')[1];                
                    string path = "/Attachment/" + Id + "/PresentWorkingStatus/";
                    string fileName = "PresentWorkingStatus " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ".pdf";
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + Id + "/PresentWorkingStatus/" + fileName);
                    PresentWorkingStatus.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl1 = path + fileName;
                }
                //Medical Certificate Document
                if (MedicalCertificate.PostedFile.FileName.Length > 0)
                {
                    if (MedicalCertificate.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('MedicalCertificate document must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(MedicalCertificate.PostedFile.FileName);
                    string ext = Path.GetExtension(MedicalCertificate.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('MedicalCertificate document Certifiacte must be a PDF file.')", true);
                        return;
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + Id + "/MedicalCertificate/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + Id + "/MedicalCertificate/"));
                    }
                    //string ext = Residence.PostedFile.FileName.Split('.')[1];                
                    string path = "/Attachment/" + Id + "/MedicalCertificate/";
                    string fileName = "MedicalCertificate " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ".pdf";
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + Id + "/MedicalCertificate/" + fileName);
                    MedicalCertificate.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl2 = path + fileName;
                }
                // Canel Period Document
                if (CanelPeriod.PostedFile.FileName.Length > 0)
                {
                    if (CanelPeriod.PostedFile.ContentLength > maxFileSize)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('CanelPeriod document must be a PDF file with a maximum size of 2MB.')", true);
                        return;
                    }
                    FileName = Path.GetFileName(CanelPeriod.PostedFile.FileName);
                    string ext = Path.GetExtension(CanelPeriod.PostedFile.FileName).ToLower();
                    if (ext != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('CanelPeriod document Certifiacte must be a PDF file.')", true);
                        return;
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Attachment/" + Id + "/CanelPeriod/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Attachment/" + Id + "/CanelPeriod/"));
                    }
                    //string ext = Residence.PostedFile.FileName.Split('.')[1];                
                    string path = "/Attachment/" + Id + "/CanelPeriod/";
                    string fileName = "CanelPeriod " + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ".pdf";
                    string filePathInfo2 = HttpContext.Current.Server.MapPath("~/Attachment/" + Id + "/CanelPeriod/" + fileName);
                    CanelPeriod.PostedFile.SaveAs(filePathInfo2);
                    flpPhotourl3 = path + fileName;
                }

                CEI.InsertRenewalSupervisorData(
                    txtName.Text.Trim(), txtCertificate.Text.Trim(), txtIssueDate.Text.Trim(), txtExpiryDate.Text.Trim(), txtBilatedDate.Text.Trim(), txtDOB.Text.Trim(), txtAge.Text.Trim(),
                    txtEmail.Text.Trim(), txtContactNo.Text.Trim(), TextAddress.Text.Trim(), DdlState.SelectedItem.ToString(), DdlDistrict.SelectedItem.ToString(), txtpincode.Text.Trim(),
                    txtTreasuryName.Text.Trim(), txtchallanNo.Text.Trim(), txtChallanDate.Text.Trim(), TxtAmount.Text.Trim(),
                    DdlEmployerType.SelectedItem.ToString(), txtEmployerLicenceNo.Text.Trim(), TxtEmployerName.Text.Trim(), txtEmployerAddress.Text.Trim(),
                    ddlEmployerState.SelectedValue == "0" ? null : ddlEmployerState.SelectedItem.ToString(), ddlEmployerDistrict.SelectedValue == "0" ? null : ddlEmployerDistrict.SelectedValue.ToString(),
                    TxtEmployerPincode.Text.Trim(), RadioButtonList2.SelectedItem.ToString(),
                    TxtDateFrom.Text.Trim(), txtDateTo.Text.Trim(), txtEmployercontractorLicence.Text.Trim(), txtChangedEmployerName.Text.Trim(),
                    txtchangedEmployerAddress.Text.Trim(), txtchangedEmployerState.SelectedValue == "0" ? null : txtchangedEmployerState.SelectedItem.ToString(),
                    ddlchangedemployerDistrict.SelectedValue == "0" ? null : ddlchangedemployerDistrict.SelectedItem.ToString(),
                    txchangedEmployerPincode.Text.Trim(), flpPhotourl, flpPhotourl1, flpPhotourl2, flpPhotourl3, txtplace.Text.Trim(), txtdeclarationdate.Text.Trim(), CreatedBy
                    );
            }
        }

        protected void txtchangedEmployerState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtchangedEmployerState.SelectedValue != null && txtchangedEmployerState.SelectedValue != "0")
            {
                ddlLoadBindDistrictForChangedEmployeer(txtchangedEmployerState.SelectedItem.ToString());
            }
        }

        protected void ddlEmployerState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmployerState.SelectedValue != null && ddlEmployerState.SelectedValue != "0")
            {
                ddlLoadBindDistrictForEmployer(ddlEmployerState.SelectedItem.ToString());
            }
        }
    }
}
