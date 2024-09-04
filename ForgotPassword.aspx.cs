using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace CEIHaryana
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        CEI CEI = new CEI();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        public string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
                return email;

            var emailParts = email.Split('@');
            var emailName = emailParts[0];
            var domainName = emailParts[1];

            var maskedEmailName = emailName.Substring(0, 1) + new string('*', emailName.Length - 2);

            return maskedEmailName + "@" + domainName;
        }


        protected void btnVerifyUser_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds1 = CEI.AuthenticateResetUser(txtUserId.Text);
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {

                    //if (Session["ResetOTPUserId"] != null && Session["ResetOTPUserId"].ToString() != txtUserId.Text)
                    //{
                    Session["ResetOTP"] = null;
                    Session["ResetOTPEmail"] = null;
                    Session["ResetOTPUserId"] = null;
                    //}

                    Session["ResetOTPEmail"] = ds1.Tables[0].Rows[0]["EmailId"].ToString();
                    Session["ResetOTPUserId"] = txtUserId.Text;
                    //string storedOtp = Session["ResetOTP"] as string;
                    string storedemailid = Session["ResetOTPEmail"] as string;

                    //if (string.IsNullOrEmpty(storedOtp) || string.IsNullOrEmpty(storedemailid))
                    //{
                    //string email = "makaslam786@gmail.com";
                    Session["ResetOTP"] = CEI.ForgetResetPasswordOtpByEmail(storedemailid);

                    //}
                    lblOtpSentMessageLabel.Visible = true;
                    string maskedEmail = MaskEmail(storedemailid);
                    lblOtpSentMessageLabel.InnerText = "Otp is Sent To Your Registered Emailid" + "   " + maskedEmail;
                    DivInputOtp.Visible = true;
                    DIVverifyotp.Visible = true;

                    lnkResendOtp.Enabled = false; 
                    hfCountdown.Value = "30"; 
                    Timer1.Enabled = true; 
                    //VerifyOtp.Enabled = false;
                    btnVerifyUser.Enabled = false;

                }
                else
                {

                    string alertScript = "alert('UserId Not Found.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                }
            }
            catch (Exception ex)
            {
            }
        }

        //old logic
        //protected void btnVerifyUser_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataSet ds1 = CEI.AuthenticateResetUser(txtUserId.Text);
        //        if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
        //        {

        //            if (Session["ResetOTPUserId"] != null && Session["ResetOTPUserId"].ToString() != txtUserId.Text)
        //            {
        //                Session["ResetOTP"] = null;
        //                Session["ResetOTPEmail"] = null;
        //            }

        //            Session["ResetOTPEmail"] = ds1.Tables[0].Rows[0]["EmailId"].ToString();
        //            Session["ResetOTPUserId"] = txtUserId.Text;
        //            string storedOtp = Session["ResetOTP"] as string;
        //            string storedemailid = Session["ResetOTPEmail"] as string;

        //            if (string.IsNullOrEmpty(storedOtp) || string.IsNullOrEmpty(storedemailid))
        //            {
        //                //string email = "makaslam786@gmail.com";
        //                Session["ResetOTP"] = CEI.ForgetResetPasswordOtpByEmail(storedemailid);

        //            }
        //            lblOtpSentMessageLabel.Visible = true;
        //            string maskedEmail = MaskEmail(storedemailid);
        //            lblOtpSentMessageLabel.InnerText = "Otp is Sent To Your Registered Emailid" + "   " + maskedEmail;
        //            DivInputOtp.Visible = true;
        //            DIVverifyotp.Visible = true;

        //            lnkResendOtp.Enabled = false; // Initially disable the Resend link
        //            hfCountdown.Value = "4"; // Set the countdown timer to 30 seconds
        //            Timer1.Enabled = true; // Start the timer

        //        }
        //        else
        //        {

        //            string alertScript = "alert('UserId Not Found.');";
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        protected void Timer1_Tick(object sender, EventArgs e)
        {
           
            int countdown = Convert.ToInt32(hfCountdown.Value);
            countdown--;
            lblCountdown.Text = countdown.ToString() + " Seconds Remaining To Resend OTP";
            hfCountdown.Value = countdown.ToString();

            if (countdown <= 0)
            {
                Timer1.Enabled = false;
                lnkResendOtp.Enabled = true;
                lblOtpSentMessageLabel.InnerText = "";
                lblCountdown.Text = "If Not received,You Can Now Resend The OTP Again.";
                // ScriptManager.RegisterStartupScript(this, GetType(), "hideCountdown", "hideCountdown();", true);
                lnkResendOtp.Visible = true;

            }
           // UpdatePanel1.Update();
        }
        protected void lnkResendOtp_Click(object sender, EventArgs e)
        {
            try
            {
               
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "showProgressBar", "showProgressBar();", true);
                //Thread.Sleep(2000);
                string storedemailid = Session["ResetOTPEmail"] as string;
                hfCountdown.Value = "30";
                Timer1.Enabled = true;
                Session["ResetOTP"] = CEI.ForgetResetPasswordOtpByEmail(storedemailid);
              

                lblOtpSentMessageLabel.Visible = true;
                string maskedEmail = MaskEmail(storedemailid);
                lblOtpSentMessageLabel.InnerText = "Otp is ReSent To Your Registered Emailid" + "   " + maskedEmail;
                DivInputOtp.Visible = true;
                DIVverifyotp.Visible = true;

                lnkResendOtp.Enabled = false; 

            }
            catch (Exception ex)
            {
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "hideProgressBar", "hideProgressBar();", true);
        }
        protected void VerifyOtp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOTPVerify.Text != "")
                {
                    if (Session["ResetOTP"].ToString() == txtOTPVerify.Text)
                    {
                        //FinalSubmit.Visible = true;
                        InputNewPassworddiv.Visible = true;
                        //Session["ResetOTP"] = null;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Incorrect OTP. Please try again.');", true);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void BtnVerify_Click(object sender, EventArgs e)
        {

            string newPassword = txtNewPassword.Text.Trim();
            string verifyPassword = txtVerifyPassword.Text.Trim();
            if (newPassword != verifyPassword)
            {

                string alertScript = "alert('New passwords do not match with verify password');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                return;
            }

            DataSet ds2 = CEI.UserResetPassword(Session["ResetOTPUserId"].ToString(), newPassword);

            string successScript = "alert('Password Reset successfull.'); window.location='Login.aspx';";
            Session["ResetOTP"] = null;
            Session["ResetOTPEmail"] = null;
            Session["ResetOTPUserId"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", successScript, true);

        }

    }
}