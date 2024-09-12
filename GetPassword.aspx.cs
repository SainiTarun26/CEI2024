using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class GetPassword : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string searchby = string.Empty;
        private static DateTime ExpiryDatte;
        private static string otp = string.Empty;
        //private static string UserId = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnProcess.Enabled = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Categary = ddluserCategary.SelectedItem.ToString();
            searchby = txtsearch.Text.ToString();
            DataTable dt = new DataTable();
            dt = CEI.GetDataByCategary(searchby, Categary);
            if (dt.Rows.Count > 0)
            {
                
                Contact.Value = dt.Rows[0]["ContactNo"].ToString();
                Email.Value= dt.Rows[0]["Email"].ToString();
                Password.Value = dt.Rows[0]["Password"].ToString();
               // UserId = dt.Rows[0]["Licence"].ToString();

                if (Categary != "Siteowner")
                {
                    Licence.Value = dt.Rows[0]["Licence"].ToString();
                    ExpiryDate.Value= dt.Rows[0]["ExpiryDate"].ToString();
                    ExpiryDatte = DateTime.Parse(dt.Rows[0]["ExpiryDate"].ToString());
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
                btnProcess.Enabled = true;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }            
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddluserCategary.SelectedIndex = 0;
            txtsearch.Text = "";
            txtLiencesExpiryDate.Text = "";
            txtContact.Text = "";
            txtEmailId.Text = "";
            txtOTPVerify.Text = "";
            txtsearch.ReadOnly = false;
            ddluserCategary.Enabled = true;
            CheckBox1.Checked = false;
            CardPersnalDetail.Visible = false;
            CreditionalCard.Visible = false;
            GridView1.DataSource = null;
            GridView1.DataBind();
            btnProcess.Enabled = false;
            btnSearch.Enabled = false;
            LblText.Visible = false;

        }

        protected void ddluserCategary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddluserCategary.SelectedValue =="1")
            {
                gstno.Visible = true;
               // pantanno.Visible = false;
            }
            //else if (ddluserCategary.SelectedValue == "2")
            //{
            //    gstno.Visible = false;
            //    pantanno.Visible = false;
            //}
            //else if (ddluserCategary.SelectedValue == "3")
            //{
            //    gstno.Visible = false;
            //    pantanno.Visible = true;
            //}
            //else if (ddluserCategary.SelectedValue == "4")
            //{
            //    gstno.Visible = false;
            //    pantanno.Visible = false;
            //}
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true && GridView1.Visible == true)
            {
                txtsearch.ReadOnly = true;
                ddluserCategary.Enabled = false;
                CardPersnalDetail.Visible = true;
                btnProcess.Enabled = false;
                btnSearch.Enabled = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('You have to check the declaration first !!!')", true);
            }
        }

        protected void btnOtp_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime EnterExpiryDate = DateTime.Parse(txtLiencesExpiryDate.Text);
                if (EnterExpiryDate == ExpiryDatte)
                {
                    string Email = txtEmailId.Text.Trim();
                    //otp = CEI.ValidateOTPthroughEmail(Email);
                    OtpCart.Visible = true;
                    LblText.Visible = true;

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('Expiry Date Not Match !!!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
           

        }

        protected void btnVerifyotp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOTPVerify.Text == otp)
                {
                string password = Password.Value.ToString();
                string Email = txtEmailId.Text.Trim();
                string Subject = "Password Revieved";
                string Message = $"Your Password is :{password}";
                CEI.ResetMessagethroughEmail(Email, Subject, Message);
                CEI.UpdateDetailsByFetchingPassword(Licence.Value, txtContact.Text.Trim(),txtEmailId.Text.Trim());
                CreditionalCard.Visible = true;
                CardPersnalDetail.Visible = false;
                CardSearchDetails.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
           
        }
    }
}