using AjaxControlToolkit;
using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class SiteOwnerRegistration : System.Web.UI.Page
    {
        //Page created by gurmeet
        CEI CEI = new CEI();
        string ApplicantType, ApplicantCode, PanTanNumber, ElectricalInstallationFor, NameOfOwner, NameofAgency, Address,
            District, PinCode, PhoneNumber, Email;
        string fileName;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlLoadBindDistrict("Haryana");
            }
        }
        private void ddlLoadBindDistrict(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                //dsDistrict = CEI.GetddlDrawDistrict(state);
                dsDistrict = CEI.GetddlDistrict();
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "AreaCovered";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }

        protected void ddlApplicantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlworktype.SelectedIndex = 0;
            LblPanNumber.Visible = false;
            LblTanNumber.Visible = false;
            txtPANTan.Visible = false;
            if (ddlApplicantType.SelectedValue == "AT001")
            {
                DivPancard_TanNo.Visible = true;
                LblPanNumber.Visible = true;
                txtPANTan.Visible = true;
                txtPANTan.Text = "";
                ListItem checklistItem1 = ddlworktype.Items.FindByValue("1");
                if (checklistItem1 != null)
                {
                    checklistItem1.Enabled = true;
                }
            }
            //else if (ddlApplicantType.SelectedValue == "AT002")
            //{
            //    NameUtility.Visible = true;
            //    Wing.Visible = true;
            //    PowerUtility.Visible = true;
            //    //ElectricalInstallation.Visible= false;
            //    ddlPoweUtilityBind();
            //    //DivPoweUtilityWing.Visible = true;
            //    txtTanNumber.Text = "";
            //    txtPAN.Text = "";
            //}
            else if (ddlApplicantType.SelectedValue == "AT003") //Other Department/Organization
            {
                DivPancard_TanNo.Visible = true;
                LblTanNumber.Visible = true;
                txtPANTan.Visible = true;
                txtPANTan.Text = "";

                ListItem checklistItem1 = ddlworktype.Items.FindByValue("1");
                if (checklistItem1 != null)
                {
                    checklistItem1.Enabled = false;
                }
            }
        }

        protected void ddlworktype_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblNameofOwner.Visible = false;
            LblAgency.Visible = false;

            if (ddlworktype.SelectedValue == "1")
            {
                LblNameofOwner.Visible = true;
            }
            else if (ddlworktype.SelectedValue == "2")
            {
                LblAgency.Visible = true;
            }
            else
            {
                LblNameofOwner.Visible = true;
            }
        }

        protected void txtPANTan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Regex regex;
                string TANNumber = txtPANTan.Text.Trim();
                //if (LblPanNumber.Visible == true)
                //{
                //regex = new System.Text.RegularExpressions.Regex("[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}");
                //}
                //else
                //{
                //regex = new System.Text.RegularExpressions.Regex("[A-Za-z]{4}[0-9]{5}[A-Za-z]{1}");
                //}

                //if (!regex.IsMatch(TANNumber))
                //{
                //    if (LblPanNumber.Visible == true)
                //    {
                //        LblPanNumber.Visible = true;
                //        LblTanNumber.Visible = false;
                //    }
                //    else
                //    {
                //        LblPanNumber.Visible = false;
                //        LblTanNumber.Visible = true;
                //    }
                //    txtPANTan.Focus();
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid Pan/Tan Number format. Please enter a valid TAN number.');", true);
                //    txtPANTan.Text = "";
                //    return;
                //}

                // Added by gurmeet for validation start(20dec 2024)
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[A-Za-z]{4}[0-9]{5}[A-Za-z]{1}$|^[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}$");
                if (!regex.IsMatch(TANNumber))
                {
                    txtPANTan.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid PAN/TAN card format. Please enter a valid PAN/TAN number.');", true);
                    txtPANTan.Text = "";
                    return;
                }
                //end
                DataSet ds = new DataSet();
                ds = CEI.GetDetailsByPanNumberId(TANNumber);
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Pan/Tan Number already exist');", true);
                    txtPANTan.Text = "";
                    return;
                }
            }
            catch (Exception ex)
            {
                // Log the exception or provide a more detailed error message
                Page.ClientScript.RegisterStartupScript(GetType(), "error", $"alert('An error occurred: {ex.Message}');", true);
            }
        }

        protected bool CheckSiteownerPAN(string PANNo)
        {
            DataTable dt = CEI.CheckSiteownerPan(PANNo);
            if (dt.Rows.Count > 0 && dt != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #region navneet added upload document changes 4-July-2025
        public string UploadPannumber()
        {
            string path = "";
             fileName = "CopyOfPanCard" + ".pdf";
            string filePathInfo2 = "";
            PanTanNumber = txtPANTan.Text.Trim();
            if (Path.GetExtension(FileUpload1.FileName).ToLower() == ".pdf")
            {

                if (FileUpload1.PostedFile.ContentLength <= 1048576)
                {
                    string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    if (!Directory.Exists(Server.MapPath("~/Attachment/" + "/SiteOwner/" + PanTanNumber + "/" + "CopyOfPanCard" + "/"  )))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Attachment/" + "/SiteOwner/" + PanTanNumber + "/" + "CopyOfPanCard" + "/"));
                    }

                    string ext = FileUpload1.PostedFile.FileName.Split('.')[1];
                    
                    path = "/Attachment/" +"/SiteOwner/" + PanTanNumber + "/" + "CopyOfPanCard" + "/" ;
                    //string fileName = DocSaveName + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                    //string fileName = DocSaveName + "." + ext;


                    filePathInfo2 = Server.MapPath("~/Attachment/" + "/SiteOwner/" + PanTanNumber + "/" + "CopyOfPanCard" + "/"  + fileName);

                    FileUpload1.PostedFile.SaveAs(filePathInfo2);

                }
                else
                {
                    fileName = "";
                    throw new Exception("Please Upload Pdf Files Less Than 1 Mb Only");
                }
            }
            else
            {
                fileName = "";
                throw new Exception("Please Upload Pdf Only");
            }
            path = path + fileName;
            return path;
        }
        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                PanTanNumber = txtPANTan.Text.Trim();
                if (CheckSiteownerPAN(PanTanNumber))
                {
                    if (FileUpload1.HasFile)
                    {
                        fileName = UploadPannumber();
                        if (fileName!="" && fileName != null) {
                            ApplicantType = ddlApplicantType.SelectedItem.ToString();
                            ApplicantCode = ddlApplicantType.SelectedValue;
                            ElectricalInstallationFor = ddlworktype.SelectedItem.ToString();
                            if (LblNameofOwner.Visible == true)
                            {
                                NameOfOwner = txtName.Text;
                            }
                            else if (LblAgency.Visible == true)
                            {
                                NameofAgency = txtName.Text;
                            }
                            Address = txtAddress.Text.Trim();
                            District = ddlDistrict.SelectedItem.ToString();
                            PinCode = txtPin.Text;
                            PhoneNumber = txtPhone.Text;
                            Email = txtEmail.Text;
                            int Ad = CEI.InsertSiteOwnerRegistration(ApplicantType, ApplicantCode, PanTanNumber, ElectricalInstallationFor, NameOfOwner, NameofAgency
                                 , Address, District, PinCode, PhoneNumber, Email, fileName);
                            if (Ad > 0)
                            {
                                CEI.SiteOwnerCredentials(txtEmail.Text, PanTanNumber);
                                Reset();
                                string script = "alert('Registration Succesffuly,Your userId And Password is sent to email'); window.location='/Login.aspx';";
                                //string script = "alert('Registration Succesffuly,Your userId And Password is sent to email');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please Upload file');", true);
                    }
                }
                else
                {
                    txtPANTan.Text = "";
                    txtPANTan.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Pan/Tan Number already exist');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                //throw;
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void Reset()
        {
            DivPancard_TanNo.Visible = false;

            txtAddress.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtPANTan.Text = "";
            txtName.Text = "";
            txtPin.Text = "";
            ddlApplicantType.SelectedIndex = 0;
            ddlworktype.SelectedIndex = 0;
            ddlDistrict.SelectedIndex = 0;
        }
    }
}