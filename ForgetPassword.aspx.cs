using CEI_PRoject;
using Org.BouncyCastle.Utilities.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace CEIHaryana
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string Email;
        string OTPs = string.Empty;
        string UserId;
        string ipaddress;
       
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                string currentIP = GetIP();
                FillCAPTCHA();
                txtSecurityCode.Text = "";
                txtUserId.Text = "";
                txtEmail.Text = "";
                Session["UserId_ResetPwd"] = "";
            }
        }
        protected string GetIP()
        {

            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            return ipaddress;
        }

        private void FillCAPTCHA()
        {
            try
            {
                Random random = new Random();
                string combination = "0123456789";
                StringBuilder captcha = new StringBuilder();
                for (int i = 0; i < 6; i++)
                    captcha.Append(combination[random.Next(combination.Length)]);
                Session["captcha"] = captcha.ToString();
                imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
            }
            catch
            {
                throw;
            }
        }

        protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            FillCAPTCHA();
        }

        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                bool UserExists = false;
                bool EmailExists = false;
                if (Session["captcha"].ToString() != txtSecurityCode.Text)
                {
                    FillCAPTCHA();
                    txtSecurityCode.Focus();
                    string alertScript = "alert('Invalid Security Code.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }

                UserId = txtUserId.Text.Trim();
                string Role = ddlApplicantType.SelectedItem.ToString();
                Email = txtEmail.Text.Trim();
                DataSet ds1 = CEI.CheckUser(txtUserId.Text);
                 if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                 {
                    UserExists = true;
                 }
                else
                {
                    string alertScript = "alert('User Not exist in system');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }
                DataSet ds2 = CEI.CheckUserEmail(txtUserId.Text, Role, txtEmail.Text);
                if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    EmailExists = true;
                  
                }
                else
                {
                    string alertScript = "alert('Credentials are not correct');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }

                if (EmailExists == true && UserExists == true)
                {
                    if (Email.Trim() == "")
                    {
                        string alertScript = "alert('You did not add any Email Please Contact Admin For Update your Email');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                        return;
                    }
                    else
                    {
                        if (txtEmail.Text.Trim() != "")
                        {
                            OTP.Visible = true;
                            ddlApplicantType.Enabled = false;
                            txtUserId.ReadOnly = true;
                            txtEmail.ReadOnly = true;
                            txtSecurityCode.ReadOnly = true;
                            btnSubmit.Visible = false;
                           // btnSubmit.Enabled = false;
                            Verify.Visible = true;
                            btnVerify.Visible = true;
                            string otp = CEI.GetPasswordthroughEmail(Email);
                            //otp save
                            DataSet ds3 = CEI.SaveIPAdress(txtUserId.Text, otp, GetIP());
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('OTP has been Sent to your registered email Id');", true);
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
            }
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetOTP(txtUserId.Text);
            if (ds.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('No OTP found for this User ID.');", true);
                return;
            }
            string existingOTP = ds.Rows[0]["OTP"].ToString();
            string enteredOTP = txtOtp.Text.Trim();
            if (existingOTP == enteredOTP)
            {
                Session["UserId_ResetPwd"] = txtUserId.Text.Trim(); 
                Response.Redirect("AddNewPassword.aspx", false);
            }
            else
            {
                string alertScript = "alert('Incorrect Password. Please Try Again.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                return;

            }
        }

       
        protected void lnkClick_Click(object sender, EventArgs e)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetOTP(txtUserId.Text);
            if (ds.Rows.Count > 0)
            {
                string existingOTP = ds.Rows[0]["OTP"].ToString();
                Email = txtEmail.Text.Trim();
                CEI.SendExistingOTP(Email, existingOTP);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('The same OTP has been resent to your registered email ID.');", true);
                return;
            }
            else {

                // If OTP is expired, generate a new one
                Email = txtEmail.Text.Trim();
                if (!string.IsNullOrEmpty(Email))
                {
                    string newOtp = CEI.GetPasswordthroughEmail(Email);
                    // save otp
                    DataSet ds3 = CEI.SaveIPAdress(txtUserId.Text, newOtp, GetIP());
                    OTP.Visible = true;
                    ddlApplicantType.Enabled = false;
                    txtUserId.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtSecurityCode.ReadOnly = true;
                    btnSubmit.Enabled = false;
                    Verify.Visible = true;
                    btnVerify.Visible = true;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('A new OTP has been sent to your registered email ID.');", true);
                }
            }
        }
    }
}