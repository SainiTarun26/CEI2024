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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            UserId = Session["UserId"].ToString();
            string NewPassword = txtNewPassword.Text.Trim();
            string ConfirmPassword = txtVerifyPassword.Text.Trim();
            //string verifyPassword = txtVerifyPassword.Text.Trim();
            if (NewPassword != ConfirmPassword)
            {

                string alertScript = "alert('New passwords do not match with verify password');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                return;
            }
            else
            {
                DataSet ds1 = CEI.SavePassword(UserId, NewPassword);
                Session["UserId"] = "";
                string successScript = "alert('Password Update successfully.'); window.location='Login.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", successScript, true);
               
            }
        }
    }
}