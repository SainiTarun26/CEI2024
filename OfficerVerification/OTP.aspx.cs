using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace CEIHaryana.OfficerVerification
{
    public partial class OTP : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!Page.IsPostBack)
                {
                    otpDetails();


                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void otpDetails()
        {
          
            txtUserId.Text = Session["StaffID"].ToString();
            txtEmail.Text = CEI.getStaffEmal(txtUserId.Text.Trim());
            SENDEMAIL();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
        }

        protected void btnverifyOTP_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["OTP"].ToString().Trim() == txtOTP.Text.Trim())
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('OTP VERIFIED SUCCESSFULLY!!!!');", true);
                    Session["StaffID"] = txtUserId.Text;
                    Session["logintype"] = "Staff";
                    Response.Cookies["StaffID"].Value = txtUserId.Text;
                    Response.Cookies["logintype"].Value = "Staff";

                    Response.Redirect("/Officers/OfficerDashboard.aspx", false);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }

        }
        protected void SENDEMAIL()
        {
            Random random = new Random();
            int otpInt = random.Next(100000, 999999);

            string otp = otpInt.ToString("D6");
            HttpContext.Current.Session["OTP"] = otp;
            string body = $"Dear Customer,\n\n Your OTP for Login is {otp}. OTPs are confidential - Do not share them with anyone. Thank you for choosing our services. If you need any assistance, feel free to contact our support team.\n\n Best regards,\n\n[CEI Haryana]";

            CEI.ResetMessagethroughEmail(txtEmail.Text.Trim(), "Otp For Login", body);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            SENDEMAIL();
        }
    }
}