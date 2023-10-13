using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace CEIHaryana
{
    public partial class OTPVerification : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string otp = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ContractorID"] != null)
                {

                }
            }
        }
        protected void GenerateOTP(object sender, EventArgs e)
        {
            try
            {
                PhoneNumber.Value = txtMobile.Text.Trim();
                Verify.Visible = false;
                VerifyOPTdiv.Visible = true;
                sendsms();
            }
            catch
            {

            }
        }
        protected void VerifyOTP(object sender, EventArgs e)
        {
            try
            {
                otp = Session["OTP"].ToString();
                if (otp.Length == 6)
                {

                    TextBox[] textboxes = new TextBox[] { TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6 };
                    bool isOTPValid = true;

                    for (int i = 0; i < 6; i++)
                    {
                        if (i < textboxes.Length)
                        {
                            if (textboxes[i].Text.Length == 1 && textboxes[i].Text[0] == otp[i])
                            {

                            }
                            else
                            {
                                isOTPValid = false;
                                break;
                            }
                        }
                    }

                    if (isOTPValid)
                    {
                        if (Session["ContractorID"] != null)
                        {
                            string Id = Session["ContractorID"].ToString();
                            CEI.updateWorkIntimation(Id, txtMobile.Text);
                            Response.Redirect("Contractor/Work_Intimation.aspx", false);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid OTP')", true);

                    }
                }
            }
            catch
            {

            }

        }
        public void sendsms()
        {
            string mobilenumber = txtMobile.Text.Trim();
            Random random = new Random();
            int otpInt = random.Next(100000, 999999);

            string otp = otpInt.ToString("D6");
            Session["OTP"] = otp;

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://smpanelv.yieldplus.in/api/mt/SendSMS?APIKey=546t3yI5n06VJogf7Keaiw&senderid=SDEI&channel=Trans&DCS=0&flashsms=0&number=" + mobilenumber + "&text=Dear Customer " + otp + " is the OTP for your request send to CEI Department, HRY. OTPs are SECRET. DO NOT share OTP with anyone --SAFEDOT&route=2&peid=1101407410000040566");
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();

            respStreamReader.Close();
            myResp.Close();
        }

    }
}