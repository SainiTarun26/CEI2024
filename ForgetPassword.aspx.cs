using CEI_PRoject;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["OTP"] = "0";
                FillCAPTCHA();
                txtSecurityCode.Text = "";
                txtUserId.Text = "";
                txtEmail.Text = "";
            }
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
                 UserId = txtUserId.Text.Trim();
                Session["UserId"] = UserId;
                string Role = ddlApplicantType.SelectedItem.ToString();
                 Email = txtEmail.Text.Trim();
                Session["Email"] = Email;
                if (Session["captcha"].ToString() != txtSecurityCode.Text)
                {
                    FillCAPTCHA();
                    txtSecurityCode.Focus();
                    string alertScript = "alert('Invalid Security Code.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }
                DataSet ds1 = CEI.CheckUser(UserId);
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
                DataSet ds2 = CEI.CheckUserEmail(UserId, Role, Email);
                if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    EmailExists = true;
                   // string dp_Id = ds2.Tables[0].Rows[0]["Email"].ToString();
                }
                else
                {
                    string alertScript = "alert('Credentials are not correct');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }


                Session["OTP"] = Convert.ToString(Convert.ToInt32(Session["OTP"]) + 1);
             
                if (Email.Trim() == "")
                {
                    string alertScript = "alert('You did not add any Email Please Contact Admin For Update your Email');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                }
                else
                {
                    if (Session["Email"].ToString().Trim() != "")
                    {
                        OTP.Visible = true;
                        ddlApplicantType.Enabled = false;
                        txtUserId.ReadOnly = true;
                        txtEmail.ReadOnly = true;
                        txtSecurityCode.ReadOnly = true;
                        btnSubmit.Enabled = false;
                        Verify.Visible= true;
                        btnVerify.Visible = true;
                        Session["OTP"] = CEI.GetPasswordthroughEmail(Email);
                        // Session["Email"] = "OTPSEND";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('OTP has been Sent to your registered email Id');", true);
                    }
                }
            }
            catch (Exception ex) 
            {}
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            //Session["OTP"] = Convert.ToString(Convert.ToInt32(Session["OTP"]) + 1);

            if (Session["OTP"].ToString() == txtOtp.Text.Trim())
            {
                UserId = Session["UserId"].ToString();
                Response.Redirect("AddNewPassword.aspx", false);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "focusGridView", "focusOnGridView();", true);
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
            Session["OTP"] = "0";
            Session["OTP"] = Convert.ToString(Convert.ToInt32(Session["OTP"]) + 1);
            Email = Session["Email"].ToString();
            if (Session["Email"].ToString().Trim() != "")
            {
                OTP.Visible = true;
                ddlApplicantType.Enabled = false;
                txtUserId.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtSecurityCode.ReadOnly = true;
                btnSubmit.Enabled = false;
                Verify.Visible = true;
                btnVerify.Visible = true;
                Session["OTP"] = CEI.GetPasswordthroughEmail(Email);
                //Session["OTP"] = OTPs.Trim();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('OTP has been Sent to your registered email Id');", true);
            }
        }
    }
}