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
    public partial class AddNewPassword : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string UserId;
        string ipaddress;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUserId.Text = Session["UserId_ResetPwd"].ToString();
                Session["UserId_ResetPwd"] = "";
                txtNewPassword.Text = "";
                txtVerifyPassword.Text = "";
            }

        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            UserId = txtUserId.Text.Trim();
            string NewPassword = txtNewPassword.Text.Trim();
            string ConfirmPassword = txtVerifyPassword.Text.Trim();
            if (string.IsNullOrEmpty(txtUserId.Text))
            {

                string alertScript = "alert('User does not exist.'); window.location='AdminLogout.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                return;


            }               
            else if (NewPassword != ConfirmPassword)
            {

                string alertScript = "alert('New passwords do not match with verify password');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                return;
            }
            else
            {
                DataSet ds1 = CEI.SavePassword(txtUserId.Text, txtNewPassword.Text);
                //Session["UserId"] = "";
                string successScript = "alert('Password Update successfully.'); window.location='AdminLogout.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", successScript, true);
                return;
            }
        }
    }
}