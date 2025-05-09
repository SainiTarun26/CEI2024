﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Mail;
using CEIHaryana.Contractor;
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
            try
            {
                if (!IsPostBack)
                {
                    if (Session["ContractorID"] != null)
                    {
                        sendsms();
                    }
                }
            }
            catch
            {
                Response.Redirect("/SiteOwnerLogout.aspx");
            }
        }
        //protected void GenerateOTP(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        PhoneNumber.Value = txtMobile.Text.Trim();
        //        Verify.Visible = false;
        //        VerifyOPTdiv.Visible = true;
        //        sendsms();
        //    }
        //    catch
        //    {

            //    }
            //}
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
                            CEI.updateWorkIntimation(Id);
                            Response.Redirect("/Contractor/Work_Intimation.aspx", false);
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
            string id = Session["ContractorID"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetContractorContact(id);
            string Email = ds.Tables[0].Rows[0]["Email"].ToString();
            string email = Email.Trim();
            Session["OTP"] = CEI.OTPthroughEmail(email);
        }


    }



}